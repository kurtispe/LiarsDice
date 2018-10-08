using LiarsDice.BE.DataModels;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_Account
    {
        #region SetUp
        public Test_Account()
        {
            sut = new Account();
        }
        private Account sut;
        #endregion

        #region Test
        [Fact]
        public void Test_Account_Props()
        {
            Assert.IsType<string>(sut.Email);
            Assert.IsType<string>(sut.Name);
        }
        #endregion

    }
}
