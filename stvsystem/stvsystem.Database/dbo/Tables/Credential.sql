CREATE TABLE [dbo].[Credential]
(
	[CredentialID] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Password] CHAR(6) NULL, 
    [SettingID] INT NULL, 
    [Status] INT NULL, 
    [UsageDateTime] DATETIME NULL
)
