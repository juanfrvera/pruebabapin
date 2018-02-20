USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO'  )
DELETE FROM [dbo].[Parameter] WHERE code='INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Título Información presupuestaria cronograma', N'INFORMACION_PRESUPUESTARIA_CRONOGRAMA_TITULO', N'', N'3', N'', null, null, N'')
GO


IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE'  )
DELETE FROM [dbo].[Parameter] WHERE code='INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE'
GO

INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Información Presupuestaria Año Visible', N'INFORMACION_PRESUPUESTARIA_ANIO_VISIBLE', N'', N'3', N'', null, null, N'')
GO
 