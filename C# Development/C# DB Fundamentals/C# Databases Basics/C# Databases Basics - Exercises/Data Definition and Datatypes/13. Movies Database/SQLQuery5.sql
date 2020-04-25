CREATE TABLE Directors 
(
Id INT PRIMARY KEY IDENTITY not null,
DirectorName NVARCHAR(MAX) NOT NULL,
Notes NVARCHAR(MAX)
);

CREATE TABLE Genres
(
Id INT PRIMARY KEY IDENTITY not null,
GenreName NVARCHAR(MAX) NOT NULL,
Notes NVARCHAR(MAX)
);
CREATE TABLE Categories
(
Id INT PRIMARY KEY IDENTITY not null,
CategoryName NVARCHAR(MAX) NOT NULL,
Notes NVARCHAR(MAX)
);
CREATE TABLE Movies
(
Id INT PRIMARY KEY IDENTITY not null,
Title NVARCHAR(MAX) not null,
DirectorId INT FOREIGN KEY REFERENCES Directors(Id) not null,
CopyrightYear INT not null,
Lenght INT not null,
CategoryId INT FOREIGN KEY REFERENCES Categories(Id) not null,
Rating INT not null,
Notes NVARCHAR(MAX)
);

INSERT INTO Directors (DirectorName,Notes) Values
('Jack','Notes1'),('Steward','Notes2'),('Stesward','Notes3'),('Stewward','Notes4'),('Stewarrd','Notes5');

INSERT INTO Genres(GenreName,Notes) VALUES
('Comedy','Funny'),('Drama','Sad'),('Love','love'),('Action','BS'),('Documental','Learning');

INSERT INTO Categories(CategoryName,Notes) VALUES
('nz1','notesnz1'),('nz2','notesnz2'),('nz3','notesnz3'),('nz4','notesnz4'),('nz5','notesnz5');


INSERT INTO Movies(Title,DirectorId,CopyrightYear,Lenght,CategoryId,Rating,Notes) values 
('Titanic',1,1998,120,4,4,'TItanicNotes'),
('Interstellar',3,2011,140,2,5,'InterstellarNotes'),
('IDK',2,2014,90,5,5,'IDKNotes'),
('Suits',4,2015,48,1,2,'SuitsNotes'),
('The100',5,2012,49,3,5,'The100Notes')