SELECT TownID, [Name] FROM Towns
WHERE SUBSTRING([Name], 1, 1) IN ('M', 'K', 'B', 'E')
ORDER BY [Name]