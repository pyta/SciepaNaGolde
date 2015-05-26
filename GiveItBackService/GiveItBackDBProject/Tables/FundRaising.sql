CREATE TABLE [dbo].[FundRaising]
(
	[Id] INT NOT NULL PRIMARY KEY, 
    [Name] NVARCHAR(100) NULL, 
    [CreatorID] INT NULL, 
    [CreateDate] DATETIME NULL, 
    [GPSCoord] NVARCHAR(50) NULL
)
