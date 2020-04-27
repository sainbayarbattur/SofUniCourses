SELECT TOP 5 c.CountryName,
IIF(p.PeakName is null,'(no highest peak)',p.PeakName) as [Highest Peak Name],
IIF(p.Elevation is NULL,'0', MAX(p.Elevation)) as [Highest Peak Elevation],
IIF(m.MountainRange is NULL,'(no mountain)',m.MountainRange) as [Mountain] 

FROM Countries AS c
LEFT JOIN MountainsCountries mc ON mc.CountryCode = c.CountryCode
LEFT JOIN Mountains m ON mc.MountainId = m.Id
LEFT JOIN Peaks p ON p.MountainId = m.Id
GROUP BY c.CountryName,p.Elevation, p.PeakName, m.MountainRange
ORDER BY c.CountryName, [Highest Peak Name]