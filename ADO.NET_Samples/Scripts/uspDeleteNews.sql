CREATE PROCEDURE [dbo].[uspDeleteNews]
	@NewsID int
AS
BEGIN
	delete from tblNews  where NewsID = @NewsID
END

