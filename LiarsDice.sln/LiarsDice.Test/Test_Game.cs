using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test
{
    public class Test_Game
    {
        public Test_Game()
        {
            sut = new Game();
            player = new Player();
            player2 = new Player("Greg");
        }
        private Game sut;
        private Player player;
        private Player player2;

        [Fact]
        public void Test_Game_Props()
        {
            Assert.IsType<int>(sut.ActiveDie);
            Assert.IsType<float>(sut.SafeNumber);
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
    }
}
