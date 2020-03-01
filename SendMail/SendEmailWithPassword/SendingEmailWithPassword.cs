using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Mail_message_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SendMail.SendEmailWithPassword
{
    public class SendingEmailWithChangingPassword : ISendingEmailWithPassword
    {
        private readonly ICreatingMailMessage _icreateMailMessage;
        private readonly ISMTP_Configuration _iSmtpConfiguration;
        private readonly IRegisterUser _iregUser;
        private readonly IInfoAboutUser _infoAboutUser;
        private readonly IEmailDescritpion _ieEmailDescritpion;

        public SendingEmailWithChangingPassword(
            ICreatingMailMessage icreateMailMessage,
            ISMTP_Configuration iSmtpConfiguration,
            IRegisterUser iregUser,
            IInfoAboutUser infoAboutUser,
            IEmailDescritpion iEmailDescritpion)
        {
            _icreateMailMessage = icreateMailMessage;
            _iSmtpConfiguration = iSmtpConfiguration;
            _iregUser = iregUser;
            _infoAboutUser = infoAboutUser;
            _ieEmailDescritpion = iEmailDescritpion;
        }

        public bool sendEmailPasswordToExistUser(string emailUser)
        {
            var userTable = _infoAboutUser.GetInfoAboutUserForLogin(emailUser);
           var passwordDefault = _iregUser.changePass(userTable.pass_id == null ? 0 : int.Parse(userTable.pass_id.ToString()));
            var decsription = _ieEmailDescritpion.CreatEmailWithoutDescriptionAndRandomNumber(
                userTable.user_imie, userTable.user_nazwisko, emailUser, "Logowanie maraton", "mszana2017@maraton24.hw7.pl");

            var result = _icreateMailMessage.createResponse(decsription,
                "Nazwa użytkownika: " + emailUser + " i hasło:" + passwordDefault + " logowania do panelu administracyjnego.");

            _iSmtpConfiguration.sendEmail(result);
            return true;
        }
    }
}
