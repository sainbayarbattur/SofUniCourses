CREATE PROC usp_WithdrawMoney (@AccountId INT , @MoneyAmount DECIMAL(18,4))
AS	
BEGIN TRANSACTION
DECLARE @account INT = (SELECT TOP(1) Id FROM Accounts WHERE Id=@AccountId)

IF(@account IS NULL)
BEGIN
ROLLBACK
RAISERROR('Invalid account Id',16,1)
RETURN 
END

DECLARE @CurrentAmount DECIMAL(18,4) = (SELECT TOP(1) Balance FROM Accounts WHERE Id=@AccountId)

IF(@MoneyAmount<0)
BEGIN
ROLLBACK
RAISERROR ('Negative Money amount!',16,1)
RETURN
END

IF(@CurrentAmount-@MoneyAmount<0)
BEGIN
ROLLBACK
RAISERROR('Not enough money!',16,1)
RETURN
END

UPDATE Accounts
SET Balance-=@MoneyAmount
WHERE Id=@AccountId
COMMIT