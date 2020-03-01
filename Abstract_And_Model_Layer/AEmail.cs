using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Mail_message_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    
    public interface IDataForDescription
    {
        DescriptionEndMail get_DataFoDescritpion(string imie, string nazwisko, string email);
    }
    public interface IDescriptionEndCreate
    {
        string createDescription(Abstract_And_Model_Layer.Mail_message_Model.DescriptionEndMail _mail);
    }
    public interface IDescriptionVerificationNumber
    {
        MailMessage create_description(string imie, string nazwisko, string email, int _random);
    }
    public interface ISendingConfirmationRegistrationEmail
    {
       int sendWelcomeEmail(string imie, string nazwisko, string email);
    }
    public interface ISendingEmailTimeVerification
    {
        int sendEmailInsertTimeVerification(MailMessage email, string imie, string nazwisko, string mail);
    }
    public interface ISendingVerifyingEmail
    {
        int sendEmailToVerification(string email, string nazwisko, string imie);
    }
    public interface ISendingEmailWithPassword
    {
        bool sendEmailPasswordToExistUser(string email);
    }
    public interface ICreatingMailMessage
    {
        MailMessage createResponse(EmailDescription _email, string description);
        MailMessage createMessage(EmailDescription _email);
    }
    public interface ISMTP_Configuration
    {
        string getSenderEmailAdress();
        int sendEmail(MailMessage _mail);
    }
    public interface IEmailDescritpion
    {
        EmailDescription CreatEmailWithoutDescriptionAndRandomNumber(string name, string surname,
            string emailsA, string subject, string recipient);
    }
}
