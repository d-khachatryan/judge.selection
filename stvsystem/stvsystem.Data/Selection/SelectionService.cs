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
            return new List<SelectionConfirmationItem>();
        }

        public SelectionItem FillSelectionItemNames(SelectionItem item)
        {
            //if (item.Candidate1ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate1ID);
            //    item.Candidate1Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate2ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate2ID);
            //    item.Candidate2Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate3ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate3ID);
            //    item.Candidate3Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate4ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate4ID);
            //    item.Candidate4Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate5ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate5ID);
            //    item.Candidate5Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate6ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate6ID);
            //    item.Candidate6Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate7ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate7ID);
            //    item.Candidate7Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate8ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate8ID);
            //    item.Candidate8Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate9ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate9ID);
            //    item.Candidate9Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            //if (item.Candidate10ID != null)
            //{
            //    var candidate = db.Candidates.Find(item.Candidate10ID);
            //    item.Candidate10Name = candidate.FirstName + " " + candidate.LastName + " " + candidate.MiddleName;
            //}
            return item;
        }

        public bool SaveSelection(SelectionItem item, CredentialService credentialService)
        {
            //int settingID = (int)credentialService.GetSettingIDByPassword(item.Password);

            //if (item.Candidate1ID != null)
            //{
            //    Result result1 = new Result
            //    {
            //        CandidateID = (int)item.Candidate1ID,
            //        CandidateIndex = 1,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result1);
            //}

            //if (item.Candidate2ID != null)
            //{
            //    Result result2 = new Result
            //    {
            //        CandidateID = (int)item.Candidate2ID,
            //        CandidateIndex = 2,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result2);
            //}

            //if (item.Candidate3ID != null)
            //{
            //    Result result3 = new Result
            //    {
            //        CandidateID = (int)item.Candidate3ID,
            //        CandidateIndex = 3,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result3);
            //}

            //if (item.Candidate4ID != null)
            //{
            //    Result result4 = new Result
            //    {
            //        CandidateID = (int)item.Candidate4ID,
            //        CandidateIndex = 4,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result4);
            //}

            //if (item.Candidate5ID != null)
            //{
            //    Result result5 = new Result
            //    {
            //        CandidateID = (int)item.Candidate5ID,
            //        CandidateIndex = 5,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result5);
            //}

            //if (item.Candidate6ID != null)
            //{
            //    Result result6 = new Result
            //    {
            //        CandidateID = (int)item.Candidate6ID,
            //        CandidateIndex = 6,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result6);
            //}

            //if (item.Candidate7ID != null)
            //{
            //    Result result7 = new Result
            //    {
            //        CandidateID = (int)item.Candidate7ID,
            //        CandidateIndex = 7,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result7);
            //}

            //if (item.Candidate8ID != null)
            //{
            //    Result result8 = new Result
            //    {
            //        CandidateID = (int)item.Candidate8ID,
            //        CandidateIndex = 8,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result8);
            //}

            //if (item.Candidate9ID != null)
            //{
            //    Result result9 = new Result
            //    {
            //        CandidateID = (int)item.Candidate9ID,
            //        CandidateIndex = 9,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result9);
            //}

            //if (item.Candidate10ID != null)
            //{
            //    Result result10 = new Result
            //    {
            //        CandidateID = (int)item.Candidate10ID,
            //        CandidateIndex = 10,
            //        CredentialID = settingID
            //    };
            //    db.Results.Add(result10);
            //}

            //updates the credential status
            //Credential credential = db.Credentials.Find(credentialService.GetCredentialIDByPassword(item.Password));
            //credential.Status = CredentialStatus.Done;
            //db.Credentials.Attach(credential);
            //db.Entry(credential).State = EntityState.Modified;

            //db.SaveChanges();

            return true;
        }
    }
}
