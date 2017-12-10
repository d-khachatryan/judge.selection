using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Threading.Tasks;

namespace stvsystem.UnitTests
{
    [TestClass]
    public class SettingUnitTests : SettingService
    {
        [TestMethod]
        public void GetSettingTest()
        {
            SettingItem item = new SettingItem
            {
                SelectionName = "SettingName",
                SelectionDate = Convert.ToDateTime("01/01/2018"),
                StartTime = TimeSpan.Parse("07:35"),
                FinishTime = TimeSpan.Parse("07:35"),
                SelectionCount = 5,
                ParticipantCount = 100,
                SelectionStatus = SelectionStatusType.InPreparation
            };

            item = this.InsertSetting(item);

            SettingItem result = this.GetSetting(item.SettingID);

            Assert.AreEqual(result.SelectionName, item.SelectionName);
        }

        [TestMethod]
        public void InsertSettingTest()
        {
            SettingItem item = new SettingItem
            {
                SelectionName = "SettingName",
                SelectionDate = Convert.ToDateTime("01/01/2018"),
                StartTime = TimeSpan.Parse("07:35"),
                FinishTime = TimeSpan.Parse("07:35"),
                SelectionCount = 5,
                ParticipantCount = 100,
                SelectionStatus = SelectionStatusType.InPreparation
            };

            this.InsertSetting(item);

            Assert.AreNotEqual(item.SettingID, 0);
        }

        [TestMethod]
        public void UpdateSettingTest()
        {
            SettingItem item = new SettingItem
            {
                SelectionName = "SettingName",
                SelectionDate = Convert.ToDateTime("01/01/2018"),
                StartTime = TimeSpan.Parse("07:35"),
                FinishTime = TimeSpan.Parse("07:35"),
                SelectionCount = 5,
                ParticipantCount = 100,
                SelectionStatus = SelectionStatusType.InPreparation
            };

            item = this.InsertSetting(item);

            item.SelectionName = "ChangedSettingName";

            SettingItem updatedItem = this.UpdateSetting(item);

            Assert.AreEqual(updatedItem.SelectionName, "ChangedSettingName");
        }

        [TestMethod]
        public async Task DeleteSettingTest()
        {

            SettingItem item = new SettingItem
            {
                SelectionName = "SettingName",
                SelectionDate = Convert.ToDateTime("01/01/2018"),
                StartTime = TimeSpan.Parse("07:35"),
                FinishTime = TimeSpan.Parse("07:35"),
                SelectionCount = 5,
                ParticipantCount = 100,
                SelectionStatus = SelectionStatusType.InPreparation
            };

            item = this.InsertSetting(item);

            int count1 = await this.Count();

            SettingItem updatedItem = this.DeleteSetting(item);

            int count2 = await this.Count();

            Assert.AreNotEqual(count1, count2);
        }
    }
}
