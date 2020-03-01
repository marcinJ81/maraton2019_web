using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace LibDatabase.Repositories.Filters
{
    public class GrupaFiltr : IGrupa
    {
        public void addNewGrupa(grupa_kolarska newGroup)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                db.grupa_kolarska.Add(newGroup);
                db.SaveChanges();
            }
        }

        public List<grupa_kolarska> filtrGrupa()
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var wynik = db.grupa_kolarska.ToList();
                List<grupa_kolarska> lista = new List<grupa_kolarska>();
                lista.Add(new grupa_kolarska
                {
                    grupa_id = 0,
                    grupa_nazwa = "Wybierz Grupę"
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
