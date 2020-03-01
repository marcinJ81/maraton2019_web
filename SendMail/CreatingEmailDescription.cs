using Abstract_And_Model_Layer;
using SendMail;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Mail_message_Model;

namespace SendMail
{
    public class CreatingEmailDescription : IEmailDescritpion
    {
        EmailDescription IEmailDescritpion.CreatEmailWithoutDescriptionAndRandomNumber(string name, string surname, string emailsA, string subject, string recipient)
        {
            EmailDescription result = new EmailDescription();//(_iSmtpConfiguration); ->stara wersja
            result.name = name;
            result.surname = surname;
            result.email_adress = emailsA;
            result.subject = subject;
            result.recipient = recipient;
            result.sender = "mszana2017@maraton24.hw7.pl"; //<-mot good idea
            return result;
        }
    }
}
