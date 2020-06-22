USE [MiniPOS]
GO
/****** Object:  Table [dbo].[Categoria]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categoria](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Habilitada] [bit] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Categoria] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CierreCaja]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CierreCaja](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Estado] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[MontoEnCaja] [numeric](18, 2) NOT NULL,
	[Diferencia] [numeric](18, 2) NOT NULL,
	[UsuarioAlta] [varchar](25) NOT NULL,
 CONSTRAINT [PK_CierreCaja] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Egresos]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Egresos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCierreCaja] [int] NOT NULL,
	[Concepto] [varchar](50) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Egresos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Gasto]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Gasto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[IdTipoGasto] [int] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[SaleDeCaja] [bit] NOT NULL,
	[Comentario] [nvarchar](max) NULL,
	[Anulada] [bit] NOT NULL,
	[MotivoAnulada] [nvarchar](max) NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[UsuarioActualizacion] [nvarchar](25) NOT NULL,
 CONSTRAINT [PK_Gasto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingresos]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingresos](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdCierreCaja] [int] NOT NULL,
	[Concepto] [varchar](50) NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_Ingresos] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Mercaderia]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Mercaderia](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Fecha] [datetime] NOT NULL,
	[FechaRecepcion] [datetime] NOT NULL,
	[IdProveedor] [int] NULL,
	[Estado] [int] NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[UsuarioActualizacion] [varchar](25) NOT NULL,
 CONSTRAINT [PK_Mercaderia] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MercaderiaItem]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MercaderiaItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdMercaderia] [int] NULL,
	[IdProducto] [int] NULL,
	[Cantidad] [int] NOT NULL,
 CONSTRAINT [PK_MercaderiaItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Pago]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Pago](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FormaPago] [int] NOT NULL,
	[Monto] [numeric](18, 2) NOT NULL,
	[MontoPago] [numeric](18, 2) NOT NULL,
	[NumeroLote] [int] NULL,
	[NumeroComprobante] [int] NULL,
 CONSTRAINT [PK_Pago] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Producto]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Producto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Codigo] [varchar](50) NOT NULL,
	[Descripcion] [varchar](max) NOT NULL,
	[IdCategoria] [int] NULL,
	[IdProveedor] [int] NULL,
	[Suelto] [bit] NOT NULL,
	[Costo] [numeric](18, 2) NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[StockMinimo] [int] NOT NULL,
	[StockOptimo] [int] NOT NULL,
	[StockActual] [int] NOT NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[UsuarioActualizacion] [varchar](25) NOT NULL,
	[Borrado] [bit] NOT NULL,
	[FechaBorrado] [datetime] NULL,
	[UsuarioBorrado] [varchar](25) NULL,
 CONSTRAINT [PK_Producto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Proveedor]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Proveedor](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RazonSocial] [nvarchar](50) NOT NULL,
	[Direccion] [nvarchar](100) NULL,
	[Telefono] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Habilitado] [bit] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_Proveedor] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProveedorXProducto]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProveedorXProducto](
	[ProveedorId] [int] NOT NULL,
	[ProductoId] [int] NOT NULL,
 CONSTRAINT [PK_ProveedorXProducto] PRIMARY KEY CLUSTERED 
(
	[ProveedorId] ASC,
	[ProductoId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TipoGasto]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TipoGasto](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Descripcion] [nvarchar](50) NOT NULL,
	[Habilitada] [bit] NOT NULL,
	[Borrado] [bit] NOT NULL,
 CONSTRAINT [PK_TipoGasto] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Usuario]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Usuario](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Alias] [nvarchar](50) NOT NULL,
	[Nombre] [nvarchar](50) NULL,
	[Apellido] [nvarchar](50) NULL,
	[Clave] [nvarchar](max) NOT NULL,
	[Habilitado] [bit] NOT NULL,
	[FechaUltimoAcceso] [datetime] NULL,
	[FechaActualizacion] [datetime] NOT NULL,
	[UsuarioActualizacion] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Usuario] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Venta]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Venta](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdPago] [int] NOT NULL,
	[FechaAlta] [datetime] NOT NULL,
	[UsuarioAlta] [varchar](25) NOT NULL,
	[Anulada] [bit] NOT NULL,
	[MotivoAnulada] [varchar](max) NULL,
	[FechaAnulada] [datetime] NULL,
	[UsuarioAnulada] [varchar](25) NULL,
 CONSTRAINT [PK_Venta] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[VentaItem]    Script Date: 20/6/2020 11:49:23 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[VentaItem](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IdVenta] [int] NOT NULL,
	[IdProducto] [int] NOT NULL,
	[Cantidad] [int] NOT NULL,
	[Precio] [numeric](18, 2) NOT NULL,
 CONSTRAINT [PK_VentaItem] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categoria] ADD  CONSTRAINT [DF_Categoria_Borrado]  DEFAULT ((0)) FOR [Borrado]
GO
ALTER TABLE [dbo].[Producto] ADD  CONSTRAINT [DF_Producto_Borrado]  DEFAULT ((0)) FOR [Borrado]
GO
ALTER TABLE [dbo].[TipoGasto] ADD  CONSTRAINT [DF_TipoGasto_Borrado]  DEFAULT ((0)) FOR [Borrado]
GO
ALTER TABLE [dbo].[Egresos]  WITH CHECK ADD  CONSTRAINT [FK_Egresos_CierreCaja] FOREIGN KEY([IdCierreCaja])
REFERENCES [dbo].[CierreCaja] ([Id])
GO
ALTER TABLE [dbo].[Egresos] CHECK CONSTRAINT [FK_Egresos_CierreCaja]
GO
ALTER TABLE [dbo].[Gasto]  WITH CHECK ADD  CONSTRAINT [FK_Gasto_TipoGasto] FOREIGN KEY([IdTipoGasto])
REFERENCES [dbo].[TipoGasto] ([Id])
GO
ALTER TABLE [dbo].[Gasto] CHECK CONSTRAINT [FK_Gasto_TipoGasto]
GO
ALTER TABLE [dbo].[Ingresos]  WITH CHECK ADD  CONSTRAINT [FK_Ingresos_CierreCaja] FOREIGN KEY([IdCierreCaja])
REFERENCES [dbo].[CierreCaja] ([Id])
GO
ALTER TABLE [dbo].[Ingresos] CHECK CONSTRAINT [FK_Ingresos_CierreCaja]
GO
ALTER TABLE [dbo].[MercaderiaItem]  WITH CHECK ADD  CONSTRAINT [FK_MercaderiaItem_Mercaderia] FOREIGN KEY([IdMercaderia])
REFERENCES [dbo].[Mercaderia] ([Id])
GO
ALTER TABLE [dbo].[MercaderiaItem] CHECK CONSTRAINT [FK_MercaderiaItem_Mercaderia]
GO
ALTER TABLE [dbo].[MercaderiaItem]  WITH CHECK ADD  CONSTRAINT [FK_MercaderiaItem_Producto] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[MercaderiaItem] CHECK CONSTRAINT [FK_MercaderiaItem_Producto]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Categoria] FOREIGN KEY([IdCategoria])
REFERENCES [dbo].[Categoria] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Categoria]
GO
ALTER TABLE [dbo].[Producto]  WITH CHECK ADD  CONSTRAINT [FK_Producto_Proveedor] FOREIGN KEY([IdProveedor])
REFERENCES [dbo].[Proveedor] ([Id])
GO
ALTER TABLE [dbo].[Producto] CHECK CONSTRAINT [FK_Producto_Proveedor]
GO
ALTER TABLE [dbo].[VentaItem]  WITH CHECK ADD  CONSTRAINT [FK_VentaItem_Venta] FOREIGN KEY([IdVenta])
REFERENCES [dbo].[Venta] ([Id])
GO
ALTER TABLE [dbo].[VentaItem] CHECK CONSTRAINT [FK_VentaItem_Venta]
GO
ALTER TABLE [dbo].[VentaItem]  WITH CHECK ADD  CONSTRAINT [FK_VentaItem_VentaItem] FOREIGN KEY([IdProducto])
REFERENCES [dbo].[Producto] ([Id])
GO
ALTER TABLE [dbo].[VentaItem] CHECK CONSTRAINT [FK_VentaItem_VentaItem]
GO

/****** alta usuario admin/admin123 ******/
SET IDENTITY_INSERT [dbo].[Usuario] ON 

INSERT [dbo].[Usuario] ([Id], [Alias], [Nombre], [Apellido], [Clave], [Habilitado], [FechaUltimoAcceso], [FechaActualizacion], [UsuarioActualizacion]) VALUES (1004, N'admin', N'admin', N'admin', N'2LMLzeHiZ6kp2M+hwTVUow==', 1, NULL, CAST(N'2020-06-20T14:15:26.447' AS DateTime), N'admin')
SET IDENTITY_INSERT [dbo].[Usuario] OFF
GO