using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MarthonOffice
{
    public class SimpleAddingParticipant2 : ISimpleAddingParticipant2
    {
        public string errorInformation { get; set; }
        public bool saveParticipantToBase { get; set; }

        public bool AddNewParticipant(string name, string sname, string email, int dys_id,
            ISimpleAddingParticipant2 isimpleAdd, IPlayerVerfication iparticipant,
            IAddZawodnik iaddParticipant, INewRecord inewRecord)
        {
            if (isimpleAdd.validateFormatEmail(email))
            {
                var result = inewRecord.createNewRecord(name, sname, email, "", null, "", "", dys_id, 1);
                if (!iparticipant.searchPlayer(result))
                {
                    return iaddParticipant.addParticipantWithoutTimeRegistrationVerification(result);
                }
                else
                {
                    this.errorInformation = "Zawodnik istnieje";
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        public bool validateFormatEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch (FormatException)
            {
                this.errorInformation = "Niewłaściwy email";
                return false;
            }
        }
    }
}
