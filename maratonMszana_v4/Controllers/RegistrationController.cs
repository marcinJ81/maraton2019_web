using maratonMszana_v4.Filters;
using maratonMszana_v4.VerificationData;
using SendMail;
using SendMail.DescriptionEndMail;
using SendMail.DescriptionVerificationNumber;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ThrowException.Exceptions;
using maratonMszana_v4.OneFilter;
using PagedList;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using Abstract_And_Model_Layer;

namespace maratonMszana_v4.Controllers
{
    public class RegistrationController : Controller
    {
     
        private readonly ICreatingFilters _filters;
        private readonly IPlayerVerfication _iplayer;
        private readonly IGrupa _igrupa;

        public RegistrationController( ICreatingFilters _filters, IPlayerVerfication _iplayer, IGrupa igrupa)
        {
            this._filters = _filters;
            this._iplayer = _iplayer;
            this._igrupa = igrupa;
        }
        
        [HttpGet]
        public ActionResult Register(string komunikat)
        {
            ViewBag.grupa_id = _filters.filtry()[0];
            ViewBag.dys_id = _filters.filtry()[1];
            ViewBag.plec_id = _filters.filtry()[2];
            if (string.IsNullOrEmpty(komunikat))
            {
                ViewBag.Warning = "";
            }
            else
            {
                ViewBag.Warning = komunikat;
            }

            return View();
        }

       
        #region modalWindow

        [HttpGet]
        public PartialViewResult addGroup()
        {
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult info1(string messageWindow)
        {
            ViewBag.InfoMessage = messageWindow;
            return PartialView();
        }

        [HttpGet]
        public PartialViewResult info2(string messageWindow)
        {
            ViewBag.InfoMessage = messageWindow;
            return PartialView();
        }

       
        #endregion
        #region Post

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Register(kartoteka2 kartoteka)
        {     
                if (!ModelState.IsValid)
                {
                    return Register(kartoteka);
                }
                else
                {
                    if (_iplayer.searchPlayer(kartoteka))
                    {
                        return RedirectToAction("info1", new { messageWindow = "Taki zawodnik jest już zarejestrowany." });
                    }
                    else
                    {
                        Session["kartoteka"] = kartoteka;
                        return RedirectToAction("VerificationNumber", "VerificationEmail", new { visibleTrue = false });
                    }

                }
     }
        [HttpPost]
        public ActionResult addGroup(grupa_kolarska _grupa)
        {
            if (string.IsNullOrEmpty(_grupa.grupa_nazwa))
            {
                return addGroup();
            }
            else
            {

                _igrupa.addNewGrupa(_grupa);
                return RedirectToAction("Register");
                
            }
 
        }

        
        #endregion

    }
}
