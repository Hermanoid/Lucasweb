﻿/*
Deployment script for Lucasweb

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "Lucasweb"
:setvar DefaultFilePrefix "Lucasweb"
:setvar DefaultDataPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"
:setvar DefaultLogPath "C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
PRINT N'Creating [dbo].[Projects]...';


GO
CREATE TABLE [dbo].[Projects] (
    [ProjectId]   INT            NOT NULL,
    [isGlyph]     BIT            NOT NULL,
    [glyphClass]  NVARCHAR (256) NULL,
    [imgSrc]      NVARCHAR (512) NULL,
    [URL]         NVARCHAR (512) NOT NULL,
    [DisplayName] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([ProjectId] ASC)
);


GO
PRINT N'Creating [dbo].[Users]...';


GO
CREATE TABLE [dbo].[Users] (
    [UserId]                INT            NOT NULL,
    [UserName]              NVARCHAR (256) NOT NULL,
    [LastName]              NVARCHAR (256) NULL,
    [FirstName]             NVARCHAR (256) NULL,
    [Email]                 NVARCHAR (256) NULL,
    [UniqueEncryptPassword] NVARCHAR (50)  NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);


GO
/*
Post-Deployment Script Template							
--------------------------------------------------------------------------------------
 This file contains SQL statements that will be appended to the build script.		
 Use SQLCMD syntax to include a file in the post-deployment script.			
 Example:      :r .\myfile.sql								
 Use SQLCMD syntax to reference a variable in the post-deployment script.		
 Example:      :setvar TableName MyTable							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------
*/

IF NOT EXISTS (SELECT 1 FROM Projects)
BEGIN
	INSERT INTO Projects (ProjectId,DisplayName,isGlyph,glyphClass,URL) VALUES (0,'Home',1,'glyphicon-home','~/Home');
END
GO

GO
PRINT N'Update complete.';


GO
