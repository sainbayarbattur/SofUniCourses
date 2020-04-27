CREATE FUNCTION
ufn_GetSalaryLevel(@salary DECIMAL(18,4))
RETURNS NVARCHAR(20)
AS
BEGIN
	DECLARE @SalaryLevel VARCHAR(20);

IF(@salary < 30000)
	SET @SalaryLevel = 'Low'
ELSE IF(@salary >= 30000 AND @salary <= 50000)
	SET @SalaryLevel = 'Average'
ELSE
	SET @SalaryLevel = 'High'

	RETURN @SalaryLevel
END;
