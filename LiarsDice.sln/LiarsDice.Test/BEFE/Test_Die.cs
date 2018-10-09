using LiarsDice.BE.DataModels;
using LiarsDice.FE;
using Xunit;

namespace LiarsDice.Test.BEFE
{
    public class Test_Die
    {
        #region SetUP
        public Test_Die(){
            sut = new Die();
        }
        private Die sut;
        #endregion
        #region Test
        [Fact]
        public void Test_Die_Props()
        {
            Assert.IsType<int>(sut.MaxDigit);
            Assert.IsType<int>(sut.Value);
        }
        [Fact]
        public void Test_Die_Roll()
        {
            var exp = 0;
            int act;
            for (int n = 0; n <= 500; n++)
            {
                sut.Roll();
                var V = sut.Value;
                if (V <= 0 | V >= 7)
                {
                    n = 501;
                    act = 7;
                }
            }
            act = sut.Value;
            Assert.True(exp != act);
            Assert.False(act == 7);
        }

        [Fact]
        public void Test_Die_Value()
        {
            var exp = 0;
            Assert.IsType<int>(sut.Value);
            Assert.True(exp == sut.Value);
        }

        [Fact]
        public void Test_Die_MaxDigit()
        {
            sut = new Die(20);
            int maxRoll = 0;

            for (int n = 0; n <= 500; n++)
            {
                sut.Roll();
                var V = sut.Value;
                if (V >= maxRoll)
                {
                    maxRoll = V;
                }
            }
            Assert.True(maxRoll == 20);
        }
        [Fact]
        public void Test_Die_Produces()
        {
            DieFE FE = sut.Produces();
            Assert.Equal(sut.Value, FE.Value);
            Assert.Equal(sut.MaxDigit, FE.MaxDigit);
        }
        [Fact]
        public void Test_Die_Consumes()
        {
            Die sutX = new Die(new DieFE()
            {
                Value = 9,
                MaxDigit = 12
            });
            Assert.Equal(9, sutX.Value);
            Assert.Equal(12, sutX.MaxDigit);
        }
        #endregion
    }
}
