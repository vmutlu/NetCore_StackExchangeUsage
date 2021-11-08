using Microsoft.AspNetCore.Mvc;
using RedisExchange.API.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RedisExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ListTypesController : BaseController
    {
        private const string _listKey = "ListTypeExample";
        public ListTypesController(RedisService redisService) : base(redisService, db: 1) { }

        [HttpPost]
        public async Task<IActionResult> SetGetRedisData(string name)
        {
            // ListLeftPushAsync -> adds to the top of the list
            // ListRightPushAsync -> adds to the end of the list

            await _database.ListRightPushAsync(_listKey, name).ConfigureAwait(false); //appends to the end

            List<string> list = new();
            if (await _database.KeyExistsAsync(_listKey).ConfigureAwait(false))
            {
                var lists = await _database.ListRangeAsync(_listKey).ConfigureAwait(false);
                if (lists.Any())
                    lists.ToList().ForEach(x => { list.Add(x); });

                return Ok(list);
            }

            return NotFound("Unexpected error encountered while inserting or reading redise data.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteRedisData(string name)
        {
            await _database.ListRemoveAsync(_listKey, name).ConfigureAwait(false);

            return Ok();
        }

        [HttpDelete("DeleteFirstRedisData")]
        public async Task<IActionResult> DeleteFirstRedisData(string name)
        {
            // ListLeftPopAsync -> delete from the beginning 
            // ListRightPopAsync -> deletes last

            await _database.ListLeftPopAsync(_listKey).ConfigureAwait(false);

            return Ok();
        }
    }
}
