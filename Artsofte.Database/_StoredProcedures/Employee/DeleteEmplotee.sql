CREATE PROCEDURE DeleteEmployee
@EmployeeId INT
AS
BEGIN
    DELETE FROM Language WHERE EmployeeId = @EmployeeId;
    DELETE FROM Employee WHERE Id = @EmployeeId;
END;
