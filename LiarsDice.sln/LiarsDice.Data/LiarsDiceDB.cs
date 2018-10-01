using LiarsDice.Library.Model;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace LiarsDice.Data
{
    public class LiarsDiceDB : DbContext 
    {
        public LiarsDiceDB() { }

        public DbSet<Player> Player { get; set; }
        public DbSet<Die> Die { get; set; }
        public DbSet<Game> Game { get; set; }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Account> Account { get; set; }

        private readonly string path = "C:/Users/kurti/Documents/MyVsProgram/LiarsDice/LiarsDice.sln/LiarsDice.Data/jsconfig1.json";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var access = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                builder.UseSqlServer(access["ConnectMe"]);
            }
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