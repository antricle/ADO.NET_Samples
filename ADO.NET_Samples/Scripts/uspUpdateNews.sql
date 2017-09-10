CREATE PROCEDURE [dbo].[uspUpdateNews]
	@Title varchar(max),
	@NewsID int
AS
BEGIN
	update tblNews set Title = @Title where NewsID = @NewsID
END

