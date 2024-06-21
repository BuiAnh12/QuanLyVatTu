CREATE PROCEDURE SP_DeleteDatHangByMasoDDH
    @MasoDDH nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    DELETE FROM [dbo].[DatHang]
    WHERE [MasoDDH] = @MasoDDH;
END
