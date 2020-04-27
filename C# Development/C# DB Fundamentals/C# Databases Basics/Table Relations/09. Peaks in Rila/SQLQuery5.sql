SELECT MountainRange, PeakName, Elevation
FROM Peaks, Mountains
WHERE Mountains.Id = 17 AND Peaks.MountainId = 17
ORDER BY Elevation DESC