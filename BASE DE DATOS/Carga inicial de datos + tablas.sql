


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
    TipoUsuario INT NOT NULL, --- ADMIN (1) O ARTISTA (2)
	ImgPerfil VARCHAR(250) NULL,
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


---------------------------------------- CARGA DE USUARIOS

INSERT INTO Usuarios(Dni, Contrasena, Mail, Telefono, TipoEspectaculo, RedesSociales, Nombre, Apellido, TipoUsuario, Estado, ImgPerfil)
VALUES ('39.405.203', 'soyemilia', 'mamadragon@gmail.com','1150908090','Acrobacias con dragones','https://www.instagram.com/p/BwP8IukFrs6/', 'Emilia', 'Clarke', 2, 1, null), 
('28.315.082','soymessi','soymessi@gmail.com','11-9455680','Juego futbol', 'https://www.facebook.com/leomessi/?locale=es_LA','Lionel', 'Messi', 2, 1, null),
('40.715.182','soytaylor','soytaylor@gmail.com','11-40408080','Canto y guitarra','https://www.youtube.com/watch?v=5UMCrq-bBCg', 'Taylor', 'Swift', 2, 1, null),
('19.900.000', 'soyadmin', 'soyadmin@gmail.com', '2923-234556', null, null, 'El administrador', 'mas capo', 1, 1, null)


---------------------------------------- CARGA DE LUGARES 

INSERT INTO 
	Lugares(Direccion, Descripcion, Nombre, Estado, UrlImagen)

 VALUES ('Av. 9 de Julio s/n.', 'Puede presentar su show a pie del monumento', 'OBELISCO', 1,'https://dkeauwle5qhyx.cloudfront.net/wp-content/uploads/2021/05/obelisco_ba.jpg'),
(' Av. Sarmiento s/n, CABA','Bosques de Palermo, frente al lago','PLANETARIO',1,'https://m.buenosaires123.com.ar/images/700/planetario-buenos-aires.jpg'),
('Cerrito 628, CABA','Presente su show en el exterior del edificio','TEATRO COL�N',1,'https://eldiariodeviaje.com/wp-content/uploads/2020/12/2017-05-23-22-14-10-01-1080x675.jpeg'),
('Estacion Belgrano ramal Mitre','Presente su show en el arco de entrada','BARRIO CHINO',1,'https://www.descubriendobuenosaires.com/wp-content/uploads/2021/07/BarrioChino3-1024.jpg'),
('Dique 3 de Puerto Madero','Excelente para espectaculos nocturnos', 'PUERTO MADERO',1,'https://cdn-media.italiani.it/site-buenosaires/2019/03/Puente-de-la-Mujer-Luces-de-noche-e1552009688826-1000x600.jpeg')

------------------------------ CARGA DE FECHAS
INSERT INTO FECHAS (numeroDia, descripcionDia, Estado)
VALUES (13, 'Jueves', 1),
(14, 'Viernes', 1),
(15, 'Sabado', 1),
(16, 'Domingo', 1),
(17, 'Lunes', 1),
(18, 'Martes', 1),
(19, 'Miercoles', 1),
(20, 'Jueves', 1),
(21, 'Viernes', 1),
(22, 'Sabado', 1),
(23, 'Domingo', 1),
(24, 'Lunes', 1),
(25, 'Martes', 1),
(26, 'Miercoles', 1),
(27, 'Jueves', 1),
(28, 'Viernes', 1),
(29, 'Sabado', 1),
(30, 'Domingo', 1)


SELECT * FROM FECHAS
SELECT * FROM Turnos

--------------------- TURNOS INICIALES:
INSERT INTO Turnos (idFecha, idLugar, idUsuario, Estado, Ocupado)
VALUES (1, 1, 4, 1, 0),
(2, 1, 4, 1, 0),
(3, 1, 4, 1, 0),
(4, 1, 4, 1, 0),
(5, 1, 4, 1, 0),
(6, 1, 4, 1, 0),
(7, 1, 4, 1, 0),

(8, 2, 4, 1, 0),
(9, 2, 4, 1, 0),
(10, 2, 4, 1, 0),
(4, 2, 4, 1, 0),
(5, 2, 4, 1, 0),
(6, 2, 4, 1, 0),
(7, 2, 4, 1, 0),

(11, 3, 4, 1, 0),
(12, 3, 4, 1, 0),
(13, 3, 4, 1, 0),
(14, 3, 4, 1, 0),
(15, 3, 4, 1, 0),
(16, 3, 4, 1, 0),
(17, 3, 4, 1, 0)
