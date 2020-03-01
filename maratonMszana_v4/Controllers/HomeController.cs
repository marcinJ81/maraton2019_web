using ModelParticipants;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace maratonMszana_v4.Controllers
{
    public class HomeController : Controller
    {
        //
        // GET: /Home/
        private IZawodnikInfo _izawodnik;

        public HomeController(IZawodnikInfo izawodnik)
        {
            _izawodnik = izawodnik;
        }

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Kontakt()
        {
            return View();
        }

        public ActionResult Zawodnik()
        {
            ViewBag.Test = _izawodnik.getNameOfParticipant(1);

            return View();
        }
    }
}
