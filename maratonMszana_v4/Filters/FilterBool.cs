using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace maratonMszana_v4.Filters
{
    public class FilterBool : IFilterBool
    {
        public Dictionary<int,string> filterOplacony()
        {
            Dictionary<int, string> result = new Dictionary<int, string>();
            result.Add(0, "Wybierz");
            result.Add(1, "Tak");
            result.Add(2, "Nie");
            return result;
        }
    }
}