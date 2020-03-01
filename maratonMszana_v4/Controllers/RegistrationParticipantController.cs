using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Marthon_Office_Model;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.Repositories.Filters;
using LibDatabase.verification;
using LibDatabase.zawodnik;
using MarthonOffice;
using ModelParticipants;
using Reports;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maratonMszana_v4.Controllers
{
    public class RegistrationParticipantController : Controller
    {
        private readonly IInfoAboutParticipant iinfoParticipant;
        private readonly IKartoteka2Info ikartoteka2;
        private readonly IDystans idystans;
        private readonly IOfficeEntities iOfficeEntities;
        private readonly IStoredProcedures istoredP;
        private readonly ISimpleAddingParticipant isimpleAdd;

        private readonly INewRecord inewRec;
        private readonly IAddZawodnik iaddZaw;
        private readonly IPlayerVerfication iplayer;

        private readonly ICheckWerification icheck;
        private readonly IParticipantReport ireport;
        private readonly IParticipantResultList iresultParticipant;
        public RegistrationParticipantController(
                IInfoAboutParticipant iinfoParticipant,
                IOfficeEntities iOfficeEntities,
                IStoredProcedures istoredP
                )
        {
            this.iinfoParticipant = iinfoParticipant;
            this.ikartoteka2 = new Kartoteka2Info();
            this.idystans = new DystansFiltr();
            this.iOfficeEntities = iOfficeEntities;
            this.istoredP = istoredP;

            this.icheck = new CheckWerification();
            this.inewRec = new NewRecord();
            this.iaddZaw = new AddZawodnik(icheck);
            this.iplayer = new PlayerVerification();
            this.isimpleAdd = new SimpleAddingParticipant(inewRec,iaddZaw,iplayer);
            this.ireport = new ParticipantResult();
            this.iresultParticipant = new ParticipantResultList();
        }

        [HttpGet]
        public ActionResult AddPArticipant()
        {
            ViewBag.dystans = new SelectList(idystans.filtrDystans(), "dys_id", "dys_wartosc");
            return View();
        }

        [HttpPost]
        public ActionResult AddPArticipant(kartoteka2 kartotekaModel, int dys_id)
        {
            if (isimpleAdd.AddNewParticipant(kartotekaModel.kart_imie, kartotekaModel.kart_nazwisko, kartotekaModel.kart_email, dys_id))
            {
                istoredP.pStartinPayment(kartotekaModel.kart_imie, kartotekaModel.kart_nazwisko, kartotekaModel.kart_email);
                istoredP.pInitializationAllParticipnat();
                return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = kartotekaModel.kart_nazwisko });
            }
            else
            {
                return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = "błąd dodawania" });
            }
        }
        [HttpGet]
        public ActionResult ParticipantRegister(int? kart_id)
        {
            if (kart_id != null && kart_id > 0)
            {
                int kartId = 0;
                int.TryParse(kart_id.ToString(), out kartId);
                var result = ikartoteka2.getOneParticipantById(ikartoteka2, kartId);

                ViewBag.dystans = new SelectList(idystans.filtrDystans(), "dys_id", "dys_wartosc");
                return View(result);
            }
            else
            {
                ViewBag.dystans = new SelectList(idystans.filtrDystans(), "dys_id", "dys_wartosc");
                return View();
            }
        }

        [HttpPost]
        public ActionResult ParticipantRegister(kartoteka2 kartotekaModel)
        {
            if (kartotekaModel != null)
            {
                var result = ikartoteka2.getInformationAboutOneParticipantFromKartoteka2(
                                        ikartoteka2,
                                        kartotekaModel.kart_imie,
                                        kartotekaModel.kart_nazwisko,
                                        kartotekaModel.kart_email);
                if (result.kart_wpis_oplata == false || result.kart_wpis_oplata == null)
                {
                    istoredP.pStartinPayment(kartotekaModel.kart_imie, kartotekaModel.kart_nazwisko, kartotekaModel.kart_email);
                    istoredP.pInitializationAllParticipnat();
                    return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = kartotekaModel.kart_nazwisko });
                }
                else
                {
                    return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = "" });
                }
            }
            else
            {
                return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = "" });
            }


        }
        public ActionResult ListOfRegistering(string surname)
        {
            var registerList = iinfoParticipant.getListOffAllParticipants(iOfficeEntities);
            if (!String.IsNullOrEmpty(surname))
            {
                registerList = registerList.Where(x => x.kart_nazwisko.Contains(surname.ToUpper())).ToList();
            }
            return View(registerList);  
        }

        [HttpGet]
        public ActionResult CertificateForParticipant(string name,string sname, string email)
        {
            var registerList = iinfoParticipant.getListOffAllParticipants(iOfficeEntities);
            int kart_id = registerList.Where(x => x.kart_imie == name && x.kart_nazwisko == sname && x.kart_email == email).FirstOrDefault().kart_id;

            if (!iresultParticipant.getResultList().Where(x => x.kart_nazwisko == "brak danych").Any())
            {
                var reportSource = iresultParticipant.getResultFotOneParticipant(kart_id, iresultParticipant);
                string mimeType = "";
                if (!(reportSource.kart_nazwisko == "brak danych"))
                {
                    string certificateName = "Certyfikat_" + reportSource.kart_imie + "_" + reportSource.kart_nazwisko+ ".pdf";
                    return File(ireport.GenerateCertificate(reportSource, out mimeType), mimeType, certificateName);
                }
                else
                    return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = "brak wyników " + name + " " + sname + " " + email });
            }
            else
            {
                return RedirectToAction("ListOfRegistering", "RegistrationParticipant", new { surname = "brak wyników " + name +" " + sname + " " + email });
            }
        }

    }
}
