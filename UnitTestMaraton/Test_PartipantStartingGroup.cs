using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Time_Tag_Participant;
using ModelParticipants;
using System.Linq;


namespace UnitTestMaraton
{
    /// <summary>
    /// Summary description for Test_PartipantStartingGroup
    /// </summary>
    [TestClass]
    public class Test_PartipantStartingGroup
    {
        private readonly IParticipantStartingGroup iFakeparticipant;
        private readonly IParticipantStartingGroup iTrueparticipant;
        public Test_PartipantStartingGroup()
        {
            this.iFakeparticipant = new Fake_ParticipantStartingGroup();
            this.iTrueparticipant = new ParticipantStartingGroup();
        }
        [Test]
        public void Test_getSpecificLists_byNameParticipant_returnRoswByList_id()
        {
            //arrange
            var result = iTrueparticipant.getSpecificList("marcin", iFakeparticipant);
            //act
            var target = iFakeparticipant.getAllList();
            //assert
            try
            {
                NUnit.Framework.Assert.Greater(result.Count, 1);
            }
            catch (AssertionException aex)
            {
                string err = aex.Message;
            }
        }

        [Test]
        public void Test_getSpecificList_byWrongNameParticipant_returnOneDefaultRow()
        {
            //arrange
            var result = iTrueparticipant.getSpecificList("nima", iFakeparticipant);
            //act
            var target = iFakeparticipant.getEmptyRow();
            //assert
            try
            {
                NUnit.Framework.Assert.AreEqual(result.First().kart_nazwisko, target.First().kart_nazwisko);
            }
            catch (AssertionException aex)
            {
                string err = aex.Message;
            }
        }
    }

    public class Fake_ParticipantStartingGroup : IParticipantStartingGroup
    {
        public List<VStartingLists> getAllList()
        {
            List<VStartingLists> result = new List<VStartingLists>() { new VStartingLists
            {
                Id = 1,
                kart_nazwisko = "test",
                kart_imie = "test",
                list_nazwa = "100 km",
                list_id = 5,
                dys_wartosc = "100 km"
            },
            new VStartingLists
            {
                Id = 1,
                kart_nazwisko = "marcin",
                kart_imie = "wiocha",
                list_nazwa = "100 km",
                list_id = 5,
                dys_wartosc = "100 km"
            },
            new VStartingLists
            {
                Id = 2,
                kart_nazwisko = "radosław",
                kart_imie = "świnski",
                list_nazwa = "400 km",
                list_id = 4,
                dys_wartosc = "400 km"
            },
            new VStartingLists
            {
                Id = 2,
                kart_nazwisko = "mieczysław",
                kart_imie = "rębajło",
                list_nazwa = "100 km",
                list_id = 5,
                dys_wartosc = "100 km"
            },
            new VStartingLists
            {
                Id = 3,
                kart_nazwisko = "marcin",
                kart_imie = "wiocha",
                list_nazwa = "700 km",
                list_id = 7,
                dys_wartosc = "700 km"
            }
            };
            return result;
        }

        public List<VStartingLists> getEmptyRow()
        {
            List<VStartingLists> result = new List<VStartingLists>() { new VStartingLists
            {
                Id = 0,
                kart_nazwisko = "brak danych",
                kart_imie = "brak danych",
                dys_wartosc = "brak danych",
                list_nazwa = "brak danych"
            }};
            return result;
        }

        public List<VStartingLists> getSpecificList(string nazwisko, IParticipantStartingGroup istartingGroup)
        {
            throw new NotImplementedException();
        }
    }
}
