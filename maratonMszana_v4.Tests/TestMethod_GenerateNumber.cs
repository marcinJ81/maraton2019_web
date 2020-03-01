using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace maratonMszana_v4.Tests
{
    class TestMethod_GenerateNumber
    {
        public int generateNumber(int number)
        {
            if (number > 1000 && number < 99999)
            {
                return number;
            }
            else
            {
                return 0;
            }
        }
    }
}
