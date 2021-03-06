USE [SCF]
GO
/****** Object:  Table [dbo].[ItemsNotaDeCredito]    Script Date: 05/21/2016 13:35:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ItemsNotaDeCredito](
	[codigoItemNotaDeCredito] [int] IDENTITY(1,1) NOT NULL,
	[codigoNotaDeCredito] [int] NOT NULL,
	[codigoItemEntrega] [int] NOT NULL,
	[cantidad] [int] NOT NULL,
 CONSTRAINT [PK_ItemsNotaDeCredito] PRIMARY KEY CLUSTERED 
(
	[codigoItemNotaDeCredito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[NotasDeCredito]    Script Date: 05/21/2016 13:35:46 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[NotasDeCredito](
	[codigoNotaDeCredito] [int] IDENTITY(1,1) NOT NULL,
	[numeroNotaDeCredito] [int] NOT NULL,
	[codigoFactura] [int] NOT NULL,
	[isFacturaCompleta] [bit] NOT NULL,
	[total] [numeric](9, 2) NOT NULL,
	[subtotal] [numeric](9, 2) NOT NULL,
	[fechaHoraNotaDeCredito] [datetime] NOT NULL,
	[cae] [varchar](200) NULL,
	[fechaHoraVencimientoCAE] [datetime] NULL,
	[codigoTipoComprobante] [int] NOT NULL,
 CONSTRAINT [PK_NotasDeCredito] PRIMARY KEY CLUSTERED 
(
	[codigoNotaDeCredito] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  ForeignKey [FK_NotasDeCredito_AFIP_TiposComprobante]    Script Date: 05/21/2016 13:35:46 ******/
ALTER TABLE [dbo].[NotasDeCredito]  WITH CHECK ADD  CONSTRAINT [FK_NotasDeCredito_AFIP_TiposComprobante] FOREIGN KEY([codigoTipoComprobante])
REFERENCES [dbo].[AFIP_TiposComprobante] ([codigoTipoComprobante])
GO
ALTER TABLE [dbo].[NotasDeCredito] CHECK CONSTRAINT [FK_NotasDeCredito_AFIP_TiposComprobante]
GO
/****** Object:  ForeignKey [FK_NotasDeCredito_Facturas]    Script Date: 05/21/2016 13:35:46 ******/
ALTER TABLE [dbo].[NotasDeCredito]  WITH CHECK ADD  CONSTRAINT [FK_NotasDeCredito_Facturas] FOREIGN KEY([codigoFactura])
REFERENCES [dbo].[Facturas] ([codigoFactura])
GO
ALTER TABLE [dbo].[NotasDeCredito] CHECK CONSTRAINT [FK_NotasDeCredito_Facturas]
GO
