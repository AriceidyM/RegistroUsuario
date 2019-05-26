select *from usuarios

go
use AriceidyDb
go

create table Usuario
{
	UsuarioId int primary key identity,
	Nombres varchar(30),
	Email varchar(30),
	NivelUsuario varchar(30),
	Usuario varchar(30),
	Clave varchar(30),
	FechaIngreso datetime,
};

create table Cargos
(
	cargoId int primary key identity,
	descripcion varchar(30),
);

select *from Cargos