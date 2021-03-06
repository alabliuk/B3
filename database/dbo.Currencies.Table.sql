USE [B3]
GO
/****** Object:  Table [dbo].[Currencies]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Currencies](
	[id] [int] IDENTITY(1,1) NOT NULL,
	[isoCode] [varchar](3) NULL,
	[name] [varchar](50) NULL,
	[type] [varchar](1) NULL,
	[createDate] [datetime] NULL,
	[updateDate] [datetime] NULL,
 CONSTRAINT [PK_Currencies] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
