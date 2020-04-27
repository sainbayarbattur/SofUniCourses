SELECT TOP 10 FirstName, LastName, DepartmentID 
FROM Employees AS T1
WHERE Salary > (SELECT AVG(Salary) FROM Employees AS T2 WHERE T1.DepartmentID = T2.DepartmentID)
ORDER BY DepartmentID