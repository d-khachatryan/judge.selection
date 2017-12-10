using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CredentialService : ServiceBase
    {
        public CredentialItem GetCredential(int credentialID)
        {
            Credential dbItem = db.Credentials.Find(credentialID);
            CredentialItem item = new CredentialItem
            {
                CredentialID = dbItem.CredentialID,
                Password = dbItem.Password,
                SettingID = dbItem.SettingID,
                CredentialStatus = dbItem.CredentialStatus,
                UsageDateTime = dbItem.UsageDateTime

            };
            return item;
        }
        public CredentialItem InsertCredential(CredentialItem item)
        {
            Credential dbItem = new Credential
            {
                Password = item.Password,
                SettingID = item.SettingID,
                CredentialStatus = item.CredentialStatus,
                UsageDateTime = item.UsageDateTime
            };
            db.Credentials.Add(dbItem);
            db.SaveChanges();
            item.CredentialID = dbItem.CredentialID;
            return item;
        }
        public CredentialItem UpdateCredential(CredentialItem item)
        {
            Credential dbItem = db.Credentials.Find(item.CredentialID);
            dbItem.CredentialID = item.CredentialID;
            dbItem.Password = item.Password;
            dbItem.SettingID = item.SettingID;
            dbItem.CredentialStatus = item.CredentialStatus;
            dbItem.UsageDateTime = item.UsageDateTime;
            db.Credentials.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }
        public CredentialItem DeleteCredential(CredentialItem item)
        {
            Credential dbItem = db.Credentials.Find(item.CredentialID);
            db.Credentials.Remove(dbItem);
            db.SaveChanges();
            return item;
        }
        protected async Task<int> Count()
        {
            var count = await db.Settings.CountAsync();
            return count;
        }
    }
}
