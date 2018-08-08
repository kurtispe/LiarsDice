using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Die
    {
        public Die() : this(6)
        {
           
        }
        public Die(int md)
        {
            value = 0;
            RNG = new Random();
            maxDigit = md + 1;
        }

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

        public void Roll() //this is how we roll with internet 
        {
            int rng = RNG.Next(1, MaxDigit);
            value = rng;
        }
    }
}
