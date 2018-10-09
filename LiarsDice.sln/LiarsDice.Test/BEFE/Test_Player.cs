using LiarsDice.BE.DataModels;
using LiarsDice.FE;
using System;
using System.Collections.Generic;
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
        [Fact]
        public void Test_Player_Produces()
        {
            sut.Dice.Add(new Die(5, 4));
            sut.Dice.Add(new Die(9,1));
            sut.Score = 99;
            sut.CalculateStats();

            PlayerFE play = sut.Produces();

            Assert.Equal(sut.DieCount, play.DieCount);
            Assert.Equal(sut.MaxDie, play.MaxDie);
            Assert.Equal(sut.Name, play.Name);
            Assert.Equal(sut.Score, play.Score);
            Assert.Equal(sut.Bet[0], play.Bet[0]);
            Assert.Equal(sut.Bet[1], play.Bet[1]);
            Assert.Equal(sut.Dice[0].Value, play.Dice[0].Value);
            Assert.Equal(sut.Dice[0].MaxDigit, play.Dice[0].MaxDigit);
            Assert.Equal(sut.Dice[1].Value, play.Dice[1].Value);
            Assert.Equal(sut.Dice[1].MaxDigit, play.Dice[1].MaxDigit);
            Assert.Equal(sut.StatLog[0], play.StatLog[0]);
            Assert.Equal(sut.StatLog[1], play.StatLog[1]);
            Assert.Equal(sut.StatLog, play.StatLog);
        }
        [Fact]
        public void Test_Player_Consumes()
        {
            PlayerFE play = new PlayerFE()
            {
                Name = "WOAH",
                MaxDie = 8,
                Score = 9,
                DieCount = 4,
                Dice = new List<DieFE>() {
                    new DieFE(){Value = 8,MaxDigit = 10},
                    new DieFE(){Value =3, MaxDigit = 70}
                },
                Bet = new int[2] { 4, 6 },
                StatLog = new int[5] { 3, 4, 3, 3, 0 }
            };
            Player sutX = new Player(play);
          
            Assert.Equal(sutX.DieCount, play.DieCount);
            Assert.Equal(sutX.MaxDie, play.MaxDie);
            Assert.Equal(sutX.Name, play.Name);
            Assert.Equal(sutX.Score, play.Score);
            Assert.Equal(sutX.Bet[0], play.Bet[0]);
            Assert.Equal(sutX.Bet[1], play.Bet[1]);
            Assert.Equal(sutX.Dice[0].Value, play.Dice[0].Value);
            Assert.Equal(sutX.Dice[0].MaxDigit, play.Dice[0].MaxDigit);
            Assert.Equal(sutX.Dice[1].Value, play.Dice[1].Value);
            Assert.Equal(sutX.Dice[1].MaxDigit, play.Dice[1].MaxDigit);
            Assert.Equal(sutX.StatLog[0], play.StatLog[0]);
            Assert.Equal(sutX.StatLog[1], play.StatLog[1]);
            Assert.Equal(sutX.StatLog, play.StatLog);
        }
        #endregion
    }
}
