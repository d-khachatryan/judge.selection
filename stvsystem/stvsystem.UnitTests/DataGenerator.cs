using Microsoft.EntityFrameworkCore;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using stvsystem.Data;
using System;
using System.Linq;
using System.Text;

namespace stvsystem.UnitTests
{
    [TestClass]
    public class DataGenerator
    {
        [TestMethod]
        public void GenerateData()
        {
            var optionsBuilder = new DbContextOptionsBuilder<StvContext>();
            optionsBuilder.UseSqlServer(@"Data Source=.\SQL2014;Database=stvsystemDB;Integrated Security=True;Persist Security Info=False;Pooling=False;MultipleActiveResultSets=False;Connect Timeout=60;Encrypt=False;TrustServerCertificate=True", null);
            StvContext db = new StvContext(optionsBuilder.Options);


            var setting = db.Settings.Single();
            int participantCount = 200;
            /////////
            CredentialService credentialService = new CredentialService(db);
            var dictionary = credentialService.GenerateCredentials((int)participantCount);
            for (var i = 0; i < participantCount; i++)
            {
                Credential credential = new Credential
                {
                    SettingID = setting.SettingID,
                    Password = dictionary.ElementAt(i).Key,
                    Status = CredentialStatus.NoSelection,
                    Setting = setting
                };
                db.Credentials.Add(credential);
            }
            db.SaveChanges();
            //////////







            int[] cycleCount = { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15 };
            Random cycleRandom = new Random();


            var candidates = (from p in db.Candidates select p.CandidateID).ToArray();
            Random candidateRandom = new Random();

            foreach (Credential credential in db.Credentials.ToList())
            {
                int credentialCycleCount = cycleCount[cycleRandom.Next(0, cycleCount.Length)];
                int candidateID = 0;

                for (int i = 1; i <= credentialCycleCount; i++)
                {
                    bool isRecordExists = true;
                    while (isRecordExists)
                    {
                        candidateID = candidates[candidateRandom.Next(0, candidates.Length)];
                        var q = from p in db.Results where p.CredentialID == credential.CredentialID && p.CandidateID == candidateID select p;
                        if (q.Count() > 0)
                        {
                            isRecordExists = true;
                        }
                        else
                        {
                            isRecordExists = false;
                        }
                    }
                    

                    Result result = new Result
                    {
                        CandidateID = candidateID,
                        CandidateIndex = i,
                        CredentialID = credential.CredentialID,
                        Status = ResultStatus.Permanent
                    };
                    db.Results.Add(result);

                    db.SaveChanges();
                }

            }

        }
    }

}