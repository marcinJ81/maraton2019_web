using Abstract_And_Model_Layer.Time_Tag_Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IParticipantStart
    {
        List<VStartingLists> getAllList(IParticipantStart istartList);
        List<string> startParticipantWithSelectedList(int list_id);
        VStartingLists getEmptyList();
    }
}
