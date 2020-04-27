CREATE VIEW V_EmployeesHiredAfter2000
AS
SELECT FirstName, LastName FROM Employees
WHERE DatePart(YEAR, HireDate) > 2000