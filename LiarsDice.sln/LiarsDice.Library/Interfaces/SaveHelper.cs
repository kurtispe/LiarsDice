using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Library.Interfaces
{
    public interface SaveHelper
    {
         int CaseID { get; }
         int PrimeKey { get; set; }
    }
}
