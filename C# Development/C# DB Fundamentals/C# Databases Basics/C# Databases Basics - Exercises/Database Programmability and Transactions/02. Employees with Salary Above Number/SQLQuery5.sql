CREATE PROC usp_GetEmployeesSalaryAboveNumber(@NUMBER DECIMAL(18, 4))
AS
SELECT FirstName, LastName
FROM Employees
WHERE Salary >= @NUMBER