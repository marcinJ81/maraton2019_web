using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Time_Tag_Participant;

namespace ModelParticipants
{
    public class ParticipantResultList : IParticipantResultList
    {
        public List<vResultList> getResultList()
        {
            using (var db = new EntitiesTagTime())
            {
               var result = db.vResultList.ToList();
                if (result.Any())
                {
                    return result;
                }
                else
                {
                    return emptyResult();
                }
            }
        }

        public List<vResultList> getResultListByDane(string dane, IParticipantResultList iparticipantResult)
        {
            List<vResultList> result = new List<vResultList>();
      
            var source = iparticipantResult.getResultList();
            result = source.Where(x => x.dane.ToUpper().Contains(dane.ToUpper())).ToList();
            if (result.Any())
            {
                result = result.OrderBy(x => x.dys_id).ThenBy(x => x.sum_seconds).ToList();
                return result;
            }
            else
            {
                return emptyResult();
            }
        }

        public List<vResultList> emptyResult()
        {
            List<vResultList> result = new List<vResultList>() {
                new vResultList
                {
                    kart_id = 0,
                    dys_id = 0,
                    zaw_id = 0,
                    tag_id = 0,
                    kart_nazwisko = "brak danych",
                    kart_imie = "brak danych",
                    dane = "brak danych"
                }};
            return result;

        }

        public List<vResultList> getResultListByDystans(int dys_id, IParticipantResultList iparticipantResult)
        {
            List<vResultList> result = new List<vResultList>();
            var source = iparticipantResult.getResultList();
            result = source.Where(x => x.dys_id == dys_id).ToList();
            if (result.Any())
            {
                result = result.OrderBy(x => x.dys_id).ThenBy(x => x.sum_seconds).ToList();
                result = result.OrderByDescending(x => x.iloscOdbic).ToList();
                return result;
            }
            else
            {
                return emptyResult();
            }
        }



        public List<vResultList> getResultListByDaneAndList(string dane, List<vResultList> participantResults)
        {
            if (!participantResults.Any())
            {
                return emptyResult();
            }
            else
            {
                var result = participantResults.Where(x => x.dane.Contains(dane)).ToList();
                return result;
            }
        }

        public List<vResultList> setOrderResultLIst(List<vResultList> participantResults)
        {
            var result = participantResults;
            result = result.OrderBy(x => x.dys_id)
                           .ThenBy(x => x.sum_seconds)
                           .OrderByDescending(x => x.iloscOdbic)
                           .ToList();
            return result;
        }

        public vResultList getResultFotOneParticipant(int kart_id, IParticipantResultList iparticipantResult)
        {
            if (kart_id > 0)
            {
                var source = iparticipantResult.getResultList();
                var result = source.Where(x => x.kart_id == kart_id);
                if (result.Any())
                    return result.First();
                else
                    return iparticipantResult.emptyResult().First();
            }
            else
            {
                return iparticipantResult.emptyResult().First();
            }

        }
    }
}
