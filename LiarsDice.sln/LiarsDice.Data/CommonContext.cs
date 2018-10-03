using LiarsDice.Data.DataModels;
using Microsoft.EntityFrameworkCore;

namespace LiarsDice.Data
{
    public class CommonContext : DbContext
    {
        public DbSet<PlayerDB> PlayerDB { get; set; }
        public DbSet<DieDB> DieDB { get; set; }
        public DbSet<GameDB> GameDB { get; set; }
        public DbSet<BetDB> BetDB { get; set; }
        public DbSet<AccountDB> AccountDB { get; set; }

        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            modBuilder.Entity<PlayerDB>().HasKey("PK");

            modBuilder.Entity<BetDB>().HasKey("PK");

            modBuilder.Entity<GameDB>().HasKey("PK");

            modBuilder.Entity<DieDB>().HasKey("PK");

            modBuilder.Entity<AccountDB>().HasKey("PK");
        }
    }
}
