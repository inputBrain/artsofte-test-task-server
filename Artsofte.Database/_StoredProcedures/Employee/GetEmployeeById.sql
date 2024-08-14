CREATE PROCEDURE GetEmployeeById
@Id INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Employee WHERE Id = @Id)
        BEGIN
            RAISERROR('Employee not found', 16, 1);
            RETURN;
        END

    SELECT e.*, d.Name AS DepartmentName, l.Language
    FROM Employee e
             LEFT JOIN Department d ON e.DepartmentId = d.Id
             LEFT JOIN Language l ON e.Id = l.EmployeeId
    WHERE e.Id = @Id;
END
GO