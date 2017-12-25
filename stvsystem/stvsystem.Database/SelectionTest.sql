GO
SET IDENTITY_INSERT [dbo].[Candidate] ON 
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (21, N'FirstName1', N'LastName1', N'MiddleName1', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (22, N'FirstName2', N'LastName2', N'MiddleName2', NULL, NULL, NULL, NULL)
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (23, N'FirstName3', N'LastName3', N'MiddleName3', NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Candidate] OFF
GO
SET IDENTITY_INSERT [dbo].[Credential] ON 
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (5, N'111111', 5, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (6, N'222222', 5, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (7, N'333333', 5, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Credential] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 
GO
INSERT [dbo].[Setting] ([SettingID], [SelectionName], [SelectionDate], [StartTime], [FinishTime], [SelectionCount], [ParticipantCount], [SelectionStatus]) VALUES (5, N'Selection1', NULL, NULL, NULL, NULL, NULL, NULL)
GO
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
