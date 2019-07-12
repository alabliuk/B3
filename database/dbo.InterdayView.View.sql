USE [B3]
GO
/****** Object:  View [dbo].[InterdayView]    Script Date: 12/07/2019 12:56:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE View [dbo].[InterdayView] as 

SELECT 
	A.code, A.companyAbvName, I.*
FROM Assets A 
INNER JOIN ProcessingAssets PA ON A.asset = PA.AssetCode
INNER JOIN Interday I ON I.idtAsset = A.idt

GO
