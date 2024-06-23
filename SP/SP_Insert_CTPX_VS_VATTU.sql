CREATE PROCEDURE SP_Insert_CTPX_VS_VATTU
    @MAPX nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Thêm vào bảng CTPX
        INSERT INTO CTPX (MAPX, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPX, @MAVT, @SOLUONG, @DONGIA);
        
        -- Cập nhật số lượng tồn trong bảng Vattu
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - @SOLUONG
        WHERE MAVT = @MAVT;
        
        -- Kiểm tra số lượng tồn sau khi trừ
        IF EXISTS (SELECT 1 FROM Vattu WHERE MAVT = @MAVT AND SOLUONGTON < 0)
        BEGIN
            -- Rollback transaction nếu số lượng tồn nhỏ hơn 0
            ROLLBACK TRANSACTION;
            THROW 50000, 'Số lượng tồn không đủ.', 1;
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
