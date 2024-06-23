USE [QLVT_DATHANG]
GO

 CREATE PROCEDURE [dbo].[SP_GenerateMDDH]
AS
BEGIN
    DECLARE @Number INT
    DECLARE @MDDHString VARCHAR(10)

    -- Select the maximum number from the DatHang table
    SELECT @Number = CAST(SUBSTRING(MAX(MasoDDH), 5, LEN(MAX(MasoDDH)) - 4) AS INT) FROM DatHang

    IF @Number IS NULL -- Handling the case where no rows exist in the table
        SET @Number = 0

    IF @Number < 100
        SET @MDDHString = 'MDDH' + RIGHT('0' + CAST(@Number + 1 AS VARCHAR(3)), 2)
    ELSE
        SET @MDDHString = 'MDDH' + RIGHT('00' + CAST(@Number + 1 AS VARCHAR(3)), 3)

    -- Output the generated MDDH string
    SELECT @MDDHString AS MDDHString
END

