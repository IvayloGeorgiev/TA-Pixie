CREATE DATABASE [Bunnyverse_simple]
GO

USE [Bunnyverse_simple]
GO
/****** Object:  Table [dbo].[Bunnies]    Script Date: 28.8.2014 г. 18:38:31 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bunnies](
	[BunnyID] [int] NOT NULL,
	[BunnyName] [nvarchar](50) NOT NULL,
	[Weight] [float] NOT NULL,
	[ShipID] [int] NOT NULL,
 CONSTRAINT [PK_Bunnies] PRIMARY KEY CLUSTERED 
(
	[BunnyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planets]    Script Date: 28.8.2014 г. 18:38:31 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planets](
	[PlanetID] [int] NOT NULL,
	[PlanetName] [nvarchar](50) NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Z] [int] NOT NULL,
 CONSTRAINT [PK_Planets] PRIMARY KEY CLUSTERED 
(
	[PlanetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ships]    Script Date: 28.8.2014 г. 18:38:31 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[ShipID] [int] NOT NULL,
	[ShipName] [nvarchar](50) NOT NULL,
	[EnginePower] [float] NOT NULL,
	[CurrentPlanetID] [int] NULL,
	[FoodQuantity] [float] NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visits]    Script Date: 28.8.2014 г. 18:38:31 ч. ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[PlanetID] [int] NOT NULL,
	[ShipID] [int] NOT NULL,
	[Date] [date] NOT NULL,
	[FoodQuantity] [float] NOT NULL,
 CONSTRAINT [PK_Visits_1] PRIMARY KEY CLUSTERED 
(
	[PlanetID] ASC,
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bunnies]  WITH CHECK ADD  CONSTRAINT [FK_Bunnies_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
ALTER TABLE [dbo].[Bunnies] CHECK CONSTRAINT [FK_Bunnies_Ships]
GO
ALTER TABLE [dbo].[Ships]  WITH CHECK ADD  CONSTRAINT [FK_Ships_Planets] FOREIGN KEY([CurrentPlanetID])
REFERENCES [dbo].[Planets] ([PlanetID])
GO
ALTER TABLE [dbo].[Ships] CHECK CONSTRAINT [FK_Ships_Planets]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Planets] FOREIGN KEY([PlanetID])
REFERENCES [dbo].[Planets] ([PlanetID])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Planets]
GO
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Ships]
GO
