
USE [aspnet-CoreAuthentication-BE4FE1DC-1288-4515-9E4A-1B6F524F8DF7]
GO

declare @procName as varchar(300)
set @procName = 'dbo.spCreateCountry';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID(@procName))
   exec('CREATE PROCEDURE '+@procName+' AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE spCreateCountry
@cName as varchar(200)
AS
begin

DECLARE @UNIQUEX UNIQUEIDENTIFIER
SET @UNIQUEX = NEWID();

if(not exists (select * from dbo.Country where Name = @cName) )
	begin
		insert into [dbo].[Country](Id,Name) values(@UNIQUEX,@cName)
	end
end

go

/****************************************************************************/

declare @procName as varchar(300)
set @procName = 'dbo.spGetCountries';
IF NOT EXISTS (SELECT * FROM sys.objects WHERE type = 'P' AND OBJECT_ID = OBJECT_ID(@procName))
   exec('CREATE PROCEDURE '+@procName+' AS BEGIN SET NOCOUNT ON; END')
GO

ALTER PROCEDURE spGetCountries
AS
begin

select [ID], [Name] from dbo.Country 

end

go