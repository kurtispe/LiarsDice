﻿using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.FE
{
    public abstract class AccountFE
    {
        #region Props
        public string Name { get; set; }
        public string Email { get; set; }
        public bool Visibility { get; set; }
        #endregion
    }
}
