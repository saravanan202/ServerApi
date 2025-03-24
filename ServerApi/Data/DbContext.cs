using ServerApi.Models;
using Microsoft.EntityFrameworkCore;

namespace ServerApi.Data
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<BlogPost> BlogPost { get; set; }
        public DbSet<Subscriber>? Subscriber { get; set; }

    }
}
