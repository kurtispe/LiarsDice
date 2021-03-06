﻿using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test
{
    public class Test_Bet
    {
        public Test_Bet()
        {
            sut = new Bet();
        }

        Bet sut;

        [Fact]
        public void Test_Bet_Weight()
        {
            var exp = sut.Weight;
            Assert.IsType<int>(sut.Weight);
            Assert.True(exp >= 1);
        }

        [Fact]
        public void Test_Bet_Digit()
        {
            var exp = sut.Digit;
            Assert.IsType<int>(sut.Digit);
            Assert.True(exp >= 1);
        }
    }
}
