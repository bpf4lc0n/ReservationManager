USE [Reservations]
GO

/****** Object:  StoredProcedure [dbo].[Usp_GetReservesByPage]    Script Date: 19/09/2020 3:41:15 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

-- =============================================
-- Author:		BPF
-- Create date: <Create Date,,>
-- Description:	RESERVES BY PAGE ACCORDING TO PAGE SIZE
-- =============================================
CREATE PROCEDURE [dbo].[Usp_GetReservesByPage]  
	
	@PageNo VARCHAR(10) ,  
	@PageSize VARCHAR(10) ,  
	@SortField VARCHAR(15),
	@SortOrder VARCHAR(4)	

	/*
	@p0 VARCHAR(10) ,  
	@p1 VARCHAR(10) ,  
	@p2 VARCHAR(15),
	@p3 VARCHAR(4)*/
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

DECLARE @SQLStatement varchar(max)

SELECT @SQLStatement =
'SELECT '+  
	'Id, DateReserve, Ranking, FavoriteStatus, CustomerId, Restaurant '+
	'FROM '+  
		'(SELECT ROW_NUMBER() OVER (   '+ 
			'ORDER BY ' + @SortField + '  ' + @SortOrder + ' ) AS [ROWNUM], * '+
			'FROM   DBO.RESERVES) T ' +  
	 'WHERE T.ROWNUM BETWEEN (('+@PageNo+'-1)*'+@PageSize+' +1) AND ('+@PageNo+'*'+@PageSize+')' 

EXEC(@SQLStatement)

END

GO


