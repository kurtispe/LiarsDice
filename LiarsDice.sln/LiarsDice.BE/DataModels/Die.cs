using LiarsDice.FE;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiarsDice.BE.DataModels
{
    public sealed class Die : DieFE
    {
        #region Constructor
        public Die() : this(6)
        {
        }
        public Die(int md) : this(md, 0)
        {
            Value = 0;
            RNG = new Random();
            MaxDigit = md + 1;
        }
        public Die(int md, int v)
        {
            Value = v;
            RNG = new Random();
            MaxDigit = md;
        }
        #endregion
        #region DataProps
        public int PK { get; set; }
        [NotMapped]
        Random RNG;
        #endregion
        #region Functions
        public void Roll()
        {
            int rng = RNG.Next(1, MaxDigit);
            Value = rng;
        }
        public Die DeepCopy()
        {
            return (Die)this.MemberwiseClone();
        }
        #endregion
    }
}
