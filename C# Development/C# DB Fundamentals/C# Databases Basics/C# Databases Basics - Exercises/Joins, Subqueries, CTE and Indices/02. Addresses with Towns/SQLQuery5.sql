SELECT TOP 50 FirstName, LastName, t.[Name], AddressText
FROM Addresses
RIGHT JOIN Towns AS t
ON Addresses.TownID = t.TownID
RIGHT JOIN Employees as e
ON Addresses.AddressID = e.AddressID
ORDER BY FirstName, LastName