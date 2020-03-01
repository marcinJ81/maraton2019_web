using Abstract_And_Model_Layer;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Time_Tag_Participant;
using ModelParticipants;
using Reports;

namespace UnitTestMaraton
{
    public class Test_Report
    {
        private IParticipantReport iParticipantReportTrue;
        private IParticipantReport iParticipantReportFake;
        private IKartoteka2Info iKartoteka2InfoFake;
        private IParticipantResultList iParticipantResultListFake;

        public Test_Report()
        {
            this.iKartoteka2InfoFake = new Fake_kartoteka2Info();
            this.iParticipantReportFake = new Fake_ParticipanReport();
            this.iParticipantReportTrue = new ParticipantResult();
            this.iParticipantResultListFake = new Test_ParticipantResultList();
        }
        [Test]
        public void Test_CertificateDataSource_returnResultForSpecificParticipant()
        {
            //arrange
            var result = iParticipantReportTrue.CertificateDataSource(iKartoteka2InfoFake, iParticipantResultListFake, "test_imie", "test_nazwisko", "test@test.pl");
            //act
            var target = iParticipantResultListFake.getResultList().Where( x => x.dane == "test_raportu").First();
            //assert
            Assert.AreEqual(target.kart_id, result.kart_id);
        }
        [Test]
        public void Test_GenerateCertificate_returnDefaultResult()
        {
            //arrange
            //tego se neda w ten sposob
            //act

            //assert
        }

    }

    public class Fake_ParticipanReport : IParticipantReport
    {
        public vResultList CertificateDataSource(IKartoteka2Info ikartotekaInfo, IParticipantResultList iresult, string name, string surname, string email)
        {
            throw new NotImplementedException();
        }

        public byte[] CertificationReport(string email, out string mimeType)
        {
            throw new NotImplementedException();
        }

        public byte[] GenerateCertificate(vResultList participantResult, out string mimeType)
        {
            throw new NotImplementedException();
        }
    }

}
