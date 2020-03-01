using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using maratonMszana_v4.Filters;
using Abstract_And_Model_Layer.Time_Tag_Participant;

namespace maratonMszana_v4.Controllers
{
    public class ParticipantController : Controller
    {
        private readonly IParticipantResultList iparticipanResult;
        private readonly ICreatingFilters ifilters;
        private readonly IParticipantStartingGroup istartGroup;
        private readonly IInfoAboutParticipant infoAboutParticipant;

        public ParticipantController(
            IParticipantResultList _iparticipanResult, 
            ICreatingFilters _filters,
            IParticipantStartingGroup _istartGroup,
            IInfoAboutParticipant infoAboutParticipant)
        {
            this.iparticipanResult = _iparticipanResult;
            this.ifilters = _filters;
            this.istartGroup = _istartGroup;
            this.infoAboutParticipant = infoAboutParticipant;
        }

        [HttpGet]
        public ActionResult ResultsList(string dane, int? dys_id)
        {
            ViewBag.dys_id = ifilters.filtry()[1];
            List<vResultList> result = new List<vResultList>();
            result = iparticipanResult.getResultList();
            if ( dys_id > 0)
            {
                int id_dys = dys_id == null ? 0 : int.Parse(dys_id.ToString());
                result = iparticipanResult.getResultListByDystans(id_dys, iparticipanResult);
                result = iparticipanResult.setOrderResultLIst(result);
            }
            if (!String.IsNullOrEmpty(dane))
            {
                result = result.Where(x => x.dane.ToUpper().Contains(dane.ToUpper())).ToList();
                result = iparticipanResult.setOrderResultLIst(result);
            }
            return View(result);
        }
    
        [HttpGet]
        public ActionResult StartingList(string nazwisko)
        {
            List<VStartingLists> result = new List<VStartingLists>();
            if (String.IsNullOrEmpty(nazwisko))
            {
                result = istartGroup.getAllList();
            }
            else
            {
                 result = istartGroup.getSpecificList(nazwisko, istartGroup);
            }
            return View(result);
        }


    }
}
