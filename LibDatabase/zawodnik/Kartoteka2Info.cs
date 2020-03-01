using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace LibDatabase.zawodnik
{
    public class Kartoteka2Info : IKartoteka2Info
    {
        public kartoteka2 getEmptyResult()
        {
            kartoteka2 result = new kartoteka2() {
                kart_imie = "brak danych",
                kart_nazwisko = "brak danych",
                kart_email = "brak danych"
            };
            return result;
        }

        public List<kartoteka2> getInformationAboutAllParticipant()
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var result = db.kartoteka2.AsNoTracking().ToList();
                return result; 
            }
        }

        public kartoteka2 getInformationAboutOneParticipantFromKartoteka2(IKartoteka2Info allParticipant,string name,string surname,string email)
        {
            var source = allParticipant.getInformationAboutAllParticipant();
            var result = source.Where(x => 
                                            x.kart_imie == name
                                            && x.kart_nazwisko == surname 
                                            && x.kart_email == email).First();
            if (result != null)
            {
                return result;
            }
            else
            {
                return getEmptyResult();
            }
        }

        public kartoteka2 getOneParticipantById(IKartoteka2Info allParticipant, int kart_id)
        {
            var result = allParticipant.getInformationAboutAllParticipant();
            result = result.Where(x => x.kart_id == kart_id).ToList();
            if (!result.Any())
            {
                return allParticipant.getEmptyResult();
            }
            else
            {
                return result.First();
            }
        }

       

    }
}
