using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseRegistration.Registration
{
    public class RegisterFunctions : IRegisterFunctions
    {
        public string defaultPassGenerator(int countMax)
        {
            return PasswordGenerator.GetUniqueKey(8);
        }

        public string hashPassGenerator(string tekst)
        {
            return PasswordGenerator.Md5Hash(tekst);
        }
    }
}
