using LiarsDice.BE.Data;
using LiarsDice.BE.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
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
        private MockDB mock;
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
        //[Fact]
        //public void Test_EntityData_GetList()
        //{
        //    sut.SavePlayer(playerDB);
        //    sut.SavePlayer(playerDB);
        //    sut.SavePlayer(new PlayerDB());
        //    sut.SavePlayer(new PlayerDB());
        //    var sanityCheck = sut.FindAllPlayers().Result;
        //    Assert.IsType<List<PlayerDB>>(sanityCheck);
        //    Assert.Equal(4, sanityCheck.Count);
        //}
        //[Fact]
        //public void Test_EntityData_DeleteItem()
        //{
        //    sut.SavePlayer(playerDB);
        //    var beforeDelete = sut.FindAllPlayers().Result;
        //    int beforeDeleteInt = beforeDelete.Count;
        //    sut.DeleteOnePlayer(playerDB);

        //    var afterDelete = sut.FindAllPlayers().Result;
        //    int afterDeleteInt = afterDelete.Count;

        //    Assert.True(beforeDeleteInt > afterDeleteInt);

        //    var genericPlayer = sut.FindPlayer(playerDB.PK).Result;
        //    var sanityCheck = sut.FindAllPlayers().Result;
        //    Assert.True(null == genericPlayer);
        //}
        //[Fact]
        //public void Test_EntityData_Update()
        //{
        //    sut.SaveDie(dieDB);
        //    var sanityCheck = dieDB;

        //    var a = die;
        //    die.Roll();

        //    dieDB = die.DeepCopy();

        //    sut.SaveDie(dieDB);

        //    var result = sut.FindDie(dieDB.PK).Result;
        //    Assert.Equal(dieDB.PK, result.PK);
        //    Assert.NotEqual(0, result.Value);
        //}
        //[Fact]
        //public void Test_EntityData_Preformance_Die()
        //{
        //    dieDB = die.DeepCopy();
        //    sut.SaveDie(dieDB);
        //    var found = sut.FindDie(dieDB.PK).Result;
        //    Assert.Equal(die.Value, found.Value);

        //    dieDB.Value = 50;
        //    sut.SaveDie(dieDB);
        //    var foundUpdated = sut.FindDie(dieDB.PK).Result;

        //    Assert.NotEqual(die.Value, foundUpdated.Value);

        //    var beforeDel = sut.FindAllDies().Result.Count;
        //    sut.DeleteOneDie(dieDB);
        //    var afterDel = sut.FindAllDies().Result.Count;
        //    var foundAfterDel = sut.FindDie(dieDB.PK).Result;
        //    Assert.True(beforeDel > afterDel);
        //    Assert.True(null == foundAfterDel);
        //}
        #endregion
    }
}
