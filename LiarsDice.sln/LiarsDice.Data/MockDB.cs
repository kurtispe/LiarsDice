using LiarsDice.Data.DataModels;
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

        public DbSet<Data_Player> Player { get; set; }
        public DbSet<Data_Die> Die { get; set; }
        public DbSet<Data_Game> Game { get; set; }
        public DbSet<Data_Bet> Bet { get; set; }

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
        }
    }
}
