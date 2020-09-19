USE [Reservations]
GO

/****** Object:  Table [dbo].[Reserves]    Script Date: 19/09/2020 3:40:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Reserves](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DateReserve] [datetime2](7) NOT NULL,
	[Ranking] [int] NOT NULL,
	[FavoriteStatus] [bit] NOT NULL,
	[CustomerId] [int] NOT NULL,
	[Restaurant] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Reserves] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

ALTER TABLE [dbo].[Reserves] ADD  DEFAULT (N'') FOR [Restaurant]
GO

ALTER TABLE [dbo].[Reserves]  WITH CHECK ADD  CONSTRAINT [FK_Reserves_Customers_CustomerId] FOREIGN KEY([CustomerId])
REFERENCES [dbo].[Customers] ([Id])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[Reserves] CHECK CONSTRAINT [FK_Reserves_Customers_CustomerId]
GO


