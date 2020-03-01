using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SendMail.SendEmailVerification
{
    public class SendingEmailTimeVerification : ISendingEmailTimeVerification
    {
        private readonly ISMTP_Configuration _ismtp;
        private readonly ICheckWerification _icheck;
        public SendingEmailTimeVerification(ISMTP_Configuration _ismtp, ICheckWerification _icheck)
        {
            this._ismtp = _ismtp;
            this._icheck = _icheck;
        }
        public int sendEmailInsertTimeVerification(MailMessage email, string imie, string nazwisko, string mail)
        {
            int result = -1;
            result =  _ismtp.sendEmail(email);
            _icheck.saveTimeWerification(new kartoteka_TMP
            {
                imie = imie,
                nazwisko = nazwisko,
                email = mail,
                dataRej = DateTime.Now
            });
            return result;
        }

        
    }
}
