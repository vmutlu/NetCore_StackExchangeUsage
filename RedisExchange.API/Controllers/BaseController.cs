using Microsoft.AspNetCore.Mvc;
using RedisExchange.API.Services;
using StackExchange.Redis;

namespace RedisExchange.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BaseController : ControllerBase
    {
        private readonly RedisService _redisService;
        protected readonly IDatabase _database;
        public BaseController(RedisService redisService, int db = 1)
        {
            _redisService = redisService;
            _database = _redisService.GetDatabase(db);
        }
    }
}
