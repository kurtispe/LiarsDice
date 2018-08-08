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
            Assert.True(dice.GetType() == typeof(int));
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
    }
}
