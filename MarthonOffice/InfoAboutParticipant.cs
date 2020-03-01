using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Marthon_Office_Model;
using System.Data.Entity;

namespace MarthonOffice
{
    public class InfoAboutParticipant : IInfoAboutParticipant
    {
        private IOfficeEntities iOfficeEntities;
       
        public InfoAboutParticipant()
        {
            iOfficeEntities = new OfficeEntities();
        }
        public List<vListParticipantsInOfficeRegisterCondition> getEmptyList()
        {
            List<vListParticipantsInOfficeRegisterCondition> result = new List<vListParticipantsInOfficeRegisterCondition>()
            {
                new vListParticipantsInOfficeRegisterCondition
                {
                    kart_nazwisko = "brak danych",
                    kart_imie = "brak danych",
                    kart_email = "brak danych"
                }
            };
            return result;
        }

        public List<vListParticipantsInOfficeRegisterCondition> getListOffAllParticipants(IOfficeEntities iOfficeEntities2)
        {
            var result = iOfficeEntities2.FillData(iOfficeEntities2);
                if (result.Any())
                    return result;
                else
                    return getEmptyList();
            
        }
    }
    public class InfoAboutParticipant2
    {
        private OfficeEntities OfficeEntities;

        public InfoAboutParticipant2(OfficeEntities OfficeEntities)
        {
            this.OfficeEntities = OfficeEntities;
        }
    }
}
