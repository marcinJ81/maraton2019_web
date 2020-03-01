using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity.Core.Objects;
using Abstract_And_Model_Layer.Registration_User_Model;
using Abstract_And_Model_Layer;

namespace DataBaseRegistration.RegisterFunctions
{
    public class RegisterUser : IRegisterUser
    {
        private IRegisterFunctions _ireg;
        public RegisterUser(IRegisterFunctions ireg)
        {
            _ireg = ireg;
        }
        public string changePass(int idPassTable)
        {
            string randomPass = _ireg.defaultPassGenerator(8);
            string hashRandomPass = _ireg.hashPassGenerator(randomPass);
            PasswordTable passTabel =  new PasswordTable(); 
 
            using (var db = new EntitiesRegistrationUser())
                    {
                        PasswordTable passT = db.PasswordTable.Single(x => x.pass_id == idPassTable);
                        passT.pass_haslo = hashRandomPass;
                        passT.pass_data = DateTime.Now;
                        db.SaveChanges();
                    }
                    return randomPass; 

        }
       
        public void connectPassworAndUser(UserTable uzytkownik, PasswordTable haslo)
        {
            throw new NotImplementedException();
        }

        public int createNewUzytkownik(UserTable uzytkownik)
        {
            string outpass = "";
            using (var db = new EntitiesRegistrationUser())
            {
                UserTable ut = new UserTable();
                ut.user_aktywny = uzytkownik.user_aktywny;
                ut.user_imie = uzytkownik.user_imie;
                ut.user_nazwisko = uzytkownik.user_nazwisko;
                ut.user_login = uzytkownik.user_login;
                ut.user_rejestracja = uzytkownik.user_rejestracja;
                ut.pass_id = generatePass(out outpass);
                db.UserTable.Add(ut);
                db.SaveChanges();
                return ut.usesr_id;
            }
        }

        public int generatePass(out string haslo)
        {
            using (var db = new EntitiesRegistrationUser())
            {
                string pass = _ireg.defaultPassGenerator(8);
                haslo = pass;
                string hashPass = _ireg.hashPassGenerator(pass);
                PasswordTable pt = new PasswordTable();
                pt.pass_aktywny = true;
                pt.pass_data = DateTime.Now;
                pt.pass_haslo = hashPass;
                db.PasswordTable.Add(pt);
                db.SaveChanges();
                return pt.pass_id;
            }
        }
    }
}
