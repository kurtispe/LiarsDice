using LiarsDice.Data.Abstracts;
using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class GameDB : SaveHelper, GenericHelper
    {
        #region Constructor 
        public GameDB() 
        {
        }
        public GameDB(Game game)
        {
            CopyValues(game);
        }
        #endregion

        #region Props
        public string caseType { get { return "Game"; } }
        public override sealed int PK { get; set; }

        public List<PlayerDB> Competitors { get; set; }
        public float SafeNumber { get; set; }
        public int ActiveDie { get; set; }
        public int maxDieValue { get; set; }
        public int numberOfDicePerPlayerAtStart { get; set; }
        public int[] StatLog;
        #endregion

        #region Function 
        public void CopyValues(Game game)
        {
            game.CalculateStats();

            ActiveDie = game.ActiveDie;
            SafeNumber = game.SafeNumber;
            maxDieValue = game.maxDieValue;
            numberOfDicePerPlayerAtStart = game.numberOfDicePerPlayerAtStart;
            StatLog = game.StatLog;
            foreach(Player p in game.Competitors)
            {
                 Competitors.Add(new PlayerDB(p));
            }   
        }
        public Game ProduceReturnable()
        {
            Game game = new Game(numberOfDicePerPlayerAtStart, maxDieValue);
            game.ActiveDie = ActiveDie;
            game.SafeNumber = SafeNumber;
            game.StatLog = StatLog;
            foreach(PlayerDB play in Competitors)
            {
                game.Competitors.Add(play.ProduceReturnable());
            }
            return game;
        }
        #endregion
    }
}
