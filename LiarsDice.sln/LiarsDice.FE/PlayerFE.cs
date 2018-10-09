using System.Collections.Generic;

namespace LiarsDice.FE
{
    public class PlayerFE 
    {
        #region Constructor
        public PlayerFE()
        {
            Dice = new List<DieFE>();
        }
        #endregion
        #region Props
        public string Name { get; set; }
        public int DieCount { get; set; }
        public int Score { get; set; }
        public int MaxDie { get; set; }
        public List<DieFE> Dice { get; set; }
        public int[] Bet = new int[2];
        public int[] StatLog;
        #endregion
    }
}
