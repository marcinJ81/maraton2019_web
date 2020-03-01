using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibDatabase.verification
{
    public class PlayerVerification : IPlayerVerfication
    {
        public bool searchPlayer(kartoteka2 kart)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var result = db.kartoteka2
                    .Where(x => x.kart_imie == kart.kart_imie && x.kart_nazwisko == kart.kart_nazwisko && x.kart_email == kart.kart_email).ToList();
                if (result.Any())
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}
