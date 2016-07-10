CREATE TABLE [dbo].[Projects]
(
	[ProjectId] INT NOT NULL PRIMARY KEY, 
    [isGlyph] BIT NOT NULL, 
    [glyphClass] NVARCHAR(256) NULL, 
    [imgSrc] NVARCHAR(512) NULL, 
    [URL] NVARCHAR(512) NOT NULL, 
    [DisplayName] NVARCHAR(50) NULL
)
