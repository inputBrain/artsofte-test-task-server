CREATE OR ALTER PROCEDURE GetDepartmentById
@Id INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            d.Id,
            d.Name,
            d.Floor,
            e.Id AS EmployeeId,
            e.Name AS EmployeeName,
            e.Surname AS EmployeeSurname,
            e.DepartmentId,
            e.LanguageId,
            e.Age,
            e.Gender
        FROM Department d
                 LEFT JOIN Employee e ON d.Id = e.DepartmentId
        WHERE d.Id = @Id;
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