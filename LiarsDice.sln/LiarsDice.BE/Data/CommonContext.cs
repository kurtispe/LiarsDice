using LiarsDice.BE.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LiarsDice.BE.Data
{
    public class CommonContext : DbContext 
    {
        public DbSet<Player> Player { get; set; }
        public DbSet<Die> DieDB { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Account> AccountDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            modBuilder.Entity<Player>().HasKey("PK");
            modBuilder.Entity<Game>().HasKey("PK");
            modBuilder.Entity<Die>().HasKey("PK");
            modBuilder.Entity<Account>().HasKey("PK");
        }
    }
}
