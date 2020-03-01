using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using Abstract_And_Model_Layer;

namespace maratonMszana_v4.Filters
{
    public class CheckValue : ICheckValue
    {
        private readonly IregistrationList _registration;

        public CheckValue(IregistrationList registration)
        {
            this._registration = registration;
        }

        public void checkValueFiltersRef(int? id_grupa, int? id_dys, int? oplata, string nazwisko, ref List<ExtModelRegistrationList> lista)
        {
            if (!(id_dys == 0 || id_grupa == 0 || oplata == 0 || nazwisko.Length == 0 || 0 == 0))
            {
                var result = _registration.generateListZawodnik();
                lista = result;
            }
        }

        public void checkValueDystansRef(int? id_dys, ref List<ExtModelRegistrationList> result)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                if (id_dys > 0)
                {
                    string dystansNazwa = db.Dystans.Where(x => x.dys_id == id_dys).FirstOrDefault().dys_wartosc;
                    result = result.Where(x => x.dystans == dystansNazwa).ToList();
                }
            }
        }

        public void checkValueGrupaRef(int? id_grupa, ref List<ExtModelRegistrationList> result)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                if (id_grupa > 0)
                {
                    string grupaNazwa = db.grupa_kolarska.Where(x => x.grupa_id == id_grupa).FirstOrDefault().grupa_nazwa;
                    result = result.Where(x => x.grupa == grupaNazwa).ToList();
                }
            }
        }

        public void checkValueOplataRef(int? oplata, ref List<ExtModelRegistrationList> result)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                if (oplata == 1)
                {
                    result = result.Where(x => x.oplacony == "Tak").ToList();

                }
                if (oplata == 2)
                {
                    result = result.Where(x => x.oplacony == "Nie").ToList();

                }
            }
        }

        public void checkValueNazwsikoRef(string nazwisko, ref List<ExtModelRegistrationList> result)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                if (!string.IsNullOrEmpty(nazwisko))
                {
                    result = result.Where(x => x.nazwisko.Contains(nazwisko)).ToList();
                }
            }
        }


    }
}