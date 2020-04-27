SELECT FirstName FROM Employees
WHERE DepartmentID = 3 OR DepartmentID = 10 AND DatePart(Year,HireDate)>=1995 and DatePart(Year,HireDate)<=2005;