
using LiarsDice.Data.DataModels;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace LiarsDice.Data
{
    public class MockDB : DbContext 
    {
        public MockDB(){ }

        public DbSet<PlayerDB> Player { get; set; }
        public DbSet<DieDB> Die { get; set; }
        public DbSet<GameDB> Game { get; set; }
        public DbSet<BetDB> Bet { get; set; }
        public DbSet<AccountDB> Account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("LiarsDiceDB");
        }

        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            modBuilder.Entity<PlayerDB>().HasKey("PrimeKey");

            modBuilder.Entity<BetDB>().HasKey("PrimeKey");

            modBuilder.Entity<GameDB>().HasKey("PrimeKey");

            modBuilder.Entity<DieDB>().HasKey("PrimeKey");

            modBuilder.Entity<AccountDB>().HasKey("PrimeKey");
        }
    }
}
