using Microsoft.AspNetCore.Mvc;
using RedisExchange.API.Models;
using RedisExchange.API.Services;
using System.Threading.Tasks;

namespace RedisExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StringTypesController : BaseController
    {
        public StringTypesController(RedisService redisService) : base(redisService, db: 0) { }

        [HttpGet]
        public async Task<IActionResult> SetGetRedisData()
        {
            await _database.StringSetAsync("name", "Veysel MUTLU").ConfigureAwait(false); //Default TTL time -1
            await _database.StringSetAsync("counter", 100).ConfigureAwait(false);

            await _database.StringIncrementAsync("counter", 1).ConfigureAwait(false); // counter ++
            await _database.StringDecrementAsync("counter", 1).ConfigureAwait(false); // counter --

            await _database.StringGetRangeAsync("name", 0, 2).ConfigureAwait(false);
            var valueLength = await _database.StringLengthAsync("name").ConfigureAwait(false);

            var valueName = await _database.StringGetAsync("name").ConfigureAwait(false);
            var valueCounter = await _database.StringGetAsync("counter").ConfigureAwait(false);
            if (valueName.HasValue)
                return Ok
                (
                    new StringTypesResponse() { Name = valueName, Counter = valueCounter, Length = valueLength }
                );

            return NotFound("Unexpected error encountered while inserting or reading redise data.");
        }
    }
}
