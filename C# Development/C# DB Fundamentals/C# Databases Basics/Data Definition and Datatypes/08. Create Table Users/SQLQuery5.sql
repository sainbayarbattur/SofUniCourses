CREATE TABLE Users
(
Id BIGINT UNIQUE IDENTITY ,
Username VARCHAR(30) UNIQUE NOT NULL,
[Password] VARCHAR(26) NOT NULL,
ProfilePicture VARBINARY(MAX),
LastLoginTime DATETIME2,
IsDeleted BIT NOT NULL DEFAULT(0)
)

ALTER TABLE Users
ADD CONSTRAINT PK_Users PRIMARY KEY(ID);

ALTER TABLE Users
ADD CONSTRAINT CH_ProfilePicture CHECK(DATALENGTH(ProfilePicture)<=900*1024);

INSERT INTO Users(Username,[Password]) VALUES
('Ivan Ivanov', 'FRFRSF'),
('Aksd asdsd', 'FRFRSF'),
('YSDSD asdsad', 'FRFRSF'),
('Asdfsd dsfsd', 'FRFRSF'),
('Asdfd asdtrtrtsd', 'FRFRSF')