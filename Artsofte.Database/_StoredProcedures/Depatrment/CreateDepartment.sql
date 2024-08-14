CREATE PROCEDURE CreateDepartment
    @Name NVARCHAR(255),
    @Floor INT
AS
BEGIN
    INSERT INTO Department (Name, Floor)
    VALUES (@Name, @Floor)
END