GO
SET IDENTITY_INSERT [dbo].[Candidate] ON 
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (1, N'Թեկնածու 1', N'Ազգանուն', N'Հայրանուն', NULL, 1, 1, 1)
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (2, N'Թեկնածու 2', N'Ազգանուն', N'Հայրանուն', NULL, 1, 2, 2)
GO
INSERT [dbo].[Candidate] ([CandidateID], [FirstName], [LastName], [MiddleName], [BirthDate], [GenderID], [CourtID], [SpecializationID]) VALUES (3, N'Թեկնածու 3', N'Ազգանուն', N'Հայրանուն', NULL, 2, 3, 3)
GO
SET IDENTITY_INSERT [dbo].[Candidate] OFF
GO
SET IDENTITY_INSERT [dbo].[Setting] ON 
GO
INSERT [dbo].[Setting] ([SettingID], [SelectionName], [SelectionDate], [StartTime], [FinishTime], [SelectionCount], [ParticipantCount], [SelectionStatus]) VALUES (1, N'Թեսթային ընտրություն', '2018-01-01', '08:00', '20:00', 3, 10, 1)
GO
SET IDENTITY_INSERT [dbo].[Setting] OFF
GO
SET IDENTITY_INSERT [dbo].[Credential] ON 
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (1, N'111111', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (2, N'222222', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (3, N'333333', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (4, N'444444', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (5, N'555555', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (6, N'666666', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (7, N'777777', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (8, N'888888', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (9, N'999999', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
INSERT [dbo].[Credential] ([CredentialID], [Password], [SettingID], [Status], [UsageDateTime]) VALUES (10, N'000000', 1, 1, CAST(N'2018-01-01T00:00:00.000' AS DateTime))
GO
SET IDENTITY_INSERT [dbo].[Credential] OFF
GO

