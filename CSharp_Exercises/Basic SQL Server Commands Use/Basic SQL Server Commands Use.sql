CREATE DATABASE CursoNet

USE CursoNet

CREATE TABLE Instructores(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nombre VARCHAR(50) NOT NULL,
	Apellido VARCHAR(50) NOT NULL
);

INSERT INTO Instructores (Nombre,Apellido)
VALUES ('Eugenio', 'Serrano')

INSERT INTO Instructores (Nombre,Apellido)
VALUES ('Carlos', 'Cornejo')

INSERT INTO Instructores (Nombre,Apellido)
VALUES ('Ezequiel', 'Etchecoin')

INSERT INTO Instructores (Nombre,Apellido)
VALUES ('Ruben', 'Benegas')

INSERT INTO Instructores (Nombre,Apellido)
VALUES ('Joaquín', 'Mateos')



SELECT Id, Nombre + ' ' + Apellido AS Descripcion FROM Instructores