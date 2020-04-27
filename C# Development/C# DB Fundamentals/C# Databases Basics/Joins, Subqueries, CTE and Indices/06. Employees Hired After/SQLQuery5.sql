SELECT FirstName, LastName, HireDate, d.[Name] AS DeptName
FROM Employees AS e
RIGHT JOIN Departments AS d
ON e.DepartmentID = d.DepartmentID
WHERE HireDate > '1-1-1999' AND d.Name IN ('Sales', 'Finance')
ORDER BY HireDate