CREATE TABLE [dbo].[Candidate] (
    [CandidateID]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]        NVARCHAR (50) NULL,
    [LastName]         NVARCHAR (50) NULL,
    [MiddleName]       NVARCHAR (50) NULL,
    [BirthDate]        DATE          NULL,
    [GenderID]         INT           NULL,
    [CourtID]          INT           NULL,
    [SpecializationID] INT           NULL,
    [CandidateStatus]  BIT           NULL,
    PRIMARY KEY CLUSTERED ([CandidateID] ASC)
);


