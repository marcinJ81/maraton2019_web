using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Mail_message_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SendMail.UniversalMessage
{
    public class CreatingMailMessage : ICreatingMailMessage
    {
        private MailMessage message;

        public CreatingMailMessage()
        {
            message = new MailMessage();
        }

        public MailMessage createResponse(EmailDescription _email, string description)
        {
            var body = description;
            message.To.Add(new MailAddress(_email.recipient));
            message.From = new MailAddress(_email.sender);
            message.Subject = _email.subject;
            message.Body = string.Format(body, _email.name, _email.surname, _email.randomNumber);
            message.IsBodyHtml = true;
            return message;
        }

        public MailMessage createMessage(EmailDescription _email)
        {
            string tresc1 = "Wprowadz poniższy numer aby dokończyć rejestrację.";
            var body = "<p>Dane  podane przy rejestracji:<b> {0} {1}</b></p><p>" + tresc1 + "</p><p><b>{2}</b></p>";

            message.To.Add(new MailAddress(_email.recipient));
            message.From = new MailAddress(_email.sender);
            message.Subject = _email.subject;
            message.Body = string.Format(body, _email.name, _email.surname, _email.randomNumber);
            message.IsBodyHtml = true;
            return message;
        }


    }
}
