using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Model
{
    public class Bet
    {
        #region Constructor
        public Bet() : this(1)
        {
        }
        public Bet(int w) : this(w,1)
        {
            weight = w;
        }
        public Bet(int w, int d)
        {
            weight = w;
            digit = d;
        }
        #endregion

        #region Props
        private int weight;
        public int Weight
        {
            get { return weight;}
        }
        private int digit;
        public int Digit
        {
            get { return digit; }
        }
        #endregion
    }
}
