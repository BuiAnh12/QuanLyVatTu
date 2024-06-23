CREATE PROCEDURE SP_UpdateSOLUONGTONVT
    @MAVT nchar(4),
    @SOLUONGTON int
AS
BEGIN
    SET NOCOUNT ON;

    -- Update the SOLUONGTON field where MAVT matches the provided value
    UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
    SET SOLUONGTON = @SOLUONGTON
    WHERE MAVT = @MAVT; 
END;
