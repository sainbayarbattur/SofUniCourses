SELECT TOP 5 e.EmployeeID, e.FirstName, p.Name
FROM Employees AS e
INNER JOIN EmployeesProjects AS ep
ON e.EmployeeID = ep.EmployeeID
INNER JOIN Projects AS p
ON p.ProjectID = ep.ProjectID
WHERE p.StartDate > '2002-08-13'
ORDER BY EmployeeID
