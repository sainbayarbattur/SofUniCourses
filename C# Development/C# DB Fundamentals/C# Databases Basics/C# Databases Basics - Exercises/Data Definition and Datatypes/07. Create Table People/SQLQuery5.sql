CREATE TABLE People
(
Id INT primary key identity,
Name NVARCHAR(200) NOT NULL,
Picture VARBINARY(MAX) CHECK(DATALENGTH(Picture) <= 2 * 1024 * 1024),
Height NUMERIC(3,2),
Weight NUMERIC(3,2),
Gender CHAR(1) CHECK([Gender] IN ('m','f')),
Birthdate DATE NOT NULL,
Biography NVARCHAR(MAX)
)

INSERT INTO People(Name,Gender,Birthdate,Biography) VALUES
('Ivan Ivanov','m', '01-01-2012','sdaaasdasd'),
('Aksd asdsd', 'f', '07-05-2011','asdasdasd'),
('YSDSD asdsad','f', '05-02-2010','wdsdsf'),
('Asdfsd dsfsd','f', '09-02-2091','asrtsd'),
('Asdfd asdtrtrtsd','m','07-09-2021','asrtrtsd')