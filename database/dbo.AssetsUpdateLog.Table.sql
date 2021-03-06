USE [B3]
GO
/****** Object:  Table [dbo].[AssetsUpdateLog]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AssetsUpdateLog](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[idt] [int] NULL,
	[code] [varchar](100) NULL,
	[asset] [varchar](100) NULL,
	[companyName] [varchar](500) NULL,
	[companyAbvName] [varchar](500) NULL,
	[createDate] [datetime] NULL
) ON [PRIMARY]
GO
