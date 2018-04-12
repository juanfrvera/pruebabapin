USE [BAPIN]
GO

IF NOT EXISTS (SELECT * FROM [dbo].[ProyectoTipo] WHERE Nombre='Indefinido'  )
BEGIN
Update ProyectoTipo set Nombre = 'IRD – Inv. Real Directa' where Nombre = '1 Inversión Real Directa'
Update ProyectoTipo set Nombre = 'Transferencia' where Nombre = '2 Transferencias'
Update ProyectoTipo set Nombre = 'Combinados' where Nombre = '3 Combinado'
Update ProyectoTipo set Nombre = 'Inversiones Financieras' where Nombre = '4 Inversiones Financieras'
Update ProyectoTipo set Nombre = 'Adelanto  a proveedores' where Nombre = '5 Adelanto a Proveedores'
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('SGC', 'Sin gastos imputados', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('GC', 'Gasto Corriente', '1', '');
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('IND', 'Indefinido', '1', '');
END;

GO


