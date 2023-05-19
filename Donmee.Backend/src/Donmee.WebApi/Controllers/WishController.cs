using Donmee.Persistence;
using Donmee.Persistence.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donmee.Application.Mappings;
using Microsoft.AspNetCore.Authorization;

namespace Donmee.WebApi.Controllers
{
    /// <summary>
    /// Желания пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class WishController : ControllerBase
    {
        public WishController(DonmeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly DonmeeDbContext _dbContext;

        /// <summary>
        /// Получить все желания других пользователей (обычные или блиц)
        /// </summary>
        /// <param name="userId">ID запрашивающего пользователя</param>
        /// <param name="wishType">Тип запрашиваемых желаний - обычные или блиц</param>
        /// <returns>Активные желания других пользователей (обычные или блиц)</returns>
        [HttpGet]
        [Route("Wishes")]
        public async Task<ActionResult<IEnumerable<Domain.Wish>>> GetWishes(
            [FromQuery] string userId,
            [FromQuery] WishType wishType)
        {
            try
            {
                // All wishes of other users
                var w = await _dbContext.Wish.ToListAsync();
                var wishes = await _dbContext.Transaction
                    .Where(trans =>
                        trans.UserId != userId &&
                        trans.TransactionType == TransactionType.Creating)
                    .Select(tr => tr.Wish)
                    .Where(wish =>
                        wish.WishStatus == WishStatus.Active &&
                        wish.WishType == wishType)
                    .ToListAsync();

                var domainWishes = new List<Domain.Wish>();
                foreach (var wish in wishes)
                {
                    domainWishes.Add(wish.ToDomain());
                }

                return domainWishes;
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }            
        }

        /// <summary>
        /// Получить все желания запрашивающего пользователя определенного статуса (активные или завершённые)
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="wishStatus">Статус желаний - активные или завершённые</param>
        /// <returns>Желания запрашивающего пользователя определенного статуса (активные или завершённые)</returns>
        [HttpGet]
        [Route("MyWishes")]
        public async Task<ActionResult<IEnumerable<Domain.Wish>>> GetWishes(
            [FromQuery] string userId,
            [FromQuery] WishStatus wishStatus)
        {
            try
            {
                var wishes = await _dbContext.Transaction
                    .Where(trans =>
                        trans.UserId == userId &&
                        trans.WishId != null &&
                        trans.TransactionType == TransactionType.Creating)
                    .Select(tr => tr.Wish)
                    .Where(wish => wish.WishStatus == wishStatus)
                    .ToListAsync();

                var domainWishes = new List<Domain.Wish>();
                foreach (var wish in wishes)
                {
                    domainWishes.Add(wish.ToDomain());
                }

                return domainWishes;
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
        }

        /// <summary>
        /// Получить желание по ID
        /// </summary>
        /// <param name="id">ID желания</param>
        /// <returns>Желание</returns>
        [HttpGet]
        [Route("Wish")]
        public async Task<ActionResult<Domain.Wish>> GetWish([FromQuery] Guid id)
        {
            try
            {
                var wish = await _dbContext.Wish
                    .FirstOrDefaultAsync(wish => wish.Id == id);
                return wish.ToDomain();
            }
            catch (Exception exc)
            {
                return BadRequest(exc);
            }
            
        }
    }
}
