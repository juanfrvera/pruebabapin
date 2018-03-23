USE [BAPIN]
GO

Update ProyectoTipo set Nombre = 'IRD – Inv. Real Directa' where Nombre = '1 Inversión Real Directa'
GO
Update ProyectoTipo set Nombre = 'Transferencia' where Nombre = '2 Transferencias'
GO
Update ProyectoTipo set Nombre = 'Combinados' where Nombre = '3 Combinado'
GO
Update ProyectoTipo set Nombre = 'Inversiones Financieras' where Nombre = '4 Inversiones Financieras'
GO
Update ProyectoTipo set Nombre = 'Adelanto  a proveedores' where Nombre = '5 Adelanto a Proveedores'
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('SGC', 'Sin gastos imputados', '1', '');
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('GC', 'Gasto Corriente', '1', '');
GO
INSERT INTO ProyectoTipo ([Sigla], [Nombre], [Activo], [Tipo]) 
VALUES ('IND', 'Indefinido', '1', '');
GO


