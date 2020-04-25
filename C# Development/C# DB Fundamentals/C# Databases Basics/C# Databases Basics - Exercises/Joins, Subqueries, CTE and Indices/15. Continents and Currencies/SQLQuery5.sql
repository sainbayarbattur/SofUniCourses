SELECT 
d.ContinentCode,
d.CurrencyCode,
d.CurrencyUsage
FROM (
	SELECT 
		co.ContinentCode,
		cu.CurrencyCode,
		COUNT(c.CurrencyCode) AS CurrencyUsage,
		DENSE_RANK() OVER (PARTITION BY co.ContinentCode ORDER BY COUNT(c.CurrencyCode) DESC) AS [rank]
	FROM 
		Currencies AS cu
		INNER JOIN Countries AS c
		ON c.CurrencyCode = cu.CurrencyCode
		INNER JOIN Continents AS co
		ON co.ContinentCode = c.ContinentCode
	GROUP BY co.ContinentCode, cu.CurrencyCode
	HAVING COUNT(c.CurrencyCode) > 1) AS d
WHERE d.rank = 1
ORDER BY D.ContinentCode
