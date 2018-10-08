using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_Account
    {
        public Test_Account()
        {

        }

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
