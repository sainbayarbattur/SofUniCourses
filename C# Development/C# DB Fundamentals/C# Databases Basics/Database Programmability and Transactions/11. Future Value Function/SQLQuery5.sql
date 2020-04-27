CREATE FUNCTION ufn_CalculateFutureValue(@Sum DECIMAL(19, 4), @YearlyInterestRate FLOAT, @NumberOfYears INT)
RETURNS DECIMAL(19, 4)
AS
BEGIN 
DECLARE @FV DECIMAL(19, 4)
SET @FV = @Sum * (POWER(1 + @YearlyInterestRate, @NumberOfYears))
RETURN @FV
END