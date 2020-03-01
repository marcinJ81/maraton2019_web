using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abstract_And_Model_Layer.Mail_message_Model;

namespace SendMail.DescriptionEndMail
{
    public class DescriptionEndCreate : IDescriptionEndCreate
    {
        public string createDescription(Abstract_And_Model_Layer.Mail_message_Model.DescriptionEndMail _mail)
        {
            string record1 = "<html><body>";
            string record2 = "<h2>Dziękujemy za rejestrację</h2>";
            string record3 = "<h3> X Edycja Slaskiego Maratonu Rowerowego 2019 </h3>";
            string record4 = @"<table rules = &#34;all&#34; style = &#34;border -color: #667; &#34; cellpadding = &#34; 10 &#34;> ";
            string record5 = " <tr style = 'background: #eee;' > ";
            string record6 = "<td style='padding: 5px 25px 5px 5px;'><strong> Imię Nazwisko </strong></td>";
            string record7 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.name + "</td> </tr>";
            string record8 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Email</strong></td>";
            string record9 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.email + "</td></tr>";
            string record10 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Dystans</strong></td>";
            string record11 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.dystansW + "</td></tr>";
            string record12 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Grupa Kolarska</strong></td>";
            string record13 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.grupaK + "</td></tr>";
            string record14 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Start</strong></td>";
            string record15 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.startZ + "</td></tr>";
            string record16 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Opłata</strong></td>";
            string record17 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.oplataZ + "</td></tr>";
            string record18 = "<tr> <td style='padding: 5px 25px 5px 5px;'><strong>Strona</strong></td>";
            string record19 = "<td style='padding: 5px 25px 5px 5px;'>" + _mail.strona + "</td>";
            string record20 = "</tr></table></body></html>";

            string result = record1 + record2 + record3 + record4 + record5 + record6 + record7 + record8 + record9 + record10
                            + record11 + record12 + record13 + record14 + record15 + record16 + record17 + record18 + record19 + record20;
            return result;
        }
    }
}
