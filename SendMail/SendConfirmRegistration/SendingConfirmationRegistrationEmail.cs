using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Mail_message_Model;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using SendMail.DescriptionEndMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ThrowException.Exceptions;

namespace SendMail.SendConfirmRegistration
{
    public class SendingConfirmationRegistrationEmail : ExceptionToBase, ISendingConfirmationRegistrationEmail
    {
        private readonly IDescriptionEndCreate iend;
        private readonly IDataForDescription idataDescription;
        private readonly ICreatingMailMessage imail;
        private readonly IEmailDescritpion iemailDescription;
        private readonly ISendingEmailTimeVerification isendingEmail;

        public SendingConfirmationRegistrationEmail(
            IDescriptionEndCreate iEnd, 
            IDataForDescription iDataDescription,
            ICreatingMailMessage iMail,
            IEmailDescritpion iEmailDescription,
            ISendingEmailTimeVerification iSendingEmail)
        {
            
            if (iEnd == null)
            {
                addExceptionToBase("constructor IDescriptionEndCreate = null", "SendingConfirmationRegistrationEmail");
                throw new NullReferenceException();
            }
            else
                this.iend = iEnd;

            if (iDataDescription == null)
            {
                addExceptionToBase("constructor IDataForDescription = null", "SendingConfirmationRegistrationEmail");
                throw new NullReferenceException();
            }
            else
                this.idataDescription = iDataDescription;

            if (iMail == null)
            {
                addExceptionToBase("constructor ICreatingMailMessage = null", "SendingConfirmationRegistrationEmail");
                throw new NullReferenceException();
            }
            else
                this.imail = iMail;

            if (iEmailDescription == null)
            {
                addExceptionToBase("constructor  IEmailDescritpion = null", "SendingConfirmationRegistrationEmail");
                throw new NullReferenceException();
            }
            else
                this.iemailDescription = iEmailDescription;

            if (iSendingEmail == null)
            {
                addExceptionToBase("constructor  ISendingEmailTimeVerification = null", "SendingConfirmationRegistrationEmail");
                throw new NullReferenceException();
            }
            else
                this.isendingEmail = iSendingEmail; 
        }

        public int sendWelcomeEmail(string imie, string nazwisko, string email)
        {
            int result = -1;
            try
            {
               string mail_description = iend.createDescription(idataDescription.get_DataFoDescritpion(imie, nazwisko, email));
                var confirmationDescription = iemailDescription.CreatEmailWithoutDescriptionAndRandomNumber(imie, nazwisko,
                    email, "Potwierdzenie Rejestracji X Maraton Rowerowy Mszana 2019", email);
                
                var info = imail.createResponse(confirmationDescription, mail_description);

                result = isendingEmail.sendEmailInsertTimeVerification(info, imie, nazwisko, email);
                return result;
            }
            catch (Exception ex)
            {
                addExceptionToBase(ex.Message + " " + email + " " + imie + " " + nazwisko , "sendWelcomeEmail");
                return result;
            }
        }
    }
}
