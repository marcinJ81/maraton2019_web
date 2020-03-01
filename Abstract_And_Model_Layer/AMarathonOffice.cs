using Abstract_And_Model_Layer.Marthon_Office_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IInfoAboutParticipant
    {
        List<vListParticipantsInOfficeRegisterCondition> getListOffAllParticipants(IOfficeEntities iOfficeEntities);
        List<vListParticipantsInOfficeRegisterCondition> getEmptyList();
    }
}
