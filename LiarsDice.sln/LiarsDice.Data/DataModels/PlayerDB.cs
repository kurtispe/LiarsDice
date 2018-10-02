using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class PlayerDB : SaveHelper
    {
        #region Constructor 
        public PlayerDB()
        { 
        }
        public PlayerDB(Player player)
        {
            CopyValues(player);
        }
        #endregion

        #region Props
        public int CaseID {get { return 3;}}
        public int PrimeKey { get; set;}

        public string Name;
        public int DieCount;
        public int Score;
        public int MaxDie;
        public List<Die> Dice;
        protected int[] StatLog;
        protected Bet bet;
        public Bet Bet
        {
            get { return bet; }
        }
        #endregion 

        #region Function 
        public void CopyValues(Player player)
        {
            bet = player.Bet;
            Name = player.Name;
            DieCount = player.DieCount;
            Score = player.Score;
            MaxDie = player.MaxDie;
            Dice = player.Dice;
        }
        #endregion
    }
}
