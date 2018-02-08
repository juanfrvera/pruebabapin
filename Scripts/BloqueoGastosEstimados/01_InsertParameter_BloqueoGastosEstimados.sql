USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Estimados', N'BLOQUEAR_GASTOS_ESTIMADOS', N'Bloquear la edición de los gastos estimados', N'3', N'N', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS_PLANES'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS_PLANES'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Estimados Planes', N'BLOQUEAR_GASTOS_ESTIMADOS_PLANES', N'Bloquear la edición de los gastos estimados para un conjunto de planes [Nombre planes separados por coma]', N'3', N'', null, null, N'');
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS'  )
DELETE FROM [dbo].[Parameter] WHERE code='BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS'
GO
INSERT INTO [dbo].[Parameter] 
([Name], [Code], [Description], [IdParameterCategory], [StringValue], [NumberValue], [DateValue], [TextValue]) 
VALUES (N'Bloquear Gastos Estimados Tipo Organismos', N'BLOQUEAR_GASTOS_ESTIMADOS_TIPO_ORGANISMOS', N'bloquear la edición de los gastos estimados para los organismos presupuestarios definidos [Ids separados por coma]', N'3', N'', null, null, N'');
GO