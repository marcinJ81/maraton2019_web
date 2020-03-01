using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IExceptionBase
    {
        void addExceptionToBase(string description, string localization);
    }
    public interface IUniqueException
    {
        string getUniqueException();
        string getUniqueException(string error);
        void setUniqueEcxeption(string localization, string description);
    }
}
