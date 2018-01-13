ALTER TABLE [dbo].[Credential]  WITH CHECK ADD  CONSTRAINT [FK_Credential_Setting] FOREIGN KEY([SettingID])
REFERENCES [dbo].[Setting] ([SettingID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Credential] CHECK CONSTRAINT [FK_Credential_Setting]
GO