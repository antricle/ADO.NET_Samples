CREATE PROCEDURE [dbo].[uspInsertNews]
	@Title varchar(max),
	@Description varchar(max)
AS
BEGIN
	INSERT INTO tblNews values(@Title, @Description)
END

