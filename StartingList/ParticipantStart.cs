using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Time_Tag_Participant;
using Abstract_And_Model_Layer.Marthon_Office_Model;

namespace StartingList
{
    public class ParticipantStart : IParticipantStart
    {
        private readonly IStoredProcedures istoredprocedures;
        private readonly IParticipantStart ipartipantStart;
        public ParticipantStart()
        {
            this.ipartipantStart = new ParticipantStart();
            this.istoredprocedures = new StoredProceduresOfficeMarathon();
        }
        public List<VStartingLists> getAllList(IParticipantStart istartList)
        {
            using (var db = new EntitiesTagTime())
            {
                var source = db.VStartingLists.AsNoTracking().ToList();
                if (source.Any())
                {
                    var result = source.Distinct().Select(x => new VStartingLists
                    {
                        list_id = x.list_id,
                        list_nazwa = x.list_nazwa,
                        dys_wartosc = x.dys_wartosc,
                        list_ilosc = x.list_ilosc
                    }).ToList();
                    return result;
                }
                else
                {
                    List<VStartingLists> emptyResult = new List<VStartingLists>();
                    emptyResult.Add(istartList.getEmptyList());
                    return emptyResult;
                }
                
            }
        }

        public VStartingLists getEmptyList()
        {
            throw new NotImplementedException();
        }

        public List<string> startParticipantWithSelectedList(int list_id)
        {
            List<string> result = new List<string>();
            //lista zawodnikow  z danej listy startowej imie nazwisko email do stringa jako wynik
            using (var db = new EntitiesTagTime())
            {
                istoredprocedures.pStartParticipantFromList(list_id);
                result.Add("name sname email");
                return result;
            }
        }
    }
}
