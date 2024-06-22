CREATE PROCEDURE [dbo].[SP_Insert_CTPN_VS_VATTU]
    @MAPN nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Start the transaction
        BEGIN TRANSACTION;

        -- Insert into CTPN
        INSERT INTO CTPN (MAPN, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPN, @MAVT, @SOLUONG, @DONGIA);

        -- Update Vattu
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @SOLUONG
        WHERE MAVT = @MAVT;

        -- Commit the transaction if all operations succeed
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if there's any error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Throw or handle the error as needed
        THROW;
    END CATCH;
END
