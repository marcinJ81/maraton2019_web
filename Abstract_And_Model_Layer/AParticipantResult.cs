using Abstract_And_Model_Layer.Time_Tag_Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IParticipantResultList
    {
        List<vResultList> getResultListByDane(string dane, IParticipantResultList iparticipantResult);
        List<vResultList> getResultList();
        List<vResultList> emptyResult();
        List<vResultList> getResultListByDystans(int dys_id, IParticipantResultList iparticipantResult);
        List<vResultList> getResultListByDaneAndList(string dane, List<vResultList> participantResults);
        List<vResultList> setOrderResultLIst(List<vResultList> participantResults);
        vResultList getResultFotOneParticipant(int kart_id, IParticipantResultList iparticipantResult);
    }

    public interface IParticipantStartingGroup
    {
        List<VStartingLists> getAllList();
        List<VStartingLists> getSpecificList(string nazwisko, IParticipantStartingGroup istartingGroup);
        List<VStartingLists> getEmptyRow();
    }
}
