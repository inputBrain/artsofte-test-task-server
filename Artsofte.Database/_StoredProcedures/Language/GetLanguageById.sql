CREATE PROCEDURE GetLanguageById
@Id INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            l.Id,
            l.Language,
            e.Id AS EmployeeId,
            e.Name AS EmployeeName,
            e.Surname AS EmployeeSurname,
            e.DepartmentId,
            e.LanguageId,
            e.Age,
            e.Gender
        FROM Language l
                 LEFT JOIN Employee e ON l.Id = e.LanguageId
        WHERE l.Id = @Id;
    END TRY
    BEGIN CATCH
        DECLARE @ErrorMessage NVARCHAR(4000);
        DECLARE @ErrorSeverity INT;
        DECLARE @ErrorState INT;

        SELECT
            @ErrorMessage = ERROR_MESSAGE(),
            @ErrorSeverity = ERROR_SEVERITY(),
            @ErrorState = ERROR_STATE;

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
    END CATCH
END;
