CREATE OR ALTER PROCEDURE CreateTables
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Department]') AND type in (N'U'))
            BEGIN
                CREATE TABLE Department
                (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Name NVARCHAR(255) NOT NULL,
                    Floor INT NOT NULL
                );
            END

        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Language]') AND type in (N'U'))
            BEGIN
                CREATE TABLE Language
                (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    Language NVARCHAR(255) NOT NULL
                );
            END

        IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Employee]') AND type in (N'U'))
            BEGIN
                CREATE TABLE Employee
                (
                    Id INT IDENTITY(1,1) PRIMARY KEY,
                    DepartmentId INT NOT NULL,
                    LanguageId INT NOT NULL,
                    Name NVARCHAR(255) NOT NULL,
                    Surname NVARCHAR(255) NOT NULL,
                    Age INT NOT NULL,
                    Gender INT NOT NULL,

                    CONSTRAINT FK_Employee_Department FOREIGN KEY (DepartmentId) REFERENCES Department(Id),
                    CONSTRAINT FK_Employee_Language FOREIGN KEY (LanguageId) REFERENCES Language(Id)
                );
            END
    END TRY
    BEGIN CATCH
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
