CREATE PROCEDURE SP_UpdateAndDeleteCTPNincreaseVattu
    @MAPN nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Begin the transaction
        BEGIN TRANSACTION;

        -- Update Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - CTPN.SOLUONG  -- Decrease SOLUONGTON based on old CTPN values
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPN ON Vattu.MAVT = CTPN.MAVT
        WHERE CTPN.MAPN = @MAPN;

        -- Delete from CTPN table
        DELETE FROM CTPN
        WHERE MAPN = @MAPN;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Raise an error or log the exception as needed
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO
