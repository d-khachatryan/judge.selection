﻿using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class SettingService : ServiceBase
    {
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
            Setting dbItem = new Setting
            {
                SelectionName = item.SelectionName,
                SelectionDate = item.SelectionDate,
                StartTime = item.StartTime,
                FinishTime = item.FinishTime,
                SelectionCount = item.SelectionCount,
                ParticipantCount = item.ParticipantCount,
                SelectionStatus = SelectionStatusType.InPreparation
            };
            db.Settings.Add(dbItem);
            db.SaveChanges();
            item.SettingID = dbItem.SettingID;
            return item;
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
        public SettingItem DeleteSetting(SettingItem item)
        {
            Setting dbItem = db.Settings.Find(item.SettingID);
            db.Settings.Remove(dbItem);
            db.SaveChanges();
            return item;
        }
        public SettingItem StartSelection(SettingItem item)
        {
            Setting dbItem = db.Settings.Find(item.SettingID);
            dbItem.SelectionStatus = SelectionStatusType.InProcess;
            db.Settings.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }
        public SettingItem FinishSelection(SettingItem item)
        {
            Setting dbItem = db.Settings.Find(item.SettingID);
            dbItem.SelectionStatus = SelectionStatusType.Finished;
            db.Settings.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
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