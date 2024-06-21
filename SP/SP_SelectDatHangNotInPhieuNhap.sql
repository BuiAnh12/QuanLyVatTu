CREATE PROCEDURE [dbo].[SP_SelectDatHangNotInPhieuNhap]
AS
BEGIN
    SET NOCOUNT ON;

    SELECT [MasoDDH],
           [NGAY],
           [NhaCC],
           [MANV],
           [MAKHO]
    FROM [dbo].[DatHang]
    WHERE [MasoDDH] NOT IN (SELECT [MasoDDH] FROM [dbo].[PhieuNhap]);
END;