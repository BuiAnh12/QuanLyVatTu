CREATE PROCEDURE [dbo].[SP_InsertCTDDH]
    @MasoDDH nchar(8),
    @MAVT nchar(4),
    @SOLUONG INT,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        INSERT INTO CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA)
        VALUES (@MasoDDH, @MAVT, @SOLUONG, @DONGIA);

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