using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.verification;
using System.Net.Mail;

namespace MarthonOffice
{
    public class SimpleAddingParticipant : ISimpleAddingParticipant
    {
        private readonly INewRecord inewRecord;
        private readonly IAddZawodnik iaddParticipant;
        private readonly IPlayerVerfication iparticipant;

        public bool saveParticipantToBase { get; set; }

        public string errorInformation { get; set; }

        public SimpleAddingParticipant(INewRecord inewRecord, IAddZawodnik iaddZawodnik, IPlayerVerfication iparticipant)
        {
            this.inewRecord = inewRecord;
            this.iaddParticipant = iaddZawodnik;
            this.iparticipant = iparticipant;
        }

        public bool AddNewParticipant(string name, string sname, string email, int dys_id)
        {
            if (validateFormatEmail(email))
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
