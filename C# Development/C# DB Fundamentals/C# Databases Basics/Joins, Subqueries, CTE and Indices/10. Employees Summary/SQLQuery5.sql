SELECT TOP 50 e.EmployeeID, CONCAT(e.FirstName, ' ', e.LastName)
AS 'EmployeeName', CONCAT(m.FirstName, ' ', m.LastName) 'ManagerName',
d.Name
FROM Employees AS e
JOIN Employees AS m
ON  m.EmployeeID = e.ManagerID
JOIN Departments AS d
ON  e.DepartmentID = d.DepartmentID
ORDER BY EmployeeID