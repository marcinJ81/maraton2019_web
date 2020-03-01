using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.verification
{
    public class RandomNumbers : IRandomNumber
    {
        public int generateNumber()
        {
            Random _random = new Random();
            int _value = _random.Next(1001, 9999);
            return _value;
        }
    }
}
