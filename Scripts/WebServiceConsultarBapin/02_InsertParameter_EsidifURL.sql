USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='URL_ESIDIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='URL_ESIDIF'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Url Esidif', N'URL_ESIDIF', N'URL root a los servicios web esidif', N'3', N'https://ws-si.mecon.gov.ar/SD_Core/ws/', null, null, N'')
GO