CREATE OR ALTER PROCEDURE ListAllDepartment
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        SELECT
            d.Id AS DepartmentId,
            d.Name AS DepartmentName,
            d.Floor AS DepartmentFloor,
            e.Id AS EmployeeId,
            e.Name AS EmployeeName,
            e.Surname AS EmployeeSurname,
            e.DepartmentId,
            e.LanguageId,
            e.Age,
            e.Gender
        FROM Department d
                 LEFT JOIN Employee e ON d.Id = e.DepartmentId
        ORDER BY d.Id, e.Id;
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
