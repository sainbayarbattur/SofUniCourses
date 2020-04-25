CREATE PROC usp_AssignProject(@emloyeeId INT, @projectID INT)
AS
BEGIN
		BEGIN TRAN

				INSERT INTO EmployeesProjects
				VALUES (@emloyeeId,@projectID)
				DECLARE @count INT = (SELECT COUNT(*) FROM EmployeesProjects WHERE EmployeeID=@emloyeeId)
				IF(@count>3)
				BEGIN
				ROLLBACK
				RAISERROR('The employee has too many projects!',16, 1)
				END
		COMMIT
END