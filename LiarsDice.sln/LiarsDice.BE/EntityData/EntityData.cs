using System;
using System.Collections.Generic;
using System.Text;

namespace LiarsDice.BE.EntityData
{
    public class EntityData
    {
        #region Constructor
        public EntityData(CommonContext db)
        {
            CTX = db;
        }
        private static CommonContext CTX;
        #endregion
    }
}
