using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibDatabase.zawodnik
{
   public class Kartoteka2Info_test : IKartoteka2Info_Test
    {
        private readonly IKartoteka2Info_Test allParticipant;

        public Kartoteka2Info_test(IKartoteka2Info_Test iallParticipant)
        {
            this.allParticipant = iallParticipant;
        }

        public kartoteka2 getEmptyResult()
        {
            throw new NotImplementedException();
        }

        public List<kartoteka2> getInformationAboutAllParticipant()
        {
            List<kartoteka2> result = new List<kartoteka2>();
            return result;
        }

        public kartoteka2 getOneParticipantById(int kart_id)
        {
            var result = allParticipant.getInformationAboutAllParticipant();
            result = result.Where(x => x.kart_id == kart_id).ToList();
            if (!result.Any())
            {
                return allParticipant.getEmptyResult();
            }
            else
            {
                return result.First();
            }
        }
    }
}
