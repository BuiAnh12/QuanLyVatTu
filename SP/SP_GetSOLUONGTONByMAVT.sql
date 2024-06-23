CREATE PROCEDURE SP_GetSOLUONGTONByMAVT
    @MAVT nchar(4)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SOLUONGTON
    FROM LINK0.QLVT_DATHANG.dbo.Vattu
    WHERE MAVT = @MAVT;
END