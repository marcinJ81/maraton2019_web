using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text.RegularExpressions;
using System.Web;

namespace maratonMszana_v4.VerificationData
{
    public class DataVerification :IDataVerification
    {
        public bool emailVerfication(string email)
        {
            try
            {
                if (email.Length > 0)
                {
                    MailAddress m = new MailAddress(email);
                    return true;
                }
                else
                {
                    return false;
                } 
            }
            catch (FormatException)
            {
                return false;
            }
        }

    }
}