using LiarsDice.FE;
using System;

namespace LiarsDice.BE.DataModels
{
    public sealed class Account : AccountFE
    {
        #region Constructor

        #endregion
        #region DataProps
        public int PK { get; set; }
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
            return new Account();
        }
        #endregion
    }
}
