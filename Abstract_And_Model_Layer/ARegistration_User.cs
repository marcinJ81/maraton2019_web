using Abstract_And_Model_Layer.Registration_User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IInfoAboutUser
    {
        UserTable GetInfoAboutUserForLogin(string loginUser);
        UserTable getIdFromUser(int idPassTable);
        PasswordTable getIdPassTable(int idUserTable);
    }
    public interface IRegisterFunctions
    {
        string defaultPassGenerator(int maxCoont);
        string hashPassGenerator(string tekst);
    }
    public interface IRegisterUser
    {
        int createNewUzytkownik(UserTable uzytkownik);
        string changePass(int idPass);
        int generatePass(out string haslo);
        void connectPassworAndUser(UserTable uzytkownik, PasswordTable haslo);

    }
}
