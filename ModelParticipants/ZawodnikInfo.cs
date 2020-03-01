using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ModelParticipants
{
    public interface IZawodnikInfo
    {
        string getNameOfParticipant(int id);
    }
    public class ZawodnikInfo : IZawodnikInfo
    {
        public string getNameOfParticipant(int id)
        {
            return "zawodnik dane";
        }
    }
}
