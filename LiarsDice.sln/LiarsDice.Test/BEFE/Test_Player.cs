using LiarsDice.BE.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_Player
    {
        #region SetUp
        public Test_Player()
        {
            sut = new Player();
        }
        private Player sut;
        #endregion
        #region Test
        [Fact]
        public void Test_Player_Props()
        {
            Assert.IsType<string>(sut.Name);
            Assert.IsType<int>(sut.MaxDie);
            Assert.IsType<int>(sut.DieCount);
            Assert.IsType<int[]>(sut.Bet);
            Assert.IsType<List<Die>>(sut.Dice);
            Assert.IsType<int>(sut.Score);
            Assert.IsType<int[]>(sut.StatLog);
        }
        [Fact]
        public void Test_Player_RollDice()
        {
            bool bit = false;
            sut.RollDice();
            foreach (var die in sut.Dice)
            {
                if (die.Value == 0)
                {
                    bit = true;
                }
            }
            Assert.False(bit);
            Assert.True(sut.Dice.Count == sut.DieCount);
        }
        [Fact]
        public void Test_Player_PlaceBet()
        {
            sut.RollDice();
            sut.PlaceBet(3, 4);
            var exp = sut.Bet[0];
            var exp2 = sut.Bet[1];

            Assert.True(exp >= 0 && exp < sut.Dice[0].MaxDigit);
            sut.PlaceBet(3, 99);
            Assert.True(sut.Bet[1] == 1);
        }
        [Fact]
        public void Test_Player_ReturnInfo()
        {
            Assert.IsType<String>(sut.ReturnInfo());
        }
        #endregion
    }
}
