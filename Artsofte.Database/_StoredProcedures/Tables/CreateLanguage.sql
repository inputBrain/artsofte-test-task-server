CREATE PROCEDURE CreateLanguageTable
AS
BEGIN
    CREATE TABLE Language
    (
      Id INT PRIMARY KEY IDENTITY(1,1),
      EmployeeId INT NOT NULL,
      Language NVARCHAR(255) NOT NULL,
      FOREIGN KEY (EmployeeId) REFERENCES Employee(Id)
    );
END
GO