IF NOT EXISTS (SELECT 1 FROM Projects)
BEGIN
	INSERT INTO Projects (ProjectId,DisplayName,isGlyph,glyphClass,URL) VALUES (0,'Home',1,'glyphicon-home','~/Home');
END