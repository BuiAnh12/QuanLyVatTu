CREATE PROCEDURE [dbo].[SP_UpdateCTDDH]
    @MasoDDH nchar(8),
    @MAVT nchar(4),
    @SOLUONG INT,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
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
            INSERT INTO LINK0.QLVT_DATHANG.dbo.CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA)
            VALUES (@MasoDDH, @MAVT, @SOLUONG, @DONGIA);
        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Optionally, you can add error handling logic here
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO