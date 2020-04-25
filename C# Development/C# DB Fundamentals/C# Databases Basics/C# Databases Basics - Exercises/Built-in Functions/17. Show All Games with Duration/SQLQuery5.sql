select Name as [Game],
Case
When DATEPART(HOUR,Start)>=0 and DATEPART(Hour,Start)<12 then 'Morning'
When DATEPART(HOUR,Start)>=12 and DATEPART(Hour,Start)<18 then 'Afternoon'
When DATEPART(HOUR,Start)>=18 and DATEPART(Hour,Start)<24 then 'Evening'
End as [Part of the day]
,
Case
when Duration<=3 then 'Extra Short'
when Duration>=4 and Duration<=6 then 'Short'
when Duration>6 then 'Long'
else 'Extra Long'
End as [Duration]
from Games
Order by name,[Duration],[Part of the day]