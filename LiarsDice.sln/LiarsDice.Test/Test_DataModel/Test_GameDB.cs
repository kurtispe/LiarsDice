using LiarsDice.Data.DataModels;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.Test_DataModel
{
    public class Test_GameDB
    {
        public Test_GameDB()
        {
            sut = new GameDB();
            game = new Game(5,7);
            player = new Player("name", 3, 4);
            player.Dice.Add(new Die(2, 3));
            game.Competitors.Add(player);
        }
        private GameDB sut;
        private Game game;
        private Player player;
        //[Fact]
        //public void Test_GameDB_CopyValues()
        //{
        //    game.CalculateStats();
        //    sut.CopyValues(game);
        //    Assert.Equal(game.maxDieValue, sut.maxDieValue);
        //    Assert.Equal(game.numberOfDicePerPlayerAtStart, sut.numberOfDicePerPlayerAtStart);
        //    Assert.Equal(game.SafeNumber, sut.SafeNumber);
        //    Assert.Equal(game.StatLog, sut.StatLog);
        //    Assert.Equal(game.ActiveDie, sut.ActiveDie);
        //}
        //[Fact]
        //public void Test_GameDB_ProduceReturnable()
        //{
        //    game.CalculateStats();
        //    sut.CopyValues(game);
        //    Game sutP = sut.ProduceReturnable();
        //    Assert.Equal(game.maxDieValue, sutP.maxDieValue);
        //    Assert.Equal(game.numberOfDicePerPlayerAtStart, sutP.numberOfDicePerPlayerAtStart);
        //    Assert.Equal(game.SafeNumber, sutP.SafeNumber);
        //    Assert.Equal(game.StatLog, sutP.StatLog);
        //    Assert.Equal(game.ActiveDie, sutP.ActiveDie);
        //}
    }
}
