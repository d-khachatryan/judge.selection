using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace stvsystem.Data
{
    public class SelectionService : ServiceBase
    {
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
    }
}
