using Donmee.Persistence;
using Donmee.Persistence.Models;
using Donmee.Persistence.Models.Enums;
using Donmee.WebApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Donmee.WebApi.Controllers
{
    /// <summary>
    /// Обработка транзакций
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class TransactionController : ControllerBase
    {
        public TransactionController(DonmeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        private readonly DonmeeDbContext _dbContext;

        /// <summary>
        /// Создание желания
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="wish">Желание</param>
        /// <returns>TransactionResult: true, если транзакция прошла успешно, false - иначе</returns>
        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> Creating(
            [FromQuery] string userId,
            [FromBody] Domain.Wish wish)
        {
            try
            {
                var dbWish = new Persistence.Models.Wish
                {
                    Name = wish.Name,
                    Description = wish.Description,
                    Goal = wish.Goal,
                    ImagePath = wish.ImagePath,
                    WishType = wish.WishType
                };

                await _dbContext.Transaction.AddAsync(new Transaction
                {
                    Count = 1,
                    TransactionType = TransactionType.Creating,
                    UserId = userId,
                    Wish = dbWish
                });
                await _dbContext.SaveChangesAsync();

                return Ok(new TransactionResult()
                {
                    Result = true
                });
            }
            catch (Exception exc)
            {
                return BadRequest(new TransactionResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        exc.Message
                    }
                });
            }

        }

        /// <summary>
        /// Пополнение баланса
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="money">Сумма пополнения</param>
        /// <returns>TransactionResult: true, если транзакция прошла успешно, false - иначе</returns>
        [HttpPost]
        [Route("Repllenishment")]
        public async Task<IActionResult> Replenishment(
            [FromQuery] string userId,
            [FromQuery] int money)
        {
            try
            {
                await _dbContext.Transaction.AddAsync(new Transaction
                {
                    Count = money,
                    TransactionType = TransactionType.Replenishment,
                    UserId = userId
                });

                var changingUser = _dbContext.Users.Update(_dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId).Result);
                changingUser.Entity.Balance += money;

                await _dbContext.SaveChangesAsync();

                return Ok(new TransactionResult()
                {
                    Result = true
                });
            }
            catch (Exception exc)
            {
                return BadRequest(new TransactionResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        exc.Message
                    }
                });
            }
        }

        /// <summary>
        /// Пожертвование
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="wishId">ID желания</param>
        /// <param name="money">Сумма пожертвования</param>
        /// <returns>TransactionResult: true, если транзакция прошла успешно, false - иначе</returns>
        [HttpPost]
        [Route("Donate")]
        public async Task<IActionResult> Donate(
            [FromQuery] string userId,
            [FromQuery] Guid wishId,
            [FromQuery] int money)
        {
            try
            {
                var changingUser = _dbContext.Users.Update(
                    _dbContext.Users.FirstOrDefaultAsync(user => user.Id == userId).Result);
                var changingWish = _dbContext.Wish.Update(
                    _dbContext.Wish.FirstOrDefaultAsync(wish => wish.Id == wishId).Result);

                if (changingUser.Entity.Balance < money)
                {
                    return BadRequest(new TransactionResult
                    {
                        Result = false,
                        Errors = new List<string>()
                        {
                            "Insufficient funds"
                        }
                    });
                }

                await _dbContext.Transaction.AddAsync(new Transaction
                {
                    Count = money,
                    TransactionType = TransactionType.Donate,
                    WishId = wishId,
                    UserId = userId
                });

                changingUser.Entity.Balance -= money;

                changingWish.Entity.CurrentAmount += money;

                if (changingWish.Entity.CurrentAmount >= changingWish.Entity.Goal ||
                    changingWish.Entity.EndDate >= DateTime.Now)
                {
                    changingWish.Entity.WishStatus = WishStatus.Completed;
                }

                await _dbContext.SaveChangesAsync();

                return Ok(new TransactionResult()
                {
                    Result = true
                });
            }

            catch (Exception exc)
            {
                return BadRequest(new TransactionResult()
                {
                    Result = false,
                    Errors = new List<string>()
                    {
                        exc.Message
                    }
                });

            }
        }
    }
}
