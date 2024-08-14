CREATE PROCEDURE UpdateLanguage
    @Id INT,
    @EmployeeId INT,
    @Language NVARCHAR(255)
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Language WHERE Id = @Id)
        BEGIN
            RAISERROR('Language with Id %d does not exist.', 16, 1, @Id)
            RETURN
        END

    UPDATE Language
    SET EmployeeId = @EmployeeId, Language = @Language
    WHERE Id = @Id
END