CREATE PROCEDURE SP_XoaPhieuXuat
    @MAPX nchar(8)
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION

    BEGIN TRY
        -- Update the SOLUONGTON in Vattu table by joining with CTPX
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = Vattu.SOLUONGTON + CTPX.SOLUONG
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN CTPX ON Vattu.MAVT = CTPX.MAVT
        WHERE CTPX.MAPX = @MAPX

        -- Delete from CTPX where MAPX matches
        DELETE FROM CTPX
        WHERE MAPX = @MAPX

        -- Delete from PhieuXuat where MAPX matches
        DELETE FROM PhieuXuat
        WHERE MAPX = @MAPX

        -- Commit the transaction
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        -- Rollback the transaction in case of error
        ROLLBACK TRANSACTION

        -- Handle the error
        DECLARE @ErrorMessage NVARCHAR(4000)
        DECLARE @ErrorSeverity INT
        DECLARE @ErrorState INT

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE()

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
    END CATCH
END
