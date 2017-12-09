CREATE TABLE [dbo].[Candidate]
(
	[CandidateID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(50) NULL
)
