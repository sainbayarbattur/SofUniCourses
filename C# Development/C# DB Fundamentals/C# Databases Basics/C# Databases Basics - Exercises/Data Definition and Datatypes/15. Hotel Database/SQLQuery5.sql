CREATE TABLE Employees (
Id INT PRIMARY KEY IDENTITY NOT NULL, 
FirstName NVARCHAR(20), 
LastName NVARCHAR(20), 
Title NVARCHAR(100), 
Notes NVARCHAR(MAX)
);

create table Customers (
Id INT PRIMARY KEY IDENTITY NOT NULL,
AccountNumber nvarchar(100), 
FirstName nvarchar(20),
LastName nvarchar(20),
PhoneNumber BIGINT,
EmergencyName nvarchar(20),
EmergencyNumber BIGINT ,
Notes nvarchar(max)
);

CREATE TABLE RoomStatus (
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomStatus nvarchar(10), 
Notes nvarchar(max)
);

create table RoomTypes (
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomType nvarchar(10), 
Notes nvarchar(max)
);

create table BedTypes (
Id INT PRIMARY KEY IDENTITY NOT NULL,
BedType nvarchar(10), 
Notes nvarchar(max)
);

create table Rooms (
Id INT PRIMARY KEY IDENTITY NOT NULL,
RoomNumber int not null, 
RoomType int foreign key references RoomTypes(Id) not null, 
BedType int foreign key references BedTypes(Id) not null, 
Rate Money, 
RoomStatus int foreign key references RoomStatus(Id) not null , 
Notes nvarchar(max)
);

Create Table Payments (
Id int primary key identity not null, 
EmployeeId int foreign key references Employees(Id) not null, 
PaymentDate Datetime2 , 
AccountNumber nvarchar(100) , 
FirstDateOccupied Datetime2 , 
LastDateOccupied Datetime2 , 
TotalDays Datetime2 , 
AmountCharged money , 
TaxRate money , 
TaxAmount money , 
PaymentTotal money , 
Notes nvarchar(max));

create table Occupancies (
Id int primary key identity not null, 
EmployeeId int foreign key references Employees(Id) not null, 
DateOccupied datetime2 , 
AccountNumber nvarchar(100), 
RoomNumber int ,
RateApplied Money ,
PhoneCharge Money , 
Notes nvarchar(max)
)

Insert into Employees(FirstName,LastName,Title) Values
('Damian','Ivanov','Manager'),('Ivan','Ivanov','Worker'),('Pesho','Petrov','Worker');
insert into Customers(AccountNumber,FirstName,LastName,PhoneNumber) values
('ACNUMBER1','Damian','Ivanov',886500727),('ACNUMBER2','Ivan','Ivanov',886500717),('ACNUMBER3','Pesho','Petrov',0886500715);
insert into RoomStatus(RoomStatus) Values
('ready'),('taken'),('cleaning');
insert into RoomTypes(RoomType) values
('family'),('double'),('single');
insert into BedTypes(BedType) Values
('single'),('double'),('kingsize');
insert into Rooms(RoomNumber,RoomType,BedType,Rate,RoomStatus) Values
(420,1,3,20,1),(520,2,2,10,3),(620,3,1,30,2);


insert into Payments(EmployeeId,PaymentDate,AccountNumber,FirstDateOccupied,LastDateOccupied,AmountCharged) Values
(1,'2019-07-30','ACNUM1','2019-07-30','2019-08-06',200),
(2,'2019-08-30','ACNUM2','2019-08-30','2019-09-06',300),
(3,'2019-09-30','ACNUM3','2019-09-30','2019-10-06',400);

insert into Occupancies(EmployeeId,DateOccupied,RoomNumber,RateApplied) values
(1,'2019-07-30',420,200),
(2,'2019-08-30',520,300),
(3,'2019-09-30',320,500);