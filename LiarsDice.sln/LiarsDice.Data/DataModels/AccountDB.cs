using LiarsDice.Data.Abstracts;
using LiarsDice.Data.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class AccountDB : SaveHelper, GenericHelper
    {
        #region Constructor 
        public AccountDB() : this (new Account())
        {
        }
        public AccountDB(Account account)
        {
            CopyValues(account);
        }
        #endregion
        #region Props
        public string caseType { get { return "Account"; } }
        public override sealed int PK { get; set; }

        public string Name;
        public string Email;
        protected bool Visibility;
        #endregion
        #region Function 
        public void CopyValues(Account account)
        {
            Name = account.Name;
            Email = account.Email;
            Visibility = account.Visibility;
        }
        #endregion
    }
}
