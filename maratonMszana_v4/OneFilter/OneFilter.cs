using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Registration_Participant_Model;
using LibDatabase.TestingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace maratonMszana_v4.OneFilter
{
    public class OneFilter : IOneFilter
    {
       

        public void filterSearchDataFromOneField(string param1, ref List<ExtModelRegistrationList> result)
        {
            CreateDataToTestKartoteka test = new CreateDataToTestKartoteka();
            //test.addTestDataTokartoteka();

            if (!string.IsNullOrEmpty(param1))
            {
                using (var db = new EntitiesRegistrationParticipant())
                {
                    var oneColumn = result.Select(x => new
                    {
                        imie = x.imie,
                        nazwisko = x.nazwisko,
                        dane = x.imie.ToUpper() 
                        + " " + x.nazwisko.ToUpper() 
                        + " " + x.grupa.ToUpper() 
                        + " " + x.dystans.ToUpper() 
                        + " " + "rezerwa " 
                        + x.rezerwa.ToUpper() 
                        + " " + "opłacono " + x.oplacony.ToUpper()
                    }).ToList();

                    var tabParam = param1.ToUpper().Split(' ').ToList();
                    tabParam = tabParam.Where(x => !string.IsNullOrWhiteSpace(x)).Distinct().ToList();
                    oneColumn = oneColumn.Where(x => tabParam.Any(y => x.dane.Contains(y))).ToList();
                    result = result.Where(x => oneColumn.Any(y => y.imie.ToUpper() == x.imie.ToUpper() 
                    && y.nazwisko.ToUpper() == x.nazwisko.ToUpper())).ToList();
                }
            }
        }
    }
}