using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using LiarsDice.Library.Model;

namespace LiarsDice.Test
{
    public class Test_Die
    {
        public Test_Die()
        {
            sut = new Die();
        }

        private Die sut;

        [Fact]
        public void Test_Die_Roll()
        {
            var exp = 0;
            int act; 
            for (int n = 0; n<=500 ; n++)
            {
                sut.Roll();
                var V = sut.Value;
                if(V <= 0 | V >= 7)
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
                if(V >= maxRoll)
                {
                    maxRoll = V;
                } 
            }
            Assert.True(maxRoll == 20);
        }
    }
}
