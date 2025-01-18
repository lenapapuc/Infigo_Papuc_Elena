USE [CMSPlus]
GO
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Commentaries](
    [Id] [int] IDENTITY(1,1) NOT NULL,
    [TopicId] [int] NOT NULL,
    [Body] [nvarchar](3000) NOT NULL,
    [Name] [nvarchar](450) NOT NULL,
    [LastName] [nvarchar](450) NOT NULL,
    [CreatedOnUtc] [datetime] NOT NULL,
    CONSTRAINT [PK_Commentaries] PRIMARY KEY CLUSTERED
(
[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
    ) ON [PRIMARY]
    GO

ALTER TABLE [dbo].[Commentaries] ADD  DEFAULT (getdate()) FOR [CreatedOnUtc]

    GO
ALTER TABLE [dbo].[Commentaries]  WITH CHECK ADD  CONSTRAINT [FK_Topic_Commentaries_TopicId] FOREIGN KEY([TopicId])
    REFERENCES [dbo].[Topics] ([Id])
    ON DELETE CASCADE
GO
