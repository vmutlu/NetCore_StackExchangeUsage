using Microsoft.AspNetCore.Mvc;
using RedisExchange.API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HashTypesController : BaseController
    {
        private const string _listKey = "HashTypeExample";
        public HashTypesController(RedisService redisService) : base(redisService, db: 4) { }

        [HttpPost]
        public async Task<IActionResult> SetGetRedisData(string key, string value)
        {
            await _database.HashSetAsync(_listKey, key, value).ConfigureAwait(false);

            Dictionary<string, string> list = new();
            if (await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
            {
                var response = await _database.HashGetAllAsync(_listKey).ConfigureAwait(false);
                response.ToList().ForEach(x => { list.Add(x.Name, x.Value); });

                return Ok(list);
            }

            return NotFound("Unexpected error encountered while inserting or reading redise data.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRedisData(string key)
        {
            await _database.HashDeleteAsync(_listKey, key).ConfigureAwait(false);

            return Ok();
        }
    }
}
