create database BDExamen
use BDExamen


CREATE TABLE Alumno
( 
	idAlumno int primary key IDENTITY ( 1,1 ),
	nombre   varchar(50)  NOT NULL ,
	apellidoMaterno   varchar(50)  NOT NULL ,
	apellidoPaterno   varchar(50)  NOT NULL ,
	FechaNacimiento   datetime  NOT NULL ,
	Sexo char(1) NOT NULL 
) 


CREATE TABLE Curso
( 
	idCurso int primary key IDENTITY ( 1,1 ),
	nombre   varchar(50)  NOT NULL ,
	descripción   varchar(50)  NOT NULL ,
	obligatoriedad   varchar(50)  NOT NULL 
) 


CREATE TABLE Nota
( 
	idNota int primary key IDENTITY ( 1,1 ),
	idAlumno   int foreign key references   Alumno(idAlumno)  NOT NULL ,
	idCurso   int foreign key references   Curso(idCurso)  NOT NULL ,
	practicaA   decimal(4,2)  NOT NULL ,
	practicaB decimal(4,2)  NOT NULL ,
	practicaC decimal(4,2)  NOT NULL,
	promedio decimal(4,2) NOT NULL  

) 


select * from Alumno
--insert into nota values(1,1,10,10,10,10) 
--  insert into Alumno values('demo','demo','demo',GETDATE(),'M')