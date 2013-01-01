CREATE TABLE [dbo].[GuestBookMessage] (
    [Id]         INT            IDENTITY (1, 1) NOT NULL,
    [Name]       NVARCHAR (50)  NOT NULL,
    [Message]    NVARCHAR (MAX) NULL,
    [CreateDate] DATETIME2 (7)  NOT NULL,
    [UpdateDate] DATETIME2 (7)  NOT NULL,
    CONSTRAINT [PK_GuestBookMessage] PRIMARY KEY CLUSTERED ([Id] ASC)
);

