using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Threading.Tasks;

namespace stvsystem.UnitTests
{
    [TestClass]
    public class CredentialUnitTests : CredentialService
    {
        [TestMethod]
        public void GetCredentialTest()
        {
            CredentialItem item = new CredentialItem
            {
                Password = "Password",
                SettingID = 1,
                CredentialStatus = 1,
                UsageDateTime = Convert.ToDateTime("01/01/2018")
            };

            item = this.InsertCredential(item);

            CredentialItem result = this.GetCredential(item.CredentialID);

            Assert.AreEqual(result.Password, item.Password);
        }

        [TestMethod]
        public void InsertCredentialTest()
        {
            CredentialItem item = new CredentialItem
            {
                Password = "Password",
                SettingID = 1,
                CredentialStatus = 1,
                UsageDateTime = Convert.ToDateTime("01/01/2018")
            };

            this.InsertCredential(item);

            Assert.AreNotEqual(item.CredentialID, 0);
        }

        [TestMethod]
        public void UpdateCredentialTest()
        {
            CredentialItem item = new CredentialItem
            {
                Password = "Password",
                SettingID = 1,
                CredentialStatus = 1,
                UsageDateTime = Convert.ToDateTime("01/01/2018")
            };

            item = this.InsertCredential(item);

            item.Password = "ChangedPassword";

            CredentialItem updatedItem = this.UpdateCredential(item);

            Assert.AreEqual(updatedItem.Password, "ChangedPassword");
        }

        [TestMethod]
        public async Task DeleteCredentialTest()
        {

            CredentialItem item = new CredentialItem
            {
                Password = "Password",
                SettingID = 1,
                CredentialStatus = 1,
                UsageDateTime = Convert.ToDateTime("01/01/2018")
            };

            item = this.InsertCredential(item);

            int count1 = await this.Count();

            CredentialItem updatedItem = this.DeleteCredential(item);

            int count2 = await this.Count();

            Assert.AreNotEqual(count1, count2);
        }
    }
}
