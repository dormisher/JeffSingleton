USE [DB_14030_dandev]
GO
/****** Object:  Table [dbo].[GalleryImages]    Script Date: 01/16/2012 14:14:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GalleryImages](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Filename] [nvarchar](max) NULL,
	[Thumbnail] [nvarchar](max) NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[GallerySection] [int] NOT NULL,
	[Order] [int] NOT NULL,
	[Title] [nvarchar](max) NULL,
	[Info] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
