using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;

namespace SendMail.SendEmailVerification
{
    public class SendingVerifyingEmail : ISendingVerifyingEmail
    {
        private readonly IRandomNumber _irandom;
        private readonly IDescriptionVerificationNumber _idesc;
        private readonly ISendingEmailTimeVerification _isendingMeailAndCheck;

        public SendingVerifyingEmail(IRandomNumber _irandom, IDescriptionVerificationNumber _desc, ISendingEmailTimeVerification _isending)
        {
            this._irandom = _irandom;
            this._idesc = _desc;
            this._isendingMeailAndCheck = _isending;
        }
        public int sendEmailToVerification(string email, string nazwisko, string imie)
        {

            if (email.Length > 0)
            {
                try
                {
                    MailAddress m = new MailAddress(email);

                }catch(FormatException)
                {
                    return 0;
                }
                
                int _random = _irandom.generateNumber();
                var _mail = _idesc.create_description(imie, nazwisko, email, _random);
                _isendingMeailAndCheck.sendEmailInsertTimeVerification(_mail, imie, nazwisko, email);
                return _random;
            }
            else
                return 0;
        }

    }
}
