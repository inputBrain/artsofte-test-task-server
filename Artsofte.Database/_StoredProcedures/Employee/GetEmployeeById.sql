CREATE OR ALTER PROCEDURE GetEmployeeById
@Id INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            e.Id,
            e.DepartmentId,
            e.LanguageId,
            e.Name,
            e.Surname,
            e.Age,
            e.Gender,
            d.Id AS DepartmentId,
            d.Name AS DepartmentName,
            l.Id AS LanguageId,
            l.Language AS LanguageName
        FROM Employee e
                 JOIN Department d ON e.DepartmentId = d.Id
                 JOIN Language l ON e.LanguageId = l.Id
        WHERE e.Id = @Id;
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
