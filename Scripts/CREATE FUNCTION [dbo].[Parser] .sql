USE [BAPINIII]
GO

/****** Object:  UserDefinedFunction [dbo].[Parser]    Script Date: 12/06/2017 11:42:08 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Parser]') AND type in (N'FN', N'IF', N'TF', N'FS', N'FT'))
DROP FUNCTION [dbo].[Parser]
GO

USE [BAPINIII]
GO

/****** Object:  UserDefinedFunction [dbo].[Parser]    Script Date: 12/06/2017 11:42:08 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE FUNCTION [dbo].[Parser] (@texto varchar(1000))  
RETURNS @table TABLE (valor varchar(255))

/*
Fecha: 24/02/2011
Version: 1.6.15
Version SP: 16
Tarea Asociada: 0000028
Responsable: German.
Motivo: se agrega el ltrim y rtrim sobre los valores a insertar en la tabla para evitar 
los espacios en blano entre las comas, por ejemplo: A, B, en la tabla resultado tiene que 
quedar 'A' y 'B' y no 'A' y ' B'.
*/


BEGIN 


while DATALENGTH(@texto) > 0
Begin
	declare @aux int
	declare @auxtexto varchar (500)
	set @texto = rtrim(@texto)
	set @aux = CHARINDEX(',', @texto)
	if (@aux != 0)
	
	 begin 	
		set @auxtexto =  Left (@texto, @aux-1)
		insert into @table values (ltrim(rtrim(@auxtexto)))
		set @texto = Right (@texto , len(@texto)-@aux)
	 end
	else
	 begin
		insert into @table values ( (ltrim(rtrim(@texto))))
		set @texto = ''		

	 end
end
Return
	


END


GO


