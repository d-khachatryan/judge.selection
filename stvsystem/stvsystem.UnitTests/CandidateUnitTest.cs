using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;

namespace stvsystem.UnitTests
{
    [TestClass]
    public class CandidateUnitTest
    {
        [TestMethod]
        public void InsertCandidateTest()
        {
            Candidate mock = new Candidate
            {
                CandidateID = 0,
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName"
            };
            CandidateService serviceMock = new CandidateService();
            serviceMock.InsertCandidate(mock);
            Assert.AreNotEqual(mock.CandidateID, 0);
        }
    }
}
