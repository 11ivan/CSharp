USE [master]
GO
/****** Object:  Database [lol]    Script Date: 13/02/2017 18:39:47 ******/
CREATE DATABASE [lol]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'lol', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER12\MSSQL\DATA\lol.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'lol_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.MSSQLSERVER12\MSSQL\DATA\lol_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [lol] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [lol].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [lol] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [lol] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [lol] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [lol] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [lol] SET ARITHABORT OFF 
GO
ALTER DATABASE [lol] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [lol] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [lol] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [lol] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [lol] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [lol] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [lol] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [lol] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [lol] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [lol] SET  DISABLE_BROKER 
GO
ALTER DATABASE [lol] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [lol] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [lol] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [lol] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [lol] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [lol] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [lol] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [lol] SET RECOVERY FULL 
GO
ALTER DATABASE [lol] SET  MULTI_USER 
GO
ALTER DATABASE [lol] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [lol] SET DB_CHAINING OFF 
GO
ALTER DATABASE [lol] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [lol] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [lol] SET DELAYED_DURABILITY = DISABLED 
GO
EXEC sys.sp_db_vardecimal_storage_format N'lol', N'ON'
GO
USE [lol]
GO
/****** Object:  User [prueba]    Script Date: 13/02/2017 18:39:47 ******/
CREATE USER [prueba] FOR LOGIN [prueba] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_owner] ADD MEMBER [prueba]
GO
ALTER ROLE [db_datareader] ADD MEMBER [prueba]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [prueba]
GO
/****** Object:  Table [dbo].[Personajes]    Script Date: 13/02/2017 18:39:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Personajes](
	[idPersonaje] [int] IDENTITY(1,1) NOT NULL,
	[nombre] [varchar](50) NOT NULL,
	[alias] [varchar](100) NULL,
	[vida] [float] NULL,
	[regeneracion] [float] NULL,
	[danno] [float] NULL,
	[armadura] [float] NULL,
	[velAtaque] [float] NULL,
	[resistencia] [float] NULL,
	[velMovimiento] [float] NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
USE [master]
GO
ALTER DATABASE [lol] SET  READ_WRITE 
GO


insert into Personajes values('Aatrox', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0),
							 ('Ahri', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0),
							 ('Akali', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0),
							 ('Alistar', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0),
							 ('Amumu', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0),
							 ('Anivia', 'El dela moto', 0.0, 0.0, 0.0, 0.0, 0.0, 0.0, 0.0)