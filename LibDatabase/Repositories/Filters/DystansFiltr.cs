using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibDatabase.Repositories.Filters
{
    public class DystansFiltr : IDystans
    {
        public List<Dystans> filtrDystans()
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var wynik = db.Dystans.Where(x => x.dys_aktywny == true).ToList();
                List<Dystans> lista = new List<Dystans>();
                lista.Add(new Dystans
                {
                    dys_id = 0,
                    dys_wartosc = "Wybierz dystans",
                    dys_aktywny = true
                });
                foreach (var i in wynik)
                {
                    lista.Add(i);
                }
                return lista;
            }
        }
    }
}
