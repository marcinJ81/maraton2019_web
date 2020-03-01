using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NUnit.Framework;
using Abstract_And_Model_Layer;
using Abstract_And_Model_Layer.Time_Tag_Participant;
using ModelParticipants;
using System.Linq;
using Moq;

namespace UnitTestMaraton
{
    /// <summary>
    /// Summary description for UnitTest_ParticipantResult
    /// </summary>
    [TestClass]
    public class UnitTest_ParticipantResult
    {
        private IParticipantResultList iparticipantResult { get; set; }
        private IParticipantResultList iparticipantResult_Test { get; set; }
        public UnitTest_ParticipantResult()
        {
            this.iparticipantResult = new ParticipantResultList();
            this.iparticipantResult_Test = new Test_ParticipantResultList();
        }
        [Test]
        public void Test_getResultListByDystans_returnSingleRow_byParam()
        {
            //arrange
            var result = iparticipantResult.getResultListByDane("test", iparticipantResult_Test);
            //act
            var target = iparticipantResult_Test.getResultList();
            //assert
            NUnit.Framework.Assert.AreEqual(result.First().kart_id, target.First ().kart_id);
            
        }

        [Test]
        public void Test_getResultListByDystans_returnEmptyRow_byWrongParam()
        {
            //arrange
            var result = iparticipantResult.getResultListByDane("pusto", iparticipantResult_Test);
            //act
            var target = iparticipantResult_Test.emptyResult();
            //assert
            NUnit.Framework.Assert.AreEqual(result.First().kart_id, target.First().kart_id);
            NUnit.Framework.Assert.AreEqual(result.First().dys_id, target.First().dys_id);
            NUnit.Framework.Assert.AreEqual(result.First().dane, target.First().dane);

        }

    }
    public class Test_ParticipantResultList : IParticipantResultList
    {
        public List<vResultList> getResultList()
        {
            List<vResultList> result = new List<vResultList>() {
                new vResultList
                {
                    kart_id = 1,
                    dys_id = 1,
                    zaw_id = 1,
                    tag_id = 1,
                    dane = "test"
                },
                 new vResultList
                {
                    kart_id = 1001,
                    dys_id = 2,
                    zaw_id = 2,
                    tag_id = 2,
                    dane = "test_raportu"

                }
            };
            return result;
           
        }
        
        public List<vResultList> getResultListByDane(string dane, IParticipantResultList iparticipantResult)
        {
            return null;
        }

        public List<vResultList> emptyResult()
        {
            List<vResultList> result = new List<vResultList>() {
                new vResultList
                {
                    kart_id = 0,
                    dys_id = 0,
                    zaw_id = 0,
                    tag_id = 0,
                    kart_nazwisko = "brak danych",
                    kart_imie = "brak danych",
                    dane = "brak danych"
                }};
            return result;
        }

        public List<vResultList> getResultListByDystans(int dys_id, IParticipantResultList iparticipantResult)
        {
            throw new NotImplementedException();
        }

        public List<vResultList> getResultListByDaneAndList(string dane, List<vResultList> participantResults)
        {
            throw new NotImplementedException();
        }

        public List<vResultList> setOrderResultLIst(List<vResultList> participantResults)
        {
            throw new NotImplementedException();
        }

        public vResultList getResultFotOneParticipant(int kart_id, IParticipantResultList iparticipantResult)
        {
            throw new NotImplementedException();
        }
    }
}
