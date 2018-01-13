using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Threading.Tasks;

namespace stvsystem.UnitTests
{
    //[TestClass]
    //public class CandidateUnitTest : CandidateService
    //{
    //    [TestMethod]
    //    public void GetCandidateTest()
    //    {
    //        CandidateItem item = new CandidateItem
    //        {
    //            CandidateID = 0,
    //            CourtID = 1,
    //            SpecializationID = 1,
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            MiddleName = "MiddleName",
    //            GenderID = 1,
    //            BirthDate = Convert.ToDateTime("01/01/2015")
    //        };

    //        item = this.InsertCandidate(item);

    //        CandidateItem result = this.GetCandidate(item.CandidateID);

    //        Assert.AreEqual(result.FirstName, item.FirstName);
    //    }

    //    [TestMethod]
    //    public void GetCandidatesTest()
    //    {
    //        CandidateItem item = new CandidateItem
    //        {
    //            CandidateID = 0,
    //            CourtID = 1,
    //            SpecializationID = 1,
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            MiddleName = "MiddleName",
    //            GenderID = 1
    //        };

    //        item = this.InsertCandidate(item);

    //        var list = this.SearchCandidates("FirstName", "LastName");
    //        Assert.AreNotEqual(list.Count, 0);
    //    }

    //    [TestMethod]
    //    public void InsertCandidateTest()
    //    {
    //        CandidateItem item = new CandidateItem
    //        {
    //            CandidateID = 0,
    //            CourtID = 1,
    //            SpecializationID = 1,
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            MiddleName = "MiddleName",
    //            GenderID = 1,
    //            BirthDate = Convert.ToDateTime("01/01/2015")
    //        };
    //        CandidateService serviceMock = new CandidateService();
    //        serviceMock.InsertCandidate(item);
    //        Assert.AreNotEqual(item.CandidateID, 0);
    //    }

    //    [TestMethod]
    //    public void UpdateCandidateTest()
    //    {
    //        CandidateItem item = new CandidateItem
    //        {
    //            CandidateID = 0,
    //            CourtID = 1,
    //            SpecializationID = 1,
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            MiddleName = "MiddleName",
    //            GenderID = 1,
    //            BirthDate = Convert.ToDateTime("01/01/2015")
    //        };

    //        item = this.InsertCandidate(item);

    //        item.FirstName = "OtherFirstName";

    //        CandidateItem updatedItem = this.UpdateCandidate(item);

    //        Assert.AreEqual(updatedItem.FirstName, "OtherFirstName");
    //    }

    //    [TestMethod]
    //    public async Task DeleteCandidateTest()
    //    {

    //        CandidateItem item = new CandidateItem
    //        {
    //            CandidateID = 0,
    //            CourtID = 1,
    //            SpecializationID = 1,
    //            FirstName = "FirstName",
    //            LastName = "LastName",
    //            MiddleName = "MiddleName",
    //            GenderID = 1,
    //            BirthDate = Convert.ToDateTime("01/01/2015")
    //        };

    //        item = this.InsertCandidate(item);

    //        int count1 = await this.Count();

    //        int candidateID = Convert.ToInt32(item.CandidateID );
    //        this.DeleteCandidate(candidateID);


    //        int count2 = await this.Count();

    //        Assert.AreNotEqual(count1, count2);
    //    }
    //}
}
