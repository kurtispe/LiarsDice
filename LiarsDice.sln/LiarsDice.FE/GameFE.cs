using System.Collections.Generic;

namespace LiarsDice.FE
{
    public class GameFE 
    {
        #region Constructor
        public GameFE()
        {
            Competitors = new List<PlayerFE>();
        }
        #endregion
        #region Props
        public List<PlayerFE> Competitors { get; set; }
        public float SafeNumber { get; set; }
        public int ActiveDie { get; set; }
        public int maxDieValue { get; set; }
        public int numberOfDicePerPlayerAtStart { get; set; }
        public int[] StatLog;
        #endregion
    }
}
