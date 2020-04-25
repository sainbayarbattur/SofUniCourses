CREATE PROC usp_GetEmployeesFromTown(@TOWNNAMES NVARCHAR(20))
AS
SELECT FirstName, LastName
FROM Employees e
JOIN Addresses a
ON e.AddressID = a.AddressID
JOIN Towns t
ON t.TownID = a.TownID
WHERE t.Name = @TOWNNAMES