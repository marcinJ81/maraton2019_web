using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.Repositories
{
    public class RegistrationExtModel : ExtModelRegistrationList, IregistrationList
    {
        public RegistrationExtModel()
           : base() {}

        public List<ExtModelRegistrationList> generateListZawodnik()
        {
            try
            {
                using (var db = new EntitiesRegistrationParticipant())
                {
                    var wyn = db.kartoteka2.Where(x => x.kart_wpis_rejestacja == true)
                        .Join(db.Dystans,
                        x => x.dys_id,
                        y => y.dys_id,
                        (x, y) => new
                        {
                            imie = x.kart_imie,
                            nazwisko = x.kart_nazwisko,
                            dystans = y.dys_wartosc,
                            grupa_id = x.grup_id,
                            rejestracja = x.kart_wpis_rejestacja,
                            oplata = x.kart_wpis_oplata == true ? "Tak" : "Nie",
                            rezerwa = x.kart_wpis_rezerwowa == true ? "Tak" : "Nie"
                        }).Join(db.grupa_kolarska,
                        i => i.grupa_id,
                        j => j.grupa_id,
                        (i, j) => new ExtModelRegistrationList
                        {
                            imie = i.imie.ToUpper(),
                            nazwisko = i.nazwisko.ToUpper(),
                            dystans = i.dystans,
                            grupa = j.grupa_nazwa,
                            rejestracja = i.rejestracja,
                            rezerwa = i.rezerwa,
                            oplacony = i.oplata
                        }).OrderBy(x => x.dystans).ToList();
                    return wyn;
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
