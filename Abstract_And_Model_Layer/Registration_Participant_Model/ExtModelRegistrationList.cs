using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Registration_Participant_Model
{
    public class ExtModelRegistrationList
    {
        public string imie { get; set; }
        public string nazwisko { get; set; }
        public string dystans { get; set; }
        public string grupa { get; set; }
        public string rezerwa { get; set; }
        public string oplacony { get; set; }
        public bool? rejestracja { get; set; }
    }
}
