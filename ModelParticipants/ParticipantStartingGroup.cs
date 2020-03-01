using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Time_Tag_Participant;

namespace ModelParticipants
{

    public class ParticipantStartingGroup : IParticipantStartingGroup
    {
    
        public List<VStartingLists> getAllList()
        {
            try
            {
                List<VStartingLists> result = new List<VStartingLists>();
                using (var db = new EntitiesTagTime())
                {
                    result = db.VStartingLists.AsNoTracking().ToList();
                    return result;
                }
            }
            catch (Exception ex)
            {
                string er = ex.Message;
                return null;
            }
        }

        public List<VStartingLists> getEmptyRow()
        {
            List<VStartingLists> result = new List<VStartingLists>() { new VStartingLists
            {
                Id = 0,
                kart_nazwisko = "brak danych",
                kart_imie = "brak danych",
                dys_wartosc = "brak danych",
                list_nazwa = "brak danych"
            }};
            return result;
        }

        public List<VStartingLists> getSpecificList(string nazwisko, IParticipantStartingGroup istartingGroup)
        {
            List<VStartingLists> result = new List<VStartingLists>();
            if (String.IsNullOrEmpty(nazwisko)) nazwisko = "";
            var source = istartingGroup.getAllList();
            source = source.Where(x => x.kart_nazwisko.ToUpper().Contains(nazwisko.ToUpper())).ToList();
            if (!source.Any())
            {
                return istartingGroup.getEmptyRow();
            }
            else
            {
                result = istartingGroup.getAllList().Where(x => source.Any(y => y.list_id == x.list_id)).ToList();
                return result;
            }
        }

    }
}
