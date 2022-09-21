CREATE TABLE [dbo].[Training]
(
	[Id] UNIQUEIDENTIFIER NOT NULL UNIQUE PRIMARY KEY, 
    [Name] NVARCHAR(64) NOT NULL, 
    [StartDate] DATE NOT NULL CHECK (StartDate > '01/01/2001'), 
    [EndDate] DATE NOT NULL CHECK (EndDate > StartDate), 
    [Description] NVARCHAR(MAX) NULL
)
