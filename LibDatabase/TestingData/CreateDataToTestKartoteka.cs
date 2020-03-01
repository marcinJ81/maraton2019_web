using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LibDatabase.TestingData
{
    public class CreateDataToTestKartoteka : ICreateDataToTestKartoteka
    {
        public string RandomStringNameDictionary()
        {
            Random random = new Random();
            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(1, "Marcin");
            lista.Add(2, "Grzegorz");
            lista.Add(3, "Zbgniew");
            lista.Add(4, "Mateusz");
            lista.Add(5, "Monika");
            lista.Add(6, "Magda");
            lista.Add(7, "Sylwester");
            lista.Add(8, "Michał");
            lista.Add(9, "Tomasz");
            lista.Add(10, "Sylwia");
            lista.Add(11, "Irena");
            lista.Add(12, "Antoni");
            lista.Add(13, "Marysia");
            lista.Add(14, "Jan");
            int key = random.Next(1, 13);

            string sname = lista.Where(x => x.Key == key).FirstOrDefault().Value;
            if (string.IsNullOrEmpty(sname))
            {
                RandomStringNameDictionary();
                return sname;
            }
            else
            {
                return sname;
            }
        }

        public string RandomStringSurnameDictionary(int lengthSName, string Sname)
        {

            Random random = new Random();
            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(1, "ma");
            lista.Add(2, "sza");
            lista.Add(3, "ko");
            lista.Add(4, "wa");
            lista.Add(5, "pie");
            lista.Add(6, "ra");
            lista.Add(7, "ka");
            lista.Add(8, "ju");
            lista.Add(9, "nek");
            lista.Add(10, "po");
            lista.Add(11, "go");
            lista.Add(12, "tka");
            lista.Add(13, "ra");
            lista.Add(14, "ka");
            lista.Add(15, "og");
            lista.Add(16, "ba");
            lista.Add(17, "la");
            lista.Add(18, "fior");
            lista.Add(19, "bu");
            lista.Add(20, "łka");
            lista.Add(21, "gem");
            lista.Add(22, "on");
            
            int key = random.Next(1, 21);
            System.Threading.Thread.Sleep(100);
            if (Sname.Length >= lengthSName)
            {
                return Sname;
            }
            else
            {
                Sname += lista.Where(x => x.Key == key).FirstOrDefault().Value;
                return RandomStringSurnameDictionary(lengthSName, Sname);
            }
        }

        public string RandomStringEmailDictionary(int lengthSName, string Sname)
        {
            Random random = new Random();
            Dictionary<int, string> lista = new Dictionary<int, string>();
            lista.Add(1, "ma");
            lista.Add(2, "sza");
            lista.Add(3, "ko");
            lista.Add(4, "wa");
            lista.Add(5, "pie");
            lista.Add(6, "ra");
            lista.Add(7, "ka");
            lista.Add(8, "ju");
            lista.Add(9, "nek");
            lista.Add(10, "po");
            lista.Add(11, "go");
            lista.Add(12, "tka");
            lista.Add(13, "ra");
            lista.Add(14, "ka");
            int key = random.Next(1, 13);
            System.Threading.Thread.Sleep(250);
            if (Sname.Length >= lengthSName)
            {
                Sname += "@.hw7.pl";
                return Sname;
            }
            else
            {
                Sname += lista.Where(x => x.Key == key).FirstOrDefault().Value;
                return RandomStringEmailDictionary(lengthSName, Sname);
            }
        }

        public void addTestDataTokartoteka()
        {
            try
            {
                using (var db = new EntitiesRegistrationParticipant())
                {
                    Random _gr = new Random();
                    Random _ds = new Random();


                    kartoteka2 test1 = new kartoteka2();
                    for (int i = 0; i < 30; i++)
                    {
                        test1.grup_id = _gr.Next(1, 3);
                        test1.kart_imie = RandomStringNameDictionary();
                        test1.kart_nazwisko = RandomStringSurnameDictionary(6, "");
                        test1.kart_email = RandomStringEmailDictionary(6, "");
                        test1.dys_id = _ds.Next(1, 7);
                        test1.plec_id = 1;
                        test1.kart_dataUr = DateTime.Parse("1981-09-01");
                        test1.kart_telefon = "123456789";
                        test1.kart_uwagi = "test";
                        test1.kart_dataRej = DateTime.Now;
                        test1.kart_wpis_rejestacja = true;
                        test1.kart_wpis_oplata = false;
                        test1.kart_wpis_rezerwowa = true;
                        db.kartoteka2.Add(test1);
                        db.SaveChanges();
                    }
                }
            }
            catch (Exception ex)
            {
                string er = ex.InnerException.Message;
            }
        }
    }
}
