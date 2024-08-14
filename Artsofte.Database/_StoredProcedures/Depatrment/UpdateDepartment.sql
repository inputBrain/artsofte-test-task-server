CREATE PROCEDURE UpdateDepartment
    @Id INT,
    @Name NVARCHAR(255),
    @Floor INT
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM Department WHERE Id = @Id)
        BEGIN
            RAISERROR('Department with Id %d does not exist.', 16, 1, @Id)
            RETURN
        END

    UPDATE Department
    SET Name = @Name, Floor = @Floor
    WHERE Id = @Id
END