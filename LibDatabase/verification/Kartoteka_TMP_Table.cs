using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace LibDatabase.verification
{
    public class Kartoteka_TMP_Table : IKartoteka_TMP
    {
        public kartoteka_TMP getInfoAboutTimeRegistrationForParticipant(string name, string surname, string email)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var result = db.kartoteka_TMP.ToList();
                var resultOnlyOne = result
                    .Where(x => x.imie == name && x.nazwisko == surname && x.email == email)
                    .OrderByDescending(x => x.dataRej)
                    .First();
                return resultOnlyOne;
            }
        }
    }
}
