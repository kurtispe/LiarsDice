using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.FE
{
    public abstract class GameFE
    {
        public List<PlayerFE> Competitors { get; set; }
        public float SafeNumber { get; set; }
        public int ActiveDie { get; set; }
        public int maxDieValue { get; set; }
        public int numberOfDicePerPlayerAtStart { get; set; }
        public int[] StatLog;
    }
}
