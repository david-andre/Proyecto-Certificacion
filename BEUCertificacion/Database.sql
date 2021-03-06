USE [master]
GO
/****** Object:  Database [DB_A6710E_DBPROYECTO]    Script Date: 20/9/2020 17:17:55 ******/
CREATE DATABASE [DB_A6710E_DBPROYECTO]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'DB_A6710E_DBPROYECTO_Data', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A6710E_DBPROYECTO_DATA.mdf' , SIZE = 8192KB , MAXSIZE = 153600KB , FILEGROWTH = 10%)
 LOG ON 
( NAME = N'DB_A6710E_DBPROYECTO_Log', FILENAME = N'H:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\DB_A6710E_DBPROYECTO_Log.LDF' , SIZE = 3072KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [DB_A6710E_DBPROYECTO].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ARITHABORT OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET  ENABLE_BROKER 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET  MULTI_USER 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET DB_CHAINING OFF 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET QUERY_STORE = OFF
GO
USE [DB_A6710E_DBPROYECTO]
GO
/****** Object:  Table [dbo].[Cliente]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cliente](
	[idcliente] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](25) NULL,
	[apellido] [varchar](25) NULL,
	[cedula] [varchar](15) NULL,
	[telefono] [varchar](15) NULL,
	[ciudad] [varchar](25) NULL,
	[direccion] [varchar](100) NULL,
	[idusuario] [int] NULL,
 CONSTRAINT [PK_Cliente] PRIMARY KEY CLUSTERED 
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallePedido]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallePedido](
	[iddetalle] [int] IDENTITY(1,1) NOT NULL,
	[idpedido] [int] NULL,
	[idservicio] [int] NULL,
	[costo] [decimal](18, 2) NULL,
 CONSTRAINT [PK_DetallePedido] PRIMARY KEY CLUSTERED 
(
	[iddetalle] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empresa]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empresa](
	[idempresa] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NULL,
	[telefono] [varchar](20) NULL,
	[ciudad] [varchar](25) NULL,
	[direccion] [varchar](100) NULL,
	[idusuario] [int] NULL,
 CONSTRAINT [PK_Empresa] PRIMARY KEY CLUSTERED 
(
	[idempresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedido]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedido](
	[idpedido] [int] IDENTITY(1,1) NOT NULL,
	[fechaPeticion] [datetime] NULL,
	[estado] [varchar](15) NULL,
	[fechaEjecucion] [datetime] NULL,
	[costo] [decimal](18, 2) NULL,
	[idcliente] [int] NULL,
 CONSTRAINT [PK_Pedido] PRIMARY KEY CLUSTERED 
(
	[idpedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Servicio]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Servicio](
	[idservicio] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](100) NULL,
	[costo] [varchar](20) NULL,
	[descripcion] [varchar](max) NULL,
	[idempresa] [int] NULL,
 CONSTRAINT [PK_Servicio] PRIMARY KEY CLUSTERED 
(
	[idservicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/9/2020 17:17:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[idusuario] [int] IDENTITY(1,1) NOT NULL,
	[usuario] [varchar](50) NULL,
	[contrasena] [varchar](50) NULL,
	[email] [varchar](50) NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[idusuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Cliente] ON 

INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (12, N'Jasson', N'Salguero', N'154987654621', N'09856987546', N'Quito', N'Chillogallo', NULL)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (15, N'David', N'Paredes', N'1804837456', N'0983187903', N'Ambato', N'Sucre y Lalama', NULL)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (20, N'Andre', N'Paredes', N'1568765461', N'0984563214', N'Ambato', N'Centro', 1)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (21, N'nombre1', N'apellido', N'489465165', N'045984', N'ciudad1', N'direccion1', 2)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (22, N'a', N'c', N'43', N'tre', N't', N'drt', 3)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (23, N'Jason', N'Salguero', N'189465', N'651651', N'Quito', N'Chillogallo', 4)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (24, N'Minombre', N'apellido', N'18654987', N'09865465', N'Lugar', N'Direccion', 5)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (25, N'Viviana', N'Paredes', N'1845697954', N'0978654613', N'Ambaro', N'Centro', 6)
INSERT [dbo].[Cliente] ([idcliente], [nombre], [apellido], [cedula], [telefono], [ciudad], [direccion], [idusuario]) VALUES (26, N'Mario', N'Andrade', N'15985642134', N'098745632', N'Ambato', N'Centro', 7)
SET IDENTITY_INSERT [dbo].[Cliente] OFF
GO
SET IDENTITY_INSERT [dbo].[DetallePedido] ON 

INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (100, 71, 19, CAST(110.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (101, 71, 22, CAST(156.56 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (102, 72, 22, CAST(156.56 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (103, 73, 18, CAST(15.01 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (104, 73, 19, CAST(110.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (105, 74, 21, CAST(25.25 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (106, 75, 15, CAST(2.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (107, 76, 19, CAST(110.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (108, 77, 21, CAST(25.25 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (109, 77, 19, CAST(110.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (110, 78, 24, CAST(10.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (111, 80, 19, CAST(110.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (112, 81, 21, CAST(25.25 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (113, 81, 25, CAST(15.50 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (114, 82, 22, CAST(156.56 AS Decimal(18, 2)))
INSERT [dbo].[DetallePedido] ([iddetalle], [idpedido], [idservicio], [costo]) VALUES (115, 82, 25, CAST(15.50 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[DetallePedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Empresa] ON 

INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (3, N'Ultra Sports', N'2820972', N'Ambato', N'Sucre 03-45 y Lalama', NULL)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (6, N'Alis', N'098213546', N'Latacunga', N'El Salto', NULL)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (8, N'L´escofier', N'0325698', N'Ambato', N'Huachi', NULL)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (9, N'Davisoft', N'0983187903', N'Ambato', N'Centro', 1)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (13, N'Empresa2', N'0987465', N'Ambato', N'Ambato', 1)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (14, N'mi empresa', N'sdf', N'sdf', N'sdf', 5)
INSERT [dbo].[Empresa] ([idempresa], [nombre], [telefono], [ciudad], [direccion], [idusuario]) VALUES (15, N'EducacionECU', N'0986548796', N'Ambato', N'Centro', 6)
SET IDENTITY_INSERT [dbo].[Empresa] OFF
GO
SET IDENTITY_INSERT [dbo].[Pedido] ON 

INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (71, CAST(N'2020-09-09T21:14:35.950' AS DateTime), N'En espera', CAST(N'2020-09-17T00:00:00.000' AS DateTime), CAST(267.06 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (72, CAST(N'2020-09-09T22:10:47.083' AS DateTime), N'En espera', CAST(N'2020-09-24T00:00:00.000' AS DateTime), CAST(156.56 AS Decimal(18, 2)), 24)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (73, CAST(N'2020-09-09T22:11:51.067' AS DateTime), N'En espera', CAST(N'2020-09-17T00:00:00.000' AS DateTime), CAST(125.51 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (74, CAST(N'2020-09-09T22:17:11.117' AS DateTime), N'En espera', CAST(N'2020-09-17T00:00:00.000' AS DateTime), CAST(25.25 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (75, CAST(N'2020-09-10T05:13:00.823' AS DateTime), N'En espera', CAST(N'2020-09-11T00:00:00.000' AS DateTime), CAST(2.50 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (76, CAST(N'2020-09-10T07:14:24.447' AS DateTime), N'En espera', CAST(N'2020-09-26T00:00:00.000' AS DateTime), CAST(110.50 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (77, CAST(N'2020-09-10T07:24:11.873' AS DateTime), N'En espera', CAST(N'2020-09-18T00:00:00.000' AS DateTime), CAST(135.75 AS Decimal(18, 2)), 25)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (78, CAST(N'2020-09-10T07:26:41.313' AS DateTime), N'En espera', CAST(N'2020-09-24T00:00:00.000' AS DateTime), CAST(10.50 AS Decimal(18, 2)), 25)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (79, CAST(N'2020-09-10T07:43:04.887' AS DateTime), N'En espera', NULL, CAST(0.00 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (80, CAST(N'2020-09-10T08:24:22.140' AS DateTime), N'En espera', CAST(N'2020-09-18T00:00:00.000' AS DateTime), CAST(110.50 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (81, CAST(N'2020-09-13T19:22:42.150' AS DateTime), N'En espera', CAST(N'2020-10-29T00:00:00.000' AS DateTime), CAST(40.75 AS Decimal(18, 2)), 20)
INSERT [dbo].[Pedido] ([idpedido], [fechaPeticion], [estado], [fechaEjecucion], [costo], [idcliente]) VALUES (82, CAST(N'2020-09-15T20:49:32.743' AS DateTime), N'En espera', CAST(N'2020-01-16T00:00:00.000' AS DateTime), CAST(172.06 AS Decimal(18, 2)), 20)
SET IDENTITY_INSERT [dbo].[Pedido] OFF
GO
SET IDENTITY_INSERT [dbo].[Servicio] ON 

INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (2, N'Sublimados', N'1.75', N'Sublimación de cualquier tipo de prendas', 3)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (9, N'Lasagña en horno', N'10.5', N'Lasagña hecha en horno bien rico', 6)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (15, N'Estampado', N'2.5', N'Estampados de toda calidad', 3)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (17, N'Alcachofas Fermentadas', N'0.5', N'Servicio de alcachoferia proveniente del mismisimo cultivo de Juanito ALCACHOFA', 3)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (18, N'Catering', N'15.01', N'Catering para cualquier tipo de evento donde la comida sea el evento principal', 6)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (19, N'Aditoría', N'110.5', N'Auditoría económica para empresas pequeñas', 9)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (21, N'Servicio Prueba', N'25.25', N'Prueba', 9)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (22, N'pREUBA2', N'156.56', N'FSDF', 9)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (23, N'gdfg', N'150.5', N'gfdgdfg', 14)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (24, N'Clase de matemáticas', N'10.5', N'El costo es por hora', 15)
INSERT [dbo].[Servicio] ([idservicio], [nombre], [costo], [descripcion], [idempresa]) VALUES (25, N'Clases de Programación', N'15.5', N'El costo es por hora', 13)
SET IDENTITY_INSERT [dbo].[Servicio] OFF
GO
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (1, N'daparedes', N'p246810', N'daparedes15@espe.edu.ec')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (2, N'usuario1', N'contrasena1', N'usuario1@hotmail.com')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (3, N'a', N'c', N'sdfgsdg')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (4, N'jasonsalguero', N'jasson', N'jason@hotmail.com')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (5, N'usuario2', N'123456', N'usuario2@hotmail.com')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (6, N'vivianap', N'p246810', N'vivianap@hotmail.com')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (7, N'mario15', N'p246810', N'mario15@hotmail.com')
INSERT [dbo].[Usuario] ([idusuario], [usuario], [contrasena], [email]) VALUES (8, N'DiVelasco', N'123456', N'diegovelasco@hotmail.com')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO
/****** Object:  Index [IX_FK_DetallePedido_Pedido]    Script Date: 20/9/2020 17:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_DetallePedido_Pedido] ON [dbo].[DetallePedido]
(
	[idpedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_DetallePedido_Servicio]    Script Date: 20/9/2020 17:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_DetallePedido_Servicio] ON [dbo].[DetallePedido]
(
	[idservicio] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Pedido_Cliente]    Script Date: 20/9/2020 17:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Pedido_Cliente] ON [dbo].[Pedido]
(
	[idcliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_FK_Servicio_Empresa]    Script Date: 20/9/2020 17:18:04 ******/
CREATE NONCLUSTERED INDEX [IX_FK_Servicio_Empresa] ON [dbo].[Servicio]
(
	[idempresa] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Cliente]  WITH CHECK ADD  CONSTRAINT [FK_Cliente_Usuario] FOREIGN KEY([idusuario])
REFERENCES [dbo].[Usuario] ([idusuario])
GO
ALTER TABLE [dbo].[Cliente] CHECK CONSTRAINT [FK_Cliente_Usuario]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Pedido] FOREIGN KEY([idpedido])
REFERENCES [dbo].[Pedido] ([idpedido])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Pedido]
GO
ALTER TABLE [dbo].[DetallePedido]  WITH CHECK ADD  CONSTRAINT [FK_DetallePedido_Servicio] FOREIGN KEY([idservicio])
REFERENCES [dbo].[Servicio] ([idservicio])
GO
ALTER TABLE [dbo].[DetallePedido] CHECK CONSTRAINT [FK_DetallePedido_Servicio]
GO
ALTER TABLE [dbo].[Empresa]  WITH CHECK ADD  CONSTRAINT [FK_Empresa_Usuario] FOREIGN KEY([idusuario])
REFERENCES [dbo].[Usuario] ([idusuario])
GO
ALTER TABLE [dbo].[Empresa] CHECK CONSTRAINT [FK_Empresa_Usuario]
GO
ALTER TABLE [dbo].[Pedido]  WITH CHECK ADD  CONSTRAINT [FK_Pedido_Cliente] FOREIGN KEY([idcliente])
REFERENCES [dbo].[Cliente] ([idcliente])
GO
ALTER TABLE [dbo].[Pedido] CHECK CONSTRAINT [FK_Pedido_Cliente]
GO
ALTER TABLE [dbo].[Servicio]  WITH CHECK ADD  CONSTRAINT [FK_Servicio_Empresa] FOREIGN KEY([idempresa])
REFERENCES [dbo].[Empresa] ([idempresa])
GO
ALTER TABLE [dbo].[Servicio] CHECK CONSTRAINT [FK_Servicio_Empresa]
GO
/****** Object:  StoredProcedure [dbo].[GetDetallesByMonth]    Script Date: 20/9/2020 17:18:04 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDetallesByMonth] @id int, @month int, @year int
AS
BEGIN
	SELECT Servicios.nombre, count(Servicios.idservicio) AS pedidos
	FROM dbo.DetallePedido AS Detalles
	INNER JOIN dbo.Servicio AS Servicios ON Detalles.idservicio = Servicios.idservicio
	INNER JOIN dbo.Pedido AS Pedidos ON Detalles.idpedido = Pedidos.idpedido
	INNER JOIN dbo.Empresa AS Empresas ON Servicios.idempresa = Empresas.idempresa
	INNER JOIN dbo.Usuario AS Usuarios ON Empresas.idusuario = Usuarios.idusuario
	WHERE Usuarios.idusuario = @id AND Month (Pedidos.fechaEjecucion) = @month AND Year (Pedidos.fechaEjecucion) = @year
	GROUP BY Servicios.idservicio, Servicios.nombre
END 
GO
/****** Object:  StoredProcedure [dbo].[GetDetallesEmpresasByMonth]    Script Date: 20/9/2020 17:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetDetallesEmpresasByMonth] @id int, @month int, @year int
AS
BEGIN
	SELECT Empresas.nombre, count(Empresas.idempresa) AS pedidos
	FROM dbo.DetallePedido AS Detalles
	INNER JOIN dbo.Servicio AS Servicios ON Detalles.idservicio = Servicios.idservicio
	INNER JOIN dbo.Pedido AS Pedidos ON Detalles.idpedido = Pedidos.idpedido
	INNER JOIN dbo.Empresa AS Empresas ON Servicios.idempresa = Empresas.idempresa
	INNER JOIN dbo.Usuario AS Usuarios ON Empresas.idusuario = Usuarios.idusuario
	WHERE Usuarios.idusuario = @id AND Month (Pedidos.fechaEjecucion) = @month AND Year (Pedidos.fechaEjecucion) = @year
	GROUP BY Empresas.idempresa, Empresas.nombre
END 
GO
/****** Object:  StoredProcedure [dbo].[GetMontoByServicio]    Script Date: 20/9/2020 17:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetMontoByServicio] @id int
AS
BEGIN
	SELECT Servicios.nombre, SUM(Detalles.costo) AS monto
	FROM dbo.DetallePedido AS Detalles
	INNER JOIN dbo.Servicio AS Servicios ON Detalles.idservicio = Servicios.idservicio
	INNER JOIN dbo.Pedido AS Pedidos ON Detalles.idpedido = Pedidos.idpedido
	INNER JOIN dbo.Empresa AS Empresas ON Servicios.idempresa = Empresas.idempresa
	INNER JOIN dbo.Usuario AS Usuarios ON Empresas.idusuario = Usuarios.idusuario
	WHERE Usuarios.idusuario = @id
	GROUP BY Servicios.idservicio, Servicios.nombre
END 
GO
/****** Object:  StoredProcedure [dbo].[reportePrueba]    Script Date: 20/9/2020 17:18:05 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[reportePrueba] @id int, @month int, @year int
AS
BEGIN
	SELECT Empresas.nombre, count(Empresas.idempresa) AS pedidos
	FROM dbo.DetallePedido AS Detalles
	INNER JOIN dbo.Servicio AS Servicios ON Detalles.idservicio = Servicios.idservicio
	INNER JOIN dbo.Pedido AS Pedidos ON Detalles.idpedido = Pedidos.idpedido
	INNER JOIN dbo.Empresa AS Empresas ON Servicios.idempresa = Empresas.idempresa
	INNER JOIN dbo.Usuario AS Usuarios ON Empresas.idusuario = Usuarios.idusuario
	WHERE Usuarios.idusuario = 1 AND Month (Pedidos.fechaEjecucion) = 9 AND Year (Pedidos.fechaEjecucion) = 2020
	GROUP BY Empresas.idempresa, Empresas.nombre
END 
GO
USE [master]
GO
ALTER DATABASE [DB_A6710E_DBPROYECTO] SET  READ_WRITE 
GO
