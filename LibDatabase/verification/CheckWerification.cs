using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.verification
{
    public class CheckWerification : ICheckWerification
    {
        public bool getTimeAndVerification(string imie, string nazwisko, string email)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var result = db.kartoteka_TMP.ToList();
                var resultOnlyOne = result
                    .Where(x => x.imie == imie && x.nazwisko == nazwisko && x.email == email)
                    .OrderByDescending(x => x.dataRej)
                    .First();

                TimeSpan? timeRegistration = DateTime.Now - resultOnlyOne.dataRej;
                if (timeRegistration.Value.Minutes > resultOnlyOne.limitCzasu)
                {
                    return false;
                }
                else
                {
                    return true;
                }
            }
        }

        public void saveTimeWerification(kartoteka_TMP _tmp)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                kartoteka_TMP tmp = _tmp;
                tmp.dataRej = DateTime.Now;
                tmp.limitCzasu = 10;
                db.kartoteka_TMP.Add(tmp);
                db.SaveChanges();
            }
        }
    }
}
