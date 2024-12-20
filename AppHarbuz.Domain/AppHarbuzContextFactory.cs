using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace AppHarbuz.Domain
{
    public class AppHarbuzContextFactory : IDesignTimeDbContextFactory<AppHarbuzContext>
    {
        public AppHarbuzContext CreateDbContext(string[] args)
        {
            // Создаем объект DbContextOptionsBuilder
            var optionsBuilder = new DbContextOptionsBuilder<AppHarbuzContext>();
            // Настраиваем подключение к базе данных
            optionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=appHarbuz;Trusted_Connection=True;");

            return new AppHarbuzContext(optionsBuilder.Options);
        }
    }
}
