CREATE PROCEDURE DeleteDepartment
@Id INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Department WHERE Id = @Id)
        BEGIN
            RAISERROR('Department with Id %d does not exist.', 16, 1, @Id)
            RETURN
        END

    DELETE FROM Department WHERE Id = @Id
END