SELECT EmployeeID, FirstName, LastName, d.[Name] AS DepartmentName
FROM Employees
RIGHT JOIN Departments AS d
ON Employees.DepartmentID = d.DepartmentID
WHERE d.DepartmentID = 3
ORDER BY EmployeeID