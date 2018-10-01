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
            die = new Die();
        }
        private EntityData sut;
        private Player player;
        private Die die;

        [Fact]
        public void Test_EntityData_Save_and_Read()
        {
            player.RollDice();
            sut.SaveAsync(player);
            var result = sut.FindAsync<Player>(player).Result;
            Assert.Equal(player.Name, result.Name);
            var result2 = sut.FindAsync<Player>(1).Result;
            Assert.Equal(player.Name, result2.Name);
        }
        [Fact]
        public void Test_EntityData_GetList()
        {
            sut.SaveAsync(player);
            sut.SaveAsync(player);
            sut.SaveAsync(new Player());
            sut.SaveAsync(new Player());
            var sanityCheck = sut.FindAllAsync<Player>().Result;
            Assert.IsType<List<Player>>(sanityCheck);
            Assert.Equal(4, sanityCheck.Count);
        }
        [Fact]
        public void Test_EntityData_DeleteItem()
        {
            sut.SaveAsync<Player>(player);
            var beforeDelete = sut.FindAllAsync<Player>().Result;
            int beforeDeleteInt = beforeDelete.Count;
            sut.DeleteOneAsync<Player>(player);
            var afterDelete = sut.FindAllAsync<Player>().Result;
            int afterDeleteInt = afterDelete.Count;
            Assert.True(beforeDeleteInt > afterDeleteInt);
            var genericPlayer = sut.FindAsync<Player>(player).Result;
            var sanityCheck =  sut.FindAllAsync<Player>().Result;
            Assert.True(null == genericPlayer);
        }
        [Fact]
        public void Test_EntityData_Update()
        {
            sut.SaveAsync<Die>(die);
            var sanityCheck = die;
            die.Roll();
            sut.SaveAsync<Die>(die);
            var result = sut.FindAsync<Die>(1).Result;
            Assert.NotEqual(0, result.Value);
        }
    }
}
