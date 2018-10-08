using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test
{
    public class Test_Player
    {
        public Test_Player()
        {
            sut = new Player();
        }

        Player sut;

        [Fact]
        public void Test_Player_Props()
        {
            var name = sut.Name;
            var dice = sut.DieCount;
            
            Assert.False(string.IsNullOrWhiteSpace(name));
            Assert.IsType<int>(dice);
        }

        [Fact]
        public void Test_Player_RollDice()
        {
            bool bit = false;
            sut.RollDice();
            foreach(var die in sut.Dice)
            {
                if(die.Value == 0)
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
    }
}
