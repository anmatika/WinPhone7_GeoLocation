CREATE TABLE [dbo].[Users] (
    [Id]          INT            IDENTITY (1, 1) NOT NULL,
    [UserName]    NVARCHAR (50)  NULL,
    [Password]    NVARCHAR (MAX) NULL,
    [ForeName]    NVARCHAR (50)  NULL,
    [Surname]     NVARCHAR (50)  NULL,
    [Address]     NVARCHAR (50)  NULL,
    [PhoneNumber] VARCHAR (50)   NULL,
    [Email]       VARCHAR (100)  NOT NULL,
    [CreateDate]  DATETIME2 (7)  NOT NULL,
    [UpdateDate]  DATETIME2 (7)  NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)
);

