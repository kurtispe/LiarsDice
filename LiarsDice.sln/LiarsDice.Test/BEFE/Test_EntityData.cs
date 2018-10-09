using LiarsDice.BE.Data;
using LiarsDice.BE.DataModels;
using System.Collections.Generic;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_EntityData
    {
        #region SetUp
        public Test_EntityData()
        {
            sut = new EntityData(new MockDB());
            player = new Player();
        }
        private EntityData sut;
        private Player player;
        #endregion
        #region Test
        [Fact]
        public void Test_EntityData_Save_and_Read()
        {
            player.Name = "karl";
            sut.SavePlayerAsync(player);
            var result = sut.FindPlayerAsync(player.PK).Result;
            Assert.Equal("karl", result.Name);
        }
        [Fact]
        public void Test_EntityData_GetList()
        {
            player.Name = "Karl";
            sut.SavePlayerAsync(player);
            sut.SavePlayerAsync(player);
            sut.SavePlayerAsync(new Player());
            sut.SavePlayerAsync(new Player());
            var sanityCheck = sut.FindAllPlayersAsync().Result;
            Assert.IsType<List<Player>>(sanityCheck);
            Assert.Equal(3, sanityCheck.Count);
        }
        [Fact]
        public void Test_EntityData_DeleteItem()
        {
            sut.SavePlayerAsync(player);
            var beforeDelete = sut.FindAllPlayersAsync().Result;
            int beforeDeleteInt = beforeDelete.Count;
            sut.DeleteOnePlayerAsync(player);

            var afterDelete = sut.FindAllPlayersAsync().Result;
            int afterDeleteInt = afterDelete.Count;

            Assert.True(beforeDeleteInt > afterDeleteInt);

            var genericPlayer = sut.FindPlayerAsync(player.PK).Result;
            var sanityCheck = sut.FindAllPlayersAsync().Result;
            Assert.True(null == genericPlayer);
        }
        [Fact]
        public void Test_EntityData_Update()
        {
            Die die = new Die();

            sut.SaveDieAsync(die);
            var sanityCheck = die.DeepCopy();
            die.Roll();
            sut.SaveDieAsync(die);

            var result = sut.FindDieAsync(die.PK).Result;

            Assert.Equal(die.PK, result.PK);
            Assert.NotEqual(sanityCheck.Value, result.Value);
        }
        #endregion
    }
}
