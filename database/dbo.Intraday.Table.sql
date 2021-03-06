USE [B3]
GO
/****** Object:  Table [dbo].[Intraday]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Intraday](
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
/****** Object:  Index [x1_unixTime]    Script Date: 12/07/2019 12:56:27 ******/
CREATE NONCLUSTERED INDEX [x1_unixTime] ON [dbo].[Intraday]
(
	[unixTime] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
/****** Object:  Index [x2_unixTime_idtAsset]    Script Date: 12/07/2019 12:56:27 ******/
CREATE NONCLUSTERED INDEX [x2_unixTime_idtAsset] ON [dbo].[Intraday]
(
	[unixTime] ASC,
	[idtAsset] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
