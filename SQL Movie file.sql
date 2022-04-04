	CREATE DATABASE MovieDB 
	USE MovieDB
	go

create table Genero(
	Id int primary key not null identity,
	Tipo nvarchar(50),
	Descripcion nvarchar(MAX)
)
go
create table Pelicula(
	Id int primary key not null identity,
	Titulo nvarchar(50),
	Sinopsis nvarchar(MAX),
	IdGenero int not null,
	Fecha_salida nvarchar(50),
	Puntuacion nvarchar(10),
	Imagen nvarchar(MAX),
	Estado nvarchar(50),
	FOREIGN KEY (IdGenero) REFERENCES Genero(Id)
)
go
create table Prestamos(
	Id int primary key not null identity,
	IdPelicula int not null unique, 
	Prestatario nvarchar(100),
	Fecha_prestamo date default Getdate(),
	FOREIGN KEY (IdPelicula) REFERENCES Pelicula(Id)
)
go 

insert into Genero values ('Accion', 'Peliculas de movimiento, peleas y otras acciones')
insert into Genero values ('Terror', 'Peliculas de terror')
insert into Genero values ('Comedia', 'Peliculas de comedia')
select * from genero 

insert into Pelicula values ('The Batman', 'Un hombre del traje negro hace cosas por la ciudad', 1, '25-5-2022', '5.5', 'N/A', 'En casa')
select * from Pelicula 
go 

--procedimientos de almacenado

create procedure Prestar_Pelicula(@id int, @prestatario varchar(100))
as 
begin 
	insert into Prestamos(IdPelicula, Prestatario) Values (@id, @prestatario)
	update Pelicula set Estado = 'Prestada' where id = @id
end 
GO
/*
create procedure Devolver_Pelicula(@idPrestamo int, @idPelicula int)
as 
begin 
	delete from Prestamos where id = @idPrestamo
	update Pelicula set Estado = 'En casa' where id = @idPelicula 
end 
GO*/

exec Prestar_Pelicula 3, 'Juan Garcia Matos' 
--exec Devolver_Pelicula 2, 1

Select * from Prestamos 


