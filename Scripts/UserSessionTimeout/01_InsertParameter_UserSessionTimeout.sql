USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='USER_SESSION_TIMEOUT'  )
DELETE FROM [dbo].[Parameter] WHERE code='USER_SESSION_TIMEOUT'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'User session timeout', N'USER_SESSION_TIMEOUT', N'En minutos', N'3', N'', 30, null, N'')
GO
