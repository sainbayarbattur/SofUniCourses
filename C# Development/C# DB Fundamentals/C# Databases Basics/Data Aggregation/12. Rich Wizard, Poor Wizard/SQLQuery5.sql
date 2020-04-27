SELECT SUM(SumDifference) AS SumDifference
FROM(SELECT wd.DepositAmount - (SELECT DepositAmount 
AS SumDifference 
FROM WizzardDeposits 
AS w
WHERE w.ID = wd.ID + 1) AS SumDifference
FROM WizzardDeposits AS wd) AS k