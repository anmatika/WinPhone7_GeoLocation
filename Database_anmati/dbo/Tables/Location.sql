CREATE TABLE [dbo].[Location] (
    [Id]         INT           IDENTITY (1, 1) NOT NULL,
    [UserId]     INT           NOT NULL,
    [Latitude]   DECIMAL (18)  NULL,
    [Longitude]  DECIMAL (18)  NULL,
    [CreateDate] DATETIME2 (7) NOT NULL,
    [UpdateDate] DATETIME2 (7) NULL,
    CONSTRAINT [PK_Location] PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_UsersLocation] FOREIGN KEY ([UserId]) REFERENCES [dbo].[Users] ([Id]) ON UPDATE CASCADE
);

