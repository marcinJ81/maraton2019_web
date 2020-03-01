using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowException.Interface
{
    public interface IUniqueException
    {
        string getUniqueException();
        string getUniqueException(string error);
        void setUniqueEcxeption(string localization, string description);
    }
}
