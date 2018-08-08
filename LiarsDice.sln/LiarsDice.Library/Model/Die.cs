using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Die
    {
        public Die()
        {
            value = 0;
            RNG = new Random();
        }

        private int value;
        public int Value
        {
            get {return value;}
        }

        Random RNG; 

        public void Roll()
        {
            int rng = RNG.Next(1, 7);
            value = rng;
        }
    }
}
