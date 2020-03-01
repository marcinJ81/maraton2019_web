using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.verification;
using Abstract_And_Model_Layer;

namespace UnitTestMaraton
{

    public class Test_CheckWerification
    {
        [Test]
        public void Test_getTimeAndVerification_param_name_surname_email_return_true()
        {
            //arange

            //act

            //assert
        }
        [Test]
        public void Test_getInfoAboutTimeRegistrationForParticipant_param_name_surname_email_return_true()
        {
            //arange
            IKartoteka_TMP actual = new Kartoteka_TMP_Table_Fake();
            //act
         var result = actual.getInfoAboutTimeRegistrationForParticipant("marcin", "juranek", "testc@test.pl");
            //assert
            NUnit.Framework.Assert.IsNotNull(result);
            NUnit.Framework.Assert.AreEqual(fake_row().nazwisko, result.nazwisko);
        }

        private kartoteka_TMP fake_row()
        {
            kartoteka_TMP kartTmp = new kartoteka_TMP()
            {
                imie = "marcin",
                nazwisko = "juranek",
                email = "testc@test.pl",
                dataRej = DateTime.Now,
                limitCzasu = 30
            };
            return kartTmp;
            
        }
    }
}
