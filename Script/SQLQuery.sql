CREATE DATABASE GCStudyBuddyDB;

CREATE TABLE QA(
Id INT  PRIMARY KEY IDENTITY(1, 1),
Question NVARCHAR(3000),
Answer NVARCHAR(3000)
);

INSERT INTO QA(Question, Answer)
Values('What is [HttpGet()] used for?', 'To retrieve data from a database'),
('What is [HttpPost()] used for?', 'To add data to a database.Can be combined with a [FromBody] parameter to receive objects.'),
('What does Npm stand for?', 'Node Package manager'),
('How do you call APIs in Angular?', 'In Angular, you can make HTTP requests to APIs using the Angular HTTPCLIENT module.'),
('Where should the connection string be stored for an API?', 'appsettings.json');

SELECT * FROM QA;

CREATE TABLE UserFavorites(
FavoriteId INT PRIMARY KEY IDENTITY(1,1),
UserId NVARCHAR(30),
QuestionId INT NOT NULL FOREIGN KEY(QuestionId) REFERENCES QA(Id)
);

INSERT INTO UserFavorites(UserId, QuestionId)
VALUES(1, 3);
SELECT * FROM UserFavorites;
