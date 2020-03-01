using Abstract_And_Model_Layer;
using Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maratonMszana_v4.Controllers
{
    public class ReportController : Controller
    {
        private IParticipantReport iParticipantReport;

        public ReportController(IParticipantReport iParticipanResult)
        {
            iParticipantReport = iParticipanResult;
        }

        [HttpGet]
        public ActionResult ReportResult()
        {
            string email = "email";
            string mimeType = "";
            byte[] result = iParticipantReport.CertificationReport(email, out mimeType);
            return File(result, mimeType, "nazwa raportu");
        }

      
    }
}
