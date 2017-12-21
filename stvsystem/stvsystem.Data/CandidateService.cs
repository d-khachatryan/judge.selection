using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace stvsystem.Data
{
    public class CandidateService : ServiceBase
    {
        public CandidateItem GetCandidate(int CandidateID)
        {
            Candidate dbItem = db.Candidates.Find(CandidateID);
            CandidateItem item = new CandidateItem
            {
                CandidateID = dbItem.CandidateID,
                CourtID = dbItem.CourtID,
                SpecializationID = dbItem.SpecializationID,
                FirstName = dbItem.FirstName,
                LastName = dbItem.LastName,
                MiddleName = dbItem.MiddleName,
                GenderID = dbItem.GenderID,
                BirthDate = dbItem.BirthDate
            };
            return item;
        }
        public CandidateItem InsertCandidate(CandidateItem item)
        {
            Candidate dbItem = new Candidate
            {
                CandidateID = item.CandidateID,
                CourtID = item.CourtID,
                SpecializationID = item.SpecializationID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                GenderID = item.GenderID,
                BirthDate = item.BirthDate
            };
            db.Candidates.Add(dbItem);
            db.SaveChanges();
            item.CandidateID = dbItem.CandidateID;
            return item;
        }
        public CandidateItem UpdateCandidate(CandidateItem item)
        {
            Candidate dbItem = db.Candidates.Find(item.CandidateID);
            dbItem.CandidateID = item.CandidateID;
            dbItem.CourtID = item.CourtID;
            dbItem.SpecializationID = item.SpecializationID;
            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;
            dbItem.MiddleName = item.MiddleName;
            dbItem.GenderID = item.GenderID;
            dbItem.BirthDate = item.BirthDate;
            db.Candidates.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }
        public CandidateItem DeleteCandidate(CandidateItem item)
        {
            Candidate dbItem = db.Candidates.Find(item.CandidateID);
            db.Candidates.Remove(dbItem);
            db.SaveChanges();
            return item;
        }
        protected async Task<int> Count()
        {
            var count = await db.Candidates.CountAsync();
            return count;
        }
    }
}
