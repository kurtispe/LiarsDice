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
        public void Test_PlayerDB_CopyValues()
        {
            player.Bet.Digit = 9;
            player.Bet.Weight = 5;
            player.Dice.Add(new Die(2,3));
            player.Dice.Add(new Die(5,7));
            player.Score = 9;
            sut.CopyValues(player);
            Assert.Equal(player.Bet.Weight, sut.Bet.Weight);
            Assert.Equal(player.Bet.Digit, sut.Bet.Digit);
            Assert.Equal(player.Dice[0].MaxDigit, sut.Dice[0].MaxDigit);
            Assert.Equal(player.Dice[0].Value, sut.Dice[0].Value);
            Assert.Equal(player.Dice[1].MaxDigit, sut.Dice[1].MaxDigit);
            Assert.Equal(player.Dice[1].Value, sut.Dice[1].Value);
            Assert.Equal(player.DieCount, sut.DieCount);
            Assert.Equal(player.MaxDie, sut.MaxDie);
            Assert.Equal(player.Score, sut.Score);
            Assert.Equal(player.Name, sut.Name);
        }
        [Fact]
        public void Test_PlayerDB_ProduceReturnable()
        {
            player.Bet.Digit = 9;
            player.Bet.Weight = 5;
            player.Dice.Add(new Die(2, 3));
            player.Dice.Add(new Die(5, 7));
            player.Score = 9;
            sut.CopyValues(player);
            var sutX = sut.ProduceReturnable();
            Assert.Equal(player.Bet.Weight, sutX.Bet.Weight);
            Assert.Equal(player.Bet.Digit, sutX.Bet.Digit);
            Assert.Equal(player.Dice[0].MaxDigit, sutX.Dice[0].MaxDigit);
            Assert.Equal(player.Dice[0].Value, sutX.Dice[0].Value);
            Assert.Equal(player.Dice[1].MaxDigit, sutX.Dice[1].MaxDigit);
            Assert.Equal(player.Dice[1].Value, sutX.Dice[1].Value);
            Assert.Equal(player.DieCount, sutX.DieCount);
            Assert.Equal(player.MaxDie, sutX.MaxDie);
            Assert.Equal(player.Score, sutX.Score);
            Assert.Equal(player.Name, sutX.Name);
        }
    }
}
