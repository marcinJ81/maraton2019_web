using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maratonMszana_v4.Filters
{
    public class FiltersOperations : IFiltersOperations
    {
        private readonly ICheckValue _checkValue;
        private readonly IregistrationList _registration;
        public FiltersOperations(ICheckValue checkValue, IregistrationList iregistrationList)
        {
            this._checkValue = checkValue;
            this._registration = iregistrationList;
        }

        public List<ExtModelRegistrationList> getData(int? id_grupa, int? id_dys, int? oplata, string nazwisko)
        {
            List<ExtModelRegistrationList> result = _registration.generateListZawodnik();

            //page load 
            if (nazwisko == null || oplata == null || id_dys == null || id_grupa == null)
            {
                return result;
            }

            _checkValue.checkValueDystansRef(id_dys, ref result);
            _checkValue.checkValueGrupaRef(id_grupa, ref result);
            _checkValue.checkValueOplataRef(oplata, ref result);
            _checkValue.checkValueNazwsikoRef(nazwisko, ref result);

            _checkValue.checkValueFiltersRef(id_grupa, id_dys, oplata, nazwisko, ref result);

            return result;

        }


    }
}