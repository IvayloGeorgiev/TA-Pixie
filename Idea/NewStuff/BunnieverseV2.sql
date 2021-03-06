IF DB_ID('Bunnyverse') IS NULL
	CREATE DATABASE [Bunnyverse]
GO

USE [Bunnyverse]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_Visits_Ships]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits] DROP CONSTRAINT [FK_Visits_Planets]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ships_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ships]'))
ALTER TABLE [dbo].[Ships] DROP CONSTRAINT [FK_Ships_Planets]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals] DROP CONSTRAINT [FK_Meals_Foods]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Bunnies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals] DROP CONSTRAINT [FK_Meals_Bunnies]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Visits]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered] DROP CONSTRAINT [FK_FoodGathered_Visits]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered] DROP CONSTRAINT [FK_FoodGathered_Foods]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo] DROP CONSTRAINT [FK_Cargo_Ships]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo] DROP CONSTRAINT [FK_Cargo_Foods]
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bunnies_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bunnies]'))
ALTER TABLE [dbo].[Bunnies] DROP CONSTRAINT [FK_Bunnies_Ships]
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Visits]') AND type in (N'U'))
DROP TABLE [dbo].[Visits]
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ships]') AND type in (N'U'))
DROP TABLE [dbo].[Ships]
GO
/****** Object:  Table [dbo].[Planets]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planets]') AND type in (N'U'))
DROP TABLE [dbo].[Planets]
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Meals]') AND type in (N'U'))
DROP TABLE [dbo].[Meals]
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Foods]') AND type in (N'U'))
DROP TABLE [dbo].[Foods]
GO
/****** Object:  Table [dbo].[FoodGathered]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FoodGathered]') AND type in (N'U'))
DROP TABLE [dbo].[FoodGathered]
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cargo]') AND type in (N'U'))
DROP TABLE [dbo].[Cargo]
GO
/****** Object:  Table [dbo].[Bunnies]    Script Date: 30/08/2014 11:23:25 ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bunnies]') AND type in (N'U'))
DROP TABLE [dbo].[Bunnies]
GO
/****** Object:  Table [dbo].[Bunnies]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Bunnies]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Bunnies](
	[BunnyID] [int] NOT NULL,
	[BunnyName] [nvarchar](50) NOT NULL,
	[ShipID] [int] NOT NULL,
 CONSTRAINT [PK_Bunnies] PRIMARY KEY CLUSTERED 
(
	[BunnyID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Cargo]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Cargo]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Cargo](
	[ShipID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[FoodQuantity] [float] NOT NULL,
 CONSTRAINT [PK_Cargo] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC,
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[FoodGathered]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[FoodGathered]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[FoodGathered](
	[FoodID] [int] NOT NULL,
	[VisitID] [int] NOT NULL,
	[Quantity] [float] NOT NULL,
 CONSTRAINT [PK_FoodGathered] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC,
	[VisitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Foods]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Foods]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Foods](
	[FoodID] [int] NOT NULL,
	[FoodName] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Foods] PRIMARY KEY CLUSTERED 
(
	[FoodID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Meals]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Meals]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Meals](
	[MealID] [int] IDENTITY(1,1) NOT NULL,
	[BunnyID] [int] NOT NULL,
	[FoodID] [int] NOT NULL,
	[FoodQuantity] [float] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Meals_1] PRIMARY KEY CLUSTERED 
(
	[MealID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Planets]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Planets]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Planets](
	[PlanetID] [int] NOT NULL,
	[PlanetName] [nvarchar](50) NOT NULL,
	[X] [float] NOT NULL,
	[Y] [float] NOT NULL,
	[Z] [float] NOT NULL,
 CONSTRAINT [PK_Planets] PRIMARY KEY CLUSTERED 
(
	[PlanetID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Ships]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Ships]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Ships](
	[ShipID] [int] NOT NULL,
	[ShipName] [nvarchar](50) NOT NULL,
	[EnginePower] [float] NOT NULL,
	[CurrentPlanetID] [int] NULL,
 CONSTRAINT [PK_Ships] PRIMARY KEY CLUSTERED 
(
	[ShipID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[Visits]    Script Date: 30/08/2014 11:23:25 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF NOT EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Visits]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[Visits](
	[VisidID] [int] IDENTITY(1,1) NOT NULL,
	[PlanetID] [int] NOT NULL,
	[ShipID] [int] NOT NULL,
	[Date] [date] NOT NULL,
 CONSTRAINT [PK_Visits] PRIMARY KEY CLUSTERED 
(
	[VisidID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
END
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bunnies_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bunnies]'))
ALTER TABLE [dbo].[Bunnies]  WITH CHECK ADD  CONSTRAINT [FK_Bunnies_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Bunnies_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Bunnies]'))
ALTER TABLE [dbo].[Bunnies] CHECK CONSTRAINT [FK_Bunnies_Ships]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Foods]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo]  WITH CHECK ADD  CONSTRAINT [FK_Cargo_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Cargo_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Cargo]'))
ALTER TABLE [dbo].[Cargo] CHECK CONSTRAINT [FK_Cargo_Ships]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered]  WITH CHECK ADD  CONSTRAINT [FK_FoodGathered_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered] CHECK CONSTRAINT [FK_FoodGathered_Foods]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Visits]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered]  WITH CHECK ADD  CONSTRAINT [FK_FoodGathered_Visits] FOREIGN KEY([VisitID])
REFERENCES [dbo].[Visits] ([VisidID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_FoodGathered_Visits]') AND parent_object_id = OBJECT_ID(N'[dbo].[FoodGathered]'))
ALTER TABLE [dbo].[FoodGathered] CHECK CONSTRAINT [FK_FoodGathered_Visits]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Bunnies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_Bunnies] FOREIGN KEY([BunnyID])
REFERENCES [dbo].[Bunnies] ([BunnyID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Bunnies]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_Bunnies]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals]  WITH CHECK ADD  CONSTRAINT [FK_Meals_Foods] FOREIGN KEY([FoodID])
REFERENCES [dbo].[Foods] ([FoodID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Meals_Foods]') AND parent_object_id = OBJECT_ID(N'[dbo].[Meals]'))
ALTER TABLE [dbo].[Meals] CHECK CONSTRAINT [FK_Meals_Foods]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ships_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ships]'))
ALTER TABLE [dbo].[Ships]  WITH CHECK ADD  CONSTRAINT [FK_Ships_Planets] FOREIGN KEY([CurrentPlanetID])
REFERENCES [dbo].[Planets] ([PlanetID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Ships_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Ships]'))
ALTER TABLE [dbo].[Ships] CHECK CONSTRAINT [FK_Ships_Planets]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Planets] FOREIGN KEY([PlanetID])
REFERENCES [dbo].[Planets] ([PlanetID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Planets]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Planets]
GO
IF NOT EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits]  WITH CHECK ADD  CONSTRAINT [FK_Visits_Ships] FOREIGN KEY([ShipID])
REFERENCES [dbo].[Ships] ([ShipID])
GO
IF  EXISTS (SELECT * FROM sys.foreign_keys WHERE object_id = OBJECT_ID(N'[dbo].[FK_Visits_Ships]') AND parent_object_id = OBJECT_ID(N'[dbo].[Visits]'))
ALTER TABLE [dbo].[Visits] CHECK CONSTRAINT [FK_Visits_Ships]
GO
