using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Abstract_And_Model_Layer
{
    //ICreatingFilters -> zwraca SelectList na razie brak koncepcji na to
    public interface ICheckValue
    {
        void checkValueFiltersRef(int? id_grupa, int? id_dys, int? oplata, string nazwisko, ref List<ExtModelRegistrationList> lista);
        void checkValueDystansRef(int? id_dys, ref List<ExtModelRegistrationList> result);
        void checkValueGrupaRef(int? id_grupa, ref List<ExtModelRegistrationList> result);
        void checkValueOplataRef(int? oplata, ref List<ExtModelRegistrationList> result);
        void checkValueNazwsikoRef(string nazwisko, ref List<ExtModelRegistrationList> result);
    }
    public interface IFilterBool
    {
        Dictionary<int, string> filterOplacony();
    }
    public interface IFiltersOperations
    {
        List<ExtModelRegistrationList> getData(int? id_grupa, int? id_dys, int? oplata, string nazwisko);

    }
    public interface IOneFilter
    {
        void filterSearchDataFromOneField(string param1, ref List<ExtModelRegistrationList> result);
    }
}
