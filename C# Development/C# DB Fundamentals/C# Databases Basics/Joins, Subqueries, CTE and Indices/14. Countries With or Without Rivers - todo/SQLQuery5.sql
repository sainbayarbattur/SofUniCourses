SELECT TOP 5 c.CountryName, r.RiverName FROM Rivers AS r
FULL OUTER JOIN CountriesRivers AS cr
ON cr.RiverId = r.Id
FULL OUTER JOIN Countries AS c
ON c.CountryCode = cr.CountryCode 
FULL OUTER JOIN Continents AS co
ON c.ContinentCode = co.ContinentCode
WHERE co.ContinentName = 'Africa'
ORDER BY c.CountryName ASC