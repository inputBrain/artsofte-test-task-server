CREATE PROCEDURE GetLanguageById
@Id INT
AS
BEGIN
    SELECT l.Id, l.EmployeeId, l.Language, e.Name, e.Surname
    FROM Language l
             LEFT JOIN Employee e ON l.EmployeeId = e.Id
    WHERE l.Id = @Id
END