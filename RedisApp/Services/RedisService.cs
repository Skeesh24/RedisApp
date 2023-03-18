using StackExchange.Redis;

namespace RedisApp.Services
{
    public class RedisService
    {
        public ConnectionMultiplexer? Client { get; set; }

        public IDatabase? Database { get; set; } 

        public RedisService()
        {
           Client = ConnectionMultiplexer.Connect("redis,abortConnect=false");
           Database = Client.GetDatabase();
        }

    }
}
