USE [SecureData]
GO

/****** Object: Table [dbo].[Orders] Script Date: 6/22/2020 2:46:35 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Orders] (
    [number]  INT          PRIMARY KEY NOT NULL,
    [date]    DATETIME     NOT NULL,
    [company] VARCHAR (50) NOT NULL,
    [amount]  FLOAT (2)  NOT NULL,
    [paid]    BIT          NOT NULL
);


