CREATE DATABASE BD_MACURI;

USE BD_MACURI;


create table Profesor
(
id int identity(1,1) primary key not null,
nombre varchar(100),
dni varchar(8),
fechaNac date,
telefono int,
correo varchar(100)
)

create table Estudiante
(
id int identity(1,1) primary key not null,
nombre varchar(100),
dni varchar(8),
fechaNac date,
telefono int,
correo varchar(100),
nivel varchar(50),
grado varchar (50)
)

create table Curso 
(
id int identity(1,1) primary key not null,
Nombre varchar(100)
)

create table Evaluacion 
(
id int identity(1,1) primary key not null,
descripcion varchar(100)
)

create table Registro
(
id int identity(1,1) primary key not null,
idRegistro int 
foreign key (idProfesor) references profesor(id),
idProfesor int 
foreign key (idProfesor) references profesor(id),
idCurso int
foreign key (idCurso) references curso(id),
fechaInicio date,
fechaTermino date
)

create table Notas
(
id int identity(1,1) primary key not null,
idEstudiante int
foreign key (idEstudiante) references estudiante(id),
idEvaluacion int
foreign key (idEvaluacion) references evaluacion(id),
nota varchar(2),
idRegistro int 
foreign key (idRegistro) references registro(id)
)

ALTER TABLE Registro
ADD FOREIGN KEY (idProfesor) REFERENCES Profesor(id);


ALTER TABLE Registro
ADD FOREIGN KEY (idCurso) REFERENCES Curso(id);

ALTER TABLE Notas
ADD FOREIGN KEY (idEstudiante) REFERENCES Estudiante(id);


ALTER TABLE Notas
ADD FOREIGN KEY (idEvaluacion) REFERENCES Evaluacion(id);

ALTER TABLE Notas
ADD FOREIGN KEY (idRegistro) REFERENCES Registro(id);

SELECT * from Information_Schema.Tables

insert into Profesor (nombre, dni, FechaNac, Telefono,Correo) values ('joe castillo','09512345','1979-03-15','959595959','joe@correo.com');
insert into Profesor (nombre, dni, FechaNac, Telefono,Correo) values ('jose haya','09564321','1985-05-25','998877661','haya@correo.com');
insert into Profesor (nombre, dni, FechaNac, Telefono,Correo) values ('carlos ampuero','09512345','1975-04-05','941234789','ampuero@correo.com');

insert into Estudiante(nombre, dni, fechaNac, telefono,correo,nivel,grado) values ('jose macuri','72614325','2002-07-03','917191954','jose@correo.com','Secun','5');
insert into Estudiante(nombre, dni, fechaNac, telefono,correo,nivel,grado) values ('juan mamani','09564321','2001-12-21','998877661','mamani@correo.com','Secun','1');


select * from Registro
select * from Notas;

use master;

drop database BD_MACURI;

