CREATE TABLE [dbo].[Users]
(
	[UserId] INT NOT NULL PRIMARY KEY, 
    [UserName] NVARCHAR(256) NOT NULL, 
    [LastName] NVARCHAR(256) NULL, 
    [FirstName] NVARCHAR(256) NULL, 
    [Email] NVARCHAR(256) NULL, 
    [UniqueEncryptPassword] NVARCHAR(50) NULL
)
