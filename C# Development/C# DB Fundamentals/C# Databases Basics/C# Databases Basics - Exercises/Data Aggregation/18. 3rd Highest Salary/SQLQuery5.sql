SELECT DepartmentID, Salary
FROM (SELECT DepartmentID, Salary, DENSE_RANK() OVER (PARTITION BY DepartmentID ORDER BY Salary DESC)
AS RANK
FROM Employees) as tmp
WHERE tmp.RANK = 3
GROUP BY DepartmentID, tmp.Salary