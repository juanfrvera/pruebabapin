

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='FILTRAR_BUSQUEDA_PROYECTO_PERIODO_STRESS'  )
DELETE FROM [dbo].[Parameter] WHERE code='FILTRAR_BUSQUEDA_PROYECTO_PERIODO_STRESS'

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
           ('Activa Periodo de stress'
           ,'FILTRAR_BUSQUEDA_PROYECTO_PERIODO_STRESS'
           ,'Activa Periodo de stress'
           ,2
           ,'N'
           ,NULL
           ,NULL
           ,''
	   )

GO


