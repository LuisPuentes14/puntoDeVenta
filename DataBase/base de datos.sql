USE [master]
GO
/****** Object:  Database [BDSISTEMA_VENTAS]    Script Date: 7/04/2025 10:29:54 a.m. ******/
CREATE DATABASE [BDSISTEMA_VENTAS]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'BDSISTEMA_VENTAS_Data', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDSISTEMA_VENTAS.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'BDSISTEMA_VENTAS_Log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\BDSISTEMA_VENTAS.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [BDSISTEMA_VENTAS].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ARITHABORT OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET  ENABLE_BROKER 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET  MULTI_USER 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET DB_CHAINING OFF 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET QUERY_STORE = ON
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [BDSISTEMA_VENTAS]
GO
/****** Object:  Table [dbo].[2]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[2](
	[Codigo] [varchar](50) NOT NULL,
	[Totalsalida] [float] NULL,
	[Totalentrada] [float] NULL,
	[Totalventa] [float] NULL,
	[Conteo] [float] NULL,
	[Fecha] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Aperturacaja]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Aperturacaja](
	[Codigo] [int] NULL,
	[Usuario] [nvarchar](50) NULL,
	[Valor] [float] NULL,
	[Fecha] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Arqueo]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Arqueo](
	[Codigo] [int] NULL,
	[Totalsalida] [float] NULL,
	[Totalentrada] [float] NULL,
	[Totalventa] [float] NULL,
	[Conteo] [float] NULL,
	[Fecha] [varchar](50) NULL,
	[usuario] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Categorías]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categorías](
	[IdCategoría] [int] NOT NULL,
	[NombreCategoría] [nvarchar](15) NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Clientes]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Clientes](
	[IdCliente] [varchar](50) NULL,
	[Nombre] [varchar](50) NULL,
	[Apellido] [varchar](50) NULL,
	[Teléfono] [varchar](50) NULL,
	[Saldo] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[DetallesVenta]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[DetallesVenta](
	[IdVenta] [varchar](10) NOT NULL,
	[IdProducto] [varchar](50) NOT NULL,
	[PrecioUnidad] [float] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Iva] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Empleados]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Empleados](
	[IdEmpleado] [int] NOT NULL,
	[Apellidos] [nvarchar](20) NOT NULL,
	[Nombre] [nvarchar](10) NOT NULL,
	[Cargo] [nvarchar](30) NULL,
	[Dirección] [nvarchar](60) NULL,
	[Telefono] [nvarchar](24) NULL,
	[Usuario] [nvarchar](255) NULL,
	[Contraseña] [nvarchar](255) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Entradaefectivo]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Entradaefectivo](
	[Codigo] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Valor] [float] NULL,
	[Fecha] [varchar](50) NULL,
	[Concepto] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Los diez productos más caros]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Los diez productos más caros](
	[DiezProductosMasCaros] [nvarchar](40) NULL,
	[PrecioUnidad] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pedidos]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pedidos](
	[IdPedido] [int] NOT NULL,
	[IdCliente] [nvarchar](5) NOT NULL,
	[IdEmpleado] [int] NULL,
	[FechaPedido] [datetime] NULL,
	[Valor] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Presentaciones]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Presentaciones](
	[Idpresentacion] [int] NULL,
	[Idproducto] [int] NULL,
	[Nombre] [varchar](50) NULL,
	[PrecioVenta] [float] NULL,
	[PrecioCompra] [float] NULL,
	[Cantidad] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos](
	[IdProducto] [int] NOT NULL,
	[NombreProducto] [nvarchar](40) NOT NULL,
	[IdProveedor] [int] NULL,
	[IdCategoría] [int] NULL,
	[CantidadPorUnidad] [nvarchar](20) NULL,
	[PrecioUnidad] [money] NULL,
	[UnidadesEnExistencia] [smallint] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Productos sobre el precio medio]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Productos sobre el precio medio](
	[NombreProducto] [nvarchar](40) NULL,
	[PrecioUnidad] [money] NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedores]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedores](
	[IdProveedor] [varchar](50) NULL,
	[NombreCompañía] [varchar](50) NULL,
	[NombreContacto] [varchar](50) NULL,
	[Direccion] [varchar](50) NULL,
	[Ciudad] [varchar](50) NULL,
	[Telefono] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Salidaefectivo]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Salidaefectivo](
	[Codigo] [varchar](50) NULL,
	[Usuario] [varchar](50) NULL,
	[Valor] [float] NULL,
	[Fecha] [varchar](50) NULL,
	[Concepto] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TProductos]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProductos](
	[CodigoProducto] [varchar](50) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[Unidad] [varchar](10) NOT NULL,
	[Cantidad] [float] NULL,
	[PrecioUnitario] [float] NOT NULL,
	[Iva] [int] NOT NULL,
	[Categoria] [varchar](50) NULL,
	[Proveedor] [varchar](50) NULL,
	[PrecioCompra] [float] NULL,
 CONSTRAINT [PK_TProductos] PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TProductos2]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProductos2](
	[CodigoProducto] [varchar](50) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[Unidad] [varchar](10) NOT NULL,
	[Cantidad] [int] NOT NULL,
	[PrecioUnitario] [float] NOT NULL,
	[Iva] [int] NULL,
 CONSTRAINT [PK__TProduct__785B009EF3BAD469] PRIMARY KEY CLUSTERED 
(
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TProductos3]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProductos3](
	[CodigoProducto] [varchar](50) NOT NULL,
	[Descripcion] [varchar](60) NOT NULL,
	[Unidad] [varchar](10) NOT NULL,
	[Cantidad] [float] NULL,
	[PrecioUnitario] [float] NOT NULL,
	[Iva] [int] NOT NULL,
	[Categoria] [varchar](50) NULL,
	[Proveedor] [varchar](50) NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TProductosVendidos]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TProductosVendidos](
	[CodigoVenta] [varchar](10) NOT NULL,
	[CodigoProducto] [varchar](50) NOT NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK__TProduct__05C7A46D5DC8706C] PRIMARY KEY CLUSTERED 
(
	[CodigoVenta] ASC,
	[CodigoProducto] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TUsuarios]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TUsuarios](
	[Usuario] [varchar](30) NOT NULL,
	[Contraseña] [varchar](20) NOT NULL,
	[Nombre] [varchar](40) NOT NULL,
	[Apellidos] [varchar](30) NOT NULL,
	[DNI] [varchar](8) NOT NULL,
	[Correo] [varchar](50) NOT NULL,
	[Categoria] [varchar](20) NULL,
PRIMARY KEY CLUSTERED 
(
	[Usuario] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TVentas]    Script Date: 7/04/2025 10:29:54 a.m. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TVentas](
	[CodigoVenta] [varchar](10) NOT NULL,
	[PrecioTotal] [varchar](50) NOT NULL,
	[Fecha] [varchar](50) NULL,
	[Cajero] [varchar](50) NULL,
	[Cliente] [varchar](50) NULL,
 CONSTRAINT [PK__TVentas__F242146465157A8C] PRIMARY KEY CLUSTERED 
(
	[CodigoVenta] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[TProductosVendidos]  WITH CHECK ADD  CONSTRAINT [FK__TProducto__Codig__3E52440B] FOREIGN KEY([CodigoVenta])
REFERENCES [dbo].[TVentas] ([CodigoVenta])
GO
ALTER TABLE [dbo].[TProductosVendidos] CHECK CONSTRAINT [FK__TProducto__Codig__3E52440B]
GO
ALTER TABLE [dbo].[TProductosVendidos]  WITH CHECK ADD  CONSTRAINT [FK__TProducto__Codig__3F466844] FOREIGN KEY([CodigoProducto])
REFERENCES [dbo].[TProductos2] ([CodigoProducto])
GO
ALTER TABLE [dbo].[TProductosVendidos] CHECK CONSTRAINT [FK__TProducto__Codig__3F466844]
GO
USE [master]
GO
ALTER DATABASE [BDSISTEMA_VENTAS] SET  READ_WRITE 
GO
