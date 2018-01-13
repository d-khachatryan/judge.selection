CREATE TABLE [dbo].[Setting]
(
	[SettingID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [SelectionName] NVARCHAR(50) NULL, 
    [SelectionDate] DATE NULL, 
    [StartTime] DATETIME NULL, 
    [FinishTime] DATETIME NULL, 
    [SelectionCount] INT NULL, 
    [ParticipantCount] INT NULL, 
    [SelectionStatus] INT NULL
)
