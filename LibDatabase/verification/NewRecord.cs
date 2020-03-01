using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.verification
{
    public class NewRecord : INewRecord
    {
        public kartoteka2 createNewRecord(string imie, string nazwisko, string email, string dataUr, int? plec, string telefon, string uwagi, int? dys, int? group)
        {
            kartoteka2 _kart = new kartoteka2();
            _kart.kart_imie = imie;
            _kart.kart_nazwisko = nazwisko;
            _kart.kart_email = email;
            _kart.kart_dataUr = DateTime.Parse(dataUr.Length == 0 ? "1940-01-01" : dataUr);
            _kart.kart_telefon = telefon;
            _kart.kart_uwagi = uwagi;
            _kart.plec_id = plec;
            _kart.dys_id = dys;
            _kart.grup_id = group;
            return _kart;
        }
    }


    
}
