using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowException.Exceptions
{
    public class UniqueException2 : IUniqueException
    {
        private IExceptionBase _iException;

        public UniqueException2(IExceptionBase _iexcp)
        {
            _iException = _iexcp;
        }

        public string getUniqueException()
        {
            throw new NotImplementedException();
        }

        public string getUniqueException(string error)
        {
            if (error.Contains("UNIQUE KEY"))
            {
                return "Zawodnik o takich danych został już dodany do bazy";
            }
            {
                return error;
            }
           
        }

        public void setUniqueEcxeption(string localization, string description)
        {
            _iException.addExceptionToBase(description, localization);
        }
    }
}
