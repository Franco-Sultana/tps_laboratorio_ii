CREATE DATABASE GymTP4
GO
USE GymTP4
GO
CREATE TABLE PersonasGym(
dni int primary key,
nombreCompleto varchar(50) not null,
edad int not null,
sexo varchar(20) not null,
diaCobrado date not null,
servicio varchar(20) not null,
activo bit not null
)