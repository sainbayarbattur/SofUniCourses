SELECT c.CountryCode, COUNT(mc.MountainRange)
FROM MountainsCountries AS c
JOIN Mountains AS mc
ON mc.Id = c.MountainId
WHERE c.CountryCode IN ('US', 'RU', 'BG')
GROUP BY c.CountryCode