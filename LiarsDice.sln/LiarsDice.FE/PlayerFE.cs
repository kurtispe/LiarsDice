using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.FE
{
    public abstract class PlayerFE
    {
        #region Props
        public string Name { get; set; }
        public int DieCount { get; set; }
        public int Score { get; set; }
        public int MaxDie { get; set; }
        public List<DieFE> Dice;
        public int[] Bet = new int[2];
        public int[] StatLog;
        #endregion
    }
}
