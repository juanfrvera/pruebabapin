USE [BAPIN]
GO

IF NOT EXISTS(SELECT 1 FROM sys.columns 
          WHERE Name = N'EsPPP'
          AND Object_ID = Object_ID(N'dbo.Proyecto'))
ALTER TABLE [dbo].[Proyecto]
ADD [EsPPP] bit NULL 
GO

--Add default to EsPPP on proyecto
if not exists (
    select *
      from sys.all_columns c
      join sys.tables t on t.object_id = c.object_id
      join sys.schemas s on s.schema_id = t.schema_id
      join sys.default_constraints d on c.default_object_id = d.object_id
    where t.name = 'Proyecto'
      and c.name = 'EsPPP'
      and s.name = 'dbo')
ALTER TABLE [dbo].[Proyecto] ADD DEFAULT 0 FOR [EsPPP]
GO

UPDATE [dbo].[Proyecto]  SET [EsPPP] = 0 where EsPPP is null
GO

