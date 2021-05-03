SELECT * FROM Genre
INSERT INTO Genre (Name)
VALUES('Horror')
INSERT INTO Genre (Name)
VALUES('Action')
INSERT INTO Genre (Name)
VALUES('Romance')
INSERT INTO Genre (Name)
VALUES('Adventure')
INSERT INTO Genre (Name)
VALUES('Psychology')


SELECT * FROM Authors

INSERT INTO Authors (Name, Birth_year, Deceased)
VALUES('Carl Jung', 1890, 'true')

SELECT * FROM Books

INSERT INTO Books (Title, AuthorId, GenreId, ImageUrl)
VALUES
('Archetypes of the collective unconscious', 1, 5,  '\images\book_of_the_day.jpg')