CREATE PROCEDURE GetAllEmployees
AS
BEGIN
    SELECT employee.*, department.Name AS DepartmentName, language.Language
    FROM Employee employee
             LEFT JOIN Department department ON employee.DepartmentId = department.Id
             LEFT JOIN Language language ON employee.Id = language.EmployeeId;
END
GO