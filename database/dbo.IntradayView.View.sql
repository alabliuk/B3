USE [B3]
GO
/****** Object:  View [dbo].[IntradayView]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



CREATE View [dbo].[IntradayView] as 

SELECT 
	A.code, A.companyAbvName, I.*,
	CONVERT(DATE, I.date, 1) AS [day]
FROM Assets A 
INNER JOIN ProcessingAssets PA ON A.asset = PA.AssetCode
INNER JOIN Intraday I ON I.idtAsset = A.idt
--WHERE CONVERT(DATE, [Date]) >= (SELECT TOP 1 CONVERT(DATE, [Date]) FROM [Intraday] ORDER BY [DATE] DESC)

GO
