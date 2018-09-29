using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Interfaces
{
    public interface Stats
    {
        string ReturnInfo();
        void CalculateStats();
        void ZeroStat();
    }
}
