﻿using System;
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
        public Die(int md)
        {
            value = 0;
            RNG = new Random();
            maxDigit = md + 1;
        }
        #endregion

        #region Props
        Random RNG;
        private int value;
        public int Value
        {
            get {return value;}
        }
        private int maxDigit;
        public int MaxDigit
        {
            get{ return maxDigit; }
        }
        #endregion

        #region Functions
        public void Roll() 
        {
            int rng = RNG.Next(1, MaxDigit);
            value = rng;
        }
        #endregion
    }
}
