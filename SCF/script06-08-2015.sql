USE [master]
GO
/****** Object:  Database [SCF]    Script Date: 06/08/2015 15:21:46 ******/
CREATE DATABASE [SCF]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'SCF', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.EZEQUIELSQL\MSSQL\DATA\SCF.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'SCF_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.EZEQUIELSQL\MSSQL\DATA\SCF_1.ldf' , SIZE = 3136KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [SCF] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [SCF].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [SCF] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [SCF] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [SCF] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [SCF] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [SCF] SET ARITHABORT OFF 
GO
ALTER DATABASE [SCF] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [SCF] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [SCF] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [SCF] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [SCF] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [SCF] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [SCF] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [SCF] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [SCF] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [SCF] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [SCF] SET  DISABLE_BROKER 
GO
ALTER DATABASE [SCF] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [SCF] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [SCF] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [SCF] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [SCF] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [SCF] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [SCF] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [SCF] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [SCF] SET  MULTI_USER 
GO
ALTER DATABASE [SCF] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [SCF] SET DB_CHAINING OFF 
GO
ALTER DATABASE [SCF] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [SCF] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
USE [SCF]
GO
/****** Object:  Table [dbo].[Articulos]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Articulos](
	[codigoArticulo] [int] IDENTITY(1,1) NOT NULL,
	[descripcionCorta] [varchar](50) NOT NULL,
	[descripcionLarga] [varchar](200) NOT NULL,
	[marca] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Articulos] PRIMARY KEY CLUSTERED 
(
	[codigoArticulo] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ArticulosProveedor]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ArticulosProveedor](
	[codigoArticuloProveedor] [int] IDENTITY(1,1) NOT NULL,
	[codigoArticulo] [int] NOT NULL,
	[codigoProveedor] [int] NOT NULL,
	[codigoInterno] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ArticulosProveedor] PRIMARY KEY CLUSTERED 
(
	[codigoArticuloProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Clientes](
	[codigoCliente] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[localidad] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[mail] [varchar](50) NULL,
	[cuil] [varchar](50) NOT NULL,
	[isInactivo] [bit] NOT NULL,
 CONSTRAINT [PK_Clientes] PRIMARY KEY CLUSTERED 
(
	[codigoCliente] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[ContratosMarco]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[ContratosMarco](
	[codigoContratoMarco] [int] IDENTITY(1,1) NOT NULL,
	[codigoCliente] [int] NOT NULL,
	[fechaInicio] [datetime] NOT NULL,
	[fechaFin] [datetime] NOT NULL,
	[descripcion] [varchar](50) NOT NULL,
 CONSTRAINT [PK_ContratosMarco] PRIMARY KEY CLUSTERED 
(
	[codigoContratoMarco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Entregas]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Entregas](
	[codigoEntrega] [int] IDENTITY(1,1) NOT NULL,
	[fechaEntregaRealizada] [datetime] NOT NULL,
	[numeroRemito] [int] NULL,
	[codigoEstado] [int] NOT NULL,
	[observaciones] [varchar](200) NULL,
 CONSTRAINT [PK_Entrega] PRIMARY KEY CLUSTERED 
(
	[codigoEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[HistorialPreciosArticuloProveedor]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[HistorialPreciosArticuloProveedor](
	[codigoHistorialPrecioArticuloProveedor] [int] IDENTITY(1,1) NOT NULL,
	[fechaDesde] [datetime] NOT NULL,
	[fechaHasta] [datetime] NULL,
	[precio] [numeric](10, 2) NOT NULL,
	[codigoArticuloProveedor] [int] NOT NULL,
	[isDolar] [bit] NOT NULL,
 CONSTRAINT [PK_HistorialPreciosArticuloProveedor] PRIMARY KEY CLUSTERED 
(
	[codigoHistorialPrecioArticuloProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemsContratoMarco]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsContratoMarco](
	[codigoItemContratoMarco] [int] IDENTITY(1,1) NOT NULL,
	[codigoContratoMarco] [int] NOT NULL,
	[codigoArticulo] [int] NOT NULL,
	[precio] [numeric](10, 2) NOT NULL,
 CONSTRAINT [PK_ItemsContratoMarco] PRIMARY KEY CLUSTERED 
(
	[codigoItemContratoMarco] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemsEntrega]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsEntrega](
	[codigoItemEntrega] [int] IDENTITY(1,1) NOT NULL,
	[codigoEntrega] [int] NOT NULL,
	[codigoItemNotaDePedido] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[codigoArticuloProveedor] [int] NOT NULL,
 CONSTRAINT [PK_ItemsEntrega] PRIMARY KEY CLUSTERED 
(
	[codigoItemEntrega] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ItemsNotaDePedido]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsNotaDePedido](
	[codigoItemNotaDePedido] [int] IDENTITY(1,1) NOT NULL,
	[codigoArticulo] [int] NOT NULL,
	[codigoNotaDePedido] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
	[fechaEntrega] [datetime] NULL,
 CONSTRAINT [PK_ItemsNotaDePedido] PRIMARY KEY CLUSTERED 
(
	[codigoItemNotaDePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[NotasDePedido]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotasDePedido](
	[codigoNotaDePedido] [int] IDENTITY(1,1) NOT NULL,
	[numeroInternoCliente] [varchar](50) NOT NULL,
	[fechaEmision] [datetime] NOT NULL,
	[codigoEstado] [int] NOT NULL,
	[observaciones] [varchar](200) NOT NULL,
	[codigoContratoMarco] [int] NULL,
	[codigoCliente] [int] NOT NULL,
 CONSTRAINT [PK_NotasDePedido] PRIMARY KEY CLUSTERED 
(
	[codigoNotaDePedido] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Proveedores](
	[codigoProveedor] [int] IDENTITY(1,1) NOT NULL,
	[razonSocial] [varchar](50) NOT NULL,
	[provincia] [varchar](50) NOT NULL,
	[localidad] [varchar](50) NOT NULL,
	[direccion] [varchar](50) NOT NULL,
	[telefono] [varchar](50) NOT NULL,
	[mail] [varchar](50) NOT NULL,
	[cuil] [varchar](50) NOT NULL,
	[isInactivo] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedores] PRIMARY KEY CLUSTERED 
(
	[codigoProveedor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Usuarios]    Script Date: 06/08/2015 15:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Usuarios](
	[codigoUsuario] [int] IDENTITY(1,1) NOT NULL,
	[nombreUsuario] [varchar](50) NOT NULL,
	[contraseña] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[codigoUsuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[ArticulosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticulosProveedor_Articulos] FOREIGN KEY([codigoArticulo])
REFERENCES [dbo].[Articulos] ([codigoArticulo])
GO
ALTER TABLE [dbo].[ArticulosProveedor] CHECK CONSTRAINT [FK_ArticulosProveedor_Articulos]
GO
ALTER TABLE [dbo].[ArticulosProveedor]  WITH CHECK ADD  CONSTRAINT [FK_ArticulosProveedor_Proveedores] FOREIGN KEY([codigoProveedor])
REFERENCES [dbo].[Proveedores] ([codigoProveedor])
GO
ALTER TABLE [dbo].[ArticulosProveedor] CHECK CONSTRAINT [FK_ArticulosProveedor_Proveedores]
GO
ALTER TABLE [dbo].[HistorialPreciosArticuloProveedor]  WITH CHECK ADD  CONSTRAINT [FK_HistorialPreciosArticuloProveedor_ArticulosProveedor] FOREIGN KEY([codigoArticuloProveedor])
REFERENCES [dbo].[ArticulosProveedor] ([codigoArticuloProveedor])
GO
ALTER TABLE [dbo].[HistorialPreciosArticuloProveedor] CHECK CONSTRAINT [FK_HistorialPreciosArticuloProveedor_ArticulosProveedor]
GO
ALTER TABLE [dbo].[ItemsContratoMarco]  WITH CHECK ADD  CONSTRAINT [FK_ItemsContratoMarco_Articulos] FOREIGN KEY([codigoArticulo])
REFERENCES [dbo].[Articulos] ([codigoArticulo])
GO
ALTER TABLE [dbo].[ItemsContratoMarco] CHECK CONSTRAINT [FK_ItemsContratoMarco_Articulos]
GO
ALTER TABLE [dbo].[ItemsContratoMarco]  WITH CHECK ADD  CONSTRAINT [FK_ItemsContratoMarco_ContratosMarco] FOREIGN KEY([codigoContratoMarco])
REFERENCES [dbo].[ContratosMarco] ([codigoContratoMarco])
GO
ALTER TABLE [dbo].[ItemsContratoMarco] CHECK CONSTRAINT [FK_ItemsContratoMarco_ContratosMarco]
GO
ALTER TABLE [dbo].[ItemsEntrega]  WITH CHECK ADD  CONSTRAINT [FK_ItemsEntrega_ArticulosProveedor] FOREIGN KEY([codigoArticuloProveedor])
REFERENCES [dbo].[ArticulosProveedor] ([codigoArticuloProveedor])
GO
ALTER TABLE [dbo].[ItemsEntrega] CHECK CONSTRAINT [FK_ItemsEntrega_ArticulosProveedor]
GO
ALTER TABLE [dbo].[ItemsEntrega]  WITH CHECK ADD  CONSTRAINT [FK_ItemsEntrega_Entrega] FOREIGN KEY([codigoItemEntrega])
REFERENCES [dbo].[Entregas] ([codigoEntrega])
GO
ALTER TABLE [dbo].[ItemsEntrega] CHECK CONSTRAINT [FK_ItemsEntrega_Entrega]
GO
ALTER TABLE [dbo].[ItemsEntrega]  WITH CHECK ADD  CONSTRAINT [FK_ItemsEntrega_ItemsNotaDePedido] FOREIGN KEY([codigoItemNotaDePedido])
REFERENCES [dbo].[ItemsNotaDePedido] ([codigoItemNotaDePedido])
GO
ALTER TABLE [dbo].[ItemsEntrega] CHECK CONSTRAINT [FK_ItemsEntrega_ItemsNotaDePedido]
GO
ALTER TABLE [dbo].[ItemsNotaDePedido]  WITH CHECK ADD  CONSTRAINT [FK_ItemsPorNotaDePedido_Articulos] FOREIGN KEY([codigoArticulo])
REFERENCES [dbo].[Articulos] ([codigoArticulo])
GO
ALTER TABLE [dbo].[ItemsNotaDePedido] CHECK CONSTRAINT [FK_ItemsPorNotaDePedido_Articulos]
GO
ALTER TABLE [dbo].[ItemsNotaDePedido]  WITH CHECK ADD  CONSTRAINT [FK_ItemsPorNotaDePedido_NotasDePedido] FOREIGN KEY([codigoNotaDePedido])
REFERENCES [dbo].[NotasDePedido] ([codigoNotaDePedido])
GO
ALTER TABLE [dbo].[ItemsNotaDePedido] CHECK CONSTRAINT [FK_ItemsPorNotaDePedido_NotasDePedido]
GO
ALTER TABLE [dbo].[NotasDePedido]  WITH CHECK ADD  CONSTRAINT [FK_NotasDePedido_Clientes] FOREIGN KEY([codigoCliente])
REFERENCES [dbo].[Clientes] ([codigoCliente])
GO
ALTER TABLE [dbo].[NotasDePedido] CHECK CONSTRAINT [FK_NotasDePedido_Clientes]
GO
ALTER TABLE [dbo].[NotasDePedido]  WITH CHECK ADD  CONSTRAINT [FK_NotasDePedido_ContratosMarco] FOREIGN KEY([codigoContratoMarco])
REFERENCES [dbo].[ContratosMarco] ([codigoContratoMarco])
GO
ALTER TABLE [dbo].[NotasDePedido] CHECK CONSTRAINT [FK_NotasDePedido_ContratosMarco]
GO
USE [master]
GO
ALTER DATABASE [SCF] SET  READ_WRITE 
GO
