CREATE OR ALTER PROCEDURE UpdateEmployee
    @Id INT,
    @DepartmentId INT,
    @LanguageId INT,
    @Name NVARCHAR(100),
    @Surname NVARCHAR(100),
    @Age INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        UPDATE Employee
        SET
            DepartmentId = @DepartmentId,
            LanguageId = @LanguageId,
            Name = @Name,
            Surname = @Surname,
            Age = @Age
        WHERE Id = @Id;

        IF @@ROWCOUNT = 0
            BEGIN
                THROW 50000, 'Employee model is not updated', 1;
            END

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

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
