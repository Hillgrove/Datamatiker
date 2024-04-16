CREATE TABLE Student (
	Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
	Name VARCHAR(50) NOT NULL,
	Email VARCHAR(50) NOT NULL
)

INSERT INTO Student
VALUES 
('Annika', 'annika@mail.dk'),
('Britta', 'britta@mail.dk'),
('Carina', 'carina@mail.dk'),
('Daniel', 'daniel@mail.dk');