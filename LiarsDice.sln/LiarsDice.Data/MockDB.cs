
using LiarsDice.Library.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;


namespace LiarsDice.Data
{
    public class MockDB : DbContext 
    {
        public MockDB(){ }

        public DbSet<Player> Player { get; set; }
        public DbSet<Die> Die { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Account> Account { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            builder.UseInMemoryDatabase("LiarsDiceDB");
        }

        protected override void OnModelCreating(ModelBuilder modBuilder)
        {
            modBuilder.Entity<Player>().HasKey("PrimeKey");
            modBuilder.Entity<Bet>().HasKey("PrimeKey");
            modBuilder.Entity<Game>().HasKey("PrimeKey");
            modBuilder.Entity<Die>().HasKey("PrimeKey");
            modBuilder.Entity<Account>().HasKey("PrimeKey");
        }
    }
}
