CREATE PROCEDURE CreateEmployeeTable
AS
BEGIN
    CREATE TABLE Employee 
    (
      Id INT PRIMARY KEY IDENTITY(1,1),
      DepartmentId INT NOT NULL,
      Name NVARCHAR(255) NOT NULL,
      Surname NVARCHAR(255) NOT NULL,
      Age INT NOT NULL CHECK (Age BETWEEN 18 AND 100),
      Gender INT NOT NULL,
      FOREIGN KEY (DepartmentId) REFERENCES Department(Id)
    );
END
GO