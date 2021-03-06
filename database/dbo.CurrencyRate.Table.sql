USE [B3]
GO
/****** Object:  Table [dbo].[CurrencyRate]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrencyRate](
	[isoCode] [varchar](3) NULL,
	[paridadeCompra] [int] NULL,
	[paridadeVenda] [int] NULL,
	[cotacaoCompra] [money] NULL,
	[cotacaoVenda] [money] NULL,
	[dataHoraCotacao] [datetime] NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [x1]    Script Date: 12/07/2019 12:56:27 ******/
CREATE NONCLUSTERED INDEX [x1] ON [dbo].[CurrencyRate]
(
	[isoCode] ASC,
	[dataHoraCotacao] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
