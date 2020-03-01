using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.zawodnik
{
    public class AddZawodnik : IAddZawodnik
    {
        private readonly ICheckWerification _icheck;

        public AddZawodnik(ICheckWerification icheck)
        {
            this._icheck = icheck;
        }

        public bool addParticipantWithoutTimeRegistrationVerification(kartoteka2 kart)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                db.pKartotekaZawodnikaDodaj(kart.kart_imie, kart.kart_nazwisko, kart.kart_email,
                    kart.kart_dataUr, kart.plec_id, kart.kart_telefon, kart.kart_uwagi,
                    kart.dys_id, kart.grup_id, true, true);
                db.SaveChanges();

                return true;
            }
        }

        public bool pKartotekaZawodnikaDodaj(kartoteka2 _kart)
        {
            if (_icheck.getTimeAndVerification(_kart.kart_imie, _kart.kart_nazwisko, _kart.kart_email))
            {
               return  addParticipantWithoutTimeRegistrationVerification(_kart);
            }
            else
            {
                return false;
            }
        }
    }
}
