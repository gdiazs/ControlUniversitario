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
		Escuela VARCHAR(200),
		NombreDelCurso VARCHAR(80) UNIQUE,
		Descripcion TEXT,
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

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'Carrera' and xtype = 'U')
	CREATE TABLE dbo.Carrera
	(
		CarreraID INTEGER, 
		NombreCarrera VARCHAR(200)
		CONSTRAINT PK_Carrera PRIMARY KEY  CLUSTERED 
		(
			CarreraID
		)
	)
	GO
GO

IF NOT EXISTS (SELECT * FROM sysobjects WHERE name = 'CarreraCurso' and xtype = 'U')
	CREATE TABLE dbo.CarreraCurso
	(
		CarreraID INT, 
		CursoID INT
		CONSTRAINT PK_CarreraCurso PRIMARY KEY  CLUSTERED 
		(
			CarreraID, 
			CursoID
		),
		CONSTRAINT FK_CarreraCurso_Carrera FOREIGN KEY 
		(
			CarreraID

		) REFERENCES dbo.Carrera (
			CarreraID
		)
		,
		CONSTRAINT FK_CarreraCurso_Curso FOREIGN KEY 
		(
			CursoID

		) REFERENCES dbo.Curso (
			CursoID
		)
	)
	GO
GO


-- Inserciones

USE ControlUniversitarioDB

GO
INSERT [dbo].[Carrera] ([CarreraID], [NombreCarrera]) VALUES (1, N'Administración de Empresas (Diplomado)')
GO
INSERT [dbo].[Carrera] ([CarreraID], [NombreCarrera]) VALUES (2, N'Administración de Empresas con Énfasis en Banca y Finanzas')
GO
INSERT [dbo].[Carrera] ([CarreraID], [NombreCarrera]) VALUES (3, N'Administración de Empresas con Énfasis en Contaduría')
GO
INSERT [dbo].[Carrera] ([CarreraID], [NombreCarrera]) VALUES (4, N'Ingeniería Informática (Bachillerato)')
GO
INSERT [dbo].[Carrera] ([CarreraID], [NombreCarrera]) VALUES (5, N'Ingeniería Informática (Licenciatura)')
GO


GO
