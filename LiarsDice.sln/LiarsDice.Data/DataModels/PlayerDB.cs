using LiarsDice.Data.Abstracts;
using LiarsDice.Data.Interfaces;
//using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class PlayerDB : SaveHelper, GenericHelper
    {
        #region Constructor 
        public PlayerDB()
        { 
        }
        //public PlayerDB(Player player)
        //{
        //    CopyValues(player);
        //}
        #endregion

        #region Props

        #region Helpers
        public string caseType { get { return "Player"; } }
        public override sealed int PK { get; set; }
        #endregion

        public string Name;
        public int DieCount;
        public int Score;
        public int MaxDie;
        public List<DieDB> Dice;
        // protected int[] StatLog;

        public int[] Bet = new int[2];
        #endregion 

        #region Function 
        //public void CopyValues(Player player)
        //{
        //    Bet = new BetDB(player.Bet);
        //    Name = player.Name;
        //    DieCount = player.DieCount;
        //    Score = player.Score;
        //    MaxDie = player.MaxDie;
        //    foreach(Die die in player.Dice)
        //    {
        //        Dice.Add(new DieDB(die));
        //    }
        //}
        //public Player ProduceReturnable()
        //{
        //    Player player = new Player(Name, DieCount, MaxDie);
        //    player.Score = Score;
        //    foreach(DieDB die in Dice)
        //    {
        //        player.Dice.Add(die.ProduceReturnable());
        //    }
        //    player.Bet = Bet.ProduceReturnable();

        //    return player;
        //}
        #endregion
    }
}
