CREATE PROCEDURE SP_IncreaseSOLUONGTON
    @MAVT nchar(4),
    @IncreaseAmount int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
    SET SOLUONGTON = SOLUONGTON + @IncreaseAmount
    WHERE MAVT = @MAVT;
END
