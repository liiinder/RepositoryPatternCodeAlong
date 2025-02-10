using Infrastructure.SQLite.Entities;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Logging;

namespace Infrastructure.SQLite
{
    public class AppDbContext : DbContext
    {
        public DbSet<Person> People => Set<Person>();
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var connectionString = new SqliteConnectionStringBuilder()
            {
                DataSource = "sqliteDemo.db",
                Cache = SqliteCacheMode.Shared
            }.ToString();

            optionsBuilder.UseSqlite(connectionString);
        }
    }
}
