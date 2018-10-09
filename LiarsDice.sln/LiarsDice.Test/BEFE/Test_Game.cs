using LiarsDice.BE.DataModels;
using LiarsDice.FE;
using System;
using System.Collections.Generic;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_Game
    {
        #region SetUp
        public Test_Game()
        {
            sut = new Game();
            player = new Player();
            player2 = new Player();
        }
        private Game sut;
        private Player player;
        private Player player2;
        #endregion
        #region Test
        [Fact]
        public void Test_Game_Props()
        {
            Assert.IsType<int>(sut.ActiveDie);
            Assert.IsType<float>(sut.SafeNumber);
            Assert.IsType<int>(sut.maxDieValue);
            Assert.IsType<int>(sut.numberOfDicePerPlayerAtStart);
            Assert.IsType<List<Player>>(sut.Competitors);
            Assert.IsType<int[]>(sut.StatLog);
        }
        [Fact]
        public void Test_Game_AddPlayer()
        {
            sut.AddPlayer(player2);
            Assert.Equal(player2.Name, sut.Competitors[0].Name);
        }
        [Fact]
        public void Test_Game_RemovePlayer()
        {
            sut.AddPlayer(player);
            sut.AddPlayer(player2);
            int beforeRemove = sut.Competitors.Count;
            sut.RemovePlayer(player);
            int afterRemove = sut.Competitors.Count;
            Assert.NotEqual(player, sut.Competitors[0]);
            Assert.True(beforeRemove > afterRemove);
        }
        [Fact]
        public void Test_Game_Stats()
        {
            player.RollDice();
            player2.RollDice();

            sut.AddPlayer(player);
            sut.AddPlayer(player2);

            sut.CalculateStats();
            Assert.Equal(4, sut.SafeNumber);
            Assert.Equal(12, sut.ActiveDie);
        }
        [Fact]
        public void Test_Game_ReturnInfo()
        {
            Assert.IsType<String>(sut.ReturnInfo());
        }
        [Fact]
        public void Test_Game_Produces()
        {
            sut.numberOfDicePerPlayerAtStart = 90;
            sut.maxDieValue = 5;
            sut.SafeNumber = 9;
            sut.Competitors.Add(new Player() {Name = "WOAH", Dice = new List<Die>() {new Die(4,2)} });
            GameFE sutX = sut.Produces();
            Assert.Equal(sut.numberOfDicePerPlayerAtStart, sutX.numberOfDicePerPlayerAtStart);
            Assert.Equal(sut.maxDieValue, sutX.maxDieValue);
            Assert.Equal(sut.SafeNumber, sutX.SafeNumber);
            Assert.Equal(sut.Competitors[0].Name, sutX.Competitors[0].Name);
            Assert.Equal(sut.Competitors[0].Dice[0].Value, sutX.Competitors[0].Dice[0].Value);
            Assert.Equal(sut.Competitors[0].Dice[0].MaxDigit, sutX.Competitors[0].Dice[0].MaxDigit);
        }
        [Fact]
        public void Test_Game_Consumes()
        {
            GameFE game = new GameFE()
            {
                SafeNumber = 3,
                StatLog = new int[3] {2,4,6},
                Competitors = new List<PlayerFE>() {new PlayerFE(){
                    Name = "WOAH",
                    Dice = new List<DieFE>(){
                        new DieFE(){Value = 4, MaxDigit =7}
                        }
                    }
                }
            };
            sut.Consumes(game);
            Assert.Equal(game.SafeNumber, sut.SafeNumber);
            Assert.Equal(game.StatLog[1], sut.StatLog[1]);
            Assert.Equal(game.Competitors[0].Name, sut.Competitors[0].Name);
            Assert.Equal(game.Competitors[0].Dice[0].Value, sut.Competitors[0].Dice[0].Value);
        }
        #endregion
    }
}
