SELECT TownID, [Name] FROM Towns
WHERE NOT SUBSTRING([Name], 1, 1) IN ('R','B', 'D')
ORDER BY [Name]