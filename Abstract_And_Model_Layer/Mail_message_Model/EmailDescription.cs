using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer.Mail_message_Model
{
    public class EmailDescription
    {
        public string name { get; set; }
        public string surname { get; set; }
        public string email_adress { get; set; }
        public int randomNumber { get; set; }
        public string emailDescription { get; set; }
        public string sender { get; set; }      //nadawca
        public string subject { get; set; }     //temat
        public string recipient { get; set; }   //adresat
    }
}
