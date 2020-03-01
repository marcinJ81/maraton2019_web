using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace UnitTestMaraton
{
    public class Kartoteka_TMP_Table_Fake : IKartoteka_TMP
    {
        public kartoteka_TMP getInfoAboutTimeRegistrationForParticipant(string name, string surname, string email)
        {
            List<kartoteka_TMP> listResult = new List<kartoteka_TMP>();
            listResult.Add(
                new kartoteka_TMP
                {
                imie = "marcin",
                nazwisko = "juranek",
                email = "testc@test.pl",
                dataRej = DateTime.Now,
                limitCzasu = 30
                } 
            );
            listResult.Add(
                new kartoteka_TMP
                {
                    imie = "marcin2",
                    nazwisko = "juranek2",
                    email = "test2c@test.pl",
                    dataRej = DateTime.Now,
                    limitCzasu = 30
                }
                );
            var kartTmp = listResult.Where(x => x.imie == name && x.nazwisko == surname && x.email == email).First();
            return kartTmp;
        }
    }
}
