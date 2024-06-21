CREATE PROCEDURE SP_generatePhieuNhap
AS
BEGIN
    DECLARE @Number INT
    DECLARE @MPNString VARCHAR(12)

    -- Select the maximum number from the PhieuNhap table in the specified linked server database
    SELECT @Number = ISNULL(MAX(CAST(SUBSTRING(MasoDDH, 4, LEN(MasoDDH) - 3) AS INT)), 0)
    FROM LINK0.QLVT_DATHANG.dbo.PhieuNhap

    -- Generate the new MPNString
    SET @MPNString = 'MPN' + CAST(@Number + 1 AS VARCHAR(10))

    -- Output the generated MPN string
    SELECT @MPNString AS MPNString
END
