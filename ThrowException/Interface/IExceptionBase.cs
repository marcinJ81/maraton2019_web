using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ThrowException.Interface
{
    public interface IExceptionBase
    {
        void addExceptionToBase(string description, string localization);
    }
}
