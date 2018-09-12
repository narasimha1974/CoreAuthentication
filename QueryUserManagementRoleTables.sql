
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




