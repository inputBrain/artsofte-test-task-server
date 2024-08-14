CREATE PROCEDURE CreateLanguage
    @EmployeeId INT,
    @Language NVARCHAR(255)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Employee WHERE Id = @EmployeeId)
        BEGIN
            RAISERROR('Employee with Id %d does not exist.', 16, 1, @EmployeeId)
            RETURN
        END

    INSERT INTO Language (EmployeeId, Language)
    VALUES (@EmployeeId, @Language)
END
