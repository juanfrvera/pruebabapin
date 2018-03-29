USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[ModalidadContratacion] 
          WHERE [Nombre] = 'No definido aún')
INSERT INTO [dbo].[ModalidadContratacion] 
([Nombre], [Activo]) 
VALUES ('No definido aún', '1')
GO

Update Proyecto set IdModalidadContratacion = 
(SELECT IdModalidadContratacion from ModalidadContratacion where nombre = 'No definido aún')
Where IdModalidadContratacion is null
GO


