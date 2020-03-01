using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Time_Tag_Participant.viewResult
{

    public class vResultList
    {
        public int kart_id { get; set; }
        public int dys_id { get; set; }
        public int tag_id { get; set; }
        public string kart_nazwisko { get; set; }
        public int zaw_id { get; set; }
        public string kart_imie { get; set; }
        public string dys_wartosc { get; set; }
        public string dane { get; set; }
        public string suma_czas { get; set; }
        public int? sum_seconds { get; set; }
        public int rzeczywistaIloscOdbic { get; set; }
        public int? tag_LabelNumber { get; set; }
        public int? iloscOdbic { get; set; }
        public string realDistance { get; set; }
    }
}
