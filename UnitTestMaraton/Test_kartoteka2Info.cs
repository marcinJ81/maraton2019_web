using Abstract_And_Model_Layer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.zawodnik;

namespace UnitTestMaraton
{
    public class Test_kartoteka2Info
    {
        private IKartoteka2Info ikartoteka2InfoTrue;
        private IKartoteka2Info ikartoteka2InfoFake;

        public Test_kartoteka2Info()
        {
            ikartoteka2InfoTrue = new Kartoteka2Info();
            ikartoteka2InfoFake = new Fake_kartoteka2Info();
        }

        [Test]
        public void Test_getInformationAboutOneParticipantFromKartoteka2_resultOneRow()
        {
            //arrange
            var target = ikartoteka2InfoFake.getInformationAboutAllParticipant().First();
            //act
            var result = ikartoteka2InfoTrue.getInformationAboutOneParticipantFromKartoteka2(ikartoteka2InfoFake, "test_imie", "test_nazwisko", "test@test.pl");
            //assert
            Assert.AreEqual(target.kart_imie, result.kart_imie);
            Assert.AreEqual(target.kart_nazwisko, result.kart_nazwisko);
            Assert.AreEqual(target.kart_email, result.kart_email);
        }
        [Test]
        public void Test_getOneParticipantById_resultOneParticipant()
        {
            //arrange
            var target = ikartoteka2InfoFake.getInformationAboutAllParticipant().First();
            //act
            var result = ikartoteka2InfoTrue.getOneParticipantById(ikartoteka2InfoFake, 1001);
            //assert
            Assert.AreEqual(target.kart_id, result.kart_id);
            Assert.AreEqual(target.kart_nazwisko, result.kart_nazwisko);
            Assert.AreEqual(target.kart_email, result.kart_email);
        }
        [Test]
        public void Test_getOneParticipantById_resultDefault_paramWrong()
        {
            //arrange
            var target = ikartoteka2InfoFake.getEmptyResult();
            //act
            var result = ikartoteka2InfoTrue.getOneParticipantById(ikartoteka2InfoFake, 101);
            //assert
            Assert.AreEqual(target.kart_imie, result.kart_imie);
            Assert.AreEqual(target.kart_nazwisko, result.kart_nazwisko);
            Assert.AreEqual(target.kart_email, result.kart_email);
        }
        
    }
    public class Fake_kartoteka2Info : IKartoteka2Info
    {
        public kartoteka2 getEmptyResult()
        {
            kartoteka2 result = new kartoteka2()
            {
                kart_imie = "brak danych",
                kart_nazwisko = "brak danych",
                kart_email = "brak danych"
            };
            return result;
        }

        public List<kartoteka2> getInformationAboutAllParticipant()
        {
            List<kartoteka2> result = new List<kartoteka2>
            { new kartoteka2
            {
                kart_id = 1001,
                kart_imie = "test_imie",
                kart_nazwisko = "test_nazwisko",
                kart_email = "test@test.pl"
            },
            new kartoteka2
            {
                kart_id = 1003,
                kart_imie = "testName",
                kart_nazwisko = "testSname",
                kart_email = "testEmail",
                dys_id = 1   
            }
            };
            return result;
        }

        public kartoteka2 getInformationAboutOneParticipantFromKartoteka2(IKartoteka2Info allParticipant, string name, string surname, string email)
        {
            return allParticipant.getInformationAboutAllParticipant().First();
        }

        public kartoteka2 getOneParticipantById(IKartoteka2Info allParticipant, int kart_id)
        {
            throw new NotImplementedException();
        }
    }
}
