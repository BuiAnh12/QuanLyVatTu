USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_TongHopNhapXuat]    Script Date: 6/18/2024 8:50:15 AM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE OR ALTER   PROCEDURE [dbo].[sp_TongHopNhapXuat]
@FromDate DATETIME,
@ToDate DATETIME
AS
BEGIN
    -- Suppress FMTONLY query
    IF (1=0)
    BEGIN
        SET FMTONLY OFF;
    END;

    -- CTE for tong_nhap
    WITH tong_nhap AS (
        SELECT SUM(CTPN.DONGIA * CTPN.SOLUONG) AS tong
        FROM CTPN
        JOIN PhieuNhap ON CTPN.MAPN = PhieuNhap.MAPN
        WHERE PhieuNhap.NGAY BETWEEN @FromDate AND @ToDate
    ),
    -- CTE for tong_xuat
    tong_xuat AS (
        SELECT SUM(CTPX.DONGIA * CTPX.SOLUONG) AS tong
        FROM CTPX
        JOIN PhieuXuat ON CTPX.MAPX = PhieuXuat.MAPX
        WHERE PhieuXuat.NGAY BETWEEN @FromDate AND @ToDate
    ),
    -- CTE for nhap
    nhap AS (
        SELECT PN.NGAY,
               SUM(CT.DONGIA * CT.SOLUONG) AS nhap,
               (SUM(CT.DONGIA * CT.SOLUONG) / (SELECT tong FROM tong_nhap)) AS ti_le_nhap
        FROM PhieuNhap AS PN
        JOIN CTPN AS CT ON PN.MAPN = CT.MAPN
        WHERE PN.NGAY BETWEEN @FromDate AND @ToDate
        GROUP BY PN.NGAY
    ),
    -- CTE for xuat
    xuat AS (
        SELECT PX.NGAY,
               SUM(CT.DONGIA * CT.SOLUONG) AS xuat,
               (SUM(CT.DONGIA * CT.SOLUONG) / (SELECT tong FROM tong_xuat)) AS ti_le_xuat
        FROM PhieuXuat AS PX
        JOIN CTPX AS CT ON PX.MAPX = CT.MAPX
        WHERE PX.NGAY BETWEEN @FromDate AND @ToDate
        GROUP BY PX.NGAY
    )
    
    -- Result query
    SELECT 
        COALESCE(nhap.NGAY, xuat.NGAY) AS NGAY,
        ISNULL(nhap.nhap, 0) AS nhap,
        ISNULL(nhap.ti_le_nhap, 0) AS ti_le_nhap,
        ISNULL(xuat.xuat, 0) AS xuat,
        ISNULL(xuat.ti_le_xuat, 0) AS ti_le_xuat
    FROM nhap
    FULL JOIN xuat ON nhap.NGAY = xuat.NGAY
    ORDER BY NGAY;
END
GO

