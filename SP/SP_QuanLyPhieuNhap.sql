
CREATE TYPE [dbo].[ChiTietPhieuNhapType] AS TABLE(
	[MAPN] [nchar](8) NULL,
	[MAVT] [nchar](4) NULL,
	[SOLUONG] [int] NULL,
	[DONGIA] [float] NULL
)


CREATE PROCEDURE [dbo].[SP_QuanLyPhieuNhap]
    @Action NVARCHAR(10),
    @MaPhieuNhap NCHAR(8),
    @Ngay DATE = NULL,
    @MasoDDH NCHAR(8) = NULL,
    @MaNV INT = NULL,
    @MaKho NCHAR(4) = NULL,
    @ChiTietPhieuNhap dbo.ChiTietPhieuNhapType READONLY
AS
BEGIN
    SET NOCOUNT ON;
    BEGIN TRANSACTION;

    BEGIN TRY
        IF @Action = 'Insert'
        BEGIN
            -- Thêm mới phiếu nhập
            INSERT INTO PhieuNhap (MAPN, NGAY, MasoDDH, MANV, MAKHO)
            VALUES (@MaPhieuNhap, @Ngay, @MasoDDH, @MaNV, @MaKho);

            -- Thêm mới chi tiết phiếu nhập
            INSERT INTO CTPN (MAPN, MAVT, SOLUONG, DONGIA)
            SELECT @MaPhieuNhap, MAVT, SOLUONG, DONGIA
            FROM @ChiTietPhieuNhap;

            -- Cập nhật số lượng vật tư
            UPDATE LINK0.QLVT_DATHANG.dbo.VatTu
            SET SOLUONGTON = V.SOLUONGTON + CT.SOLUONG
            FROM LINK0.QLVT_DATHANG.dbo.VatTu V
            INNER JOIN @ChiTietPhieuNhap CT ON V.MAVT = CT.MAVT;
        END
        ELSE IF @Action = 'Update'
        BEGIN
            -- Cập nhật phiếu nhập
            UPDATE LINK0.QLVT_DATHANG.dbo.PhieuNhap
            SET NGAY = @Ngay, MasoDDH = @MasoDDH, MANV = @MaNV, MAKHO = @MaKho
            WHERE MAPN = @MaPhieuNhap;

            -- Cập nhật chi tiết phiếu nhập và số lượng vật tư
            UPDATE LINK0.QLVT_DATHANG.dbo.CTPN
            SET SOLUONG = CT.SOLUONG, DONGIA = CT.DONGIA
            FROM LINK0.QLVT_DATHANG.dbo.CTPN CTPN
            INNER JOIN @ChiTietPhieuNhap CT ON CTPN.MAPN = @MaPhieuNhap AND CTPN.MAVT = CT.MAVT;

            -- Cập nhật số lượng vật tư dựa trên thay đổi chi tiết phiếu nhập
            UPDATE LINK0.QLVT_DATHANG.dbo.VatTu 
            SET SOLUONGTON = V.SOLUONGTON + CT.SOLUONG
            FROM LINK0.QLVT_DATHANG.dbo.VatTu V
            INNER JOIN @ChiTietPhieuNhap CT ON V.MAVT = CT.MAVT;
        END
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Bắt lỗi và trả về thông báo lỗi
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END