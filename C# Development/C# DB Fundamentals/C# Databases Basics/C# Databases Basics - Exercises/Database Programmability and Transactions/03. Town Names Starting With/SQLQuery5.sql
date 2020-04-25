CREATE PROC usp_GetTownsStartingWith(@NAME VARCHAR(20))
AS
SELECT [Name] AS Town
FROM Towns
WHERE [Name] LIKE @NAME + '%'