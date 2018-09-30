using LiarsDice.Data;
using LiarsDice.Data.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;


namespace LiarsDice.Test
{
    public class Test_EntityData
    {
        public Test_EntityData()
        {
            sut = new EntityData();
            player = new Data_Player()
            {
                Name = "Karl",
                Score = 4
            };
            db = new MockDB();
        }
        private EntityData sut;
        private Data_Player player;
        private MockDB db;

        [Fact]
        public void Test_EntityData_Save_and_Read()
        {
            player.RollDice();
            sut.SaveAsync<Data_Player>(player);
            var result = sut.FindAsync<Data_Player, Data_Player>(player).Result;
            Assert.Equal(player.Name, result.Name); 
        }
    }
}
