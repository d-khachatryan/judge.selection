CREATE TABLE [dbo].[TmpResult](
	[ResultID] [int] IDENTITY(1,1) NOT NULL,
	[CredentialID] [int] NOT NULL,
	[CandidateID] [int] NOT NULL,
	[CandidateIndex] [int] NOT NULL,
	[Status] [int] NULL,
	[ResultVal] [numeric](3, 2) NOT NULL
)
