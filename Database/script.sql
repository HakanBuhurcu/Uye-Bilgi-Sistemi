USE [master]
GO
/****** Object:  Database [Aybirveri]    Script Date: 24.6.2019 00:07:39 ******/
CREATE DATABASE [Aybirveri]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Aybirveri', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Aybirveri.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Aybirveri_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.MSSQLSERVER\MSSQL\DATA\Aybirveri_log.ldf' , SIZE = 1856KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Aybirveri] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Aybirveri].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Aybirveri] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Aybirveri] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Aybirveri] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Aybirveri] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Aybirveri] SET ARITHABORT OFF 
GO
ALTER DATABASE [Aybirveri] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [Aybirveri] SET AUTO_SHRINK ON 
GO
ALTER DATABASE [Aybirveri] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Aybirveri] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Aybirveri] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Aybirveri] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Aybirveri] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Aybirveri] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Aybirveri] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Aybirveri] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Aybirveri] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Aybirveri] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Aybirveri] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Aybirveri] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Aybirveri] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Aybirveri] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Aybirveri] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Aybirveri] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Aybirveri] SET  MULTI_USER 
GO
ALTER DATABASE [Aybirveri] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Aybirveri] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Aybirveri] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Aybirveri] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [Aybirveri] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Aybirveri] SET QUERY_STORE = OFF
GO
USE [Aybirveri]
GO
/****** Object:  Table [dbo].[kayitlar]    Script Date: 24.6.2019 00:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[kayitlar](
	[kayitID] [int] IDENTITY(1,1) NOT NULL,
	[kisiID] [int] NOT NULL,
	[tarih] [date] NOT NULL,
	[eskipetek] [float] NOT NULL,
	[alinantakoz] [float] NOT NULL,
	[yerinemum] [float] NOT NULL,
	[dusurulenfire] [float] NOT NULL,
	[satilanpetek] [float] NOT NULL,
	[oduncpetek] [float] NOT NULL,
	[odenentakoz] [float] NOT NULL,
	[odenenkarapetek] [float] NOT NULL,
	[alinanpara] [float] NOT NULL,
 CONSTRAINT [PK_kayitlar] PRIMARY KEY CLUSTERED 
(
	[kayitID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Kisiler]    Script Date: 24.6.2019 00:07:39 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Kisiler](
	[kisiID] [int] IDENTITY(1,1) NOT NULL,
	[Ad] [nvarchar](100) NOT NULL,
	[Soyad] [nvarchar](100) NOT NULL,
	[Telefon] [varchar](100) NULL,
PRIMARY KEY CLUSTERED 
(
	[kisiID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[kayitlar] ON 

INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (16, 19, CAST(N'2016-06-27' AS Date), 0, 0, 0, 0, 0, 845, 0, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (17, 20, CAST(N'2016-06-27' AS Date), 485, 4545, 0, 0, 0, 0, 445, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (18, 20, CAST(N'2016-06-29' AS Date), 9, 0, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (19, 19, CAST(N'2016-07-30' AS Date), 12.5, 0, 395.7, 500, 0, 55.3, 0, 0, 580)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (22, 22, CAST(N'2016-07-01' AS Date), 13.5, 49.7, 0, 0, 1000, 85.7, 500, 85, 500)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (25, 19, CAST(N'2016-07-05' AS Date), 0, 0, 0, 0, 0, 0, 0, 0, 455)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (26, 22, CAST(N'2016-06-27' AS Date), 0, 4554, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (28, 20, CAST(N'2016-07-18' AS Date), 0, 55.5, 0, 0, 0, 0, 0, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (29, 19, CAST(N'2019-06-23' AS Date), 48, 32.7, 153, 52, 36, 0, 0, 0, 0)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (30, 24, CAST(N'2019-05-27' AS Date), 152.7, 65.7, 21.6, 52.9, 0, 0, 0, 0, 655)
INSERT [dbo].[kayitlar] ([kayitID], [kisiID], [tarih], [eskipetek], [alinantakoz], [yerinemum], [dusurulenfire], [satilanpetek], [oduncpetek], [odenentakoz], [odenenkarapetek], [alinanpara]) VALUES (32, 25, CAST(N'2019-06-23' AS Date), 45, 0, 0, 0, 0, 0, 0, 0, 450)
SET IDENTITY_INSERT [dbo].[kayitlar] OFF
SET IDENTITY_INSERT [dbo].[Kisiler] ON 

INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (19, N'FURKAN', N'KAPLAN', N'532 452 22 12')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (20, N'YUSUF', N'DEMİR', N'535 452 16 54')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (21, N'AHMET', N'YILDIRIMİ', N'532 478 52 16')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (22, N'EMRE MEHMET  ', N'KARSAVURGAN     ', N'532 452 22 12')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (23, N'SERHAT', N'GÖKÇE', N'541 842 69 74')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (24, N'SERDAR', N'ŞİMŞEK', N'535 540 60 54')
INSERT [dbo].[Kisiler] ([kisiID], [Ad], [Soyad], [Telefon]) VALUES (25, N'SEMİH', N'KADİROĞLU', N'538 459 01 65')
SET IDENTITY_INSERT [dbo].[Kisiler] OFF
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [eskipetek]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [alinantakoz]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [yerinemum]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [dusurulenfire]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [satilanpetek]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [oduncpetek]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [odenentakoz]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [odenenkarapetek]
GO
ALTER TABLE [dbo].[kayitlar] ADD  DEFAULT ((0)) FOR [alinanpara]
GO
USE [master]
GO
ALTER DATABASE [Aybirveri] SET  READ_WRITE 
GO
