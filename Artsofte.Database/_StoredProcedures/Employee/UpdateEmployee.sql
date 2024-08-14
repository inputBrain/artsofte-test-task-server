CREATE PROCEDURE UpdateEmployee
    @Id INT,
    @DepartmentId INT,
    @Name NVARCHAR(255),
    @Surname NVARCHAR(255),
    @Age INT,
    @Gender INT,
    @Languages NVARCHAR(MAX)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Employee WHERE Id = @Id)
        BEGIN
            RAISERROR('Employee not found', 16, 1);
            RETURN;
        END

    IF NOT EXISTS (SELECT * FROM Department WHERE Id = @DepartmentId)
        BEGIN
            RAISERROR('Invalid department', 16, 1);
            RETURN;
        END

    BEGIN TRANSACTION;

    UPDATE Employee
    SET DepartmentId = @DepartmentId,
        Name = @Name,
        Surname = @Surname,
        Age = @Age,
        Gender = @Gender
    WHERE Id = @Id;

    DELETE FROM Language WHERE EmployeeId = @Id;

    INSERT INTO Language (EmployeeId, Language)
    SELECT @Id, value
    FROM STRING_SPLIT(@Languages, ',');

    COMMIT TRANSACTION;
END
GO