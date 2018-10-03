using LiarsDice.Data;
using LiarsDice.Data.DataModels;
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
            sut = new EntityData(new MockDB());

            player = new Player()
            {
                Name = "Karl",
                Score = 4
            };
            die = new Die();
            playerDB = new PlayerDB(player);
            dieDB = new DieDB();
            bet = new Bet(4, 7);
            betDB = new BetDB();
        }
        private EntityData sut;

        private Player player;
        private PlayerDB playerDB;
        private DieDB dieDB;
        private Die die;
        private Bet bet;
        private BetDB betDB;
        //[Fact]
        //public void Test_EntityData_Save_and_Read()
        //{
        //    sut.SaveAsync<PlayerDB>(playerDB);
        //    var result = sut.FindAsync<PlayerDB>(playerDB).Result;
        //    Assert.Equal("Karl", result.Name);
        //}
        //[Fact]
        //public void Test_EntityData_GetList()
        //{
        //    sut.SaveAsync(playerDB);
        //    sut.SaveAsync(playerDB);
        //    sut.SaveAsync(new PlayerDB());
        //    sut.SaveAsync(new PlayerDB());
        //    var sanityCheck = sut.FindAllAsync<PlayerDB>().Result;
        //    Assert.IsType<List<PlayerDB>>(sanityCheck);
        //    Assert.Equal(4, sanityCheck.Count);
        //}
        //[Fact]
        //public void Test_EntityData_DeleteItem()
        //{
        //    sut.SaveAsync(playerDB);
        //    var beforeDelete = sut.FindAllAsync<PlayerDB>().Result;
        //    int beforeDeleteInt = beforeDelete.Count;
        //    sut.DeleteOneAsync(playerDB);

        //    var afterDelete = sut.FindAllAsync<PlayerDB>().Result;
        //    int afterDeleteInt = afterDelete.Count;

        //    Assert.True(beforeDeleteInt > afterDeleteInt);

        //    var genericPlayer = sut.FindAsync(playerDB).Result;
        //    var sanityCheck =  sut.FindAllAsync<PlayerDB>().Result;
        //    Assert.True(null == genericPlayer);
        //}
        //[Fact]
        //public void Test_EntityData_Update()
        //{
        //    sut.SaveAsync(dieDB);
        //    var sanityCheck = dieDB;

        //    die.Roll();

        //    dieDB.CopyValues(die);

        //    sut.SaveAsync<DieDB>(dieDB);

        //    var result = sut.FindAsync<DieDB>(dieDB.PK).Result;

        //    Assert.NotEqual(0, result.Value);
        //}
        [Fact]
        public void Test_EntityData_Preformance_Bet()
        {
            betDB.CopyValues(bet);
            sut.SaveBet(betDB);
            var found = sut.FindBet(betDB.PK).Result;
            Assert.Equal(bet.Digit, found.Digit);
            Assert.Equal(bet.Weight, found.Weight);
            betDB.Weight = 50;
            sut.SaveBet(betDB);
            var foundUpdated = sut.FindBet(betDB.PK).Result;
            Assert.NotEqual(bet.Weight, foundUpdated.Weight);
            Assert.Equal(bet.Digit, foundUpdated.Digit);
            var beforeDel = sut.FindAllBets().Result.Count;
            sut.DeleteOneBet(betDB);
            var afterDel = sut.FindAllBets().Result.Count;
            var foundAfterDel = sut.FindBet(betDB.PK).Result;
            Assert.True(beforeDel > afterDel);
            Assert.True(null == foundAfterDel);
        }
    }
}
