using Microsoft.AspNetCore.Mvc;
using RedisExchange.API.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SortedSetTypesController : BaseController
    {
        private const string _listKey = "SortedSetTypeExample";
        public SortedSetTypesController(RedisService redisService) : base(redisService, db: 3) { }

        [HttpPost]
        public async Task<IActionResult> SetGetRedisData(string name, int score = 1)
        {
            if (!await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
                await _database.KeyExpireAsync(_listKey, DateTime.Now.AddMinutes(10)).ConfigureAwait(false);

            await _database.SortedSetAddAsync(_listKey, name, score).ConfigureAwait(false);

            HashSet<string> nameList = new();
            if (await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
            {
                _database.SortedSetScan(_listKey).ToList().ForEach(x => { nameList.Add(x.ToString()); });

                return Ok(nameList);
            }

            return NotFound("Unexpected error encountered while inserting or reading redise data.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRedisData(string name)
        {
            await _database.SortedSetRemoveAsync(_listKey, name).ConfigureAwait(false);

            return Ok();
        }
    }
}
