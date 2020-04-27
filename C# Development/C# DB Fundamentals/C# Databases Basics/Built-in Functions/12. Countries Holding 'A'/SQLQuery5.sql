SELECT CountryName, IsoCode
FROM Countries
WHERE len(CountryName) - LEN(REPLACE(CountryName,'a','')) >= 3
ORDER BY IsoCode