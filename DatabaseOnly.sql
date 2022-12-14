USE [master]
GO
/****** Object:  Database [Company2]    Script Date: 20.10.2022 17:56:26 ******/
CREATE DATABASE [Company2]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Company2', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company2.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Company2_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Company2_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Company2] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Company2].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Company2] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Company2] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Company2] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Company2] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Company2] SET ARITHABORT OFF 
GO
ALTER DATABASE [Company2] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Company2] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Company2] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Company2] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Company2] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Company2] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Company2] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Company2] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Company2] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Company2] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Company2] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Company2] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Company2] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Company2] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Company2] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Company2] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Company2] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Company2] SET RECOVERY FULL 
GO
ALTER DATABASE [Company2] SET  MULTI_USER 
GO
ALTER DATABASE [Company2] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Company2] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Company2] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Company2] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Company2] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Company2] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Company2', N'ON'
GO
ALTER DATABASE [Company2] SET QUERY_STORE = OFF
GO
USE [Company2]
GO
/****** Object:  Table [dbo].[PreRegistration]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PreRegistration](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](320) NULL,
	[Ip] [nvarchar](50) NULL,
	[Hash] [nvarchar](max) NULL,
	[EndDate] [smalldatetime] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_PreRegistration] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductCategories]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductCategories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_ProductCategories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductDetails]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[Description] [nvarchar](max) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_ProductDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Products]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[DetailId] [int] NULL,
	[CategoryId] [int] NULL,
	[Price] [float] NULL,
	[PaidPrice] [float] NULL,
	[Tax] [float] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ProductUserPermissions]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductUserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserPermissionId] [int] NULL,
	[ProductId] [int] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_ProductUserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Sales]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Sales](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[ProductId] [int] NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_Sales] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[User]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[User](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserPermissionId] [int] NULL,
	[Email] [nvarchar](320) NULL,
	[Password] [nvarchar](50) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserInformation]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserInformation](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NULL,
	[Name] [nvarchar](50) NULL,
	[Surname] [nvarchar](50) NULL,
	[FullAddress] [nvarchar](200) NULL,
	[City] [nvarchar](35) NULL,
	[Country] [nvarchar](35) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_UserInformation] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserPermissions]    Script Date: 20.10.2022 17:56:26 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserPermissions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [nvarchar](20) NULL,
	[CreatedAt] [smalldatetime] NULL,
	[UpdatedAt] [smalldatetime] NULL,
	[DeletedAt] [smalldatetime] NULL,
 CONSTRAINT [PK_UserPermissions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductCategories] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[ProductCategories] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductCategories]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductDetails] FOREIGN KEY([DetailId])
REFERENCES [dbo].[ProductDetails] ([Id])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductDetails]
GO
ALTER TABLE [dbo].[ProductUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_ProductUserPermissions_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[ProductUserPermissions] CHECK CONSTRAINT [FK_ProductUserPermissions_Products]
GO
ALTER TABLE [dbo].[ProductUserPermissions]  WITH CHECK ADD  CONSTRAINT [FK_ProductUserPermissions_UserPermissions] FOREIGN KEY([UserPermissionId])
REFERENCES [dbo].[UserPermissions] ([Id])
GO
ALTER TABLE [dbo].[ProductUserPermissions] CHECK CONSTRAINT [FK_ProductUserPermissions_UserPermissions]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_Products]
GO
ALTER TABLE [dbo].[Sales]  WITH CHECK ADD  CONSTRAINT [FK_Sales_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[Sales] CHECK CONSTRAINT [FK_Sales_User]
GO
ALTER TABLE [dbo].[User]  WITH CHECK ADD  CONSTRAINT [FK_User_UserPermissions] FOREIGN KEY([UserPermissionId])
REFERENCES [dbo].[UserPermissions] ([Id])
GO
ALTER TABLE [dbo].[User] CHECK CONSTRAINT [FK_User_UserPermissions]
GO
ALTER TABLE [dbo].[UserInformation]  WITH CHECK ADD  CONSTRAINT [FK_UserInformation_User] FOREIGN KEY([UserId])
REFERENCES [dbo].[User] ([Id])
GO
ALTER TABLE [dbo].[UserInformation] CHECK CONSTRAINT [FK_UserInformation_User]
GO
USE [master]
GO
ALTER DATABASE [Company2] SET  READ_WRITE 
GO
