CREATE PROCEDURE [dbo].[SP_UpdateCTDDH]
    @MasoDDH nchar(8),
    @MAVT nchar(4),
    @SOLUONG INT,
    @DONGIA float
AS
BEGIN
    -- Check if the row exists
    IF EXISTS (SELECT 1 FROM LINK0.QLVT_DATHANG.dbo.CTDDH WHERE MasoDDH = @MasoDDH AND MAVT = @MAVT)
    BEGIN
        -- Update existing row
        UPDATE LINK0.QLVT_DATHANG.dbo.CTDDH
        SET SOLUONG = @SOLUONG,
            DONGIA = @DONGIA
        WHERE MasoDDH = @MasoDDH AND MAVT = @MAVT;
    END
    ELSE
    BEGIN
        -- Insert new row
        INSERT INTO CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA)
        VALUES (@MasoDDH, @MAVT, @SOLUONG, @DONGIA);
    END
END;
