SELECT TOP(50) [Name], FORMAT([Start], 'yyyy-MM-dd') AS 'Start'
FROM Games
WHERE DATEPART(yyyy ,[Start]) IN (2012, 2011)
ORDER BY [Start], [Name]