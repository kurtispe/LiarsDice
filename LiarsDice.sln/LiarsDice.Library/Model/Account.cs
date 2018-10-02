using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Account : Stats
    {
        #region Constructor
        public Account() : this("genericName", "genericEmail@.com")
        {
           
        }
        public Account(string name, string email)
        {
            Name = name;
            Email = email;
            Visibility = true;
        }
        #endregion

        #region Props

        public readonly string Name;
        public readonly string Email;
        public bool Visibility;

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
        #endregion

        #endregion
    }
}
