using LiarsDice.Data.DataModels;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.Test_DataModel
{
    public class Test_BetDB
    {
        public Test_BetDB()
        {
            sut = new BetDB();
            bet = new Bet();
        }
        private BetDB sut;
        private Bet bet;

        [Fact]
        public void Test_DieDB_CopyValues()
        {
            bet.Digit = 7;
            bet.Weight = 5;
            sut.CopyValues(bet);
            Assert.Equal(bet.Digit, sut.Digit);
            Assert.Equal(bet.Weight, sut.Weight);
        }
        [Fact]
        public void Test_DieDB_ProduceReturnable()
        {
            bet.Digit = 7;
            bet.Weight = 5;
            sut.CopyValues(bet);
            Bet produced = sut.ProduceReturnable();
            Assert.Equal(bet.Digit, produced.Digit);
            Assert.Equal(bet.Weight, produced.Weight);
        }
    }
}
