USE Project2
SELECT * FROM Genres
INSERT INTO Genres (Name)
VALUES('Horror')
INSERT INTO Genres (Name)
VALUES('Action')
INSERT INTO Genres (Name)
VALUES('Romance')
INSERT INTO Genres (Name)
VALUES('Adventure')
INSERT INTO Genres (Name)
VALUES('Psychology')

USE Project2
SELECT * FROM Authors

INSERT INTO Authors (Name, Birth_year, Deceased)
VALUES('Carl Jung', 1890, 'true')

USE Project2

SELECT * FROM Books

INSERT INTO Books (Title, AuthorId, GenreId, ImageUrl)
VALUES
('Archetypes of the collective unconscious', 1, 5,  '/images/book_of_the_day.jpg')


USE Project2

DELETE FROM Books