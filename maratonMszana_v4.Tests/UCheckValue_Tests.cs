using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using LibDatabase.ModelExt;
using System.Collections.Generic;

namespace maratonMszana_v4.Tests
{
    [TestClass]
    public class UCheckValue_Tests
    {
        [TestMethod]
        public void TestMethod_checkValueFiltersRef(int? id_grupa, int? id_dys, int? oplata, string nazwisko)
        {
            //Arrange test
            List<ExtModelRegistrationList> lista = new List<ExtModelRegistrationList>();

            //Act test
            //checkValueFiltersRef(1, 1, 1, "", ref lista);
            //Assert test

        }
    }
}
