IF DB_ID('Bunnyverse') IS NULL
	CREATE DATABASE [Bunnyverse]
GO

USE [Bunnyverse]
GO
ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_Visits_Ships]
GO
ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_Visits_Planets]
GO
ALTER TABLE [dbo].[Ships] DROP CONSTRAINT [FK_Ships_Planets]
GO
ALTER TABLE [dbo].[Meals] DROP CONSTRAINT [FK_Meals_Foods]
GO
ALTER TABLE [dbo].[Meals] DROP CONSTRAINT [FK_Meals_Bunnies]
GO
ALTER TABLE [dbo].[FoodGathered] DROP CONSTRAINT [FK_FoodGathered_Visits]
GO
ALTER TABLE [dbo].[FoodGathered] DROP CONSTRAINT [FK_FoodGathered_Foods]
GO
ALTER TABLE [dbo].[Cargo] DROP CONSTRAINT [FK_Cargo_Ships]
GO
ALTER TABLE [dbo].[Cargo] DROP CONSTRAINT [FK_Cargo_Foods]
GO
ALTER TABLE [dbo].[Bunnies] DROP CONSTRAINT [FK_Bunnies_Ships]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Visits]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Ships]
GO
/****** Object:  Table [dbo].[Planets]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Planets]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Meals]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Foods]
GO
/****** Object:  Table [dbo].[FoodGathered]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[FoodGathered]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Cargo]
GO
/****** Object:  Table [dbo].[Bunnies]    Script Date: 02/09/2014 12:08:59 ******/
DROP TABLE [dbo].[Bunnies]
GO
/****** Object:  Table [dbo].[Bunnies]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Bunnies](
	[BunnyID] [uniqueidentifier] NOT NULL,
	[BunnyName] [nvarchar](50) NOT NULL,
	[ShipID] [uniqueidentifier] NOT NULL,
 CONSTRAINT [PK_Bunnies] PRIMARY KEY CLUSTERED 
(
	[BunnyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cargo](
	[ShipID] [uniqueidentifier] NOT NULL,
	[FoodID] [uniqueidentifier] NOT NULL,
	[FoodQuantity] [float] NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC,
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[FoodGathered]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FoodGathered](
	[FoodID] [uniqueidentifier] NOT NULL,
	[VisitID] [uniqueidentifier] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_FoodGathered] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC,
	[VisitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Foods]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Foods](
	[FoodID] [uniqueidentifier] NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Meals]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Meals](
	[MealID] [int] IDENTITY(1,1) NOT NULL,
	[BunnyID] [uniqueidentifier] NOT NULL,
	[FoodID] [uniqueidentifier] NOT NULL,
	[FoodQuantity] [float] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Meals_1] PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Planets]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Planets](
	[PlanetID] [uniqueidentifier] NOT NULL,
	[PlanetName] [nvarchar](50) NOT NULL,
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[Z] [float] NOT NULL,
 CONSTRAINT [PK_Planets] PRIMARY KEY CLUSTERED 
(
	[PlanetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Ships]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ships](
	[ShipID] [uniqueidentifier] NOT NULL,
	[ShipName] [nvarchar](50) NOT NULL,
	[EnginePower] [float] NOT NULL,
	[CurrentPlanetID] [uniqueidentifier] NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Visits]    Script Date: 02/09/2014 12:08:59 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Visits](
	[VisidID] [uniqueidentifier] NOT NULL,
	[PlanetID] [uniqueidentifier] NOT NULL,
	[ShipID] [uniqueidentifier] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[VisidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[Bunnies]  WITH CHECK ADD  CONSTRAINT [FK_Bunnies_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
ALTER TABLE [dbo].[Bunnies] CHECK CONSTRAINT [FK_Bunnies_Ships]
GO
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Foods]
GO
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Ships]
GO
ALTER TABLE [dbo].[FoodGathered]  WITH CHECK ADD  CONSTRAINT [FK_FoodGathered_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
ALTER TABLE [dbo].[FoodGathered] CHECK CONSTRAINT [FK_FoodGathered_Foods]
GO
ALTER TABLE [dbo].[FoodGathered]  WITH CHECK ADD  CONSTRAINT [FK_FoodGathered_Visits] FOREIGN KEY([VisitID])
REFERENCES [dbo].[Visits] ([VisidID])
GO
ALTER TABLE [dbo].[FoodGathered] CHECK CONSTRAINT [FK_FoodGathered_Visits]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_Bunnies] FOREIGN KEY([BunnyID])
REFERENCES [dbo].[Bunnies] ([BunnyID])
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_Bunnies]
GO
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_Foods]
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
