using LiarsDice.BE.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LiarsDice.BE.EntityData
{
    public class CommonContext : DbContext
    {
        public DbSet<Player> PlayerDB { get; set; }
        public DbSet<Die> DieDB { get; set; }
        public DbSet<Game> GameDB { get; set; }
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
