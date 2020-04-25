CREATE TRIGGER tr_NewEmail ON Logs FOR INSERT 
AS
DECLARE @oldSum DECIMAL(15,2) =(SELECT TOP(1)OldSum FROM inserted)
DECLARE @newSum DECIMAL(15,2) = (SELECT TOP(1)NewSum FROM inserted)
DECLARE @AccId INT = (SELECT TOP(1) AccountId FROM inserted)
DECLARE @subject NVARCHAR(MAX) = CONCAT('Balance change for account: ',@AccId)
DECLARE @Body NVARCHAR(MAX) = CONCAT('On' ,GETDATE(), ' your balance was changed from ',@oldSum,' to ',@newSum)

INSERT INTO NotificationEmails(Recipient,Subject,Body) VALUES
(@AccId,@subject,@Body)