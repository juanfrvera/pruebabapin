

IF  EXISTS (SELECT * FROM [dbo].[Parameter] WHERE code='ACTIVAR_AUDITORIA'  )
DELETE FROM [dbo].[Parameter] WHERE code='ACTIVAR_AUDITORIA'

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
           ('Activar Auditoria'
           ,'ACTIVAR_AUDITORIA'
           ,'Indica si se va a realizar la auditoria de operacion ("S" = si)'
           ,3
           ,'S'
           ,NULL
           ,NULL
           ,''
	   )

GO


