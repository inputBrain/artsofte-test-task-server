CREATE TABLE EmployeeLanguages 
(
   EmployeeId INT NOT NULL,
   LanguageId INT NOT NULL,
   PRIMARY KEY (EmployeeId, LanguageId),
   FOREIGN KEY (EmployeeId) REFERENCES Employee(Id),
   FOREIGN KEY (LanguageId) REFERENCES Language(Id)
)
