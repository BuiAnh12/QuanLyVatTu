CREATE PROCEDURE SP_DeleteCTDDH
    @MasoDDH nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    -- Delete statement
    DELETE FROM [dbo].[CTDDH]
    WHERE [MasoDDH] = @MasoDDH;
END
GO