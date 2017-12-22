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

SET IDENTITY_INSERT [dbo].[Court] ON 
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (1, NULL, N'Հայաստանի Հանրապետության Վճռաբեկ դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (2, NULL, N'Հայաստանի Հանրապետության  Վերաքննիչ քաղաքացիական դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (3, NULL, N'Հայաստանի Հանրապետության Վերաքննիչ քրեական դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (4, NULL, N'Հայաստանի Հանրապետության Վարչական վերաքննիչ դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (5, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Երևանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (6, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Գյումրու նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (7, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Վանաձորի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (8, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Սևանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (9, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Վեդիի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (10, NULL, N'Հայաստանի Հանրապետության Վարչական դատարան, Կապանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (11, NULL, N'Կենտրոն և Նորք-Մարաշ վարչական շրջանների ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (12, NULL, N'Աջափնյակ և Դավթաշեն վարչական շրջանների ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (13, NULL, N'Ավան և Նոր Նորք վարչական շրջանների ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (14, NULL, N'Արաբկիր և Քանաքեռ-Զեյթուն վարչական շրջանների ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (15, NULL, N'Շենգավիթ վարչական շրջանի ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (16, NULL, N'Մալաթիա-Սեբաստիա վարչական շրջանի ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (17, NULL, N'Էրեբունի և Նուբարաշեն վարչական շրջանների ընդհանուր իրավասության դատարան')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (18, NULL, N'Կոտայքի մարզի ընդհանուր իրավասության դատարան, Չարենցավանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (19, NULL, N'Կոտայքի մարզի ընդհանուր իրավասության դատարան, Եղվարդի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (20, NULL, N'Կոտայքի մարզի ընդհանուր իրավասության դատարան, Աբովյանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (21, NULL, N'Արարատի և Վայոց Ձորի մարզերի ընդհանուր իրավասության դատարան, Արտաշատի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (22, NULL, N'Արարատի և Վայոց Ձորի մարզերի ընդհանուր իրավասության դատարան, Մասիսի նստավայր ')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (23, NULL, N'Արարատի և Վայոց Ձորի մարզերի ընդհանուր իրավասության դատարան, Վեդիի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (24, NULL, N'Արարատի և Վայոց Ձորի մարզերի ընդհանուր իրավասության դատարան, Եղեգնաձորի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (25, NULL, N'Արարատի և Վայոց Ձորի մարզերի ընդհանուր իրավասության դատարան, Վայքի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (26, NULL, N'Արմավիրի մարզի ընդհանուր իրավասության դատարան, Արմավիրի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (27, NULL, N'Արմավիրի մարզի ընդհանուր իրավասության դատարան, Էջմիածնի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (28, NULL, N'Արմավիրի մարզի ընդհանուր իրավասության դատարան, Աշտարակի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (29, NULL, N'Արմավիրի մարզի ընդհանուր իրավասության դատարան, Ապարանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (30, NULL, N'Արմավիրի մարզի ընդհանուր իրավասության դատարան, Թալինի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (31, NULL, N'Տավուշի մարզի ընդհանուր իրավասության դատարան, Իջևանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (32, NULL, N'Տավուշի մարզի ընդհանուր իրավասության դատարան, Դիլիջանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (33, NULL, N'Տավուշի մարզի ընդհանուր իրավասության դատարան, Նոյեմբերյանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (34, NULL, N'Տավուշի մարզի ընդհանուր իրավասության դատարան, Բերդի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (35, NULL, N'Գեղարքունիքի մարզի ընդհանուր իրավասության դատարան, Գավառի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (36, NULL, N'Գեղարքունիքի մարզի ընդհանուր իրավասության դատարան, Սևանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (37, NULL, N'Գեղարքունիքի մարզի ընդհանուր իրավասության դատարան, Մարտունու նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (38, NULL, N'Գեղարքունիքի մարզի ընդհանուր իրավասության դատարան, Վարդենիսի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (39, NULL, N'Գեղարքունիքի մարզի ընդհանուր իրավասության դատարան, Ճամբարակի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (40, NULL, N'Լոռու մարզի ընդհանուր իրավասության դատարան, Վանաձորի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (41, NULL, N'Լոռու մարզի ընդհանուր իրավասության դատարան, Ալավերդիի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (42, NULL, N'Լոռու մարզի ընդհանուր իրավասության դատարան, Տաշիրի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (43, NULL, N'Լոռու մարզի ընդհանուր իրավասության դատարան, Սպիտակի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (44, NULL, N'Լոռու մարզի ընդհանուր իրավասության դատարան, Ստեփանավանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (45, NULL, N'Սյունիքի մարզի ընդհանուր իրավասության դատարան, Կապանի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (46, NULL, N'Սյունիքի մարզի ընդհանուր իրավասության դատարան, Գորիսի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (47, NULL, N'Սյունիքի մարզի ընդհանուր իրավասության դատարան, Սիսիանի նստավայր ')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (48, NULL, N'Սյունիքի մարզի ընդհանուր իրավասության դատարան, Մեղրու նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (49, NULL, N'Շիրակի մարզի ընդհանուր իրավասության դատարան,  Գյումրու նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (50, NULL, N'Շիրակի մարզի ընդհանուր իրավասության դատարան,  Արթիկի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (51, NULL, N'Շիրակի մարզի ընդհանուր իրավասության դատարան,  Մարալիկի նստավայր')
INSERT [dbo].[Court] ([CourtID], [CourtTypeID], [CourtName]) VALUES (52, NULL, N'Շիրակի մարզի ընդհանուր իրավասության դատարան,  Աշոցքի և Ամասիայի նստավայր')
SET IDENTITY_INSERT [dbo].[Court] OFF
