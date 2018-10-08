using LiarsDice.Data.DataModels;
using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Account : AccountDB, Stats
    {
        #region Constructor
        public Account() : this("genericName", "genericEmail@.com")
        {
        }
        public Account(string name, string email) : this (name, email, true)
        {
            Name = name;
            Email = email;
        }
        public Account(string name, string email, bool vis)
        {
            Name = name;
            Email = email;
            Visibility = vis;
        }
        #endregion

        #region Props
        #endregion

        #region Functions
        #region Stats
        public string ReturnInfo()
        {
            throw new NotImplementedException();
        }

        public void CalculateStats()
        {
            throw new NotImplementedException();
        }

        public void ZeroStat()
        {
            throw new NotImplementedException();
        }
        #endregion
        public Account DeepCopy()
        {
            return new Account(Name, Email, Visibility);
        }
        #endregion

    }
}
