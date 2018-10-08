using LiarsDice.Data.DataModels;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.Test_DataModel
{
    public class Test_PlayerDB
    {
        public Test_PlayerDB()
        {
            sut = new PlayerDB();
            player = new Player("Karl", 7, 8);
        }
        private PlayerDB sut;
        private Player player;

        [Fact]
        public void Test_PlayerDB_ConsumePlayer()
        {
            player.Bet[0] = 9;
            player.Bet[1] = 5;
            player.Dice.Add(new Die(2, 3));
            player.Dice.Add(new Die(5, 7));
            player.Score = 9;
            sut = player.DeepCopy() as PlayerDB;
            Assert.Equal(player.Bet[0], sut.Bet[0]);
            Assert.Equal(player.Bet[1], sut.Bet[1]);
            Assert.Equal(player.Dice[0].MaxDigit, sut.Dice[0].MaxDigit);
            Assert.Equal(player.Dice[0].Value, sut.Dice[0].Value);
            Assert.Equal(player.Dice[1].MaxDigit, sut.Dice[1].MaxDigit);
            Assert.Equal(player.Dice[1].Value, sut.Dice[1].Value);
            Assert.Equal(player.DieCount, sut.DieCount);
            Assert.Equal(player.MaxDie, sut.MaxDie);
            Assert.Equal(player.Score, sut.Score);
            Assert.Equal(player.Name, sut.Name);
           // Assert.NotEqual(player.PK, sut.PK);
        }
        [Fact]
        public void Test_PlayerDB_ProduceReturnable()
        {
            player.Bet[0] = 9;
            player.Bet[1] = 5;
            player.Dice.Add(new Die(2, 3));
            player.Dice.Add(new Die(5, 7));
            player.Score = 9;
            sut = player.DeepCopy();
            Player sutX = (Player)sut; //can put dta model into library model... OK
            Assert.Equal(player.Bet[0], sutX.Bet[0]);
            Assert.Equal(player.Bet[1], sutX.Bet[1]);
            Assert.Equal(player.Dice[0].MaxDigit, sutX.Dice[0].MaxDigit);
            Assert.Equal(player.Dice[0].Value, sutX.Dice[0].Value);
            Assert.Equal(player.Dice[1].MaxDigit, sutX.Dice[1].MaxDigit);
            Assert.Equal(player.Dice[1].Value, sutX.Dice[1].Value);
            Assert.Equal(player.DieCount, sutX.DieCount);
            Assert.Equal(player.MaxDie, sutX.MaxDie);
            Assert.Equal(player.Score, sutX.Score);
            Assert.Equal(player.Name, sutX.Name);
           // Assert.NotEqual(player.PK, sutX.PK);
        }
    }
}
