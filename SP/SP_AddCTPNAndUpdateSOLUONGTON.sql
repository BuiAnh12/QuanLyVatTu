CREATE PROCEDURE SP_AddCTPNAndUpdateSOLUONGTON
    @MAPN nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    -- Begin a transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insert the new record into the CTPN table
        INSERT INTO [dbo].[CTPN] (MAPN, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPN, @MAVT, @SOLUONG, @DONGIA);

        -- Update the SOLUONGTON in the Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @SOLUONG
        WHERE MAVT = @MAVT;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if any error occurs
        ROLLBACK TRANSACTION;

        -- Raise the error to the caller
        THROW;
    END CATCH
END;
