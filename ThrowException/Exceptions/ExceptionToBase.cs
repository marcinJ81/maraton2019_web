using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace ThrowException.Exceptions
{
    public class ExceptionToBase : IExceptionBase
    {
        public void addExceptionToBase(string description, string localization)
        {
            using (var db = new EntitiesRegistrationParticipant())
            {
                Exception_Table _table = new Exception_Table();
                _table.er_description = description;
                _table.er_name = localization;
                _table.er_Date = DateTime.Now;
                db.Exception_Table.Add(_table);
                db.SaveChanges();
            }
        }
    }
}
