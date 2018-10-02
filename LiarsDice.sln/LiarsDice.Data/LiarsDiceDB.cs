using LiarsDice.Data.DataModels;
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

        public DbSet<PlayerDB> Player { get; set; }
        public DbSet<DieDB> Die { get; set; }
        public DbSet<GameDB> Game { get; set; }
        public DbSet<BetDB> Bet { get; set; }
        public DbSet<AccountDB> Account { get; set; }

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
            modBuilder.Entity<PlayerDB>().HasKey("PrimeKey");
            modBuilder.Entity<BetDB>().HasKey("PrimeKey");
            modBuilder.Entity<GameDB>().HasKey("PrimeKey");
            modBuilder.Entity<DieDB>().HasKey("PrimeKey");
            modBuilder.Entity<AccountDB>().HasKey("PrimeKey");
        }
    }
}