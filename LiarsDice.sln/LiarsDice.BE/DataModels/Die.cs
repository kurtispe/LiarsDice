using LiarsDice.FE;
using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace LiarsDice.BE.DataModels
{
    public sealed class Die 
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
        public Die(DieFE die)
        {
            Consumes(die);
        }
        #endregion
        #region DataProps
        public int PK { get; set; }
        #endregion
        #region Props
        public int Value { get; set; }
        public int MaxDigit { get; set; }
        [NotMapped]
        Random RNG;
        #endregion
        #region Functions
        public void Consumes(DieFE die)
        {
            Value = die.Value;
            MaxDigit = die.MaxDigit;
        }
        public DieFE Produces()
        {
            return new DieFE
            {
                Value = Value,
                MaxDigit = MaxDigit
            };
        }
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
