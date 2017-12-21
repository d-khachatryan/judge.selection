CREATE TABLE [dbo].[Judge]
(
	[JudgeID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [CourtID] INT NULL, 
    [SpecializationID] INT NULL, 
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL, 
    [MiddleName] NVARCHAR(50) NULL, 
    [GenderID] INT NULL
)
