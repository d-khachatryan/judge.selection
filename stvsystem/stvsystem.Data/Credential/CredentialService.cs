﻿using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CredentialService : ServiceBase
    {
        public CredentialService(StvContext db)
            : base(db)
        {

        }
        public IList<CredentialItem> Search(string password, string idStr)
        {
            IList<CredentialItem> result = (from credential in db.Credentials

                                            select new
                                            {
                                                CredentialTable = credential
                                            }).Select(list => new CredentialItem
                                            {
                                                CredentialID = list.CredentialTable.CredentialID,
                                                Password = list.CredentialTable.Password,
                                                SettingID = list.CredentialTable.SettingID,
                                                CredentialStatus = list.CredentialTable.Status,
                                                UsageDateTime = list.CredentialTable.UsageDateTime
                                            }).ToList();

            if (!string.IsNullOrEmpty(password))
            {
                result = result.Where(p => p.Password.StartsWith(password, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(idStr))
            {
                int id = Convert.ToInt32(idStr);
                Credential credential = db.Credentials.Find(id);
                result = result.Where(p => p.CredentialID == credential.CredentialID).ToList();
            }
            return result;
        }

        public IList<CredentialItem> Details(string start, string end)
        {
            IList<CredentialItem> result = (from credential in db.Credentials

                                            select new
                                            {
                                                CredentialTable = credential
                                            }).Select(list => new CredentialItem
                                            {
                                                CredentialID = list.CredentialTable.CredentialID,
                                                Password = list.CredentialTable.Password,
                                                SettingID = list.CredentialTable.SettingID,
                                                CredentialStatus = list.CredentialTable.Status,
                                                UsageDateTime = list.CredentialTable.UsageDateTime
                                            }).ToList();
            if (!string.IsNullOrEmpty(start))
            {
                int startInt = Convert.ToInt32(start);
                result = result.Where(p => p.CredentialID >= startInt).ToList();
            }
            if (!string.IsNullOrEmpty(end))
            {
                int endInt = Convert.ToInt32(end);
                result = result.Where(p => p.CredentialID <= endInt).ToList();
            }
            return result;
        }

        public Dictionary<string, string> GenerateCredentials(int participantCount)
        {
            Dictionary<string, string> dictionaryList = new Dictionary<string, string>();
            const string pool = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            Random random = new Random();
            var builder = new StringBuilder();

            for (var i = 0; i < participantCount; i++)
            {
                string password = "";
                builder.Clear();
                for (var ii = 0; ii < 6; ii++)
                {
                    var c = pool[random.Next(0, pool.Length)];
                    builder.Append(c);
                }
                password = builder.ToString();
                try
                {
                    dictionaryList.Add(password, password);
                }
                catch
                {
                    i--;
                }
            }

            return dictionaryList;
        }

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
            Setting setting = db.Settings.Find(item.SettingID);
            Credential dbItem = new Credential
            {
                Password = item.Password,
                SettingID = item.SettingID,
                Status = item.CredentialStatus,
                UsageDateTime = item.UsageDateTime,
                Setting = setting

            };
            db.Credentials.Add(dbItem);
            db.SaveChanges();
            item.CredentialID = dbItem.CredentialID;
            return item;
        }

        public CredentialItem UpdateCredential(CredentialItem item)
        {
            Setting setting = db.Settings.Find(item.SettingID);
            Credential dbItem = db.Credentials.Find(item.CredentialID);
            dbItem.CredentialID = item.CredentialID;
            dbItem.Password = item.Password;
            dbItem.SettingID = item.SettingID;
            dbItem.Status = item.CredentialStatus;
            dbItem.UsageDateTime = item.UsageDateTime;
            dbItem.Setting = setting;
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
