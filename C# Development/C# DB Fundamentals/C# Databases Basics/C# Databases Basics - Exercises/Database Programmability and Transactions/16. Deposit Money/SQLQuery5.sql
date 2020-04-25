CREATE PROC usp_DepositMoney (@AccountId INT , @MoneyAmount DECIMAL(18,4))
AS
BEGIN TRANSACTION
DECLARE @account INT = (SELECT Id FROM Accounts WHERE Id=@AccountId)
IF(@account is null)

BEGIN
ROLLBACK
RAISERROR('Invalid account Id',16,1)
RETURN 
END
IF(@MoneyAmount<0)
BEGIN
ROLLBACK
RAISERROR ('Negative Money amount!',16,1)
RETURN
END

UPDATE Accounts
SET Balance+=@MoneyAmount
WHERE Id=@AccountId
COMMIT