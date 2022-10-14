-- Crear base de datos

USE master
GO

IF NOT EXISTS (SELECT * FROM sys.sysdatabases WHERE name = 'ControlUniversitarioDB')
	CREATE DATABASE "ControlUniversitarioDB"
	GO
GO


USE ControlUniversitarioDB
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Estudiante')
	CREATE TABLE dbo.Estudiante
	(
		EstudianteID BIGINT IDENTITY(1,1),
		Identificacion VARCHAR(12) UNIQUE,
		Nombre VARCHAR(255) NOT NULL,
		PrimerApellido VARCHAR(255) NOT NULL,
		SegundoApellido  VARCHAR(255) NOT NULL,
		FechaDeNacimiento DATETIME NOT NULL,
		FechaDeIngreso DATETIME NOT NULL,
		CONSTRAINT PK_Estudiante PRIMARY KEY  CLUSTERED 
		(
			EstudianteID
		)
	)
	GO
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Curso' and xtype = 'U')
	CREATE TABLE dbo.Curso
	(
		CursoID INT IDENTITY(1,1),
		NombreDelCurso VARCHAR(80) UNIQUE,
		Descripcion TEXT NOT NULL,
		Precio MONEY NOT NULL,
		CONSTRAINT PK_Curso PRIMARY KEY  CLUSTERED 
		(
			CursoID
		)
	)

	GO
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'MatriculaDeCurso' and xtype = 'U')
	CREATE TABLE dbo.MatriculaDeCurso
	(
		EstudianteID BIGINT, 
		CursoID INT,
		FechaDeMatricula DATETIME NOT NULL,
		Cuatrimestre VARCHAR(80) NOT NULL,
		PrecioMatricula MONEY NOT NULL,
		CONSTRAINT PK_MatriculaDeCurso PRIMARY KEY  CLUSTERED 
		(
			EstudianteID,
			CursoID
		),
		CONSTRAINT FK_MatriculaDeCurso_Estudiante FOREIGN KEY 
		(
			EstudianteID

		) REFERENCES dbo.Estudiante (
			EstudianteID
		),
		CONSTRAINT FK_MatriculaDeCurso_Curso FOREIGN KEY 
		(
			CursoID

		) REFERENCES dbo.Curso (
			CursoID
		)
	)
	GO
GO


CREATE LOGIN UsuarioK456u2 WITH PASSWORD = 'fn803UXsdD82', DEFAULT_DATABASE = ControlUniversitarioDB
GO

CREATE USER UsuarioK456u2 for login UsuarioK456u2
GO

GRANT SELECT, INSERT, DELETE ON Estudiante TO UsuarioK456u2
GRANT SELECT, INSERT, DELETE ON Curso TO UsuarioK456u2
GRANT SELECT, INSERT, DELETE ON MatriculaDeCurso TO UsuarioK456u2
GO

-- Inserciones
USE ControlUniversitarioDB
GO

INSERT INTO dbo.Curso
           (NombreDelCurso, Descripcion, Precio)
     VALUES
           ('Matemáticas','Curso general',87990.23),
		   ('Literatura','Curso general',95000.00),
		   ('Ingeniería Informática','Curso general', 250369.17)
GO
