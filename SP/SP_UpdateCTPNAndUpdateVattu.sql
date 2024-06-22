CREATE PROCEDURE SP_UpdateCTPNAndUpdateVattu
    @MAPN nchar(8),
    @MAVT nchar(4),
    @NewSOLUONG int,
    @NewDONGIA float
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

        -- Update CTPN table with new values
        UPDATE LINK0.QLVT_DATHANG.dbo.CTPN
        SET 
            SOLUONG = @NewSOLUONG,
            DONGIA = @NewDONGIA
        WHERE MAPN = @MAPN AND MAVT = @MAVT;

        -- Increase Vattu table based on updated CTPN values
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @NewSOLUONG  -- Increase SOLUONGTON with new SOLUONG value
        WHERE MAVT = @MAVT;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Raise an error or log the exception as needed
        THROW;
    END CATCH;
END;
GO
