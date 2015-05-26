CREATE PROCEDURE [dbo].[InsertMember]
(@record dbo.Members readonly)

AS
BEGIN
insert into dbo.Members(Name, Surname,PhoneNumber)
select 
	   [Name],
	   [Surname],
	   [PhoneNumber]
from @record 
	  END