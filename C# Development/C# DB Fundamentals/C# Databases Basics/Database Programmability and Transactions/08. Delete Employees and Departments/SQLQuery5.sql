CREATE proc usp_DeleteEmployeesFromDepartment (@departmentId INT)
as
Alter Table Departments
alter column ManagerID int null

declare @EmployeesToDelete  Table (Id int)
insert into @EmployeesToDelete
Select EmployeeID from Employees where DepartmentID =@departmentId

delete EmployeesProjects
where EmployeeID in (Select Id from @EmployeesToDelete)

Update Employees
set ManagerID=NULL
where ManagerID in (select id from @EmployeesToDelete)

update Departments
set ManagerID = null
where ManagerID in (select Id from @EmployeesToDelete)

delete from Employees
where EmployeeID in (Select Id from @EmployeesToDelete)

Delete Departments
where DepartmentID=@departmentId	

Select Count(EmployeeID) as [Employees to Delete] from Employees
where DepartmentID=@departmentId