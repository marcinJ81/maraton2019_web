using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.Repositories.Filters
{
    public class PlecFiltr : IPlec
    {
        public List<Plec> filtrPlec()
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                var wynik = db.Plec.ToList();
                List<Plec> lista = new List<Plec>();
                lista.Add(new Plec
                {
                    plec_id = 0,
                    plec_opis = "Wybierz Płeć",
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
