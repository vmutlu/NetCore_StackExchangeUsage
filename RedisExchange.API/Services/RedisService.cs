using Microsoft.Extensions.Configuration;
using StackExchange.Redis;
using System.Threading.Tasks;

namespace RedisExchange.API.Services
{
    public class RedisService
    {
        private readonly string _redisHost;
        private readonly string _redisPort;
        private ConnectionMultiplexer _redis;
        public IDatabase _db { get; set; }

        public RedisService(IConfiguration configuration)
        {
            _redisHost = configuration["RedisConnections:Host"];
            _redisPort = configuration["RedisConnections:Port"];
        }

        public async Task ConnectAsync()
        {
            var configString = $"{_redisHost}:{_redisPort}";
            _redis = await ConnectionMultiplexer.ConnectAsync(configString).ConfigureAwait(false);
        }

        public IDatabase GetDatabase(int db = 0) => _redis.GetDatabase(db);
    }
}
