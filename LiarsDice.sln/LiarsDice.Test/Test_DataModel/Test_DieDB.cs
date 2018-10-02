using LiarsDice.Data.DataModels;
using LiarsDice.Library.Model;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace LiarsDice.Test.Test_DataModel
{
    public class Test_DieDB
    {
        public Test_DieDB()
        {
            sut = new DieDB();
            die = new Die();
        }
        private DieDB sut;
        private Die die;

        [Fact]
        public void Test_DieDB_CopyValues()
        {
            die.Roll();
            sut.CopyValues(die);
            Assert.Equal(die.Value, sut.Value);
            Assert.Equal(die.MaxDigit, sut.MaxDigit);
        }
        [Fact]
        public void Test_DieDB_ProduceReturnable()
        {
            die.Roll();
            sut.CopyValues(die);
            Die produced = sut.ProduceReturnable();
            Assert.Equal(die.Value, produced.Value);
            Assert.Equal(die.MaxDigit, produced.MaxDigit);
        }
    }
}
