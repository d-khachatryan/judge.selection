using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace stvsystem.Data
{
    public class CandidateService : ServiceBase
    {
        public CandidateService(StvContext db)
            : base(db)
        {

        }

        public List<SelectListItem> GetCandidateDropDownItems()
        {
            var candidateList = new List<CandidateItem>();
            var dropDownList = new List<SelectListItem>();

            foreach (var dbItem in db.Candidates)
            {
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
                candidateList.Add(item);
            }

            dropDownList = candidateList.Select(x => new SelectListItem { Text = x.CandidateName, Value = x.CandidateID.ToString() }).ToList();
            return dropDownList;
        }

        public List<SelectListItem> GetFilteredCandidateDropDownItems(int? courtID, string candidateName)
        {
            var candidateList = new List<CandidateItem>();
            var dropDownList = new List<SelectListItem>();

            var q = from p in db.Candidates select p;
            if (courtID!= null)
            {
                q = from p in q where p.CourtID == courtID select p;
            }
            if (!string.IsNullOrEmpty(candidateName))
            {
                q = from p in q where p.LastName.Contains(candidateName) select p;
            }

            foreach (var dbItem in q)
            {
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
                candidateList.Add(item);
            }

            dropDownList = candidateList.Select(x => new SelectListItem { Text = x.CandidateName, Value = x.CandidateID.ToString() }).ToList();
            return dropDownList;
        }


        public IList<CandidateItem> SearchCandidates(string firstName, string lastName)
        {
            IList<CandidateItem> result = (from candidate in db.Candidates
                                       join t1 in db.Specializations on candidate.SpecializationID equals t1.SpecializationID into r1
                                       from specialization in r1.DefaultIfEmpty()
                                       join t2 in db.Genders on candidate.GenderID equals t2.GenderID into r2
                                       from gender in r2.DefaultIfEmpty()
                                       join t3 in db.Courts on candidate.CourtID equals t3.CourtID into r3
                                       from court in r3.DefaultIfEmpty()
                                       select new
                                       {
                                           CandidateTable = candidate,
                                           GenderTable = gender,
                                           CourtTable = court,
                                           SpecializationTable = specialization
                                       }).Select(list => new CandidateItem
                                       {
                                           CandidateID = list.CandidateTable.CandidateID,
                                           FirstName = list.CandidateTable.FirstName,
                                           LastName = list.CandidateTable.LastName,
                                           MiddleName = list.CandidateTable.MiddleName,
                                           BirthDate = list.CandidateTable.BirthDate,
                                           CourtID = list.CandidateTable.CourtID,
                                           CourtName = list.CourtTable.CourtName,
                                           GenderID = list.CandidateTable.GenderID,
                                           GenderName = list.GenderTable.GenderName,
                                           SpecializationID = list.CandidateTable.SpecializationID,
                                           SpecializationName = list.SpecializationTable.SpecializationName
                                       }).ToList();

            if (!string.IsNullOrEmpty(firstName))
            {
                result = result.Where(p => p.FirstName.StartsWith(firstName, StringComparison.OrdinalIgnoreCase)).ToList();
            }
            if (!string.IsNullOrEmpty(lastName))
            {
                result = result.Where(p => p.LastName.StartsWith(lastName, StringComparison.OrdinalIgnoreCase)).ToList();
            }

            return result;

        }

       
        public CandidateItem GetCandidate(int? candidateID = null)
        {
            if (candidateID != null)
            {
                var dbItem = (from candidate in db.Candidates
                              join t1 in db.Specializations on candidate.SpecializationID equals t1.SpecializationID into r1
                              from specialization in r1.DefaultIfEmpty()
                              join t2 in db.Genders on candidate.GenderID equals t2.GenderID into r2
                              from gender in r2.DefaultIfEmpty()
                              join t3 in db.Courts on candidate.CourtID equals t3.CourtID into r3
                              from court in r3.DefaultIfEmpty()
                              where candidate.CandidateID == candidateID
                              select new { candidateTable = candidate, specializationTable = specialization, genderTable = gender, courtTable = court })
                             .Select(list => new CandidateItem
                             {
                                 CandidateID = list.candidateTable.CandidateID,
                                 FirstName = list.candidateTable.FirstName,
                                 LastName = list.candidateTable.LastName,
                                 MiddleName = list.candidateTable.MiddleName,
                                 BirthDate = list.candidateTable.BirthDate,
                                 CourtID = list.candidateTable.CourtID,
                                 CourtName = list.courtTable.CourtName,
                                 GenderID = list.candidateTable.GenderID,
                                 GenderName = list.genderTable.GenderName,
                                 SpecializationID = list.candidateTable.SpecializationID,
                                 SpecializationName = list.specializationTable.SpecializationName
                             }).First();


                CandidateItem item = new CandidateItem
                {
                    CandidateID = dbItem.CandidateID,
                    CourtID = dbItem.CourtID,
                    SpecializationID = dbItem.SpecializationID,
                    FirstName = dbItem.FirstName,
                    LastName = dbItem.LastName,
                    MiddleName = dbItem.MiddleName,
                    BirthDate = dbItem.BirthDate,
                    GenderID = dbItem.GenderID,
                    GenderName = dbItem.GenderName,
                    SpecializationName = dbItem.SpecializationName,
                    CourtName = dbItem.CourtName
                };
                return item;
            }
            else
            {
                var item = new CandidateItem();
                return item;
            }
        }

        public CandidateItem InsertCandidate(CandidateItem item)
        {
            Candidate dbItem = new Candidate
            {
                CourtID = item.CourtID,
                SpecializationID = item.SpecializationID,
                FirstName = item.FirstName,
                LastName = item.LastName,
                MiddleName = item.MiddleName,
                BirthDate = item.BirthDate,
                GenderID = item.GenderID
            };
            db.Candidates.Add(dbItem);
            db.SaveChanges();
            item.CandidateID = dbItem.CandidateID;
            return item;
        }
        public CandidateItem UpdateCandidate(CandidateItem item)
        {
            Candidate dbItem = db.Candidates.Find(item.CandidateID);
            dbItem.CandidateID = (int)item.CandidateID;
            dbItem.CourtID = item.CourtID;
            dbItem.SpecializationID = item.SpecializationID;
            dbItem.FirstName = item.FirstName;
            dbItem.LastName = item.LastName;
            dbItem.MiddleName = item.MiddleName;
            dbItem.BirthDate = item.BirthDate;
            dbItem.GenderID = item.GenderID;
            db.Candidates.Attach(dbItem);
            db.Entry(dbItem).State = EntityState.Modified;
            db.SaveChanges();
            return item;
        }


        public void DeleteCandidate(int id)
        {
            Candidate dbItem = db.Candidates.Find(id);
            db.Candidates.Remove(dbItem);
            db.SaveChanges();
            //return item;
        }
        public async Task<int> Count()
        {
            var count = await db.Candidates.CountAsync();
            return count;
        }
    }
}
