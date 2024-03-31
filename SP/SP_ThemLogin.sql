USE [QLVT_DATHANG]
GO

/****** Object:  StoredProcedure [dbo].[SP_ThemLogin]    Script Date: 3/31/2024 9:21:55 PM ******/
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
        -- Add login
        EXEC sp_addlogin @LoginName, @Password, @DatabaseName;

        -- Disable password policy for the login
        EXEC('ALTER LOGIN [' + @LoginName + '] WITH CHECK_POLICY = OFF;');

        -- Create user for the login in the specified database
        EXEC('USE [' + @DatabaseName + ']; CREATE USER [' + @UserName + '] FOR LOGIN [' + @LoginName + '];');

        -- Add user to database role
        EXEC sp_addrolemember @DatabaseRole, @UserName;

        -- Add login to server role if necessary
        IF @DatabaseRole = 'CONGTY' OR @DatabaseRole = 'CHINHANH'
        BEGIN
            EXEC sp_addsrvrolemember @LoginName, 'securityadmin';
        END
    END TRY
    BEGIN CATCH
        -- Throw an error with a custom message
        DECLARE @ErrorMessage NVARCHAR(4000) = ERROR_MESSAGE();
        THROW 50001, @ErrorMessage, 1;
    END CATCH
END

GO


