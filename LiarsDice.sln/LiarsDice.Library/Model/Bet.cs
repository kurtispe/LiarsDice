using LiarsDice.Library.Interfaces;
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
            Weight = w;
        }
        public Bet(int w, int d)
        {
            Weight = w;
            Digit = d;
        }
        #endregion

        #region Props
        public int Weight { get; set; }
        public int Digit { get; set; }
        #endregion
    }
}
