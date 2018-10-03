using LiarsDice.Data.Abstracts;
using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class BetDB : SaveHelper, GenericHelper
    {
        #region Constructor 
        public BetDB() : this(new Bet())
        { 
        }
        public BetDB(Bet bet)
        {
            CopyValues(bet);
        }
        #endregion
        #region Props
        public string caseType { get { return "Bet"; } }
        public override sealed int PK { get; set; }
        public int Weight { get; set; }
        public int Digit { get; set; }
        #endregion
        #region Function 
        public void CopyValues(Bet bet)
        {
            Weight = bet.Weight;
            Digit = bet.Digit;
        }
        public Bet ProduceReturnable()
        {
            return new Bet(Weight, Digit);
        }
        #endregion
    }
}
