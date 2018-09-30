using LiarsDice.Data;
using LiarsDice.Library.Model;
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
            player = new Player()
            {
                Name = "Karl",
                Score = 4
            };
        }
        private EntityData sut;
        private Player player;

        [Fact]
        public void Test_EntityData_Save_and_Read()
        {
            player.RollDice();
            sut.SaveAsync<Player>(player);
            var result = sut.FindAsync<Player, Player>(player).Result;
            Assert.Equal(player.Name, result.Name); 
        }
    }
}
