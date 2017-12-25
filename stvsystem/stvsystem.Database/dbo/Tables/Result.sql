CREATE TABLE [dbo].[Result]
(
	[ResultID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CredentialID] INT NOT NULL, 
    [CandidateID] INT NOT NULL, 
    [CandidateIndex] INT NOT NULL
)
