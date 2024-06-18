USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[SP_ChiTietSoLuongTriGiaHangHoaNhapXuat]    Script Date: 6/18/2024 8:50:52 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER PROCEDURE [dbo].[SP_ChiTietSoLuongTriGiaHangHoaNhapXuat]
    @ROLE NVARCHAR(8),
    @TYPE NVARCHAR(4),
    @DATEFROM DATETIME,
    @DATETO DATETIME
AS
BEGIN
    SET NOCOUNT ON;

    IF @ROLE = 'CHINHANH' OR @ROLE = 'USER'
    BEGIN
        IF @TYPE = 'NHAP'
        BEGIN
            SELECT FORMAT(NGAY, 'MM-yyyy') AS thang_nam, 
                   TENVT, 
                   SUM(SOLUONG) AS tong_soluong,
                   SUM(SOLUONG * DONGIA) AS tri_gia
            FROM PhieuNhap p
            JOIN CTPN ct ON p.MAPN = ct.MAPN
            JOIN Vattu vt ON vt.MAVT = ct.MAVT
            WHERE NGAY BETWEEN @DATEFROM AND @DATETO
            GROUP BY FORMAT(NGAY, 'MM-yyyy'), TENVT
            ORDER BY FORMAT(NGAY, 'MM-yyyy'), TENVT;
        END
        ELSE IF @TYPE = 'XUAT'
        BEGIN
            SELECT FORMAT(NGAY, 'MM-yyyy') AS thang_nam, 
                   TENVT, 
                   SUM(SOLUONG) AS tong_soluong,
                   SUM(SOLUONG * DONGIA) AS tri_gia
            FROM PhieuXuat p
            JOIN CTPX ct ON p.MAPX = ct.MAPX
            JOIN Vattu vt ON vt.MAVT = ct.MAVT
            WHERE NGAY BETWEEN @DATEFROM AND @DATETO
            GROUP BY FORMAT(NGAY, 'MM-yyyy'), TENVT
            ORDER BY FORMAT(NGAY, 'MM-yyyy'), TENVT;
        END
    END
    ELSE IF @ROLE = 'CONGTY'
    BEGIN
        IF @TYPE = 'NHAP'
        BEGIN
            SELECT FORMAT(NGAY, 'MM-yyyy') AS thang_nam, 
                   TENVT, 
                   SUM(SOLUONG) AS tong_soluong,
                   SUM(SOLUONG * DONGIA) AS tri_gia
            FROM LINK0.QLVT_DATHANG.DBO.PhieuNhap p
            JOIN LINK0.QLVT_DATHANG.DBO.CTPN ct ON p.MAPN = ct.MAPN
            JOIN LINK0.QLVT_DATHANG.DBO.Vattu vt ON vt.MAVT = ct.MAVT
            WHERE NGAY BETWEEN @DATEFROM AND @DATETO
            GROUP BY FORMAT(NGAY, 'MM-yyyy'), TENVT
            ORDER BY FORMAT(NGAY, 'MM-yyyy'), TENVT;
        END
        ELSE IF @TYPE = 'XUAT'
        BEGIN
            SELECT FORMAT(NGAY, 'MM-yyyy') AS thang_nam, 
                   TENVT, 
                   SUM(SOLUONG) AS tong_soluong,
                   SUM(SOLUONG * DONGIA) AS tri_gia
            FROM LINK0.QLVT_DATHANG.DBO.PhieuXuat p
            JOIN LINK0.QLVT_DATHANG.DBO.CTPX ct ON p.MAPX = ct.MAPX
            JOIN LINK0.QLVT_DATHANG.DBO.Vattu vt ON vt.MAVT = ct.MAVT
            WHERE NGAY BETWEEN @DATEFROM AND @DATETO
            GROUP BY FORMAT(NGAY, 'MM-yyyy'), TENVT
            ORDER BY FORMAT(NGAY, 'MM-yyyy'), TENVT;
        END
    END
END;
GO

