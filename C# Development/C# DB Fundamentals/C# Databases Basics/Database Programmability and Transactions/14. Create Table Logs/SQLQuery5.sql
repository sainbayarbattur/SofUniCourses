CREATE TRIGGER tr_InsertAccountInfo ON Accounts For Update
AS
DECLARE @newSum DECIMAL(15,2) = (SELECT Balance FROM inserted)
DECLARE @oldSum DECIMAL(15,2) =(SELECT Balance FROM deleted)	
DECLARE @AccId INT = (SELECT Id FROM inserted)

INSERT INTO Logs(AccountId,NewSum,OldSum)
VALUES
(@AccId,@newSum,@oldSum)