using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maratonMszana_v4.Filters
{
    public class CreatingFilters : ICreatingFilters
    {
        private readonly IDystans _iDystans;
        private readonly IGrupa _iGrupa;
        private readonly IPlec _iPlec;
        public CreatingFilters(IDystans _iDystans, IGrupa _iGrupa, IPlec _iPlec)
        {
            this._iDystans = _iDystans;
            this._iGrupa = _iGrupa;
            this._iPlec = _iPlec;
        }

        public List<SelectList> filtry()
        {
            try
            {
                List<SelectList> result = new List<SelectList>();
                using (var db = new EntitiesRegistrationParticipant())
                {
                    result.Add(new SelectList(_iGrupa.filtrGrupa(), "grupa_id", "grupa_nazwa"));
                    result.Add(new SelectList(_iDystans.filtrDystans(), "dys_id", "dys_wartosc"));
                    result.Add(new SelectList(_iPlec.filtrPlec(), "plec_id", "plec_opis"));
                }
                return result;
            }
            catch (Exception ex)
            {
                string blad = ex.InnerException.Message;
                return null;
            }
        }

       
    }
}