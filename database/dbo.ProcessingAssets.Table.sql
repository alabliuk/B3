USE [B3]
GO
/****** Object:  Table [dbo].[ProcessingAssets]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProcessingAssets](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[assetCode] [varchar](10) NULL,
	[createDate] [datetime] NULL,
 CONSTRAINT [PK_IntradayAsset] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
