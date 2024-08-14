CREATE PROCEDURE DeleteLanguage
@Id INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Language WHERE Id = @Id)
        BEGIN
            RAISERROR('Language with Id %d does not exist.', 16, 1, @Id)
            RETURN
        END

    DELETE FROM Language WHERE Id = @Id
END