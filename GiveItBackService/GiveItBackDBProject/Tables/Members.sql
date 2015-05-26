CREATE TABLE [dbo].[Members]
(
	[Id] INT NOT NULL PRIMARY KEY IDENTITY, 
    [Name] NVARCHAR(100) NULL, 
    [Surname] NVARCHAR(100) NULL, 
    [PhoneNumber] BIGINT NULL
)
