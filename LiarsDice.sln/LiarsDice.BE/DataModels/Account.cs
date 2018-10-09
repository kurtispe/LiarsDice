using LiarsDice.FE;
using System;

namespace LiarsDice.BE.DataModels
{
    public sealed class Account 
    {
        #region Constructor

        #endregion
        #region DataProps
        public int PK { get; set; }
        #endregion
        #region Props
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Visibility { get; set; }
        #endregion
        #region Functions
        #region Stats
        public void Consumes(AccountFE acc)
        {
            Name = acc.Name;
            Email = acc.Email;
            Visibility = acc.Visibility;
        }
        public AccountFE Produceces()
        {
            return new AccountFE()
            {
                Email = Email,
                Name = Name,
                Visibility = Visibility   
            };
        }
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
            return new Account();
        }
        #endregion
    }
}
