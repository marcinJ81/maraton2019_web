
using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_User_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace DataBaseRegistration.RegisterFunctions
{
    public class InfoAboutUser : IInfoAboutUser
    {
        public UserTable getIdFromUser(int idPassTable)
        {
            using (var db = new EntitiesRegistrationUser())
            {
                var userTable = db.UserTable.SingleOrDefault(x => x.pass_id == idPassTable);
                return userTable;
            }
        }
        public PasswordTable getIdPassTable(int idUserTable)
        {
            using (var db = new EntitiesRegistrationUser())
            {
                int idPass = db.UserTable.Where(x => x.usesr_id == idUserTable).FirstOrDefault().pass_id == null ? 0
                    : int.Parse(db.UserTable.Where(x => x.usesr_id == idUserTable).FirstOrDefault().pass_id.ToString());
                var result = db.PasswordTable.Single(x => x.pass_id == idPass);
                return result;
            }
        }

        public UserTable GetInfoAboutUserForLogin(string loginUser)
        {
            using (var db = new EntitiesRegistrationUser())
            {
                var userTable = db.UserTable.SingleOrDefault(x => x.user_login == loginUser);
                return userTable;
            }
        }
    }
}
