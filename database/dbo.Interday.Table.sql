USE [B3]
GO
/****** Object:  Table [dbo].[Interday]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Interday](
	[idtAsset] [int] NULL,
	[date] [datetime] NULL,
	[unixTime] [numeric](18, 0) NULL,
	[price] [money] NULL,
	[low] [money] NULL,
	[high] [money] NULL,
	[var] [float] NULL,
	[varpct] [float] NULL,
	[vol] [int] NULL
) ON [PRIMARY]
GO
/****** Object:  Index [dateX1]    Script Date: 12/07/2019 12:56:27 ******/
CREATE NONCLUSTERED INDEX [dateX1] ON [dbo].[Interday]
(
	[unixTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [dateX2]    Script Date: 12/07/2019 12:56:27 ******/
CREATE NONCLUSTERED INDEX [dateX2] ON [dbo].[Interday]
(
	[unixTime] ASC,
	[date] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
