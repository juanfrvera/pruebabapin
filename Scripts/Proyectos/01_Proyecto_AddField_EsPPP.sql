USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EsPPP'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [EsPPP] bit NULL 
GO

--Add default to EsPPP on proyecto
ALTER TABLE [dbo].[Proyecto] ADD DEFAULT 0 FOR [EsPPP]
GO

UPDATE [dbo].[Proyecto]  SET [EsPPP] = 0 where EsPPP is null
GO

