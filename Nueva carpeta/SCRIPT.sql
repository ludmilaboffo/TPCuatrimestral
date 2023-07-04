
DROP DATABASE FreeShowMusic -- PARA BORRAR LA BASE 

CREATE DATABASE FreeShowMusic
GO

USE FreeShowMusic
GO

CREATE TABLE Usuarios (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Dni VARCHAR(10) NOT NULL UNIQUE,
    Contrasena VARCHAR(10),
    Mail VARCHAR (30) UNIQUE,
    Telefono VARCHAR(20),
    Direccion VARCHAR (50),
    Nombre VARCHAR(30),
    Apellido VARCHAR (30),
    TipoUsuario INT,         -- ADMIN (1) O USUARIO (2)
    Estado BIT
)
GO
 WHERE 

CREATE TABLE Lugares (
    idLugar INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Direccion VARCHAR (50),
    Descripcion VARCHAR(50),
    Nombre VARCHAR (50),
    Estado BIT,
	UrlImagen VARCHAR(250)
)
GO

CREATE TABLE Dias(
    idDias INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    descripcion Varchar(30)
	)
GO



Create TABLE Turnos (
    idTurnos INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idFecha int NOT NULL FOREIGN KEY REFERENCES FECHAS(idFecha),
    idLugar INT NOT NULL FOREIGN KEY REFERENCES Lugares (idLugar),
    idUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios (Id),
    Estado BIT
)
GO
 --- SI NO HAY 
INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado)
VALUES (4, 5, 1, 1),
       (4, 2, 1, 1),
       (1, 1, 1, 1),
       (2, 2, 1, 1),
       (1, 4, 1, 1),
       (3, 3, 1, 1)
	   
	   ------ STORE PROCEDURE DE ALTA ------
	   
	   GO
	  ALTER PROCEDURE ST_AltaTurno (
		   @idFecha int, 
		   @idLugar int,
		   @idUsuario int,
		   @Estado bit
	   )
	   AS
	   BEGIN
			INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado) VALUES (@idFecha, @idLugar, @idUsuario, @Estado)
	   END
	   GO


	   EXEC ST_AltaTurno 1,2,1,1

	   go
	   alter procedure StoredModificarLugar
	   @idLugar int,
	   @Direccion varchar(50),
	   @Descripcion varchar(50),
	   @Nombre varchar (50),
	   @Estado bit,
	   @UrlImagen varchar (250),
	   as begin
	    update -- TERMINAR EL UPDATE DE LUGARES--


CREATE TABLE FECHAS(
	idFecha int  not null primary key identity (1,1),
	numeroDia int not null,
	descripcionDia varchar(30)
)

INSERT INTO Turnos(numeroDia, descripcionDia)
VALUES (25, 'VIERNES'),
		(26,'SABADO'),
		(27, 'DOMINGO'),
		(28, 'LUNES')

	 
	 DROP TABLE TURNOS
Select * from Turnos
Select * from Dias
Select * from Lugares
Select * from Usuarios



INSERT INTO 
	Lugares(Direccion, Descripcion, Nombre, Estado, UrlImagen)

 VALUES ('Av. 9 de Julio s/n', 'Obelisco del centro porteño', 'OBELISCO', 1,'https://dkeauwle5qhyx.cloudfront.net/wp-content/uploads/2021/05/obelisco_ba.jpg')
VALUES(' Av. Sarmiento s/n, CABA','Ubicado en medio de los bosques de Palermo','PLANETARIO',1,'https://m.buenosaires123.com.ar/images/700/planetario-buenos-aires.jpg')
VALUES('Cerrito 628, CABA','Teatro de Opera, ubicado en plaza de Mayo','TEATRO COLÓN',1,'https://eldiariodeviaje.com/wp-content/uploads/2020/12/2017-05-23-22-14-10-01-1080x675.jpeg')
VALUES('Estacion Belgrano ramal Mitre','Cultura y gastronomico oriental','BARRIO CHINO',1,'https://www.descubriendobuenosaires.com/wp-content/uploads/2021/07/BarrioChino3-1024.jpg')
--values('Dique 3 de Puerto Madero','Excelente foco turistico y gastronomico', 'PUENTE DE LA MUJER',1,'https://cdn-media.italiani.it/site-buenosaires/2019/03/Puente-de-la-Mujer-Luces-de-noche-e1552009688826-1000x600.jpeg')




SELECT * FROM Usuarios

INSERT INTO 
	Usuarios(Dni, Contrasena, Mail, Telefono, Direccion, Nombre, Apellido, TipoUsuario, Estado)

VALUES('28.315.082','artista123','soyartista@gmail.com','11-9455680','Mi casa 123', 'LOLA', 'RODRIGUEZ', 2, 1)
VALUES('40.715.182','admin123','soyadmin@gmail.com','11-40408080','Calle Falsa 123', 'JUAN', 'PEREZ', 1, 1)


INSERT INTO 
HORARIOS(Horario)
Values(23)



go



CREATE PROCEDURE StoredModificarLugar
	@idLugar int,
	@Direccion varchar(50),
	@Descripcion varchar(50),
	@Nombre varchar(50),
	@Estado bit,
	@UrlImagen varchar(250)
AS
BEGIN
	UPDATE Lugares
	SET Direccion = @Direccion,
		Descripcion = @Descripcion,
		Nombre = @Nombre,
		Estado = @Estado,
		UrlImagen = @UrlImagen
	WHERE idLugar = @idLugar
END
select * from Turnos

ALTER TABLE FECHAS
ADD Estado bit;


UPDATE FECHAS
SET Estado = 0 WHERE idFecha = 2

SELECT T.idTurnos, T.idFecha, T.idLugar, T.idUsuario, T.Estado, L.Nombre, F.numeroDia, F.descripcionDia
FROM Turnos T
INNER JOIN FECHAS F on F.idFecha = T.idFecha
INNER JOIN Lugares L on L.idLugar = T.idLugar
WHERE F.Estado = 1 AND L.Estado = 1
go

ALTER PROCEDURE StoredListarTurnos
AS
BEGIN
SELECT T.idTurnos, T.idFecha, T.idLugar, T.idUsuario, T.Estado, L.Nombre, F.numeroDia, F.descripcionDia, T.Ocupado FROM Turnos T INNER JOIN Fechas F ON F.idFecha = T.idFecha INNER JOIN Lugares L ON L.idLugar = T.idLugar
END
exec StoredListarTurnos

create PROCEDURE StoredListarLugares
AS
BEGIN
	Select* from Lugares
END 

SELECT OBJECT_ID('ST_ListadoTurnos') AS ObjectID;
IF OBJECT_ID('ST_ListadoTurnos', 'P') IS NOT NULL
BEGIN
    DROP PROCEDURE SP_ListarLugares;
END

CREATE PROCEDURE StoredFechaFiltrada(
 @id int
 )
 AS
BEGIN
	SELECT F.idFecha, F.descripcionDia, F.numeroDia, F.Estado, L.idLugar FROM FECHAS F
	INNER JOIN Turnos T on T.idFecha = F.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE F.Estado = 1 AND T.idLugar = @id
END

EXEC StoredFechaFiltrada 3
alter PROCEDURE StoredProcedureBajaFecha
   @BAJA int
AS
BEGIN
    UPDATE FECHAS
    SET Estado = 0
    WHERE idFecha IN (
        SELECT idFecha
        FROM Turnos
        WHERE idLugar = @BAJA
    )
END


DELETE FROM TURNOS WHERE idTurnos between 2 AND 70


DELETE FROM TURNOS WHERE idTurnos = 65



CREATE ALTER PROCEDURE StoredFechaFiltradaPorTurno(
 @id int
 )
 AS
BEGIN
	SELECT F.idFecha, F.descripcionDia, F.numeroDia, F.Estado, L.idLugar, T.idTurnos FROM FECHAS F
	INNER JOIN Turnos T on T.idFecha = F.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE F.Estado = 1 AND T.idTurnos = @id
END

EXEC StoredFechaFiltradaPorTurno 17

    UPDATE turnos
    SET Estado = 1
    FROM Turnos AS T
    INNER JOIN Fechas AS F ON T.idFecha = F.idFecha
    WHERE T.idLugar = @idLugarParam;


UPDATE FECHAS
SET Estado = 1
WHERE Estado = 0 
select *  from Fechas 


ins


alter PROCEDURE SP_BajaFecha
    @idLugarParam int
AS
BEGIN
		UPDATE FECHAS F
		SET F.ESTADO = 0
		WHERE(
		 SELECT T.idLugar FROM TURNOS T
		 INNER JOIN Lugares L on L.idLugar = T.idLugar
		 INNER JOIN FECHAS F on F.idFecha = T.idFecha
		) = @idLugarParam
END



SELECT * FROM FECHAS
delete from turnos where idTurnos between 67 and 71

ALTER TABLE Turnos
ADD Ocupado BIT NOT NULL DEFAULT 0
