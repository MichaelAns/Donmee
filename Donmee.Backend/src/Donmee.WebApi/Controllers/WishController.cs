using Donmee.Persistence;
using Donmee.Persistence.Models.Enums;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Donmee.Application.Mappings;

namespace Donmee.WebApi.Controllers
{
    /// <summary>
    /// Желания пользователя
    /// </summary>
    [Route("api/[controller]")]
    [ApiController]
    public class WishController : ControllerBase
    {
        public WishController(DonmeeDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private readonly DonmeeDbContext _dbContext;

        /// <summary>
        /// Получить все желания других пользователей определённого типа
        /// </summary>
        /// <param name="userId">ID запрашивающего пользователя</param>
        /// <param name="wishType">Тип запрашиваемых желаний</param>
        /// <returns>Активные желания других пользователей определённого типа</returns>
        [HttpGet]
        [Route("Wishes")]
        public async Task<ActionResult<IEnumerable<Domain.Wish>>> GetWishes(
            [FromQuery] string userId,
            [FromQuery] WishType wishType)
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

        /// <summary>
        /// Получить желания запрашивающего пользователя определенного статуса
        /// </summary>
        /// <param name="userId">ID пользователя</param>
        /// <param name="wishStatus">Статус желание</param>
        /// <returns></returns>
        [HttpGet]
        [Route("MyWishes")]
        public async Task<ActionResult<IEnumerable<Domain.Wish>>> GetWishes(
            [FromQuery] string userId,
            [FromQuery] WishStatus wishStatus)
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

        /// <summary>
        /// Получить желание по Id
        /// </summary>
        /// <param name="id">ID желания</param>
        /// <returns>Желание</returns>
        [HttpGet]
        [Route("Wish")]
        public async Task<ActionResult<Domain.Wish>> GetWish([FromQuery] Guid id)
        {
            var wish = await _dbContext.Wish
                    .FirstOrDefaultAsync(wish => wish.Id == id);
            return wish.ToDomain();
        }
    }
}
