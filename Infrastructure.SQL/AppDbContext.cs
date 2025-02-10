using Infrastructure.SQL.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.SQL
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
