CREATE TABLE Passports
(
PassportID INT PRIMARY KEY NOT NULL,
PassportNumber VARCHAR(8) NOT NULL
)

CREATE TABLE Persons
(
PersonID INT PRIMARY KEY IDENTITY NOT NULL,
FirstName VARCHAR(30) NOT NULL,
Salary MONEY NOT NULL,
PassportID INT FOREIGN KEY REFERENCES Passports(PassportID)
)

INSERT INTO Passports(PassportID, PassportNumber) VALUES
(102, 'N34FG21B'),
(103, 'K65LO4R7'),
(101, 'ZE657QP2')

INSERT INTO Persons(FirstName, Salary, PassportID) VALUES
('Roberto', 43300.00, 102),
('Tom', 56100.00, 103),
('Yana', 60200.00, 101)

SELECT * FROM Passports

SELECT * FROM Persons
