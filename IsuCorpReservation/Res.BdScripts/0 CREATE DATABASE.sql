USE [master]
GO

/****** Object:  Database [Reservations]    Script Date: 19/09/2020 16:12:45 ******/
CREATE DATABASE [Reservations]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Reservations', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Reservations.mdf' , SIZE = 4160KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Reservations_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL11.MSSQLSERVER\MSSQL\DATA\Reservations_log.ldf' , SIZE = 1040KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO

ALTER DATABASE [Reservations] SET COMPATIBILITY_LEVEL = 110
GO

IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Reservations].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

ALTER DATABASE [Reservations] SET ANSI_NULL_DEFAULT OFF 
GO

ALTER DATABASE [Reservations] SET ANSI_NULLS OFF 
GO

ALTER DATABASE [Reservations] SET ANSI_PADDING OFF 
GO

ALTER DATABASE [Reservations] SET ANSI_WARNINGS OFF 
GO

ALTER DATABASE [Reservations] SET ARITHABORT OFF 
GO

ALTER DATABASE [Reservations] SET AUTO_CLOSE OFF 
GO

ALTER DATABASE [Reservations] SET AUTO_CREATE_STATISTICS ON 
GO

ALTER DATABASE [Reservations] SET AUTO_SHRINK OFF 
GO

ALTER DATABASE [Reservations] SET AUTO_UPDATE_STATISTICS ON 
GO

ALTER DATABASE [Reservations] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO

ALTER DATABASE [Reservations] SET CURSOR_DEFAULT  GLOBAL 
GO

ALTER DATABASE [Reservations] SET CONCAT_NULL_YIELDS_NULL OFF 
GO

ALTER DATABASE [Reservations] SET NUMERIC_ROUNDABORT OFF 
GO

ALTER DATABASE [Reservations] SET QUOTED_IDENTIFIER OFF 
GO

ALTER DATABASE [Reservations] SET RECURSIVE_TRIGGERS OFF 
GO

ALTER DATABASE [Reservations] SET  ENABLE_BROKER 
GO

ALTER DATABASE [Reservations] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO

ALTER DATABASE [Reservations] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO

ALTER DATABASE [Reservations] SET TRUSTWORTHY OFF 
GO

ALTER DATABASE [Reservations] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO

ALTER DATABASE [Reservations] SET PARAMETERIZATION SIMPLE 
GO

ALTER DATABASE [Reservations] SET READ_COMMITTED_SNAPSHOT ON 
GO

ALTER DATABASE [Reservations] SET HONOR_BROKER_PRIORITY OFF 
GO

ALTER DATABASE [Reservations] SET RECOVERY FULL 
GO

ALTER DATABASE [Reservations] SET  MULTI_USER 
GO

ALTER DATABASE [Reservations] SET PAGE_VERIFY CHECKSUM  
GO

ALTER DATABASE [Reservations] SET DB_CHAINING OFF 
GO

ALTER DATABASE [Reservations] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO

ALTER DATABASE [Reservations] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO

ALTER DATABASE [Reservations] SET  READ_WRITE 
GO

