using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using TestApp.Models;

namespace TestApp.Data
{
    public class LeagueContext: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var configBuilder = new ConfigurationBuilder().AddJsonFile("appsettings.json").Build();
            var configSection = configBuilder.GetSection("ConnectionStrings");
            var connectionString = configSection["SQLServerConnection"] ?? null;
            optionsBuilder.UseSqlServer(connectionString);
        }
        public DbSet<Team> Teams { get; set; }
    }
}
