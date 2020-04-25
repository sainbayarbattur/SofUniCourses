Select*
From(
Select EmployeeID,FirstName,LastName,Salary,
DENSE_RANK() OVER (Partition by Salary
order by EmployeeID) as Rank
from Employees 
where Salary between 10000 AND 50000 ) as Sorted
where Sorted.Rank=2
order by Salary desc