/*
 Pre-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be executed before the build script.	
 Use SQLCMD syntax to include a file in the pre-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the pre-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF EXISTS (SELECT * FROM sys.tables where name = 'Candidate')
DELETE FROM dbo.Candidate 

IF EXISTS (SELECT * FROM sys.tables where name = 'Credential')
DELETE FROM dbo.Credential 

IF EXISTS (SELECT * FROM sys.tables where name = 'Judge')
DELETE FROM dbo.Judge 

IF EXISTS (SELECT * FROM sys.tables where name = 'Court')
DELETE FROM dbo.Court 

IF EXISTS (SELECT * FROM sys.tables where name = 'CourtType')
DELETE FROM dbo.CourtType 

IF EXISTS (SELECT * FROM sys.tables where name = 'Specialization')
DELETE FROM dbo.Specialization 

IF EXISTS (SELECT * FROM sys.tables where name = 'Setting')
DELETE FROM dbo.Setting 

IF EXISTS (SELECT * FROM sys.tables where name = 'Gender')
DELETE FROM dbo.Gender 
