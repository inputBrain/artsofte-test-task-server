CREATE OR ALTER PROCEDURE CreateDatabase
AS
BEGIN
    DECLARE @SQL NVARCHAR(MAX);

    SET @SQL = N'CREATE DATABASE artsofte_db;';
    EXEC sp_executesql @SQL;

    SET @SQL = N'CREATE LOGIN artsofte_user WITH PASSWORD = ''fz7M91C6iKH1lTzB'';';
    EXEC sp_executesql @SQL;

    SET @SQL = N'USE artsofte_db;';
    EXEC sp_executesql @SQL;

    SET @SQL = N'CREATE USER artsofte_user FOR LOGIN artsofte_user;';
    EXEC sp_executesql @SQL;

    SET @SQL = N'ALTER ROLE db_owner ADD MEMBER artsofte_user;';
    EXEC sp_executesql @SQL;

    SET @SQL = N'GRANT CONNECT TO artsofte_user;';
    EXEC sp_executesql @SQL;
END
GO


