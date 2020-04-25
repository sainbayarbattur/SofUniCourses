CREATE TABLE Teachers
(
TeacherID INT NOT NULL,
[Name] VARCHAR(30),
ManagerID INT
)

ALTER TABLE Teachers
ADD PRIMARY KEY(TeacherID)

ALTER TABLE Teachers
ADD FOREIGN KEY(ManagerID) REFERENCES Teachers(TeacherID)

INSERT INTO Teachers(TeacherID, [Name], ManagerID)
VALUES
(101, 'John', NULL),
(102, 'Maya', 106),
(103, 'Silvia', 106),
(104, 'Ted', 105),
(105, 'Mark', 101),
(106, 'Greta', 101)

SELECT * FROM Teachers