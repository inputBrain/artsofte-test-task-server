CREATE OR ALTER PROCEDURE ListAllEmployee
    @Skip INT,
    @Take INT,
    @TotalCount INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        SELECT @TotalCount = COUNT(*)
        FROM Employee;

        SELECT e.Id, e.DepartmentId, e.LanguageId, e.Name, e.Surname, e.Age, e.Gender,
               d.Name AS DepartmentName,
               l.Language AS LanguageName
        FROM Employee e
                 JOIN Department d ON e.DepartmentId = d.Id
                 JOIN Language l ON e.LanguageId = l.Id
        ORDER BY e.Id
        OFFSET @Skip ROWS FETCH NEXT @Take ROWS ONLY;

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
