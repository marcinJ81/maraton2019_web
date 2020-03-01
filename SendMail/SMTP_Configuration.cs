using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Text;
using ThrowException.Exceptions;

namespace SendMail
{
    public class SMTP_Configuration : ISMTP_Configuration
    {
       
        private NetworkCredential _credential;
       

        public SMTP_Configuration()
        {
            _credential = new NetworkCredential
            {
                UserName = "mszana2017@maraton24.hw7.pl",  // replace with valid value
                Password = "Test1234!"  // replace with valid value
            };
        }
    
        public string getSenderEmailAdress()
        {
            return _credential.UserName;
        }

        public int sendEmail(MailMessage _mail)
        {
            int result = 1;
            //try
            //{
            //    using (var smtp = new SmtpClient())
            //    {
            //        smtp.Credentials = _credential;
            //        smtp.Host = "poczta.dcsweb.pl";
            //        smtp.Port = 587;
            //        smtp.EnableSsl = false;
            //        smtp.Send(_mail);
            //        result = 1;
            //    }
            //}
            //catch (SmtpException ex)
            //{
            //    string er = ex.Message;
            //    ExceptionToBase _iexcp = new ExceptionToBase();
            //    _iexcp.addExceptionToBase(ex.Message, "sendmail");
            //    result = 0;
            //}
            return result;
        }
    }
}
