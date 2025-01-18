USE [CMSPlus]
GO

ALTER TABLE [dbo].[Commentaries]
ADD [UpdatedOnUtc] [datetime] NOT NULL;
GO