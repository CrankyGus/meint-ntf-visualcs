CREATE TABLE [dbo].[Table]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Collection] NVARCHAR(MAX) NULL, 
    [Name] NVARCHAR(MAX) NULL, 
    [Image] IMAGE NULL, 
    [ImageURL] NVARCHAR(MAX) NULL
)
