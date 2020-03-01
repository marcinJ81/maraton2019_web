using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using maratonMszana_v4.Controllers;
using LibDatabase.verification;
using NUnit.Framework;

namespace maratonMszana_v4.Tests
{
    [TestClass]
    public class UnitTest1
    {
        TestMethod_GenerateNumber _test = new TestMethod_GenerateNumber();
        [TestMethod]
        public void TestMethod1()
        {
            //Arrange test
            var target = new RandomNumbers();
            int actual;

            //Act test
            actual = target.generateNumber();
            int result = _test.generateNumber(actual);

            //Assert test
            NUnit.Framework.Assert.AreEqual(result, actual);
        }
        
        [TestMethod]
        
        public void Test_verification(DateTime? start, DateTime? finish, bool expected)
        {
            //Arrange test
            //var target = new CheckWerification();
            //bool actual = false;

            ////Act test
            //actual = target.verification(start, finish);

            ////Assert test
            //NUnit.Framework. Assert.AreEqual(expected,actual);
        }
    }
}
