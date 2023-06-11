-- BD: ColegioABC



-- Un Estudiante puede pertenecer a un solo Curso,  un Curso puede tener varios Estudiantes.
-- Una Materia pertenece a varios Cursos y un Estudiante puede estar inscrito en varias Materias.
-- ACLARACIONES:
-- Estudiantes uno a muchos Cursos (un estudiante pertenece a un solo curso)
-- Estudiantes muchos a muchos Materias (Estudiante_Materia)
-- Cursos muchos a muchos Materias (Curso_Materia)



CREATE TABLE Estudiantes
   (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Nombre nvarchar(255) not null,
	Apellido nvarchar(255) not null,
	Edad smallint not null
   );

CREATE TABLE Cursos
   (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Nombre nvarchar(255) not null,
	IDEstudiante int,
	FOREIGN KEY (IDEstudiante) REFERENCES Estudiantes(id),
	UNIQUE (IDEstudiante)
   );
   
CREATE TABLE Materias
   (
	ID int IDENTITY(1,1) PRIMARY KEY,
	Nombre nvarchar(255) not null
   );
   
CREATE TABLE Estudiante_Materia
   (
	IDMateria int not null,
	IDEstudiante int not null,
	PRIMARY KEY (IDMateria, IDEstudiante),
	FOREIGN KEY (IDMateria) REFERENCES Materias(ID),
	FOREIGN KEY (IDEstudiante) REFERENCES Estudiantes(ID)  
   );
      
CREATE TABLE Curso_Materia
(
	IDCurso int not null,
	IDMateria int not null,
	PRIMARY KEY (IDCurso, IDMateria),
	FOREIGN KEY (IDCurso) REFERENCES Cursos(ID),
	FOREIGN KEY (IDMateria) REFERENCES Materias(ID) 
);
