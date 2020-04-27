Create Table Categories
	(
	Id Int primary key identity not null,
	CategoryName NVARCHAR(MAX),
	DailyRate int,
	WeeklyRate Money,
	MonthlyRate Money,
	WeekendRate Money,

	);

	Create Table Cars
	(
	Id INT PRIMARY KEY identity not null,
	PlateNumber NVARCHAR(10),
	Manufacturer NVARCHAR(Max),
	Model NVARCHAR(MAX),
	CarYear int,
	CategoryId INT Foreign key REFERENCES Categories(Id) not null,
	Doors Int,
	Picture Varbinary,
	Condition Nvarchar(10),
	Avaiable Nvarchar(10),
	);

	Create Table Employees 
	(
	Id INT PRIMARY KEY IDENTITY not null, 
	FirstName NVARCHAR(20), 
	LastName NVARCHAR(20), 
	Title NVARCHAR(MAX), 
	Notes NVARCHAR(MAX)
	);

	CREATE Table Customers 
	(
	Id int primary key identity not null, 
	DriverLicenceNumber nvarchar(10), 
	FullName nvarchar(max),
	Address nvarchar(max), 
	City nvarchar(10), 
	ZIPCode nvarchar(10), 
	Notes nvarchar(max)
	);

	create table RentalOrders 
	(
	Id int primary key identity not null, 
	EmployeeId int foreign key references Employees(Id) not null, 
	CustomerId int foreign key references Customers(Id) not null, 
	CarId int foreign key references Cars(Id) not null, 
	TankLevel decimal(10,2), 
	KilometrageStart 
	int, 
	KilometrageEnd int , 
	TotalKilometrage int , 
	StartDate Datetime2, 
	EndDate Datetime2, 
	TotalDays int, 
	RateApplied Money, 
	TaxRate Money, 
	OrderStatus nvarchar(10),
	Notes NVARCHAR(MAX)
	)

	Insert INTO Categories(CategoryName,DailyRate,WeeklyRate,MonthlyRate,WeekendRate) VALUES
	('Sport',20,120,400,50),
	('Van',10,60,200,30),
	('Jeep',15,80,300,40);


	Insert into Cars(PlateNumber,Manufacturer,Model,CarYear,CategoryId,Doors,Condition,Avaiable) Values	
	('CA1234CP','Renault','Laguna2',2003,1,5,'Used','yes'),
	('CA4321PC','Peugeot','307',2007,2,5,'New','no'),
	('CD9876OC','Subaru','WSX',2009,3,3,'Used','yes');

	Insert into Employees(FirstName,LastName,Title) Values
	('Damian','Ivanov','nz'),
	('Ivanov','Ivanov','ddz'),
	('Pesho','Petrov','rabotnik');

	Insert into Customers(DriverLicenceNumber,FullName,ZIPCode) values
	('123456789','Damian Ivanov',1281),
	('987654321','Ivan Ivanov',1280),
	('654321789','Pesho Petrov',1212);

	Insert into RentalOrders(EmployeeId,CustomerId,CarId,TankLevel,KilometrageStart,KilometrageEnd,TotalKilometrage,StartDate,EndDate,TotalDays,RateApplied,TaxRate,OrderStatus)Values
	(1,1,1,0.7,1200,1500,1500-1200,'2019-07-30','2019-08-03',DATEDIFF(Day,'2019-07-30','2019-08-03'),15,20,'ready'),
	(2,2,2,0.5,1200,1500,1500-1200,'2019-07-31','2019-08-04',DATEDIFF(DAY,'2019-07-31','2019-08-04'),20,30,'not ready'),
	(3,3,3,0.3,1200,1500,1500-1200,'2019-08-01','2019-08-05',DATEDIFF(DAY,'2019-08-01','2019-08-05'),25,40,'not ready');