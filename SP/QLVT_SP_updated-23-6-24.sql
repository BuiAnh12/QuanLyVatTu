USE [QLVT_DATHANG]
GO
/****** Object:  View [dbo].[V_DS_PHANMANH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[V_DS_PHANMANH]
AS
SELECT TENCN=PUBS.description, TENSERVER= subscriber_server
FROM dbo.sysmergepublications PUBS, dbo.sysmergesubscriptions SUBS
WHERE PUBS.pubid= SUBS.PUBID AND PUBS.publisher <> SUBS.subscriber_server
AND PUBS.description <> N'TRA CỨU'
GO
/****** Object:  View [dbo].[view_DanhSachNhanVien]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[view_DanhSachNhanVien] 
AS
    SELECT 
        HO, 
        TEN, 
        CONCAT(HO, ' ', TEN) as HOTEN, 
        CONVERT(CHAR(10), NGAYSINH, 105) as NGAYSINH_FORMATTED, 
        SOCMND, 
        LUONG, 
        TrangThaiXoa
    FROM dbo.NHANVIEN
    ORDER BY TEN, HO
    OFFSET 0 ROWS;
GO
/****** Object:  View [dbo].[view_DanhSachVatTu]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create VIEW [dbo].[view_DanhSachVatTu] 
AS
    SELECT TENVT, MAVT, DVT, SOLUONGTON
	FROM Vattu 
	ORDER BY TENVT
	OFFSET 0 ROWS;
GO
/****** Object:  StoredProcedure [dbo].[SP_AddCTPNAndUpdateSOLUONGTON]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_AddCTPNAndUpdateSOLUONGTON]
    @MAPN nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    -- Begin a transaction
    BEGIN TRANSACTION;

    BEGIN TRY
        -- Insert the new record into the CTPN table
        INSERT INTO [dbo].[CTPN] (MAPN, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPN, @MAVT, @SOLUONG, @DONGIA);

        -- Update the SOLUONGTON in the Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @SOLUONG
        WHERE MAVT = @MAVT;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if any error occurs
        ROLLBACK TRANSACTION;

        -- Raise the error to the caller
        THROW;
    END CATCH
END;

GO
/****** Object:  StoredProcedure [dbo].[SP_CheckExistMasoDDHInPhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_CheckExistMasoDDHInPhieuNhap]
    @MasoDDH nchar(8),
    @ExistStatus BIT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    IF EXISTS (SELECT 1 FROM [dbo].[PhieuNhap] WHERE [MasoDDH] = @MasoDDH)
        SET @ExistStatus = 1;
    ELSE
        SET @ExistStatus = 0;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_ChiTietSoLuongTriGiaHangHoaNhapXuat]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE   PROCEDURE [dbo].[SP_ChiTietSoLuongTriGiaHangHoaNhapXuat]
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
/****** Object:  StoredProcedure [dbo].[sp_DanhSachNhanVien]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_DanhSachNhanVien]
AS 
BEGIN
	SELECT CONCAT(HO, ' ', TEN) as HOTEN, format(NGAYSINH, 'dd-MM-yyyy'), SOCMND, LUONG, TrangThaiXoa
	FROM NHANVIEN 
	ORDER BY TEN, HO
END
GO
/****** Object:  StoredProcedure [dbo].[sp_DanhSachVatTu]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_DanhSachVatTu]
AS 
BEGIN
	SELECT TENVT, MAVT, DVT, SOLUONGTON
	FROM Vattu 
	ORDER BY TENVT
END

GO
/****** Object:  StoredProcedure [dbo].[SP_DeleteCTDDH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteCTDDH]
    @MasoDDH nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Delete statement
        DELETE FROM [dbo].[CTDDH]
        WHERE [MasoDDH] = @MasoDDH;

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
/****** Object:  StoredProcedure [dbo].[SP_DeleteDatHangByMasoDDH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeleteDatHangByMasoDDH]
    @MasoDDH nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Delete statement
        DELETE FROM [dbo].[DatHang]
        WHERE [MasoDDH] = @MasoDDH;

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
/****** Object:  StoredProcedure [dbo].[SP_DeletePhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_DeletePhieuNhap]
    @MAPN nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Begin the transaction
        BEGIN TRANSACTION;

        -- Update Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - CTPN.SOLUONG  -- Decrease SOLUONGTON based on old CTPN values
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPN ON Vattu.MAVT = CTPN.MAVT
        WHERE CTPN.MAPN = @MAPN;

        -- Delete from CTPN table
        DELETE FROM CTPN
        WHERE MAPN = @MAPN;

		DELETE FROM PhieuNhap
        WHERE MAPN = @MAPN;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Raise an error or log the exception as needed
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[sp_DonHangKhongPhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_DonHangKhongPhieuNhap]
AS
BEGIN
    SELECT 
        DH.MasoDDH, 
        DH.Ngay, 
        DH.NhaCC, 
        NV.HO + ' ' + NV.TEN as HOTEN,
        VT.TENVT,
        CT.SOLUONG,
        CT.DONGIA
    FROM 
        DBO.DatHang AS DH
    JOIN 
        DBO.NhanVien AS NV ON DH.MANV = NV.MANV
    JOIN 
        DBO.CTDDH AS CT ON DH.MasoDDH = CT.MasoDDH
    JOIN 
        DBO.VatTu AS VT ON CT.MAVT = VT.MAVT
    LEFT JOIN 
        DBO.PhieuNhap AS PN ON DH.MasoDDH = PN.MasoDDH
    WHERE 
        PN.MasoDDH IS NULL
    ORDER BY 
        DH.Ngay, DH.MasoDDH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_generatePhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_generatePhieuNhap]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_generatePhieuXuat]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_generatePhieuXuat]
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
GO
/****** Object:  StoredProcedure [dbo].[SP_GetSOLUONGTONByMAVT]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_GetSOLUONGTONByMAVT]
    @MAVT nchar(4)
AS
BEGIN
    SET NOCOUNT ON;
    
    SELECT SOLUONGTON
    FROM LINK0.QLVT_DATHANG.dbo.Vattu
    WHERE MAVT = @MAVT;
END
GO
/****** Object:  StoredProcedure [dbo].[sp_HoatDongNhanVien]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_HoatDongNhanVien]
@MANV int,
@DATEFROM DATETIME,
@DATETO DATETIME
AS
BEGIN
	SELECT FORMAT(HoatDong.NGAY, 'yyyy-MM') AS THANGNAM, 
		   HoatDong.NGAY, 
		   HoatDong.MAPHIEU,
		   HoatDong.LOAI,
		   HoatDong.KHACH,
		   HoatDong.TENVT, 
		   HoatDong.SOLUONG,
		   HoatDong.DONGIA,
		   HoatDong.SOLUONG * HoatDong.DONGIA AS TRIGIA
		   
	FROM (
		SELECT 
			NGAY, 
			P.MAPN AS MAPHIEU, 
			'NHAP' AS LOAI,
			'' AS KHACH,
			TENVT,
			SOLUONG, 
			DONGIA
			
		FROM PhieuNhap AS P
		JOIN CTPN ON P.MAPN = CTPN.MAPN
		JOIN Vattu AS VT ON CTPN.MAVT = VT.MAVT
		WHERE NGAY BETWEEN @DATEFROM AND @DATETO 
		AND MANV = @MANV

		UNION ALL

		SELECT 
			NGAY, 
			P.MAPX AS MAPHIEU,
			'XUAT' AS LOAI,
			P.HOTENKH AS KHACH,
			TENVT, 
			SOLUONG, 
			DONGIA
		FROM PhieuXuat AS P
		JOIN CTPX ON P.MAPX = CTPX.MAPX
		JOIN Vattu AS VT ON CTPX.MAVT = VT.MAVT
		WHERE NGAY BETWEEN @DATEFROM AND @DATETO 
		AND MANV = @MANV
	) HoatDong
	ORDER BY HoatDong.NGAY, HoatDong.MAPHIEU, HoatDong.TENVT
END
GO
/****** Object:  StoredProcedure [dbo].[SP_IncreaseSOLUONGTON]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_IncreaseSOLUONGTON]
    @MAVT nchar(4),
    @IncreaseAmount int
AS
BEGIN
    SET NOCOUNT ON;

    UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
    SET SOLUONGTON = SOLUONGTON + @IncreaseAmount
    WHERE MAVT = @MAVT;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_CTPN_VS_VATTU]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insert_CTPN_VS_VATTU]
    @MAPN nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        -- Start the transaction
        BEGIN TRANSACTION;

        -- Insert into CTPN
        INSERT INTO CTPN (MAPN, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPN, @MAVT, @SOLUONG, @DONGIA);

        -- Update Vattu
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @SOLUONG
        WHERE MAVT = @MAVT;

        -- Commit the transaction if all operations succeed
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if there's any error
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Throw or handle the error as needed
        THROW;
    END CATCH;
END
GO
/****** Object:  StoredProcedure [dbo].[SP_Insert_CTPX_VS_VATTU]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_Insert_CTPX_VS_VATTU]
    @MAPX nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;
    
    BEGIN TRY
        BEGIN TRANSACTION;
        
        -- Thêm vào bảng CTPX
        INSERT INTO CTPX (MAPX, MAVT, SOLUONG, DONGIA)
        VALUES (@MAPX, @MAVT, @SOLUONG, @DONGIA);
        
        -- Cập nhật số lượng tồn trong bảng Vattu
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - @SOLUONG
        WHERE MAVT = @MAVT;
        
        -- Kiểm tra số lượng tồn sau khi trừ
        IF EXISTS (SELECT 1 FROM Vattu WHERE MAVT = @MAVT AND SOLUONGTON < 0)
        BEGIN
            -- Rollback transaction nếu số lượng tồn nhỏ hơn 0
            ROLLBACK TRANSACTION;
            THROW 50000, 'Số lượng tồn không đủ.', 1;
        END
        
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;
        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();
        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_InsertCTDDH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
/****** Object:  StoredProcedure [dbo].[sp_KiemTraMaKho]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_KiemTraMaKho]
	@MAKHO nchar(4)
as
begin
	if( exists( select 1 
				from LINK2.QLVT_DATHANG.DBO.KHO as K 
				where K.MAKHO = @MAKHO ) )
		return 1; -- ton tai
	return 0;-- khong ton tai
end
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraMaNV]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_KiemTraMaNV]
	@MANV int
as
begin
	-- Su dung site tra cuu
	if( exists( select 1 
				from LINK2.QLVT_DATHANG.DBO.NhanVien as nv 
				where nv.MANV = @MANV ) )
		return 1; -- ton tai
	return 0;-- khong ton tai
end
GO
/****** Object:  StoredProcedure [dbo].[sp_KiemTraMaVatTu]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[sp_KiemTraMaVatTu]
@MAVT nchar(4)
AS
BEGIN
	IF EXISTS(SELECT 1 
			  FROM Vattu VT  
			  WHERE VT.MAVT = @MAVT)
			RETURN 1; -- Mã Vattu đang dùng ở phân mảnh hiện tại
	ELSE IF EXISTS(SELECT 1
				   FROM LINK0.QLVT_DATHANG.DBO.Vattu VT  -- Dùng site chủ để tra cứu
				   WHERE VT.MAVT = @MAVT)
			RETURN 1; -- Mã Vattu đang dùng ở phân mảnh khác
	RETURN 0; -- Chưa tồn tại
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LayLogin]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_LayLogin]
/*
	SP nhằm truy xuất login nhân viên thông qua MANV -> trả về LoginName và Role
	
	-----------------------------------------------------------
	2 func sẽ dùng thường xuyên
		SUSER_SID(Login_name)	-> sid
		SUSER_SNAME(sid)		-> Login_name
	3 thuộc tính hay thấy:
		uid -> user_id tồn tại với mỗi user được tạo và mỗi group
		sid -> security_id tồn tại với mỗi login và user. Thuộc tính này sẽ map user vào login nào
	3 bảng hay dùng:
		sys.sysusers	-> bảng tổng hợp user và role
		sys.syslogins	-> bảng tổng hợp các login vào hệ thống
		sys.sysmembers	-> bảng tổng hợp mapping giữa user và role thông qua uid
	-----------------------------------------------------------

*/
    @MANV INT
AS
BEGIN

    DECLARE @UID INT, @TENLOGIN NVARCHAR(20)
    
    -- Lấy thông tin của LoginName và UID để phục vụ tìm role
    SELECT 
    @UID = UID, 
    @TENLOGIN = SUSER_SNAME(sid) 
    FROM sys.sysusers 
    WHERE NAME = CAST(@MANV AS VARCHAR(50))

    -- Truy vấn thông tin cần thiết về LoginName và Role
    SELECT TENLOGIN = @TENLOGIN,
           TENNHOM = NAME
    FROM sys.sysusers
    WHERE UID = (SELECT GROUPUID
                 FROM SYS.SYSMEMBERS
                 WHERE MEMBERUID = @UID)
END
GO
/****** Object:  StoredProcedure [dbo].[SP_LayThongTinNhanVien]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROC [dbo].[SP_LayThongTinNhanVien]
/*
	SP nhằm lấy thông tin nhân viên khi đăng nhập vào hệ thống
	
	-----------------------------------------------------------
	2 func sẽ dùng thường xuyên
		SUSER_SID(Login_name)	-> sid
		SUSER_SNAME(sid)		-> Login_name
	3 thuộc tính hay thấy:
		uid -> user_id tồn tại với mỗi user được tạo và mỗi group
		sid -> security_id tồn tại với mỗi login và user. Thuộc tính này sẽ map user vào login nào
	3 bảng hay dùng:
		sys.sysusers	-> bảng tổng hợp user và role
		sys.syslogins	-> bảng tổng hợp các login vào hệ thống
		sys.sysmembers	-> bảng tổng hợp mapping giữa user và role thông qua uid
	-----------------------------------------------------------

*/
@TENLOGIN NVARCHAR (50)
AS
DECLARE @TENUSER NVARCHAR(50), @UID INT
	SELECT @UID= UID, @TENUSER=NAME FROM sys.sysusers -- Ten User sẽ là MANV
	WHERE sid = SUSER_SID(@TENLOGIN)
	SELECT MANV = @TENUSER,
	HOTEN = (SELECT HO + ' ' + TEN FROM NHANVIEN WHERE MANV = @TENUSER ),
	TENNHOM = NAME
	FROM sys.sysusers -- Lấy role trực thuộc
	WHERE UID = 
				(SELECT GROUPUID
					FROM SYS.SYSMEMBERS
					WHERE MEMBERUID= @UID)
GO
/****** Object:  StoredProcedure [dbo].[sp_luanChuyenNV]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_luanChuyenNV] 
	@MANV INT, 
	@MACN nchar(10)
AS
DECLARE @LGNAME VARCHAR(50)
DECLARE @USERNAME VARCHAR(50)
SET XACT_ABORT ON; -- XACT_ABORT: 1 chạy hết 2 không chạy gì cả
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE;
BEGIN
	BEGIN DISTRIBUTED TRAN
		DECLARE @HONV NVARCHAR(40)
		DECLARE @TENNV NVARCHAR(10)
		DECLARE @DIACHINV NVARCHAR(100)
		DECLARE @NGAYSINHNV DATETIME
		DECLARE @CMND NVARCHAR(10)
		DECLARE @LUONGNV FLOAT						
		-- B1:	Lưu lại thông tin nhân viên cần chuyển chi nhánh -> điều kiện kiểm tra
		SELECT @HONV = HO, @TENNV = TEN, @DIACHINV = DIACHI, @NGAYSINHNV = NGAYSINH, @LUONGNV = LUONG, @CMND = SOCMND FROM NhanVien WHERE MANV = @MANV
		
		
		-- B2a:	Kiểm tra xem bên Site chuyển tới đã có dữ liệu nhân viên đó chưa. Nếu có rồi thì đổi trạng thái
		IF EXISTS(select 1
				from LINK1.QLVT_DATHANG.dbo.NhanVien
				where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
				and NGAYSINH = @NGAYSINHNV and LUONG = @LUONGNV and SOCMND = @CMND)
			BEGIN
				UPDATE LINK1.QLVT_DATHANG.dbo.NhanVien
				SET TrangThaiXoa = 0
				WHERE MANV = (	select MANV
								from LINK1.QLVT_DATHANG.dbo.NhanVien
								where HO = @HONV and TEN = @TENNV and DIACHI = @DIACHINV
										and NGAYSINH = @NGAYSINHNV and LUONG = @LUONGNV and SOCMND = @CMND)
			END
		ELSE

		-- B2b:	nếu chưa tồn tại thì thêm mới hoàn toàn vào chi nhánh mới với MANV sẽ là MANV lớn nhất hiện tại ở phân mảnh đó + 1
			BEGIN
				INSERT INTO LINK1.QLVT_DATHANG.dbo.NhanVien (MANV, HO, TEN, DIACHI, NGAYSINH, LUONG, MACN, TRANGTHAIXOA, SOCMND)
				VALUES ((SELECT MAX(MANV) FROM LINK0.QLVT_DATHANG.dbo.NhanVien) + 1, @HONV, @TENNV, @DIACHINV, @NGAYSINHNV, @LUONGNV, @MACN, 0, @CMND)
			END

		-- B4:	Đổi trạng thái xóa đối với tài khoản cũ ở site hiện tại
		UPDATE dbo.NhanVien
		SET TrangThaiXoa = 1
		WHERE MANV = @MANV
	COMMIT TRAN;

		-- B5: Xoa login của nv đó ở site đang đứng
	IF EXISTS(SELECT 1 FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR))
		BEGIN
			SET @LGNAME = CAST((SELECT SUSER_SNAME(sid) FROM sys.sysusers WHERE name = CAST(@MANV AS NVARCHAR)) AS VARCHAR(50))
			SET @USERNAME = CAST(@MANV AS VARCHAR(50))
			EXEC SP_DROPUSER @USERNAME;
			EXEC SP_DROPLOGIN @LGNAME;
		END
END
GO
/****** Object:  StoredProcedure [dbo].[sp_PhieuNvLapTrongNamTheoLoai]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[sp_PhieuNvLapTrongNamTheoLoai]
    @MANV INT,
    @LOAI CHAR,
    @NAM INT
AS
BEGIN
    IF @LOAI = 'N'
    BEGIN
        SELECT 
            ps.PHIEU, 
            ps.NGAY, 
            vt.TENVT, 
            ct.SOLUONG, 
            ct.DONGIA
        FROM 
            (SELECT MAPN AS PHIEU, NGAY 
             FROM PhieuNhap 
             WHERE MANV = @MANV AND YEAR(NGAY) = @NAM) AS ps
        JOIN CTPN AS ct ON ps.PHIEU = ct.MAPN
        JOIN VatTu AS vt ON ct.MAVT = vt.MAVT
        ORDER BY 
            ps.NGAY, ps.PHIEU;
    END
    ELSE
    BEGIN
        SELECT 
            ps.PHIEU, 
            ps.NGAY, 
            vt.TENVT, 
            ct.SOLUONG, 
            ct.DONGIA
        FROM 
            (SELECT MAPX AS PHIEU, NGAY 
             FROM PhieuXuat 
             WHERE MANV = @MANV AND YEAR(NGAY) = @NAM) AS ps
        JOIN CTPX AS ct ON ps.PHIEU = ct.MAPX
        JOIN VatTu AS vt ON ct.MAVT = vt.MAVT
        ORDER BY 
            ps.NGAY, ps.PHIEU;
    END
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_QuanLyPhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectCTDDHByMasoDDH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_SelectCTDDHByMasoDDH]
    @MasoDDH NCHAR(8)
AS
BEGIN
    SELECT MasoDDH, MAVT, SOLUONG, DONGIA
    FROM dbo.CTDDH
    WHERE MasoDDH = @MasoDDH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_SelectDatHangNotInPhieuNhap]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
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
GO
/****** Object:  StoredProcedure [dbo].[SP_ThemLogin]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_ThemLogin]
    @LoginName NVARCHAR(100),
    @Password NVARCHAR(100),
    @DatabaseName NVARCHAR(100),
    @UserName NVARCHAR(100),
    @DatabaseRole NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        -- Thêm Login vào database
        EXEC sp_addlogin @LoginName, @Password, @DatabaseName;

        -- Tắt password policy để ko bắt nhập lại pass mới vv
        EXEC('ALTER LOGIN [' + @LoginName + '] WITH CHECK_POLICY = OFF;');

        -- Tạo user cho login vừa tạo
        EXEC('USE [' + @DatabaseName + ']; CREATE USER [' + @UserName + '] FOR LOGIN [' + @LoginName + '];');

        -- Thêm user đó vào role
        EXEC sp_addrolemember @DatabaseRole, @UserName;

        -- Nếu là Công ty và Chi nhánh thì thêm role SecurytyAdmin để có thể tạo tk mới
        IF @DatabaseRole = 'CONGTY' OR @DatabaseRole = 'CHINHANH'
        BEGIN
            EXEC sp_addsrvrolemember @LoginName, 'securityadmin';
        END
    END TRY
    BEGIN CATCH
        -- Quăng lỗi 
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50001, @ErrorMessage, 1;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[sp_TimNV]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[sp_TimNV]
@X int
as
DECLARE @MACN VARCHAR(10), @HO nvarchar(50), @TEN nvarchar(10)
begin
	-- Kiểm tra nhân viên đã tồn tại ở site đang đứng không 
	if exists (select MANV from dbo.NhanVien where MANV = @X)
	begin
		select TENCN = (select ChiNhanh from dbo.ChiNhanh),HO, TEN 
		from NhanVien where MANV = @X
	end
	-- Kiểm tra ở site chủ thông tin nhân viên đó
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
/****** Object:  StoredProcedure [dbo].[sp_TongHopNhapXuat]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE   PROCEDURE [dbo].[sp_TongHopNhapXuat]
@FromDate DATETIME,
@ToDate DATETIME
AS
BEGIN
    /*
	-- Suppress FMTONLY query
    IF (1=0)
    BEGIN
        SET FMTONLY OFF;
    END;
	*/
    -- CTE cho tong_nhap
    WITH tong_nhap AS (
        SELECT SUM(CTPN.DONGIA * CTPN.SOLUONG) AS tong
        FROM CTPN
        JOIN PhieuNhap ON CTPN.MAPN = PhieuNhap.MAPN
        WHERE PhieuNhap.NGAY BETWEEN @FromDate AND @ToDate
    ),
    -- CTE cho tong_xuat
    tong_xuat AS (
        SELECT SUM(CTPX.DONGIA * CTPX.SOLUONG) AS tong
        FROM CTPX
        JOIN PhieuXuat ON CTPX.MAPX = PhieuXuat.MAPX
        WHERE PhieuXuat.NGAY BETWEEN @FromDate AND @ToDate
    ),
    -- CTE cho nhap
    nhap AS (
        SELECT PN.NGAY,
               SUM(CT.DONGIA * CT.SOLUONG) AS nhap,
               (SUM(CT.DONGIA * CT.SOLUONG) / (SELECT tong FROM tong_nhap)) AS ti_le_nhap
        FROM PhieuNhap AS PN
        JOIN CTPN AS CT ON PN.MAPN = CT.MAPN
        WHERE PN.NGAY BETWEEN @FromDate AND @ToDate
        GROUP BY PN.NGAY
    ),
    -- CTE cho xuat
    xuat AS (
        SELECT PX.NGAY,
               SUM(CT.DONGIA * CT.SOLUONG) AS xuat,
               (SUM(CT.DONGIA * CT.SOLUONG) / (SELECT tong FROM tong_xuat)) AS ti_le_xuat
        FROM PhieuXuat AS PX
        JOIN CTPX AS CT ON PX.MAPX = CT.MAPX
        WHERE PX.NGAY BETWEEN @FromDate AND @ToDate
        GROUP BY PX.NGAY
    )
    
    -- kết quả
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
/****** Object:  StoredProcedure [dbo].[SP_UpdateAndDeleteCTPNincreaseVattu]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateAndDeleteCTPNincreaseVattu]
    @MAPN nchar(8)
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Begin the transaction
        BEGIN TRANSACTION;

        -- Update Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - CTPN.SOLUONG  -- Decrease SOLUONGTON based on old CTPN values
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPN ON Vattu.MAVT = CTPN.MAVT
        WHERE CTPN.MAPN = @MAPN;

        -- Delete from CTPN table
        DELETE FROM CTPN
        WHERE MAPN = @MAPN;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Raise an error or log the exception as needed
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT 
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE();

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCTDDH]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCTDDH]
    @MasoDDH nchar(8),
    @MAVT nchar(4),
    @SOLUONG INT,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        -- Check if the row exists
        IF EXISTS (SELECT 1 FROM LINK0.QLVT_DATHANG.dbo.CTDDH WHERE MasoDDH = @MasoDDH AND MAVT = @MAVT)
        BEGIN
            -- Update existing row
            UPDATE LINK0.QLVT_DATHANG.dbo.CTDDH
            SET SOLUONG = @SOLUONG,
                DONGIA = @DONGIA
            WHERE MasoDDH = @MasoDDH AND MAVT = @MAVT;
        END
        ELSE
        BEGIN
            -- Insert new row
            INSERT INTO LINK0.QLVT_DATHANG.dbo.CTDDH (MasoDDH, MAVT, SOLUONG, DONGIA)
            VALUES (@MasoDDH, @MAVT, @SOLUONG, @DONGIA);
        END

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
/****** Object:  StoredProcedure [dbo].[SP_UpdateCTPNAndUpdateVattu]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCTPNAndUpdateVattu]
    @MAPN nchar(8),
    @MAVT nchar(4),
    @NewSOLUONG int,
    @NewDONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        -- Begin the transaction
        BEGIN TRANSACTION;

        -- Update Vattu table
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON - CTPN.SOLUONG  -- Decrease SOLUONGTON based on old CTPN values
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN LINK0.QLVT_DATHANG.dbo.CTPN ON Vattu.MAVT = CTPN.MAVT
        WHERE CTPN.MAPN = @MAPN;

        -- Update CTPN table with new values
        UPDATE LINK0.QLVT_DATHANG.dbo.CTPN
        SET 
            SOLUONG = @NewSOLUONG,
            DONGIA = @NewDONGIA
        WHERE MAPN = @MAPN AND MAVT = @MAVT;

        -- Increase Vattu table based on updated CTPN values
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = SOLUONGTON + @NewSOLUONG  -- Increase SOLUONGTON with new SOLUONG value
        WHERE MAVT = @MAVT;

        -- Commit the transaction
        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        -- Rollback the transaction if an error occurs
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        -- Raise an error or log the exception as needed
        THROW;
    END CATCH;
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateCTPXandVATTU]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateCTPXandVATTU]
    @MAPX nchar(8),
    @MAVT nchar(4),
    @SOLUONG int,
    @SOLUONGTON int,
    @DONGIA float
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRANSACTION;

    BEGIN TRY
        
        BEGIN
            -- Cập nhật lại CTPX
            UPDATE LINK0.QLVT_DATHANG.dbo.CTPX
            SET SOLUONG = @SOLUONG, DONGIA = @DONGIA
            WHERE MAPX = @MAPX AND MAVT = @MAVT;

            -- Cập nhật lại SOLUONGTON trong Vattu
            UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
            SET SOLUONGTON =@SOLUONGTON
            WHERE MAVT = @MAVT;

        END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        ROLLBACK TRANSACTION;

        -- Xử lý lỗi nếu có
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
GO
/****** Object:  StoredProcedure [dbo].[SP_UpdateSOLUONGTONVT]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_UpdateSOLUONGTONVT]
    @MAVT nchar(4),
    @SOLUONGTON int
AS
BEGIN
    SET NOCOUNT ON;

    -- Update the SOLUONGTON field where MAVT matches the provided value
    UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
    SET SOLUONGTON = @SOLUONGTON
    WHERE MAVT = @MAVT; 
END;
GO
/****** Object:  StoredProcedure [dbo].[SP_XoaLogin]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

CREATE PROCEDURE [dbo].[SP_XoaLogin]
    @login NVARCHAR(100),
    @user NVARCHAR(100)
AS
BEGIN
    BEGIN TRY
        -- Xóa user khỏi db
        EXEC('DROP USER [' + @user + '];')
        -- Xóa login khỏi db
        EXEC sp_droplogin @login;
    END TRY
    BEGIN CATCH
        -- Throw an error with a custom message
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50001, @ErrorMessage, 1;
    END CATCH
END
GO
/****** Object:  StoredProcedure [dbo].[SP_XoaPhieuXuat]    Script Date: 6/23/2024 11:11:02 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SP_XoaPhieuXuat]
    @MAPX nchar(8)
AS
BEGIN
    -- Start a transaction
    BEGIN TRANSACTION

    BEGIN TRY
        -- Update the SOLUONGTON in Vattu table by joining with CTPX
        UPDATE LINK0.QLVT_DATHANG.dbo.Vattu
        SET SOLUONGTON = Vattu.SOLUONGTON + CTPX.SOLUONG
        FROM LINK0.QLVT_DATHANG.dbo.Vattu
        INNER JOIN CTPX ON Vattu.MAVT = CTPX.MAVT
        WHERE CTPX.MAPX = @MAPX

        -- Delete from CTPX where MAPX matches
        DELETE FROM CTPX
        WHERE MAPX = @MAPX

        -- Delete from PhieuXuat where MAPX matches
        DELETE FROM PhieuXuat
        WHERE MAPX = @MAPX

        -- Commit the transaction
        COMMIT TRANSACTION
    END TRY
    BEGIN CATCH
        -- Rollback the transaction in case of error
        ROLLBACK TRANSACTION

        -- Handle the error
        DECLARE @ErrorMessage NVARCHAR(4000)
        DECLARE @ErrorSeverity INT
        DECLARE @ErrorState INT

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE()

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState)
    END CATCH
END
GO
