using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class SettingService : ServiceBase
    {
        public SettingService(StvContext db)
            : base(db)
        {

        }

        public async Task<SettingItem> GetLatestSetting()
        {
            if (await Count() > 0)
            {
                Setting dbItem = await db.Settings.LastAsync();
                SettingItem item = new SettingItem
                {
                    SettingID = dbItem.SettingID,
                    SelectionName = dbItem.SelectionName,
                    SelectionDate = dbItem.SelectionDate,
                    StartTime = dbItem.StartTime,
                    FinishTime = dbItem.FinishTime,
                    SelectionCount = dbItem.SelectionCount,
                    ParticipantCount = dbItem.ParticipantCount,
                    SelectionStatus = dbItem.SelectionStatus
                };
                return item;
            }
            else
            {
                SettingItem item = new SettingItem
                {
                    SettingID = -1,
                    SelectionStatus = SettingStatus.InPreparation
                };
                return item;
            }
        }
        public SettingItem GetSetting(int settingID)
        {
            Setting dbItem = db.Settings.Find(settingID);
            SettingItem item = new SettingItem
            {
                SettingID = dbItem.SettingID,
                SelectionName = dbItem.SelectionName,
                SelectionDate = dbItem.SelectionDate,
                StartTime = dbItem.StartTime,
                FinishTime = dbItem.FinishTime,
                SelectionCount = dbItem.SelectionCount,
                ParticipantCount = dbItem.ParticipantCount,
                SelectionStatus = dbItem.SelectionStatus
            };
            return item;
        }
        public SettingItem InsertSetting(SettingItem item)
        {
            bool deleteResult = DeleteSettings();
            if (deleteResult)
            {
                Setting dbItem = new Setting
                {
                    SelectionName = item.SelectionName,
                    SelectionDate = item.SelectionDate,
                    StartTime = item.StartTime,
                    FinishTime = item.FinishTime,
                    SelectionCount = item.SelectionCount,
                    ParticipantCount = item.ParticipantCount,
                    SelectionStatus = SettingStatus.InPreparation
                };
                db.Settings.RemoveRange(db.Settings);
                db.Settings.Add(dbItem);

                CredentialService credentialService = new CredentialService(db);
                var dictionary = credentialService.GenerateCredentials((int)item.ParticipantCount);
                for (var i = 0; i < item.ParticipantCount; i++)
                {
                    Credential credential = new Credential
                    {
                        SettingID = item.SettingID,
                        Password = dictionary.ElementAt(i).Key,
                        Status = CredentialStatus.NoSelection,
                        Setting = dbItem
                    };
                    db.Credentials.Add(credential);
                }
                db.SaveChanges();
                item.SettingID = dbItem.SettingID;
                return item;
            }
            else
            {
                return null;
            }
        }

        public SettingItem UpdateSetting(SettingItem item)
        {
            Setting dbItem = db.Settings.Find(item.SettingID);
            dbItem.SettingID = item.SettingID;
            dbItem.SelectionName = item.SelectionName;
            dbItem.SelectionDate = item.SelectionDate;
            dbItem.StartTime = item.StartTime;
            dbItem.FinishTime = item.FinishTime;
            dbItem.SelectionCount = item.SelectionCount;
            dbItem.ParticipantCount = item.ParticipantCount;
            dbItem.SelectionStatus = item.SelectionStatus;
            db.Settings.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }

        public bool DeleteSettings()
        {
            var settingSet = db.Settings;
            foreach (Setting setting in settingSet.ToList())
            {

                IQueryable<Credential> credentailSet = db.Credentials.Where(p => p.SettingID == setting.SettingID);
                foreach (Credential credentialItem in credentailSet.ToList())
                {
                    IQueryable<Result> resultSet = db.Results.Where(p => p.CredentialID == credentialItem.CredentialID);
                    db.Results.RemoveRange(resultSet);
                }
                db.Credentials.RemoveRange(credentailSet);
                db.Settings.Remove(setting);
                db.SaveChanges();
            }
            return true;
        }

        public SettingItem DeleteSetting(SettingItem settingItem)
        {
            IQueryable<Credential> credentailSet = db.Credentials.Where(p => p.SettingID == settingItem.SettingID);
            foreach (Credential credentialItem in credentailSet.ToList())
            {
                IQueryable<Result> resultSet = db.Results.Where(p => p.CredentialID == credentialItem.CredentialID);
                db.Results.RemoveRange(resultSet);
            }
            db.Credentials.RemoveRange(credentailSet);
            Setting setting = db.Settings.Find(settingItem.SettingID);
            db.Settings.Remove(setting);
            db.SaveChanges();
            return settingItem;
        }
        public SettingItem StartSelection(SettingItem item)
        {
            Setting dbItem = db.Settings.Find(item.SettingID);
            dbItem.SelectionStatus = SettingStatus.InProcess;
            db.Settings.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }
        public async Task<bool> FinishSelection()
        {
            try
            {
                Setting dbItem = await db.Settings.LastAsync();
                dbItem.SelectionStatus = SettingStatus.Finished;
                db.Settings.Attach(dbItem);
                db.Entry(dbItem).State = EntityState.Modified;
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        protected async Task<int> Count()
        {
            var count = await db.Settings.CountAsync();
            return count;
        }
    }
}
