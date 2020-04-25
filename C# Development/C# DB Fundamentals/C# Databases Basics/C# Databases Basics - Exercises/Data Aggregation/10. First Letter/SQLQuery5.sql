SELECT LEFT(FirstName, 1) AS FirstLetter
FROM WizzardDeposits
GROUP BY LEFT(FirstName, 1), DepositGroup
HAVING DepositGroup = 'Troll Chest'
ORDER BY FirstLetter