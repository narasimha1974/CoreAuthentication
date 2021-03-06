
USE [aspnet-CoreAuthentication-BE4FE1DC-1288-4515-9E4A-1B6F524F8DF7]
GO

/****** Script for SelectTopNRows command from SSMS  ******/
/*
delete FROM [dbo].[AspNetUsers]
delete FROM [dbo].[AspNetRoles]
delete FROM [dbo].[AspNetUserRoles]
delete FROM [dbo].[AspNetUserLogins]



*/

/*

SELECT * FROM [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
SELECT * FROM [dbo].[AspNetRoles] where Name = 'Admin'
SELECT * FROM [dbo].[AspNetUserRoles] UR inner join [dbo].[AspNetUsers] U on UR.UserId = U.Id where U.UserName = 'narasimhasastrykln@gmail.com'

*/
SELECT * FROM [dbo].[AspNetUsers]
SELECT * FROM [dbo].[AspNetRoles]
SELECT * FROM [dbo].[AspNetUserRoles]
SELECT * FROM [dbo].[AspNetUserLogins]
SELECT * FROM [dbo].[AspNetUserClaims]
SELECT * FROM [dbo].[AspNetRoleClaims]

SELECT * FROM [dbo].[AspNetUserTokens]

exec spGetCountries

declare @UserId as nvarchar(450) = '';
declare @RoleId as nvarchar(450) = '';
declare @ClaimType as nvarchar(max) = '';
declare @ClaimValue as nvarchar(max) = '';

/****************************************************/
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
set @ClaimType ='dob'
set @ClaimValue = '29-July-1974'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
set @ClaimType ='Role'
set @ClaimValue = 'Admin'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/	
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
set @ClaimType ='ManagerType'
set @ClaimValue = 'Manager'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/	
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
set @ClaimType ='ManagerType'
set @ClaimValue = 'CEO'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/	

select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
set @ClaimType ='ManagerType'
set @ClaimValue = 'CTO'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/	

select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'sastry@gmail.com'
set @ClaimType ='ManagerType'
set @ClaimValue = 'CFO'

if not exists (select * from [dbo].[AspNetUserClaims] where UserId = @UserId and ClaimType =@ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetUserClaims]
           ([UserId],[ClaimType],[ClaimValue]) VALUES (@UserId ,@ClaimType,@ClaimValue);

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;

end
/****************************************************/	

select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
select @RoleId = RoleId from dbo.AspNetUserRoles where UserId = @UserId
set @ClaimType ='Home'
set @ClaimValue = 'About'

if not exists (select RoleId = UR.RoleId from dbo.AspNetUserRoles UR inner join dbo.AspNetRoleClaims RC on UR.RoleId = RC.RoleId where ClaimType = @ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetRoleClaims] 
			([RoleId],[ClaimType],[ClaimValue]) VALUES 
			(@RoleId,@ClaimType,@ClaimValue)

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;
end

/****************************************************/	
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
select @RoleId = RoleId from dbo.AspNetUserRoles where UserId = @UserId
set @ClaimType ='Home'
set @ClaimValue = 'Index'

if not exists (select RoleId = UR.RoleId from dbo.AspNetUserRoles UR inner join dbo.AspNetRoleClaims RC on UR.RoleId = RC.RoleId where ClaimType = @ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetRoleClaims] 
			([RoleId],[ClaimType],[ClaimValue]) VALUES 
			(@RoleId,@ClaimType,@ClaimValue)

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;
end

/****************************************************/	
select @UserId = Id  from [dbo].[AspNetUsers] where UserName = 'narasimhasastrykln@gmail.com'
select @RoleId = RoleId from dbo.AspNetUserRoles where UserId = @UserId
set @ClaimType ='Home'
set @ClaimValue = 'Contact'

if not exists (select RoleId = UR.RoleId from dbo.AspNetUserRoles UR inner join dbo.AspNetRoleClaims RC on UR.RoleId = RC.RoleId where ClaimType = @ClaimType  and ClaimValue  = @ClaimValue)
begin

INSERT INTO [dbo].[AspNetRoleClaims] 
			([RoleId],[ClaimType],[ClaimValue]) VALUES 
			(@RoleId,@ClaimType,@ClaimValue)

set @UserId = null;
set @RoleId = null;
set @ClaimType = null;
set @ClaimValue = null;
end

/****************************************************/	

declare @tableType as varchar(200)
declare @tableSchema as varchar(200)
declare @tableName as varchar(200)

set @tableType = 'BASE TABLE'
set @tableSchema = 'dbo'

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'School')
begin
Create table School(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
    AddressLine1 nvarchar(450),
	AddressLine2 nvarchar(450),
	AddressLine3 nvarchar(450),
	PIN nvarchar(450),	
	CityId nvarchar(450),
	DistrictId nvarchar(450),
	StateId nvarchar(450),
	CountryId nvarchar(450),
    PhonesGroupId nvarchar(450),
	EmailsGroupId nvarchar(450),
	FaxsGroupId nvarchar(450),
	WebSitesGroupId nvarchar(450),		 
);

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'City')
begin
Create table City(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
	DistrinctId nvarchar(450),
    StateId nvarchar(450),
	CountryId nvarchar(450),    
);

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'District')
begin
Create table District(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
	StateId nvarchar(450),
	CountryId nvarchar(450),    
);

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'State')
begin
Create table State(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
	CountryId nvarchar(450),    
);

end

/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Country')
begin
Create table Country(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255)	
);

end

/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Phone')
begin
Create table Phone(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
    PhNumber numeric(12,0),		 
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'PhonesGroup')
begin
Create table PhonesGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),    
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'PhonesOfPhonesGroup')
begin
Create table PhonesOfPhonesGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
	PhoneId varchar(255),
    PhoneGroupId numeric(12,0),		 
);

end
/****************************************************/	
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Email')
begin
Create table Email(ID nvarchar(450) NOT NULL PRIMARY KEY,
    EMail nvarchar(255)
    	 
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'EmailsGroup')
begin
Create table EmailsGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),    
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'EmailsOfEmailsGroup')
begin
Create table EmailsOfEmailsGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    EmailId varchar(255),
    EmailsGroupId numeric(12,0),		 
);

end
/****************************************************/	
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Fax')
begin
Create table Fax(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Fax nvarchar(255)
    	 
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'FaxsGroup')
begin
Create table FaxsGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),    
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'FaxsOfFaxsGroup')
begin
Create table FaxsOfFaxsGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    FaxId varchar(255),
    FaxsGroupId numeric(12,0),		 
);

end
/****************************************************/	
/*WebSitesGroupId*/
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'WebSite')
begin
Create table WebSite(ID nvarchar(450) NOT NULL PRIMARY KEY,
    WebSite nvarchar(255)
    	 
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'WebSitesGroup')
begin
Create table WebSitesGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),    
);

end
/****************************************************/	
if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'WebSitesOfWebSitesGroup')
begin
Create table WebSitesOfWebSitesGroup(ID nvarchar(450) NOT NULL PRIMARY KEY,
    WebSiteId varchar(255),
    WebSitesGroupId numeric(12,0),		 
);

end
/****************************************************/	



if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Subject')
begin
Create table Subject(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
 );

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'EducationBoard')
begin
Create table EducationBoard(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
 );

end

/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'SyllabusType')
begin
Create table SyllabusType(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
 );

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'SyllabusType')
begin
Create table SyllabusType(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
 );

end
/****************************************************/	

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'Class')
begin
Create table Class(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
 );

end
/****************************************************/	
/****************************************************/	

--declare @tableType as varchar(200)
--declare @tableSchema as varchar(200)
--declare @tableName as varchar(200)

set @tableType = 'BASE TABLE'
set @tableSchema = 'dbo'

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'StudentAddress')
begin
Create table StudentAddress(ID nvarchar(450) NOT NULL PRIMARY KEY,
    Name varchar(255),
	FatherName varchar(255),
	MotherName varchar(255),
	GurdianName varchar(255),
    AddressLine1 nvarchar(450),
	AddressLine2 nvarchar(450),
	AddressLine3 nvarchar(450),
	PIN nvarchar(450),
	CityId nvarchar(450),
	DistrictId nvarchar(450),
	StateId nvarchar(450),
	CountryId nvarchar(450),
    PhonesGroupId nvarchar(450),
	EmailsGroupId nvarchar(450),
	FaxsGroupId nvarchar(450),
	WebSitesGroupId nvarchar(450),	
	DOB DateTime,	 
);

end

/****************************************************/	

--declare @tableType as varchar(200)
--declare @tableSchema as varchar(200)
--declare @tableName as varchar(200)

set @tableType = 'BASE TABLE'
set @tableSchema = 'dbo'

if not exists (SELECT * FROM INFORMATION_SCHEMA.TABLES WHERE TABLE_TYPE=@tableType and table_schema = @tableSchema and TABLE_NAME = 'StudentEducation')
begin
Create table StudentEducation(ID nvarchar(450) NOT NULL PRIMARY KEY,
    StudentId nvarchar(450),
	ClassId nvarchar(450),
	SchoolId nvarchar(450),
    SyllabusId nvarchar(450),
	BoardId nvarchar(450),
	ForAcademicYearFrom DateTime,		 
	ForAcademicYearTo DateTime,		 
);

end


