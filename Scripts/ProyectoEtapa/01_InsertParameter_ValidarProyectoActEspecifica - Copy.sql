USE [BAPIN]
GO

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_ACT_ESPECIF'  )
DELETE FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_ACT_ESPECIF'

GO

INSERT INTO [dbo].[Parameter]
           ([Name]
           ,[Code]
           ,[Description]
           ,[IdParameterCategory]
           ,[StringValue]
           ,[NumberValue]
           ,[DateValue]
           ,[TextValue])
     VALUES
           ('Valida ingreso de actividad especifica'
           ,'VALIDAR_PROYECTO_ACT_ESPECIF'
           ,'Valida ingreso de actividad especifica'
           ,2
           ,'S' /* S por defecto */
           ,NULL
           ,NULL
           ,''
	   )

GO
 