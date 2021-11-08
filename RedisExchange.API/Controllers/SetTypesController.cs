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
    public class SetTypesController : BaseController
    {
        private const string _listKey = "SetTypeExample";
        public SetTypesController(RedisService redisService) : base(redisService, db: 2) { }

        /// <summary>
        /// It adds uniq as it adds it as a hash set. It does not add two data with the same name, its distinguishing feature from the list type is that it is uniq.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost]
        public async Task<IActionResult> SetGetRedisData(string name)
        {
            if (!await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
                await _database.KeyExpireAsync(_listKey, DateTime.Now.AddMinutes(10)).ConfigureAwait(false);

            await _database.SetAddAsync(_listKey, name).ConfigureAwait(false);

            HashSet<string> nameList = new();
            if (await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
            {
                var nameGetList = await _database.SetMembersAsync(_listKey).ConfigureAwait(false);
                nameGetList.ToList().ForEach(x => { nameList.Add(x); });

                return Ok(nameList);
            }

                return NotFound("Unexpected error encountered while inserting or reading redise data.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRedisData(string name)
        {
            await _database.SetRemoveAsync(_listKey, name).ConfigureAwait(false);

            return Ok();
        }
    }
}
