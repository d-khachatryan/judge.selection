using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace stvsystem.Data
{
    public class SelectionService : ServiceBase
    {
        public SelectionService(StvContext db)
            : base(db)
        {

        }

        public PasswordStatus ValidatePassword(PasswordItem item)
        {
            var result = db.Credentials.Where(p => p.Password == item.Password);
            if (result.Count() > 0)
            {
                if (result.First().Status == CredentialStatus.NoSelection)
                {
                    return PasswordStatus.Success;
                }
                else
                {
                    return PasswordStatus.DoubleLogin;
                }
            }
            else
            {
                return PasswordStatus.Fail;
            }
        }

        public List<SelectionConfirmationItem> GetSelectionConfirmationItems(int credentialID)
        {
            List<SelectionConfirmationItem> list = new List<SelectionConfirmationItem>();

            var result = db.Results.Where(p => p.CredentialID == credentialID);

            foreach (Result resultItem in result)
            {
                var candidate = db.Candidates.Find(resultItem.CandidateID);
                SelectionConfirmationItem item = new SelectionConfirmationItem
                {
                    CandidateID = resultItem.CandidateID,
                    CandidateIndex = resultItem.CandidateIndex,
                    CredentialID = resultItem.CredentialID,
                    FirstName = candidate.FirstName,
                    LastName = candidate.LastName,
                    MiddleName = candidate.MiddleName
                };
                list.Add(item);
            }

            return list;
        }

        public bool SaveSelectionItem(SelectionItem item)
        {
            try
            {
                Result dbItem = new Result
                {
                    CandidateID = (int)item.CandidateID,
                    CandidateIndex = (int)item.CandidateIndex,
                    CredentialID = (int)item.CredentialID,
                    Status = ResultStatus.Temp
                };
                db.Results.Add(dbItem);
                db.SaveChanges();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool CancelSelections(int credentialID)
        {
            try
            {
                var result = db.Results.Where(p => p.CredentialID == credentialID);

                if (result.Count() > 0)
                {
                    foreach (Result item in result)
                    {
                        db.Results.Remove(item);
                    };

                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public bool SaveSelections(int credentialID)
        {
            try
            {
                var result = db.Results.Where(p => p.CredentialID == credentialID);

                if (result.Count() > 0)
                {
                    foreach (Result item in result)
                    {
                        item.Status = ResultStatus.Permanent;
                        db.Results.Attach(item);
                        db.Entry(item).State = EntityState.Modified;
                    };

                    Credential dbItem = db.Credentials.Find(credentialID);
                    dbItem.Status = CredentialStatus.Done;
                    db.Credentials.Attach(dbItem);
                    db.Entry(dbItem).State = EntityState.Modified;

                    db.SaveChanges();
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        
        public IList<SummaryItem> GetResults()
        {
            IList<SummaryItem> result = (from summary in db.Summaries
                                         join t1 in db.Candidates on summary.CandidateID equals t1.CandidateID into r1
                                         from candidate in r1.DefaultIfEmpty()
                                         select new
                                         {
                                             SummaryTable = summary,
                                             CandidateTable = candidate
                                         }).Select(list => new SummaryItem
                                         {
                                             CandidateID = list.SummaryTable.CandidateID,
                                             FirstName = list.CandidateTable.FirstName,
                                             MiddleName = list.CandidateTable.MiddleName,
                                             LastName = list.CandidateTable.LastName,
                                             N1 = list.SummaryTable.N1,
                                             N2 = list.SummaryTable.N2,
                                             N3 = list.SummaryTable.N3,
                                             N4 = list.SummaryTable.N4,
                                             N5 = list.SummaryTable.N5,
                                             N6 = list.SummaryTable.N6,
                                             N7 = list.SummaryTable.N7,
                                             N8 = list.SummaryTable.N8,
                                             N9 = list.SummaryTable.N9,
                                             N10 = list.SummaryTable.N10,
                                             N11 = list.SummaryTable.N11,
                                             N12 = list.SummaryTable.N12,
                                             N13 = list.SummaryTable.N13,
                                             N14 = list.SummaryTable.N14,
                                             N15 = list.SummaryTable.N15
                                         }).ToList();
            return result;
        }
    }
}
