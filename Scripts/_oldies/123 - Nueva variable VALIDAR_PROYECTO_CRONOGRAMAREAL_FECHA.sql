

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_CRONOGRAMAREAL_FECHA'  )
DELETE FROM [dbo].[Parameter] WHERE code='VALIDAR_PROYECTO_CRONOGRAMAREAL_FECHA'

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
           ('Valida fecha gastos'
           ,'VALIDAR_PROYECTO_CRONOGRAMAREAL_FECHA'
           ,'Valida la fecha del gasto dentro del Cronograma de Gastos Realizados'
           ,3
           ,'N'
           ,NULL
           ,NULL
           ,''
	   )

GO


