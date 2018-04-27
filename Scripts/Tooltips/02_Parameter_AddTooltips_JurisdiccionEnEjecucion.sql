USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[Text] 
          WHERE [Code] = 'TooltipProyectoJurisdiccionEnEjecucion')

INSERT INTO [Text] (
	[Code], [Description], [IdTextCategory], 
	[IsAutomaticLoad], [StartDate], 
	[Checked], [CheckedDate], [IdUsuarioChecked]) 
VALUES 
('TooltipProyectoJurisdiccionEnEjecucion', 'Jurisdicción en ejecución', '1', '1', GETDATE(), '0', NULL, NULL)
GO

IF NOT EXISTS(SELECT 1 FROM [dbo].[TextLanguage] 
          WHERE IdText = (Select IdText from [Text] where Code = 'TooltipProyectoJurisdiccionEnEjecucion'))

INSERT INTO TextLanguage 
--(IdText, IdTextLanguage,[TranslateText], [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]) 
Select IdText, (Select [IdLanguage] from [Language] where Name = 'Español'), Description, [IsAutomaticLoad], [StartDate], [Checked], [CheckedDate], [IdUsuarioChecked]
from [Text]
where IdText >= (Select IdText from [Text] where Code = 'TooltipProyectoJurisdiccionEnEjecucion')
GO