CREATE PROCEDURE CreateEmployee
    @DepartmentId INT,
    @Name NVARCHAR(255),
    @Surname NVARCHAR(255),
    @Age INT,
    @Gender INT,
    @LanguageId INT
AS
BEGIN
    IF NOT EXISTS (SELECT * FROM Department WHERE Id = @DepartmentId)
        BEGIN
            RAISERROR('Invalid department', 16, 1);
        END

    BEGIN TRANSACTION;

    INSERT INTO Employee (DepartmentId, Name, Surname, Age, Gender, LanguageId)
    VALUES (@DepartmentId, @Name, @Surname, @Age, @Gender, @LanguageId);

    DECLARE @EmployeeId INT = SCOPE_IDENTITY();

    COMMIT TRANSACTION;
END
GO