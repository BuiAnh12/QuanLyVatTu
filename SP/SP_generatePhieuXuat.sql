CREATE PROCEDURE SP_generatePhieuXuat
AS
BEGIN
    DECLARE @Number INT
    DECLARE @MPXString VARCHAR(12)

    -- Select the maximum number from the PhieuNhap table in the specified linked server database
    SELECT @Number = ISNULL(MAX(CAST(SUBSTRING(MAPX, 4, LEN(MAPX) - 3) AS INT)), 0)
    FROM LINK0.QLVT_DATHANG.dbo.PhieuXuat

    -- Generate the new MPNString
    SET @MPXString = 'MPX' + CAST(@Number + 1 AS VARCHAR(10))

    -- Output the generated MPN string
    SELECT @MPXString AS MPXString
END
