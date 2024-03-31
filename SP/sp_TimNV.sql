USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[sp_TimNV]    Script Date: 3/31/2024 9:22:08 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE procedure [dbo].[sp_TimNV]
@X int
as
DECLARE @MACN VARCHAR(10), @HO nvarchar(50), @TEN nvarchar(10)
begin
	if exists (select MANV from dbo.NhanVien where MANV = @X)
	begin
		select TENCN = (select ChiNhanh from dbo.ChiNhanh),HO, TEN 
		from NhanVien where MANV = @X
	end
	else if exists ( select MANV from LINK0.QLVT_DATHANG.dbo.NHANVIEN where MANV = @X)
	begin 
		SELECT @MACN= MACN, @HO=HO, @TEN=TEN
		FROM LINK0.QLVT_DATHANG.dbo.NHANVIEN WHERE MANV=@X
			SELECT TENCN=CHINHANH, HO=@HO, TEN =@TEN
			FROM LINK0.QLVT_DATHANG.dbo.CHINHANH WHERE MACN=@MACN
	end
	else
		raiserror('Ma nhan vien ban tim khong ton tai',16,1);
end
GO


