CREATE TABLE [dbo].[Buys] (
    [ID]        INT            IDENTITY (1, 1) NOT NULL,
    [Quantity]  NVARCHAR (MAX) NOT NULL,
    [Purchased] INT            NULL,
    [Amount]    NVARCHAR (MAX) NULL,
    [Date]      DATETIME       NOT NULL,
    [userID]    INT            NULL,
    [rowID]     INT            NULL,
    CONSTRAINT [PK_dbo.Buys] PRIMARY KEY CLUSTERED ([ID] ASC)
);

