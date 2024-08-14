CREATE PROCEDURE GetDepartmentById
@Id INT
AS
BEGIN
    SELECT d.Id, d.Name, d.Floor
    FROM Department d
    WHERE d.Id = @Id
END