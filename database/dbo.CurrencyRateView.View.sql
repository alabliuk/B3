USE [B3]
GO
/****** Object:  View [dbo].[CurrencyRateView]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[CurrencyRateView] as 

SELECT 
	C.name, CR.*
FROM Currencies C 
INNER JOIN CurrencyRate CR ON C.isoCode = CR.isoCode

GO
