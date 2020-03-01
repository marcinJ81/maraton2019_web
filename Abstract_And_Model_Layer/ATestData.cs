using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface ICreateDataToTestKartoteka
    {
        string RandomStringSurnameDictionary(int lengthSName, string Sname);
        string RandomStringEmailDictionary(int lengthSName, string Sname);
        string RandomStringNameDictionary();
        void addTestDataTokartoteka();
    }
}
