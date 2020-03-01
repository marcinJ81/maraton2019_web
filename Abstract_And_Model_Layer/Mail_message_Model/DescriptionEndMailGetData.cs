using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Mail_message_Model
{
    public class DescriptionEndMailGetData : IDataForDescription
    {
        public DescriptionEndMail get_DataFoDescritpion(string imie, string nazwisko, string email)
        {
            try
            {
                using (var db = new EntitiesRegistrationParticipant())
                {
                    var result = db.kartoteka2.ToList();
                    result = result.Where(z => z.kart_imie == imie && z.kart_nazwisko == nazwisko && z.kart_email == email).ToList();

                    var result_DK = result.Join(db.Dystans,
                             kartoteka2 => kartoteka2.dys_id,
                             dystans => dystans.dys_id,
                             (kartoteka2, dystans) => new { kartoteka2, dystans });

                    var result_GK = result_DK.Join(db.grupa_kolarska,
                            kart2 => kart2.kartoteka2.grup_id,
                            gr => gr.grupa_id,
                            (kart2, gr) => new { kart2, gr });

                    var result_DIK = result_GK.Join(db.dystans_info,
                            k2 => k2.kart2.dystans.info_id,
                            info => info.info_id,
                            (k2, info) => new { k2, info });

                    var result_TMP = result_DIK.Select(x => new DescriptionEndMail
                    {
                        name = x.k2.kart2.kartoteka2.kart_imie + " " + x.k2.kart2.kartoteka2.kart_nazwisko,
                        email = x.k2.kart2.kartoteka2.kart_email,
                        dystansW = x.k2.kart2.dystans.dys_wartosc,
                        grupaK = x.k2.gr.grupa_nazwa,
                        startZ = x.info.info_start_date + " " + x.info.info_start_time,
                        oplataZ = x.info.info_oplata,
                        strona = "maratonmszana.hw7.pl"
                    }).First();

                    return result_TMP;
                }
            }
            catch (Exception ex)
            {
                string er = ex.InnerException.Message;
                return null;
            }
        }
    }
}
