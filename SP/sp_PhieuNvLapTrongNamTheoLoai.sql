USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_PhieuNvLapTrongNamTheoLoai]    Script Date: 3/31/2024 9:21:39 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[sp_PhieuNvLapTrongNamTheoLoai]
@MANV int, @LOAI char, @NAM int
as 
begin 
	if @loai = 'N'
		select ps.PHIEU, NGAY, TENVT, SOLUONG, DONGIA
		FROM (SELECT MAPN as PHIEU, NGAY from  PhieuNhap
		WHERE MANV = @MANV and YEAR(NGAY) = @NAM) ps,
		CTPN ct, VatTu vt
		WHERE ps.PHIEU=ct.MAPN and ct.MAVT = vt.MAVT
		ORDER BY NGAY, PS.PHIEU
	else
		select ps.PHIEU, NGAY, TENVT, SOLUONG, DONGIA
		FROM (SELECT MAPX as PHIEU, NGAY from  PhieuXuat
		WHERE MANV = @MANV and YEAR(NGAY) = @NAM) ps,
		CTPX ct, VatTu vt
		WHERE ps.PHIEU=ct.MAPX and ct.MAVT = vt.MAVT
		ORDER BY NGAY, PS.PHIEU
end
GO


