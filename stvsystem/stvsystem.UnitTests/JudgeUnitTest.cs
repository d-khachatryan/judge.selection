using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Threading.Tasks;

namespace stvsystem.UnitTests
{
    [TestClass]
    public class JudgeUnitTest : JudgeService
    {
        [TestMethod]
        public void GetJudgeTest()
        {
            JudgeItem item = new JudgeItem
            {
                JudgeID = 0,
                CourtID = 1,
                SpecializationID = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName",
                GenderID = 1
            };

            item = this.InsertJudge(item);

            JudgeItem result = this.GetJudge(item.JudgeID);

            Assert.AreEqual(result.FirstName, item.FirstName);
        }

        [TestMethod]
        public void GetJudgesTest()
        {
            var list = this.SearchJudges();
            Assert.AreNotEqual(list.Count, 0);
        }

        [TestMethod]
        public void InsertJudgeTest()
        {
            JudgeItem item = new JudgeItem
            {
                JudgeID = 0,
                CourtID = 1,
                SpecializationID = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName",
                GenderID = 1

            };
            JudgeService serviceMock = new JudgeService();
            serviceMock.InsertJudge(item);
            Assert.AreNotEqual(item.JudgeID, 0);
        }

        [TestMethod]
        public void UpdateJudgeTest()
        {
            JudgeItem item = new JudgeItem
            {
                JudgeID = 0,
                CourtID = 1,
                SpecializationID = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName",
                GenderID = 1
            };

            item = this.InsertJudge(item);

            item.FirstName = "OtherFirstName";

            JudgeItem updatedItem = this.UpdateJudge(item);

            Assert.AreEqual(updatedItem.FirstName, "OtherFirstName");
        }

        [TestMethod]
        public async Task DeleteJudgeTest()
        {

            JudgeItem item = new JudgeItem
            {
                JudgeID = 0,
                CourtID = 1,
                SpecializationID = 1,
                FirstName = "FirstName",
                LastName = "LastName",
                MiddleName = "MiddleName",
                GenderID = 1
            };

            item = this.InsertJudge(item);

            int count1 = await this.Count();

            int judgeID = Convert.ToInt32(item.JudgeID);
            this.DeleteJudge(judgeID);

            int count2 = await this.Count();

            Assert.AreNotEqual(count1, count2);
        }
    }
}
