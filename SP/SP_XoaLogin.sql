USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[SP_XoaLogin]    Script Date: 3/31/2024 9:22:27 PM ******/
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
        -- Drop the user from the database
        EXEC('DROP USER [' + @user + '];')
        -- Drop the login from the server
        EXEC sp_droplogin @login;
    END TRY
    BEGIN CATCH
        -- Throw an error with a custom message
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50001, @ErrorMessage, 1;
    END CATCH
END

GO


