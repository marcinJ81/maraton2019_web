using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowException.Exceptions
{
    public class UniqueException : System.Exception,IUniqueException
    {
        private IExceptionBase _iException;

        public UniqueException(string message, IExceptionBase _iexcp)
            : base(message)
        {

            _iException = _iexcp;
        }

        public UniqueException(string message, Exception inner, IExceptionBase _iexcp)
            : base(message, inner)
        {
            _iException = _iexcp;
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

        public string getUniqueException()
        {
            if (this.InnerException.Message.Contains("UNIQUE KEY"))
            {
                return "Zawodnik o takich danych został już dodany do bazy";
            }
            {
                return this.Message;
            }
        }

        public void setUniqueEcxeption(string _local, string _descript)
        {
            _iException.addExceptionToBase(_descript, _local);
        }
    }
}
