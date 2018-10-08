﻿using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;

namespace LiarsDice.BE.EntityData
{
    public class LiarsDiceDB : CommonContext
    {
        public LiarsDiceDB() { }

        private readonly string path = "C:/Users/kurti/Documents/MyVsProgram/LiarsDice/LiarsDice.sln/LiarsDice.BE/EntityData/jsonconfig.json";

        protected override void OnConfiguring(DbContextOptionsBuilder builder)
        {
            using (StreamReader reader = new StreamReader(path))
            {
                var access = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                builder.UseSqlServer(access["ConnectMe"]);
            }
        }
    }

}