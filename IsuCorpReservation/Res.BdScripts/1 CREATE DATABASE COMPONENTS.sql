/*
Run this script on:

        (local).RESERVE    -  This database will be modified

to synchronize it with:

        (local).Reservations

You are recommended to back up your database before running this script

Script created by SQL Compare version 11.6.11 from Red Gate Software Ltd at 19/09/2020 3:43:58

*/
SET NUMERIC_ROUNDABORT OFF
GO
SET ANSI_PADDING, ANSI_WARNINGS, CONCAT_NULL_YIELDS_NULL, ARITHABORT, QUOTED_IDENTIFIER, ANSI_NULLS ON
GO
SET XACT_ABORT ON
GO
SET TRANSACTION ISOLATION LEVEL SERIALIZABLE
GO
BEGIN TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Reserves]'
GO
CREATE TABLE [dbo].[Reserves]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[DateReserve] [datetime2] NOT NULL,
[Ranking] [int] NOT NULL,
[FavoriteStatus] [bit] NOT NULL,
[CustomerId] [int] NOT NULL,
[Restaurant] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NOT NULL CONSTRAINT [DF__Reserves__Restau__47DBAE45] DEFAULT (N'')
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Reserves] on [dbo].[Reserves]'
GO
ALTER TABLE [dbo].[Reserves] ADD CONSTRAINT [PK_Reserves] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_Reserves_CustomerId] on [dbo].[Reserves]'
GO
CREATE NONCLUSTERED INDEX [IX_Reserves_CustomerId] ON [dbo].[Reserves] ([CustomerId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[CustomerTypes]'
GO
CREATE TABLE [dbo].[CustomerTypes]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[ContactType] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_CustomerTypes] on [dbo].[CustomerTypes]'
GO
ALTER TABLE [dbo].[CustomerTypes] ADD CONSTRAINT [PK_CustomerTypes] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Customers]'
GO
CREATE TABLE [dbo].[Customers]
(
[Id] [int] NOT NULL IDENTITY(1, 1),
[Name] [nchar] (50) COLLATE Modern_Spanish_CI_AS NOT NULL,
[ContactTypeId] [int] NOT NULL,
[Telephone] [nchar] (15) COLLATE Modern_Spanish_CI_AS NOT NULL,
[DateBirth] [datetime2] NOT NULL,
[Description] [nvarchar] (max) COLLATE Modern_Spanish_CI_AS NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK_Customers] on [dbo].[Customers]'
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED  ([Id])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating index [IX_Customers_ContactTypeId] on [dbo].[Customers]'
GO
CREATE NONCLUSTERED INDEX [IX_Customers_ContactTypeId] ON [dbo].[Customers] ([ContactTypeId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[__EFMigrationsHistory]'
GO
CREATE TABLE [dbo].[__EFMigrationsHistory]
(
[MigrationId] [nvarchar] (150) COLLATE Modern_Spanish_CI_AS NOT NULL,
[ProductVersion] [nvarchar] (32) COLLATE Modern_Spanish_CI_AS NOT NULL
)
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating primary key [PK___EFMigrationsHistory] on [dbo].[__EFMigrationsHistory]'
GO
ALTER TABLE [dbo].[__EFMigrationsHistory] ADD CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED  ([MigrationId])
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Creating [dbo].[Usp_GetReservesByPage]'
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
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Customers]'
GO
ALTER TABLE [dbo].[Customers] ADD CONSTRAINT [FK_Customers_CustomerTypes_ContactTypeId] FOREIGN KEY ([ContactTypeId]) REFERENCES [dbo].[CustomerTypes] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
PRINT N'Adding foreign keys to [dbo].[Reserves]'
GO
ALTER TABLE [dbo].[Reserves] ADD CONSTRAINT [FK_Reserves_Customers_CustomerId] FOREIGN KEY ([CustomerId]) REFERENCES [dbo].[Customers] ([Id]) ON DELETE CASCADE
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
COMMIT TRANSACTION
GO
IF @@ERROR <> 0 SET NOEXEC ON
GO
DECLARE @Success AS BIT
SET @Success = 1
SET NOEXEC OFF
IF (@Success = 1) PRINT 'The database update succeeded'
ELSE BEGIN
	IF @@TRANCOUNT > 0 ROLLBACK TRANSACTION
	PRINT 'The database update failed'
END
GO
