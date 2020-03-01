using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using MarthonOffice;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UnitTestMaraton
{
    public class TestSimpleAddingParticipant
    {
        private readonly ISimpleAddingParticipant isimpleAdd_true;
        private readonly IPlayerVerfication iparticipant;

        public TestSimpleAddingParticipant()
        {
            isimpleAdd_true = new SimpleAddingParticipant(new NewRecord_Fake(),new AddZawodnik_Fake(), new PlayerVerfication_Fake());    
        }
        [Test]
      public void Test_AddNewParticipant_withAllParametersNotNull()
        {
            //arrange
            isimpleAdd_true.AddNewParticipant("testName","testSname", "testEmail@test.pl", 1);
            var result = isimpleAdd_true.saveParticipantToBase;
            //act
            var target = new AddZawodnik_Fake().pKartotekaZawodnikaDodaj(new kartoteka2
            {
                kart_id = 1003,
                kart_imie = "testName",
                kart_nazwisko = "testSname",
                kart_email = "testEmail",
                dys_id = 1
            });
            //assert
            Assert.AreEqual(target, result);
        }

        [Test]
        [TestCase("testName", "testSname", "testEmail@test.pl", false)]
        [TestCase("testName2", "testSname2", "testEmail@test.pl", true)]
        public void Test_AddNewParticipant_verificationExistParticipant_returnFalse(string name,string sname, string email,bool result)
        {
            var result2 = isimpleAdd_true.AddNewParticipant(name, sname, email, 1);
            Assert.AreEqual(result, result2);
        }

        [Test]
        [TestCase( @"NotAnEmail", false)]
        [TestCase( "@majl.com", false)]
        [TestCase(@"@majl.com", false)]
        [TestCase( @"test @test.pl", false)]
        [TestCase( @"name.sname2@test.pl", true)]
        [TestCase(@"name_sname2@test.pl", true)]
        [TestCase(@"test@ test.pl", false)]
        [TestCase(@"1234@test.pl", true)]
        [TestCase(@"1234_mmm@test.pl", true)]
        public void Test_validateFormatEmail(string email, bool resultParam)
        {
           var result = isimpleAdd_true.validateFormatEmail(email);
            Assert.AreEqual(resultParam,result);
        }
    }


    public class PlayerVerfication_Fake : IPlayerVerfication
    {
        public bool searchPlayer(kartoteka2 kart)
        {

            kartoteka2 result = new kartoteka2
            {
                kart_imie = "testName",
                kart_nazwisko = "testSname",
                kart_email = "testEmail@test.pl",
            };
            if (kart.kart_email == result.kart_email && kart.kart_imie == result.kart_imie && kart.kart_nazwisko == result.kart_nazwisko)
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }

    public class TestSimpleAddingParticipant_fake : ISimpleAddingParticipant
    {
        public bool saveParticipantToBase { get; set; }
        public string errorInformation { get; set; }
        public bool AddNewParticipant(string name, string sname, string email, int dys_id)
        {
            throw new NotImplementedException();
        }

        public bool validateFormatEmail(string email)
        {
            throw new NotImplementedException();
        }
    }

    public class NewRecord_Fake : INewRecord
    {
        public kartoteka2 createNewRecord(string imie, string nazwisko, string email, string dataUr, int? plec, string telefon, string uwagi, int? dys, int? group)
        {
           kartoteka2 result = new kartoteka2
            {
                kart_id = 1003,
                kart_imie = imie,
                kart_nazwisko = nazwisko,
                kart_email = email,
                dys_id = 1
            };
            return result;
        }
    }

    public class AddZawodnik_Fake : IAddZawodnik
    {
        public bool addParticipantWithoutTimeRegistrationVerification(kartoteka2 kart)
        {

            return true;

        }

        public bool pKartotekaZawodnikaDodaj(kartoteka2 kart)
        {
            
            return false;
            
        }
    }


}
