/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/
GO
SET IDENTITY_INSERT Gender ON 
INSERT INTO dbo.Gender (GenderID,GenderName) VALUES (1,N'Արական');
INSERT INTO dbo.Gender (GenderID,GenderName) VALUES (2,N'Իգական');
SET IDENTITY_INSERT Gender OFF 

GO
SET IDENTITY_INSERT CourtType ON 
INSERT INTO dbo.CourtType (CourtTypeID,CourtTypeName) VALUES (1,N'Երևանի առաջին ատյանի դատարան');
INSERT INTO dbo.CourtType (CourtTypeID,CourtTypeName) VALUES (2,N'Այլ առաջին ատյանի դատարան');
INSERT INTO dbo.CourtType (CourtTypeID,CourtTypeName) VALUES (3,N'Վերաքննիչ դատարան');
INSERT INTO dbo.CourtType (CourtTypeID,CourtTypeName) VALUES (4,N'Վճռաբեկ դատարան');
SET IDENTITY_INSERT CourtType OFF 

GO
SET IDENTITY_INSERT Specialization ON 
INSERT INTO dbo.Specialization (SpecializationID,SpecializationName) VALUES (1,N'Քրեական');
INSERT INTO dbo.Specialization (SpecializationID,SpecializationName) VALUES (2,N'Քաղաքացիական');
INSERT INTO dbo.Specialization (SpecializationID,SpecializationName) VALUES (3,N'Վարչական');
SET IDENTITY_INSERT Specialization OFF 
