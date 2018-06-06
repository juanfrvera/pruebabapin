USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='ID_TEMPLATE_IMPORTACION'  )
DELETE FROM [dbo].[Parameter] WHERE code='ID_TEMPLATE_IMPORTACION'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Id Template Importación', N'ID_TEMPLATE_IMPORTACION', N'', N'3', N'', null, null, N'')
GO