using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class GameDB : SaveHelper
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
        public int CaseID { get { return 2; } }
        public int PrimeKey { get; set; }

        protected List<PlayerDB> competitors;
        public List<PlayerDB> Competitors
        {
            get
            {
                return competitors;
            }
        }
        public float SafeNumber { get; set; }
        public int ActiveDie { get; set; }
        private int maxDieValue;
        private int numberOfDicePerPlayerAtStart;
        private int[] StatLog;
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
                 competitors.Add(new PlayerDB(p));
            }   
        }
        #endregion
    }
}
