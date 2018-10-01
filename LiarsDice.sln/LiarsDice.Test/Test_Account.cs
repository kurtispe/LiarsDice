using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test
{
    public class Test_Account
    {
        #region Constructor
        public Test_Account()
        {
            sut = new Account();
        }

        private Account sut;
        #endregion

        [Fact]
        public void Test_Account_Props()
        {
            Assert.IsType<string>(sut.Email);
            Assert.IsType<string>(sut.Name);  
        }
    }
}
