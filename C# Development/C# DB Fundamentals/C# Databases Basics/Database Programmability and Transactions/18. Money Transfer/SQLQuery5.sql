CREATE PROC usp_TransferMoney(@SenderId INT, @ReceiverId INT, @Amount DECIMAL(18,4))
AS	
BEGIN TRANSACTION 
DECLARE @sender INT = (SELECT TOP(1) Id FROM Accounts WHERE Id=@SenderId)
DECLARE @receiver INT = (SELECT TOP(1) Id FROM Accounts WHERE Id=@ReceiverId)

IF(@sender IS NULL or @receiver IS NULL)
BEGIN
ROLLBACK
RAISERROR('Invalid account Id',16,1)
RETURN 
END

IF(@Amount<0)
BEGIN
ROLLBACK
RAISERROR ('Negative Money amount!',16,1)
RETURN
END

DECLARE @CurrentAmountSender DECIMAL(18,4) = (SELECT TOP(1) Balance FROM Accounts WHERE Id=@SenderId)

IF(@CurrentAmountSender-@Amount<0)
BEGIN
ROLLBACK
RAISERROR('Not enough money!',16,1)
RETURN
END


UPDATE Accounts
SET Balance-=@Amount
WHERE Id=@sender

UPDATE Accounts
SET Balance+=@Amount
WHERE Id= @receiver
COMMIT