CREATE PROCEDURE CreateEmployee
    @DepartmentId INT,
    @LanguageId INT,
    @Name NVARCHAR(100),
    @Surname NVARCHAR(100),
    @Age INT,
    @Gender INT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO Employee (DepartmentId, LanguageId, Name, Surname, Age, Gender)
        VALUES (@DepartmentId, @LanguageId, @Name, @Surname, @Age, @Gender);

        DECLARE @NewEmployeeId INT = SCOPE_IDENTITY();

        SELECT
            e.Id,
            e.DepartmentId,
            e.LanguageId,
            e.Name,
            e.Surname,
            e.Age,
            e.Gender,
            d.Id AS DepartmentId,
            d.Name AS DepartmentName,
            l.Id AS LanguageId,
            l.Name AS LanguageName
        FROM Employee e
                 JOIN Department d ON e.DepartmentId = d.Id
                 JOIN Language l ON e.LanguageId = l.Id
        WHERE e.Id = @NewEmployeeId;

        COMMIT TRANSACTION;
        
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

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
