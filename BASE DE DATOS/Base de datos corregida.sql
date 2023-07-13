
CREATE DATABASE StreetART


USE StreetART
GO

------------------- CREACION DE LAS TABLAS -------------------------

CREATE TABLE Usuarios (
    Id INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    Dni VARCHAR(10) NULL,
    Contrasena VARCHAR(10) NOT NULL,
    Mail VARCHAR (30) NOT NULL,
    Telefono VARCHAR(20),
    TipoEspectaculo VARCHAR (50) NULL,
	RedesSociales VARCHAR (50) NULL,
    Nombre VARCHAR(30) NULL,
    Apellido VARCHAR (30)  NULL,
    TipoUsuario INT NOT NULL,         -- ADMIN (1) O USUARIO (2)
    Estado BIT NOT NULL
)




SELECT * from Usuarios
CREATE TABLE Lugares (
    idLugar INT NOT NULL PRIMARY KEY IDENTITY(1,1), 
    Direccion VARCHAR (50) NOT NULL,
    Descripcion VARCHAR(50) NOT NULL,
    Nombre VARCHAR (50) NOT NULL,
    Estado BIT NOT NULL,
	UrlImagen VARCHAR(250)
)
GO


CREATE TABLE FECHAS(
	idFecha int  not null primary key identity (1,1),
	numeroDia int not null,
	descripcionDia varchar(30) NOT NULL,
	Estado bit NOT NULL
)

GO
Create TABLE Turnos (
    idTurnos INT NOT NULL PRIMARY KEY IDENTITY(1,1),
    idFecha int NOT NULL FOREIGN KEY REFERENCES FECHAS(idFecha),
    idLugar INT NOT NULL FOREIGN KEY REFERENCES Lugares (idLugar),
    idUsuario INT NOT NULL FOREIGN KEY REFERENCES Usuarios (Id),
    Estado BIT NOT NULL,
	Ocupado BIT NOT NULL
)


------------------------- CARGA DE DATOS -----------------------------

INSERT INTO Usuarios(Dni, Contrasena, Mail, Telefono, TipoEspectaculo, RedesSociales, Nombre, Apellido, TipoUsuario, Estado)
VALUES ('2222222', 'artista2', 'art@gmail', '22222', 'micasa', 'https://www.instagram.com/emilia_clarke','Laura', 'Perez', 2, 1),
('28.315.082','artista123','soyartista@gmail.com','11-9455680','Mi casa 123', 'https://www.instagram.com/emilia_clarke','LOLA', 'RODRIGUEZ', 2, 1),
('40.715.182','admin123','soyadmin@gmail.com','11-40408080','Calle Falsa 123','https://www.instagram.com/emilia_clarke', 'JUAN', 'PEREZ', 1, 1);

----------------------------------------

INSERT INTO 
	Lugares(Direccion, Descripcion, Nombre, Estado, UrlImagen)

 VALUES ('Av. 9 de Julio s/n', 'Obelisco del centro porte�o', 'OBELISCO', 1,'https://dkeauwle5qhyx.cloudfront.net/wp-content/uploads/2021/05/obelisco_ba.jpg'),
(' Av. Sarmiento s/n, CABA','Ubicado en medio de los bosques de Palermo','PLANETARIO',1,'https://m.buenosaires123.com.ar/images/700/planetario-buenos-aires.jpg'),
('Cerrito 628, CABA','Teatro de Opera, ubicado en plaza de Mayo','TEATRO COL�N',1,'https://eldiariodeviaje.com/wp-content/uploads/2020/12/2017-05-23-22-14-10-01-1080x675.jpeg'),
('Estacion Belgrano ramal Mitre','Cultura y gastronomico oriental','BARRIO CHINO',1,'https://www.descubriendobuenosaires.com/wp-content/uploads/2021/07/BarrioChino3-1024.jpg'),
('Dique 3 de Puerto Madero','Excelente foco turistico y gastronomico', 'PUENTE DE LA MUJER',1,'https://cdn-media.italiani.it/site-buenosaires/2019/03/Puente-de-la-Mujer-Luces-de-noche-e1552009688826-1000x600.jpeg')

-------------------------------------------------------------------
INSERT INTO FECHAS (numeroDia, descripcionDia, Estado)
VALUES (1, 'Lunes', 1),
(2, 'Martes', 1),
(3, 'Miercoles', 1),
(4, 'Jueves', 1),
(5, 'Viernes', 1),
(6, 'Sabado', 1),
(7, 'Domingo', 1),
(8, 'Lunes', 1)

----------------------------------------------------------------



 --- SI NO HAY 
INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado, Ocupado)
VALUES (4, 5, 1, 1, 0),
       (4, 2, 1, 1, 0),
       (1, 1, 1, 1, 0),
       (2, 2, 1, 1, 0)

--------------------------------------------------------------------------

             ---------------- P R O C E D I M I E N T O S ---------------------

			 

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

	   ------------- STORED PARA LISTAR LOS TURNOS DE CADA ARTISTA ------------------
	   GO
 ALTER PROCEDURE SP_listarPorArtistas(
 @idArtista int
 )
 AS
BEGIN
	SELECT F.numeroDia, F.descripcionDia, L.Nombre, L.Direccion, T.Estado, T.idTurnos from Turnos T
	INNER JOIN FECHAS  F on F.idFecha = T.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE T.idUsuario = @idArtista
END





Exec SP_listarPorArtistas 1
GO
    ------------------ STORED PARA MODIFICAR UN LUGAR -------------------------
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

GO
    ------------------ STORED PARA LISTAR TODOS LOS TURNOS -------------------------

ALTER PROCEDURE StoredListarTurnos
AS
BEGIN
SELECT T.idTurnos, T.idFecha, T.idLugar, T.idUsuario, T.Estado, L.Nombre, F.Estado, F.numeroDia, F.descripcionDia, T.Ocupado FROM Turnos T INNER JOIN Fechas F ON F.idFecha = T.idFecha INNER JOIN Lugares L ON L.idLugar = T.idLugar
END
GO
exec StoredListarTurnos

GO
  CREATE PROCEDURE [dbo].[StoredListarTurnos]




    ------------------ STORED PARA LISTAR TODOS LOS LUGARES -------------------------


	create PROCEDURE StoredListarLugares
AS
BEGIN
	Select* from Lugares
END 
GO
   ------------------ STORED PARA LISTAR TODOS LOS LUGARES -------------------------
   ALTER PROCEDURE StoredFechaFiltrada(
 @id int
 )
 AS
BEGIN
	SELECT F.idFecha, F.descripcionDia, F.numeroDia, F.Estado, L.idLugar, T.Ocupado FROM FECHAS F
	INNER JOIN Turnos T on T.idFecha = F.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE F.Estado = 1 AND T.idLugar = @id
END
GO

exec StoredFechaFiltrada 2, 0
   ------------------ STORED PARA DAR DE BAJA UNA FECHA -------------------------
   CREATE PROCEDURE StoredProcedureBajaFecha(
   @BAJA int)
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

GO

 --------------- STORED PARA MOSTRAR LAS FECHAS DISPONIBLES RELACIONADAS A UN LUGAR X ID TURNO ---------------

CREATE ALTER PROCEDURE StoredFechaFiltradaPorTurno(
 @id int
 )
 AS
BEGIN
	SELECT F.idFecha, F.descripcionDia, F.numeroDia, F.Estado, L.idLugar, T.idTurnos FROM FECHAS F
	INNER JOIN Turnos T on T.idFecha = F.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE F.Estado = 1 AND T.idLugar = @id
END

GO
exec StoredFechaFiltradaPorTurno 2
------------- STORED PARA LISTAR LOS TURNOS DE CADA ARTISTA ------------
GO
CREATE PROCEDURE SP_listarPorArtistas(
 @idArtista int
 )
 AS
BEGIN
	SELECT F.numeroDia, F.descripcionDia, L.Nombre, L.Direccion, T.Ocupado from Turnos T
	INNER JOIN FECHAS  F on F.idFecha = T.idFecha
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	WHERE T.idUsuario = @idArtista
END

Exec SP_listarPorArtistas 1

------------- STORED PARA LISTAR LOS USUARIOS ------------
GO
ALTER PROCEDURE StoredListarUsuarios
AS
BEGIN
SELECT Id, Dni, Contrasena, Mail, Telefono, TipoEspectaculo, RedesSociales, Nombre, Apellido, TipoUsuario, Estado FROM Usuarios
END

exec StoredListarUsuarios
GO
----------------------- STORED PARA ALTA TURNO DESDE ARTISTA -------------------------
CREATE PROCEDURE StoredAltaTurno(
	@idFecha int,
	@idLugar int,
	@idUsuario int,
	@Estado bit,
	@Ocupado bit
)
as
	   BEGIN			
			INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado, Ocupado) VALUES (@idFecha, @idLugar, @idUsuario, @Estado, @Ocupado)
			UPDATE FECHAS
			SET Estado = 0
			FROM FECHAS F
			Inner Join Turnos T on T.idFecha = F.idFecha
			Inner Join Lugares L on L.idLugar = T.idLugar
			WHERE T.idFecha = @idFecha
	   END
GO



------------------------------------------------
GO	
CREATE PROCEDURE SP_TurnoOcupado(
	@idLugar int
)
AS
BEGIN
	UPDATE Turnos 
	SET Ocupado = 1
	from turnos
	Inner Join Lugares L on L.idLugar = T.idLugar
	WHERE L.idLugar = @idLugar AND T.Ocupado = 1

END


go
--------------------------------------------


GO
   ------------------ STORED PARA LISTAR TODOS LOS LUGARES -------------------------
ALTER PROCEDURE StoredEncontrarArtista(
 @id int
 )
 AS
BEGIN 
	SELECT U.Id  from Turnos T
	INNER JOIN Lugares L on L.idLugar = T.idLugar
	INNER JOIN Usuarios U on u.Id = T.idUsuario
	WHERE T.idTurnos = @id
END
GO


select * from Turnos

EXEC StoredEncontrarArtista 12

------------------------------------------
ALTER PROCEDURE ST_ModificarTurnos(
		  @idTurnos int,
		  @idFecha int, 
		   @idLugar int,
		   @idUsuario int,
		   @Estado bit,
		   @Ocupado bit
	   )
	   AS
	   BEGIN
			UPDATE Turnos SET idFecha = @idFecha, idLugar = @idLugar, idUsuario = @idUsuario, Estado = @Estado, Ocupado = @Ocupado
			WHERE idTurnos = @idTurnos	
END
GO


--------------------------------------------------


-----------------MODIFICACIONES

GO
alter PROCEDURE InsertarNuevo(
@email varchar (50) , 
@pass VARCHAR (50)
)
AS
BEGIN
insert into Usuarios  (Mail, Contrasena, TipoUsuario, Estado)
 OUTPUT inserted.Id 
 values (@email, @pass, 2, 1)
END


