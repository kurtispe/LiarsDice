using LiarsDice.Library.Interfaces;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
   
    public class Die 
    {
        #region Contructor
        public Die() : this(6)
        {
        }
        public Die(int md) : this (md, 0)
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

        #region Props
        Random RNG;

        public int Value { get; set; }
        public int MaxDigit { get; set; }
        #endregion

        #region Functions
        public void Roll() 
        {
            int rng = RNG.Next(1, MaxDigit);
            Value = rng;
        }
        #endregion
    }
}
