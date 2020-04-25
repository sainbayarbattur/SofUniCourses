SELECT COUNT(*) - COUNT(mc.CountryCode) AS CountryCode
FROM Countries AS c
LEFT JOIN MountainsCountries AS mc
ON mc.CountryCode = c.CountryCode