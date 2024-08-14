CREATE PROCEDURE CreateEmployee
    @DepartmentId INT,
    @Name NVARCHAR(255),
    @Surname NVARCHAR(255),
    @Age INT,
    @Gender INT,
    @Languages NVARCHAR(MAX)
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Department WHERE Id = @DepartmentId)
        BEGIN
            RAISERROR('Invalid department', 16, 1);
            RETURN;
        END

    BEGIN TRANSACTION;

    INSERT INTO Employee (DepartmentId, Name, Surname, Age, Gender)
    VALUES (@DepartmentId, @Name, @Surname, @Age, @Gender);

    DECLARE @EmployeeId INT = SCOPE_IDENTITY();

    INSERT INTO Language (EmployeeId, Language)
    SELECT @EmployeeId, value
    FROM STRING_SPLIT(@Languages, ',');

    COMMIT TRANSACTION;
END
GO