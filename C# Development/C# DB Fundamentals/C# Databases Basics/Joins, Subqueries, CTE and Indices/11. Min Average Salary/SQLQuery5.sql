SELECT TOP 1 MIN(MinAverageSalary) AS MinAverageSalary FROM
(
SELECT AVG(SALARY) AS MinAverageSalary FROM Employees
GROUP BY DepartmentID
)AS A