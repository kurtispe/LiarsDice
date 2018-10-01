using LiarsDice.Library.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Account : SaveHelper, Stats
    {
        #region Constructor
        public Account() : this("genericName", "genericEmail@.com")
        {
           
        }
        public Account(string name, string email)
        {
            Name = name;
            Email = email;
        }
        #endregion

        #region Props
        public int CaseID {get { return 4;}}
        public int PrimeKey {get; set;}
        public string Name;
        public string Email;
        private bool Visibility;
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
    }
}
