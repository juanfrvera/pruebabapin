USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='USERNAME_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='USERNAME_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Username Esidif', N'USERNAME_ESIDIF', N'Username para los servicios web esidif', N'3', N'BAPIN', null, null, N'')
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='PASSWORD_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='PASSWORD_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Password Esidif', N'PASSWORD_ESIDIF', N'Password para los servicios web esidif', N'3', N'BapinEsidif2018', null, null, N'')
GO