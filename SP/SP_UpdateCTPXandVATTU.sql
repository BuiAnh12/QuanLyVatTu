CREATE PROCEDURE SP_UpdateCTPXandVATTU
    @MAPX nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @SOLUONGTON int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        
        BEGIN
            -- Cập nhật lại CTPX
            UPDATE LINK0.QLVT_DATHANG.dbo.CTPX
            SET SOLUONG = @SOLUONG, DONGIA = @DONGIA
            WHERE MAPX = @MAPX AND MAVT = @MAVT;

            -- Cập nhật lại SOLUONGTON trong Vattu
            UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
            SET SOLUONGTON =@SOLUONGTON
            WHERE MAVT = @MAVT;

        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Xử lý lỗi nếu có
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END