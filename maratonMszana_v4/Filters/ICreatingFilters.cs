using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace maratonMszana_v4.Filters
{
    public interface ICreatingFilters
    {
        List<SelectList> filtry();
    }
}
