CREATE DATABASE GymTP4
GO
USE GymTP4
GO
CREATE TABLE PERSONAS(
DNI int primary key,
NOMBRE_COMPLETO varchar(50) not null,
EDAD int not null,
SEXO varchar(20) not null,
DIA_COBRADO date not null,
SERVICIO varchar(20) not null,
ACTIVO bit not null
)