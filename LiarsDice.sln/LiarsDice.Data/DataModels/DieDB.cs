using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class DieDB :  SaveHelper
    {
        #region Constructor 
        public DieDB() : this (new Die())
        {
        }
        public DieDB(Die die)
        {
            CopyValues(die);
        }
        #endregion
        #region Props
        public int CaseID { get { return 1; } }
        public int PrimeKey { get; set; }
        public int Value { get; set; }
        public int MaxDigit;
        #endregion
        #region Function 
        public void CopyValues(Die die)
        {
            Value = die.Value;
            MaxDigit = die.MaxDigit;
        }
        public Die ProduceReturnable()
        {
            Die die = new Die(MaxDigit, Value);
            return die;
        }
        #endregion
    }
}
