using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistration.RegisterFunction
{
    public interface IRegisterFunctions
    {
        bool loginUser(string login, string pass);
        bool createUser(string login, string pass);
    }
}
