CREATE PROCEDURE SP_CheckExistMasoDDHInPhieuNhap
    @MasoDDH nchar(8),
    @ExistStatus BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MasoDDH] = @MasoDDH)
        SET @ExistStatus = 1;
    ELSE
        SET @ExistStatus = 0;
END

