USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados', N'BLOQUEAR_GASTOS_REALIZADOS', N'Bloquear la edición de los gastos realizados', N'3', N'N', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_ANIOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_ANIOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados Años', N'BLOQUEAR_GASTOS_REALIZADOS_ANIOS', N'Bloquear la edición de los gastos realizados para un conjunto de años [Años separados por coma]', N'3', N'', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Realizados Tipo Organismos', N'BLOQUEAR_GASTOS_REALIZADOS_TIPO_ORGANISMOS', N'bloquear la edición de los gastos realizados para los organismos presupuestarios definidos [Ids separados por coma]', N'3', N'', null, null, N'');
GO