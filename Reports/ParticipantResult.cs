using Abstract_And_Model_Layer;
using Microsoft.Reporting.WebForms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Abstract_And_Model_Layer.Time_Tag_Participant;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace Reports
{
   
    public class ParticipantResult : IParticipantReport
    {
       
        public vResultList CertificateDataSource(IKartoteka2Info ikartotekaInfo, IParticipantResultList iresult, string name, string surname, string email)
        {
            var source = ikartotekaInfo.getInformationAboutOneParticipantFromKartoteka2(ikartotekaInfo, name, surname, email);
            var listOfResult = iresult.getResultList().Where(x => x.kart_id == source.kart_id).First();
            return listOfResult;
        }

        public byte[] CertificationReport(string email, out string mimeType)
        {
            ReportViewer reportViewer = new ReportViewer();

            string format = "PDF";
            //domyslnie format pdf

            var dbList = new List<ExtModelRegistrationList>(); //_regList.generateListZawodnik();

                reportViewer.ProcessingMode = ProcessingMode.Local;
                reportViewer.SizeToReportContent = true;
                reportViewer.LocalReport.ReportPath =   @"Reports\ParticipantResult.rdlc";
                reportViewer.LocalReport.DataSources.Add(new ReportDataSource("listaKartoteka", dbList));

              
                string encoding;
                string filenameExtension;
                string[] streams;
                Warning[] warnings;
                byte[] streamBytes;
                try
                {
                    streamBytes = reportViewer.LocalReport.Render(format, null, out mimeType, out encoding, out filenameExtension, out streams, out warnings);
                   
                }
                catch (Exception ex)
                {
                    string er = ex.InnerException.Message;
                    byte[] tabEmpty = new byte[1];
                    mimeType = "pusto";
                    return tabEmpty; 
                }      
            return streamBytes;

        }

        public byte[] GenerateCertificate(vResultList participantResult, out string mimeType)
        {

            ReportViewer reportViewer = new ReportViewer();

            string format = "PDF";
            //domyslnie format pdf

            List<vResultList> dbResult = new List<vResultList>();
            dbResult.Add(participantResult);
            

            reportViewer.ProcessingMode = ProcessingMode.Local;
            reportViewer.SizeToReportContent = true;
            reportViewer.LocalReport.ReportPath = @"Reports\ParticipantResult.rdlc";
            // reportViewer.LocalReport.ReportPath = @"~\ParticipantResult.rdlc";

            reportViewer.LocalReport.DataSources.Add(new ReportDataSource("listawynikow", dbResult));


            string encoding;
            string filenameExtension;
            string[] streams;
            Warning[] warnings;
            byte[] streamBytes;
            try
            {
                streamBytes = reportViewer.LocalReport.Render(format, null, out mimeType, out encoding, out filenameExtension, out streams, out warnings);

            }
            catch (Exception ex)
            {
                string er = ex.InnerException.Message;
                byte[] tabEmpty = new byte[1];
                mimeType = "pusto";
                return tabEmpty;
            }
            return streamBytes;
        }

       
    }
}
