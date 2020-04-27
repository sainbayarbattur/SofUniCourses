CREATE PROC usp_GetHoldersWithBalanceHigherThan(@SuppliedNumber DECIMAL(18, 4))
AS
SELECT ac.FirstName, ac.LastName
FROM Accounts a
JOIN AccountHolders ac
ON a.AccountHolderId = ac.Id
GROUP BY ac.FirstName, ac.LastName
HAVING SUM(a.Balance) > @SuppliedNumber
ORDER BY FirstName, LastName