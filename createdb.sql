USE [master]
GO

IF DB_ID('Baseball') IS NOT NULL
BEGIN

 alter database [Baseball] set single_user with rollback immediate
/****** Object:  Database [Baseball]    Script Date: 11/3/2022 1:51:19 PM ******/
DROP DATABASE [Baseball]
END


/****** Object:  Database [Baseball]    Script Date: 11/3/2022 1:51:19 PM ******/
CREATE DATABASE [Baseball]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Baseball', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Baseball.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Baseball_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Baseball_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Baseball].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Baseball] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Baseball] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Baseball] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Baseball] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Baseball] SET ARITHABORT OFF 
GO

ALTER DATABASE [Baseball] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Baseball] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Baseball] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Baseball] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Baseball] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Baseball] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Baseball] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Baseball] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Baseball] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Baseball] SET  DISABLE_BROKER 
GO

ALTER DATABASE [Baseball] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Baseball] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Baseball] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Baseball] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Baseball] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Baseball] SET READ_COMMITTED_SNAPSHOT OFF 
GO

ALTER DATABASE [Baseball] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Baseball] SET RECOVERY SIMPLE 
GO

ALTER DATABASE [Baseball] SET  MULTI_USER 
GO

ALTER DATABASE [Baseball] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Baseball] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Baseball] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Baseball] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO

ALTER DATABASE [Baseball] SET DELAYED_DURABILITY = DISABLED 
GO

ALTER DATABASE [Baseball] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO

ALTER DATABASE [Baseball] SET QUERY_STORE = OFF
GO

ALTER DATABASE [Baseball] SET  READ_WRITE 
GO


USE [Baseball]
GO

/****** Object:  Table [dbo].[Teams]    Script Date: 11/3/2022 1:51:55 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Teams]') AND type in (N'U'))
DROP TABLE [dbo].[Teams]
GO

/****** Object:  Table [dbo].[Teams]    Script Date: 11/3/2022 1:51:55 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Teams](
	[TeamID] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [varchar](50) NOT NULL,
	[City] [varchar](50) NOT NULL,
	[League] [varchar](50) NOT NULL,
	[Wins] [int] NOT NULL,
	[Losses] [int] NOT NULL,
	[TeamMascot] [varchar](50) NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO

USE [Baseball]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 11/3/2022 1:52:14 PM ******/
IF  EXISTS (SELECT * FROM sys.objects WHERE object_id = OBJECT_ID(N'[dbo].[Players]') AND type in (N'U'))
DROP TABLE [dbo].[Players]
GO

/****** Object:  Table [dbo].[Players]    Script Date: 11/3/2022 1:52:14 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[Players](
	[PlayerID] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](50) NOT NULL,
	[LastName] [varchar](50) NOT NULL,
	[TeamID] [int] NOT NULL,
	[BattingAverage] [float] NOT NULL,
	[HomeRuns] [int] NOT NULL,
	[RBIs] [int] NOT NULL,
	[Position] [nchar](10) NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO


USE [Baseball]
GO

DELETE Players;
DELETE Teams;

declare @teamid int

INSERT INTO [dbo].[Teams]
           ([TeamName]
           ,[City]
           ,[League]
           ,[Wins]
           ,[Losses]
           ,[TeamMascot])
     VALUES
           ('Phillies'
           ,'Philadelphia'
           ,'National'
		   ,87
           ,75
           ,'Phanatic')
set @teamid = SCOPE_IDENTITY()

INSERT INTO [dbo].[Players]
           ([FirstName]
           ,[LastName]
           ,[TeamID]
           ,[BattingAverage]
           ,[HomeRuns]
           ,[RBIs]
           ,[Position])
     VALUES
           ('Kyle'
           ,'Schwaber'
		   ,@teamid
           ,0.218
           ,46
           ,94
           ,'LF'),
		   ('JT'
           ,'Realmuto'
		   ,@teamid
           ,0.276
           ,22
           ,84
           ,'C')

INSERT INTO [dbo].[Teams]
           ([TeamName]
           ,[City]
           ,[League]
           ,[Wins]
           ,[Losses]
           ,[TeamMascot])
     VALUES
           ('Yankees'
           ,'New York'
           ,'American'
		   ,99
           ,63
           ,'')
set @teamid = SCOPE_IDENTITY()

INSERT INTO [dbo].[Players]
           ([FirstName]
           ,[LastName]
           ,[TeamID]
           ,[BattingAverage]
           ,[HomeRuns]
           ,[RBIs]
           ,[Position])
     VALUES
           ('Aaron'
           ,'Judge'
		   ,@teamid
           ,0.311
           ,62
           ,131
           ,'CF'),
		   ('Anthony'
           ,'Rizzo'
		   ,@teamid
           ,0.224
           ,32
           ,75
           ,'1B')
GO




