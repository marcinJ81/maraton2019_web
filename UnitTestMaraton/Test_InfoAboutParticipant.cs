using Abstract_And_Model_Layer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abstract_And_Model_Layer.Marthon_Office_Model;
using NUnit.Framework;
using MarthonOffice;
using System.Data;

namespace UnitTestMaraton
{
    public class Test_InfoAboutParticipant
    {
        private readonly IOfficeEntities iofficeEntities_Fake;
        private readonly IInfoAboutParticipant infoAboutParticipant;
        public Test_InfoAboutParticipant()
        {
            iofficeEntities_Fake = new Fake_IOfficeEntities();
            this.infoAboutParticipant = new InfoAboutParticipant();
        }

        [Test]
        public void Test_getListOffAllParticipants()
        {
            //arrange
            var result = infoAboutParticipant.getListOffAllParticipants(iofficeEntities_Fake);
            //act
            var target = iofficeEntities_Fake.FillData(iofficeEntities_Fake);
            //assert
            Assert.AreEqual(target.First().kart_email, result.First().kart_email);
            Assert.AreEqual(target.First().kart_nazwisko, result.First().kart_nazwisko);
            Assert.AreEqual(target.First().kart_nazwisko, result.First().kart_nazwisko);
        }


    }
    public class Fake_IOfficeEntities : IOfficeEntities
    {

        public List<vListParticipantsInOfficeRegisterCondition> FillData(IOfficeEntities ioffice)
        {
            List<vListParticipantsInOfficeRegisterCondition> result = new List<vListParticipantsInOfficeRegisterCondition>();
            result.Add(new vListParticipantsInOfficeRegisterCondition
            {
                kart_nazwisko = "test_nazwisko",
                kart_email = "test_email",
                kart_imie = "test_imie"
            });

            return result;
        }

        public DataTable getDataFromBase()
        {
            DataTable result = new DataTable();
            result.Clear();
            result.Columns.Add("kart_id");
            result.Columns.Add("kart_nazwisko");
            result.Columns.Add("kart_imie");
            result.Columns.Add("kart_email");
            DataRow dr = result.NewRow();
            dr["kart_id"] = 0;
            dr["kart_nazwisko"] = "test_nazwisko";
            dr["kart_imie"] = "test_imie";
            dr["kart_email"] = "test_email";
            result.Rows.Add(dr);

            return result;
        }
    }
}
