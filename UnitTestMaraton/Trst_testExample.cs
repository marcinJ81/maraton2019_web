using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.zawodnik;
using NUnit.Framework;

namespace UnitTestMaraton
{
   public class Test_testExample
    {
        private IKartoteka2Info_Test iFake;
        private IKartoteka2Info_Test iTrue;

        public Test_testExample()
        {
            iFake =  new Test_testExample_fake();
            iTrue = new Kartoteka2Info_test(iFake);
        }
        [Test]
        public void testmethod()
        {
            var result = iTrue.getOneParticipantById(1001);
            var target = iFake.getInformationAboutAllParticipant();

            Assert.AreEqual(target.First().kart_id, result.kart_id);
        }
    }

    public class Test_testExample_fake : IKartoteka2Info_Test
    {
        private readonly IKartoteka2Info allParticipant;

        public kartoteka2 getEmptyResult()
        {
            kartoteka2 result = new kartoteka2()
            {
                kart_id = 1002,
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
            }};
            return result;
        }

        public kartoteka2 getOneParticipantById(int kart_id)
        {
            throw new NotImplementedException();
        }
    }
}
