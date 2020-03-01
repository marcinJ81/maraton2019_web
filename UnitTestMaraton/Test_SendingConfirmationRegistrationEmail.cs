using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Abstract_And_Model_Layer;
using SendMail.SendConfirmRegistration;
using Abstract_And_Model_Layer.Mail_message_Model;
using System.Net.Mail;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace UnitTestMaraton
{
    /// <summary>
    /// Summary description for Test_SendingConfirmationRegistrationEmail
    /// </summary>
    [TestClass]
    public class Test_SendingConfirmationRegistrationEmail
    {
        [Test]
        public void UTest_sendWelcomeEmail_withAllParameters_result_zero()
        {
            //Arrange
            ISendingConfirmationRegistrationEmail isendingConfirm = new Test_SendingConfirmationRegistrationEmail2();

            //IDescriptionEndCreate idescEndCreate = new Test_DescriptionEndCreate();
            //IDataForDescription idataFroDesc = new Test_DataForDescrition();
            //ICreatingMailMessage icreatingMail = new Test_CreatingMailMessage();
            //IEmailDescritpion iemailDesc = new Test_EmailDescription();
            //ISendingEmailTimeVerification isendingEmail = new Test_SendingEmailTimeVerification();
            //ISMTP_Configuration ismtpConf = new Test_SMTP_Configuration();
            //ICheckWerification icheckWer = new Test_CheckWerification2();

            //ISendingConfirmationRegistrationEmail isendingConfirm = new SendingConfirmationRegistrationEmail(
            //    idescEndCreate,
            //    idataFroDesc,
            //    icreatingMail,
            //    iemailDesc,
            //    isendingEmail
            //    );
            //Act
           int result = isendingConfirm.sendWelcomeEmail("strus", "pedziwiater", "test@test.pl");
            //Assert
            NUnit.Framework.Assert.AreEqual(result, 0);
        }
    }
    #region Test Class from Class SendingConfirmationRegistrationEmail
    //add new instance off class inheritable about interface
    class Test_DescriptionEndCreate : IDescriptionEndCreate
    {
        public string createDescription(DescriptionEndMail _mail)
        {
            throw new NotImplementedException();
        }
    }
    class Test_DataForDescrition : IDataForDescription
    {
        public DescriptionEndMail get_DataFoDescritpion(string imie, string nazwisko, string email)
        {
            throw new NotImplementedException();
        }
    }
    class Test_CreatingMailMessage : ICreatingMailMessage
    {
        public MailMessage createMessage(EmailDescription _email)
        {
            throw new NotImplementedException();
        }

        public MailMessage createResponse(EmailDescription _email, string description)
        {
            throw new NotImplementedException();
        }
    }
    class Test_EmailDescription : IEmailDescritpion
    {
        public EmailDescription CreatEmailWithoutDescriptionAndRandomNumber(string name, string surname, string emailsA, string subject, string recipient)
        {
            throw new NotImplementedException();
        }
    }
    class Test_SendingEmailTimeVerification : ISendingEmailTimeVerification
    {
        public int sendEmailInsertTimeVerification(MailMessage email, string imie, string nazwisko, string mail)
        {
            throw new NotImplementedException();
        }
    }
    class Test_SendingConfirmationRegistrationEmail2 : ISendingConfirmationRegistrationEmail
    {
        public int sendWelcomeEmail(string imie, string nazwisko, string email)
        {
            return 0;
        }
    }
    #endregion
    #region Test Class from Class SendingEmailTimeVerification
    class Test_SMTP_Configuration : ISMTP_Configuration
    {
        public string getSenderEmailAdress()
        {
            throw new NotImplementedException();
        }

        public int sendEmail(MailMessage _mail)
        {
            throw new NotImplementedException();
        }
    }
    class Test_CheckWerification2 : ICheckWerification
    {
        public bool getTimeAndVerification(string imie, string naziwsko, string email)
        {
            throw new NotImplementedException();
        }

        public void saveTimeWerification(kartoteka_TMP _tmp)
        {
            throw new NotImplementedException();
        }
    }
    #endregion

}
