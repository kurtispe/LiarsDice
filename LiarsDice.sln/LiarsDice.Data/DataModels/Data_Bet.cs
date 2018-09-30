﻿using LiarsDice.Library.Interfaces;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.Data.DataModels
{
    public class Data_Bet : Bet, SaveHelper
    {
       // private int pk;
        public int PrimeKey { get; set;}
        public int CaseID { get { return 0; }}
    }
}