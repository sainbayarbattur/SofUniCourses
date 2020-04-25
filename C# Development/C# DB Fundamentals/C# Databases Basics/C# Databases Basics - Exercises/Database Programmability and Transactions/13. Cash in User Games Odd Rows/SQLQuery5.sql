CREATE FUNCTION ufn_CashInUsersGames(@GameName VARCHAR(30))
RETURNS TABLE AS
RETURN
(
SELECT SUM(k.Cash) AS SumCash
FROM
(SELECT g.Name, ug.Cash, ROW_NUMBER() over (order by Cash desc ) as rn
FROM Games g JOIN UsersGames ug ON ug.GameId = g.Id
WHERE g.Name = @GameName) AS k
WHERE k.rn % 2 != 0
)