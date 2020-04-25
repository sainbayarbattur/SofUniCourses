SELECT TOP 5 EmployeeID, FirstName, Salary, d.[Name] AS DepartmentName
FROM Employees
RIGHT JOIN Departments AS d
ON d.DepartmentID = Employees.DepartmentID
WHERE Salary > 15000
ORDER BY d.DepartmentID