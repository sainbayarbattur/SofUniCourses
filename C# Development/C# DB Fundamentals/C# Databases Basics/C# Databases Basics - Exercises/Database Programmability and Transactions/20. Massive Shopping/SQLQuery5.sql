DECLARE @StamatID INT =(SELECT Id FROM UsersGames WHERE UserId=9 AND GameId=87)
DECLARE @cash DECIMAL(15,2) =(SELECT Cash FROM UsersGames WHERE UserId=9 AND GameId=87)
DECLARE @itemsPrice DECIMAL(15,2)=(SELECT SUM(Price) FROM Items WHERE MinLevel BETWEEN 11 AND 12)


IF(@cash>=@itemsPrice)
BEGIN
BEGIN TRANSACTION
UPDATE UsersGames
SET Cash-=@itemsPrice
WHERE Id=@StamatID
INSERT INTO UserGameItems(ItemId,UserGameId)
SELECT Id,@StamatID FROM Items WHERE MinLevel BETWEEN 11 AND 12
END
COMMIT

DECLARE @NewCash DECIMAL(15,2)=(SELECT Cash FROM UsersGames WHERE UserId =9 AND GameId=87)
DECLARE @NewitemsPrice DECIMAL(15,2)=(SELECT Sum(Price) FROM Items WHERE MinLevel BETWEEN 19 AND 21)

IF(@Newcash>=@NewitemsPrice)
BEGIN
BEGIN TRANSACTION
UPDATE UsersGames
SET Cash-=@NewitemsPrice
WHERE Id=@StamatID

INSERT INTO UserGameItems(ItemId,UserGameId)
SELECT Id,@StamatID FROM Items WHERE MinLevel between 19 and 21

COMMIT
END


SELECT i.NAME FROM UsersGames AS ug 
JOIN Games AS g ON g.Id=ug.GameId
JOIN Users AS u ON u.Id=ug.UserId
JOIN UserGameItems AS ugi ON ugi.UserGameId=ug.Id
JOIN Items AS i ON i.Id=ugi.ItemId
WHERE u.FirstName='Stamat' and g.NAME ='Safflower' 
ORDER BY i.NAME