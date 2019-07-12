USE [B3]
GO
/****** Object:  Table [dbo].[CurrenciesUpdateLog]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CurrenciesUpdateLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isoCode] [varchar](3) NULL,
	[name] [varchar](50) NULL,
	[type] [varchar](1) NULL,
	[createDate] [datetime] NULL
) ON [PRIMARY]
GO
