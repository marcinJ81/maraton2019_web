using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;

namespace maratonMszana_v4.Controllers
{
    public class RegistrationListUserController : Controller
    {
        private readonly IOneFilter _ioneFilter;
        private readonly IregistrationList _registration;
        public RegistrationListUserController(IOneFilter ioneFilter, IregistrationList _registration)
        {
            this._ioneFilter = ioneFilter;
            this._registration = _registration;
        }

        [HttpGet]
        public ActionResult RegistrationList(string param1, string currentFilter_param1, int? page)
        {
            List<ExtModelRegistrationList> result = _registration.generateListZawodnik();
            if (param1 != null)
            {
                page = 1;
            }
            else
            {
                param1 = currentFilter_param1;
            }
            ViewBag.currentFilter_param1 = param1;
            _ioneFilter.filterSearchDataFromOneField(param1, ref result);
            ViewBag.licznik = result.Count.ToString();
            ViewBag.zmienne = param1 == null ? " " : param1;

            int pageSize = 30;
            int pageNumber = (page ?? 1);
            return View(result.ToPagedList(pageNumber, pageSize));
        }

    }
}
