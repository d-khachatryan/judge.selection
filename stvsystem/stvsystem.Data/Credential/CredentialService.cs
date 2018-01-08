using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CredentialService : ServiceBase
    {
        public int? GetSettingIDByPassword(string password)
        {
            var result = db.Credentials.Where(p => p.Password == password);
            if (result.Count() == 1)
            {
                return result.First().SettingID;
            }
            else
            {
                return null;
            }
        }

        public int? GetCredentialIDByPassword(string password)
        {
            var result = db.Credentials.Where(p => p.Password == password);
            if (result.Count() == 1)
            {
                return result.First().CredentialID;
            }
            else
            {
                return null;
            }
        }

        public CredentialItem GetCredential(int credentialID)
        {
            Credential dbItem = db.Credentials.Find(credentialID);
            CredentialItem item = new CredentialItem
            {
                CredentialID = dbItem.CredentialID,
                Password = dbItem.Password,
                SettingID = dbItem.SettingID,
                CredentialStatus = dbItem.Status,
                UsageDateTime = dbItem.UsageDateTime

            };
            return item;
        }

        public List<CredentialStatisticItem> GetCredentialStatistics()
        {
            var credentialStatisticsItem = new List<CredentialStatisticItem>();

            credentialStatisticsItem = (from c in db.Credentials
                                        group c by c.Status into g
                                        select new CredentialStatisticItem
                                        {
                                            Status = g.Key,                                            
                                            StatusCount = g.Count(),
                                        }).ToList();

            return credentialStatisticsItem;
        }

        public CredentialItem InsertCredential(CredentialItem item)
        {
            Credential dbItem = new Credential
            {
                Password = item.Password,
                SettingID = item.SettingID,
                Status = item.CredentialStatus,
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
            dbItem.Status = item.CredentialStatus;
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
            var count = await db.Credentials.CountAsync();
            return count;
        }
    }
}
