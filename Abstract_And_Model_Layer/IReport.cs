using Abstract_And_Model_Layer.Time_Tag_Participant;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    public interface IParticipantReport
    {
        byte[] CertificationReport(string email, out string mimeType);
        vResultList CertificateDataSource(IKartoteka2Info ikartotekaInfo, IParticipantResultList iresult, string name, string surname, string email);
        byte[] GenerateCertificate(vResultList participantResult, out string mimeType);
    }
}
