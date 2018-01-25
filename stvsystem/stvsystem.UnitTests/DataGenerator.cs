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

            db.Database.ExecuteSqlCommand("delete from dbo.setting");
            db.Database.ExecuteSqlCommand("delete from dbo.credential");
            db.Database.ExecuteSqlCommand("delete from dbo.result");
            db.Database.ExecuteSqlCommand("delete from dbo.candidate");


            db.Database.ExecuteSqlCommand(@"SET IDENTITY_INSERT[dbo].[Candidate] ON
INSERT[dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES(1, N'Թեկնածու 1', N'Ազգանուն', N'Հայրանուն', NULL, 1, 1, 1)
INSERT[dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES(2, N'Թեկնածու 2', N'Ազգանուն', N'Հայրանուն', NULL, 1, 2, 2)
INSERT[dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES(3, N'Թեկնածու 3', N'Ազգանուն', N'Հայրանուն', NULL, 2, 3, 3)
INSERT[dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES(4, N'Թեկնածու 4', N'Ազգանուն', N'Հայրանուն', NULL, 1, 4, 1)
INSERT[dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES(5, N'Թեկնածու 5', N'Ազգանուն', N'Հայրանուն', NULL, 1, 5, 2)
SET IDENTITY_INSERT[dbo].[Candidate] OFF
SET IDENTITY_INSERT[dbo].[Setting] ON
INSERT[dbo].[Setting]([SettingID], [SelectionName], [SelectionDate], [StartTime], [FinishTime], [SelectionCount], [ParticipantCount], [SelectionStatus]) VALUES(1, N'Թեսթային ընտրություն', '2018-01-01', '08:00', '20:00', 3, 10, 1)
SET IDENTITY_INSERT[dbo].[Setting] OFF");

            var setting = db.Settings.Single();
            int participantCount = 30;
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







            int[] cycleCount = { 1, 2, 3, 4, 5 };
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