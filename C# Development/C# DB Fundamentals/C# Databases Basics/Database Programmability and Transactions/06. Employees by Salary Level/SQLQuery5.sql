CREATE PROC usp_EmployeesBySalaryLevel(@LEVEL VARCHAR(20))
AS
SELECT FirstName, LastName
FROM Employees
WHERE @LEVEL = dbo.ufn_GetSalaryLevel(Salary)
