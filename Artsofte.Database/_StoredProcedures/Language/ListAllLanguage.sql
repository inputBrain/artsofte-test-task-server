CREATE OR ALTER PROCEDURE ListAllLanguage
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            l.Id AS LanguageId,
            l.Language AS LanguageName,
            e.Id AS EmployeeId,
            e.Name AS EmployeeName,
            e.Surname AS EmployeeSurname,
            e.DepartmentId,
            e.LanguageId,
            e.Age,
            e.Gender
        FROM Language l
                 LEFT JOIN Employee e ON l.Id = e.DepartmentId
        ORDER BY l.Id, e.Id;
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
