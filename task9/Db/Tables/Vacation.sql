CREATE TABLE [dbo].[Vacation]
(
	[Id] UNIQUEIDENTIFIER NOT NULL UNIQUE PRIMARY KEY, 
    [StartDate] DATE NOT NULL CHECK (StartDate > '01/01/2001'), 
    [EndDate] DATE NOT NULL CHECK (EndDate > StartDate)
)
