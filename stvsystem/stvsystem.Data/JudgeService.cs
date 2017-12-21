using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class JudgeService : ServiceBase
    {
        public JudgeItem GetJudge(int judgeID)
        {
            Judge dbItem = db.Judges.Find(judgeID);
            JudgeItem item = new JudgeItem
            {
                JudgeID = dbItem.JudgeID,
                CourtID = dbItem.CourtID,
                SpecializationID = dbItem.SpecializationID,
                FirstName = dbItem.FirstName,
                LastName = dbItem.LastName,
                MiddleName = dbItem.MiddleName,
                GenderID= dbItem.GenderID
            };
            return item;
        }
        public JudgeItem InsertJudge(JudgeItem item)
        {
            Judge dbItem = new Judge
            {
                JudgeID = item.JudgeID,
                CourtID = item.CourtID,
                SpecializationID = item.SpecializationID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                GenderID = item.GenderID
            };
            db.Judges.Add(dbItem);
            db.SaveChanges();
            item.JudgeID = dbItem.JudgeID;
            return item;
        }
        public JudgeItem UpdateJudge(JudgeItem item)
        {
            Judge dbItem = db.Judges.Find(item.JudgeID);
            dbItem.JudgeID = item.JudgeID;
            dbItem.CourtID = item.CourtID;
            dbItem.SpecializationID = item.SpecializationID;
            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;
            dbItem.MiddleName = item.MiddleName;
            dbItem.GenderID = item.GenderID;
            db.Judges.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }
        public JudgeItem DeleteJudge(JudgeItem item)
        {
            Judge dbItem = db.Judges.Find(item.JudgeID);
            db.Judges.Remove(dbItem);
            db.SaveChanges();
            return item;
        }
        protected async Task<int> Count()
        {
            var count = await db.Judges.CountAsync();
            return count;
        }
    }
}
