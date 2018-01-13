using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace stvsystem.UnitTests
{
    //[TestClass]
    //public class CredentialUnitTests : CredentialService
    //{
    //    [TestMethod]
    //    public void GenerateCredentialTest()
    //    {
    //        int credentialCount = 1000;
    //        Dictionary<string,string> test = this.GenerateCredentials(credentialCount);
    //        Assert.AreEqual(test.Count, credentialCount);
    //    }

    //    //[TestMethod]
    //    //public void GetCredentialTest()
    //    //{
    //    //    CredentialItem item = new CredentialItem
    //    //    {
    //    //        Password = "123456",
    //    //        SettingID = 1,
    //    //        CredentialStatus = CredentialStatus.NoSelection,
    //    //        UsageDateTime = Convert.ToDateTime("01/01/2018")
    //    //    };

    //    //    item = this.InsertCredential(item);

    //    //    CredentialItem result = this.GetCredential(item.CredentialID);

    //    //    Assert.AreEqual(result.Password, item.Password);
    //    //}

    //    //[TestMethod]
    //    //public void InsertCredentialTest()
    //    //{
    //    //    CredentialItem item = new CredentialItem
    //    //    {
    //    //        Password = "123456",
    //    //        SettingID = 1,
    //    //        CredentialStatus = CredentialStatus.NoSelection,
    //    //        UsageDateTime = Convert.ToDateTime("01/01/2018")
    //    //    };

    //    //    this.InsertCredential(item);

    //    //    Assert.AreNotEqual(item.CredentialID, 0);
    //    //}

    //    //[TestMethod]
    //    //public void GetCredentialStatisticsTest()
    //    //{
    //    //    var credentialStatisticsItem = new List<CredentialStatisticItem>();

    //    //    credentialStatisticsItem = GetCredentialStatistics();

    //    //    Assert.AreNotEqual(credentialStatisticsItem.Count, 0);
    //    //}

    //    //[TestMethod]
    //    //public void UpdateCredentialTest()
    //    //{
    //    //    CredentialItem item = new CredentialItem
    //    //    {
    //    //        Password = "123456",
    //    //        SettingID = 1,
    //    //        CredentialStatus = CredentialStatus.NoSelection,
    //    //        UsageDateTime = Convert.ToDateTime("01/01/2018")
    //    //    };

    //    //    item = this.InsertCredential(item);

    //    //    item.Password = "456789";

    //    //    CredentialItem updatedItem = this.UpdateCredential(item);

    //    //    Assert.AreEqual(updatedItem.Password, "456789");
    //    //}

    //    //[TestMethod]
    //    //public async Task DeleteCredentialTest()
    //    //{

    //    //    CredentialItem item = new CredentialItem
    //    //    {
    //    //        Password = "123456",
    //    //        SettingID = 1,
    //    //        CredentialStatus = CredentialStatus.NoSelection,
    //    //        UsageDateTime = Convert.ToDateTime("01/01/2018")
    //    //    };

    //    //    item = this.InsertCredential(item);

    //    //    int count1 = await this.Count();

    //    //    CredentialItem updatedItem = this.DeleteCredential(item);

    //    //    int count2 = await this.Count();

    //    //    Assert.AreNotEqual(count1, count2);
    //    //}
    //}
}
