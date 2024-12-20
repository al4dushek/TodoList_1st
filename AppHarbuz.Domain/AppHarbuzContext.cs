using AppHarbuz.Domain.Entities;
using Microsoft.EntityFrameworkCore;


namespace AppHarbuz.Domain
{
    public class AppHarbuzContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DbSet<TaskApp> Tasks { get; set; }

        public AppHarbuzContext(DbContextOptions<AppHarbuzContext> options) : base(options)
        {
            
        }
    }
}
