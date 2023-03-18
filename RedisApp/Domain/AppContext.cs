using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using RedisApp.Domain.Entities;

namespace RedisApp.Domain
{
    public class AppContext : DbContext
    {
        public DbSet<ReplyEntity> Replies { get; set; }


        public AppContext(DbContextOptions<AppContext> options) : base(options)
        {
            Database.EnsureCreated();
            // узнать про мигрэйт
            //Database.Migrate();
        }
    }
}
