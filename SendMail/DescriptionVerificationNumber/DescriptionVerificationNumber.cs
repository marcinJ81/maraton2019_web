using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Mail_message_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SendMail.DescriptionVerificationNumber
{
    public class DescriptionVerificationNumber : IDescriptionVerificationNumber
    {
        private readonly ISMTP_Configuration _mailConfig;
        private readonly IEmailDescritpion _iemail;
        private readonly ICreatingMailMessage _icreatemail;

        public DescriptionVerificationNumber(ISMTP_Configuration _smtp, IEmailDescritpion iemail, ICreatingMailMessage icreatemail)
        {
            this._mailConfig = _smtp;
            this._iemail = iemail;
            this._icreatemail = icreatemail;
        }

        public MailMessage create_description(string imie, string nazwisko, string email, int _random)
        {
            var result = _iemail.CreatEmailWithoutDescriptionAndRandomNumber(
                imie,nazwisko,email, "Weryfikacja adresu Email - X Maraton Rowerowy Mszana 2019",email);

            result.randomNumber = _random;
          

            var messageMail = _icreatemail.createMessage(result);
           
            return messageMail;
        }
    }
}
