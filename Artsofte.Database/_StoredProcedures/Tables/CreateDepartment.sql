CREATE PROCEDURE CreateDepartmentTable
AS
BEGIN
    CREATE TABLE Department
    (
        Id INT PRIMARY KEY IDENTITY(1,1),
        Name NVARCHAR(255) NOT NULL,
        Floor INT NOT NULL CHECK (Floor BETWEEN -5 AND 100)
    );
END
GO