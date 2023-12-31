USE MASTER
GO
CREATE DATABASE
QLKHO
USE QLKHO
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiTietNhaCungCaps]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietNhaCungCaps](
	[MaSp] [int] NOT NULL,
	[MaNcc] [int] NOT NULL,
	[GiaNhap] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_chiTietNhaCungCaps] PRIMARY KEY CLUSTERED 
(
	[MaNcc] ASC,
	[MaSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiTietPhieuNhaps]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietPhieuNhaps](
	[MaPN] [int] NOT NULL,
	[MaSp] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_chiTietPhieuNhaps] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC,
	[MaSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[chiTietPhieuXuats]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[chiTietPhieuXuats](
	[MaPX] [int] NOT NULL,
	[MaSp] [int] NOT NULL,
	[SoLuong] [int] NOT NULL,
	[DonGia] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_chiTietPhieuXuats] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC,
	[MaSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[donViTinhs]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[donViTinhs](
	[MaDvt] [int] IDENTITY(1,1) NOT NULL,
	[TenDvt] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_donViTinhs] PRIMARY KEY CLUSTERED 
(
	[MaDvt] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[khachHangs]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[khachHangs](
	[MaKh] [int] IDENTITY(1,1) NOT NULL,
	[TenKh] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](max) NULL,
	[Phone] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_khachHangs] PRIMARY KEY CLUSTERED 
(
	[MaKh] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[nhaCungCaps]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[nhaCungCaps](
	[MaNcc] [int] IDENTITY(1,1) NOT NULL,
	[TenNcc] [nvarchar](500) NOT NULL,
	[Email] [nvarchar](500) NOT NULL,
	[Sdt] [nvarchar](500) NOT NULL,
 CONSTRAINT [PK_nhaCungCaps] PRIMARY KEY CLUSTERED 
(
	[MaNcc] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieuNhaps]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieuNhaps](
	[MaPN] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime2](7) NOT NULL,
	[TongSoLuong] [int] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[MaNcc] [int] NULL,
	[UserId] [nvarchar](450) NULL,
 CONSTRAINT [PK_phieuNhaps] PRIMARY KEY CLUSTERED 
(
	[MaPN] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[phieuXuats]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[phieuXuats](
	[MaPX] [int] IDENTITY(1,1) NOT NULL,
	[NgayLap] [datetime2](7) NOT NULL,
	[TongSoLuong] [int] NOT NULL,
	[TongTien] [decimal](18, 2) NOT NULL,
	[UserId] [nvarchar](450) NULL,
	[MaKh] [int] NULL,
 CONSTRAINT [PK_phieuXuats] PRIMARY KEY CLUSTERED 
(
	[MaPX] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RoleClaims]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_RoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Roles]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Roles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_Roles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[sanPhams]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[sanPhams](
	[MaSp] [int] IDENTITY(1,1) NOT NULL,
	[TenSp] [nvarchar](500) NOT NULL,
	[GiaBan] [decimal](18, 2) NOT NULL,
	[SoLuongCo] [int] NOT NULL,
	[Photo] [nvarchar](1000) NULL,
	[MaDvt] [int] NULL,
 CONSTRAINT [PK_sanPhams] PRIMARY KEY CLUSTERED 
(
	[MaSp] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserClaims]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserLogins]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserLogins](
	[LoginProvider] [nvarchar](450) NOT NULL,
	[ProviderKey] [nvarchar](450) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserRoles]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_UserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [nvarchar](450) NOT NULL,
	[FullName] [nvarchar](100) NULL,
	[PhotoAvatar] [nvarchar](1000) NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserTokens]    Script Date: 11/7/2023 9:58:52 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](450) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_UserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516170327_Add1', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516175827_Add2', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230516180444_Add3', N'5.0.17')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20230523010303_Add4', N'5.0.17')
GO
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (13, 6, CAST(390000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (15, 6, CAST(450000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (23, 6, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (26, 6, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (37, 6, CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (16, 7, CAST(3650000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (18, 7, CAST(1800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (27, 7, CAST(3200000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (16, 8, CAST(320000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (18, 8, CAST(1790000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (27, 15, CAST(3400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (39, 15, CAST(4800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (40, 15, CAST(8500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (41, 15, CAST(290000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (42, 15, CAST(15000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietNhaCungCaps] ([MaSp], [MaNcc], [GiaNhap]) VALUES (38, 16, CAST(180000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (31, 18, 12, CAST(1690000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (34, 16, 10, CAST(365000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (34, 18, 10, CAST(1800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (35, 16, 10, CAST(320000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (35, 18, 19, CAST(1600000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (37, 13, 12, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (37, 15, 12, CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (37, 23, 12, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (37, 26, 34, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (38, 18, 2, CAST(1800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (38, 27, 2, CAST(3200000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (39, 39, 7, CAST(4800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (39, 40, 10, CAST(8500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (39, 41, 10, CAST(290000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (40, 38, 28, CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (41, 13, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (41, 23, 12, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (41, 26, 12, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (41, 37, 12, CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (42, 27, 19, CAST(3400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (42, 39, 9, CAST(4800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (43, 39, 10, CAST(4800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (43, 40, 10, CAST(8500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (43, 41, 10, CAST(290000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (45, 39, 10, CAST(4500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (45, 40, 10, CAST(8000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (46, 38, 10, CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (47, 23, 10, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (47, 26, 10, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (47, 37, 10, CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (48, 27, 19, CAST(3000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (48, 39, 10, CAST(4500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (48, 40, 18, CAST(8100000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (49, 13, 30, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (49, 15, 30, CAST(10500.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (49, 23, 30, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (49, 26, 30, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (49, 37, 30, CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (50, 27, 10, CAST(3100000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (50, 40, 9, CAST(8000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (50, 41, 10, CAST(270000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (51, 27, 10, CAST(3400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (51, 42, 3, CAST(15000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (52, 23, 10, CAST(220000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (52, 26, 10, CAST(401000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (52, 37, 10, CAST(370000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (53, 16, 10, CAST(320000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (53, 18, 2, CAST(1790000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (54, 38, 10, CAST(180000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (55, 18, 1, CAST(1800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuNhaps] ([MaPN], [MaSp], [SoLuong], [DonGia]) VALUES (55, 27, 13, CAST(3200000.00 AS Decimal(18, 2)))
GO
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (9, 13, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (9, 15, 10, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (9, 23, 10, CAST(240000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (9, 26, 1, CAST(45000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (9, 29, 10, CAST(270000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (10, 13, 1, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (10, 15, 1, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (10, 29, 2, CAST(270000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (12, 16, 3, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (14, 16, 6, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (14, 18, 2, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (14, 27, 1, CAST(3600000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (15, 16, 9, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (15, 18, 12, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (16, 16, 1, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (16, 18, 1, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (17, 23, 10, CAST(240000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (17, 26, 4, CAST(45000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (18, 16, 5, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (18, 18, 2, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (18, 27, 2, CAST(3600000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (19, 16, 9, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (19, 39, 2, CAST(5400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (19, 40, 10, CAST(9500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (19, 41, 8, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (20, 13, 10, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (20, 15, 10, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (20, 37, 3, CAST(450000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (21, 18, 20, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (21, 27, 1, CAST(3600000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (22, 39, 11, CAST(5400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (22, 41, 1, CAST(360000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (24, 15, 100, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (24, 26, 16, CAST(45000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (24, 29, 69, CAST(290000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (25, 18, 10, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (25, 39, 6, CAST(5400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (25, 40, 6, CAST(9800000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (26, 16, 10, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (26, 18, 12, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (26, 27, 14, CAST(3600000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (27, 40, 5, CAST(9500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (27, 41, 10, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (28, 16, 10, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (28, 40, 8, CAST(9500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (29, 16, 4, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (29, 18, 4, CAST(3000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (29, 27, 2, CAST(3700000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (30, 27, 5, CAST(4550000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (30, 39, 6, CAST(5400000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (30, 40, 10, CAST(9500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (31, 16, 5, CAST(6300000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (31, 18, 1, CAST(2200000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (31, 27, 5, CAST(4550000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (31, 40, 18, CAST(9500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (32, 27, 5, CAST(4700000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (32, 42, 5, CAST(18000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 13, 100, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 15, 100, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 23, 50, CAST(240000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 26, 30, CAST(460000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 29, 30, CAST(270000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (34, 37, 30, CAST(450000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (35, 16, 10, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (35, 27, 10, CAST(4550000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (35, 42, 10, CAST(18000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (36, 18, 5, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (36, 27, 6, CAST(4550000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (36, 41, 10, CAST(350000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (36, 42, 3, CAST(18000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (38, 13, 100, CAST(12000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (38, 15, 100, CAST(18000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (38, 27, 5, CAST(4550000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (38, 38, 20, CAST(3420000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (38, 42, 5, CAST(18000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (39, 15, 4, CAST(520000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (39, 16, 2, CAST(5500000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (39, 18, 5, CAST(2000000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (39, 26, 3, CAST(460000.00 AS Decimal(18, 2)))
INSERT [dbo].[chiTietPhieuXuats] ([MaPX], [MaSp], [SoLuong], [DonGia]) VALUES (39, 37, 3, CAST(450000.00 AS Decimal(18, 2)))
GO
SET IDENTITY_INSERT [dbo].[donViTinhs] ON 

INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (1, N'Chai')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (5, N'Lon')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (6, N'Cái')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (7, N'Gói')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (8, N'Thùng')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (9, N'Chiếc')
INSERT [dbo].[donViTinhs] ([MaDvt], [TenDvt]) VALUES (12, N'Hộp')
SET IDENTITY_INSERT [dbo].[donViTinhs] OFF
GO
SET IDENTITY_INSERT [dbo].[khachHangs] ON 

INSERT [dbo].[khachHangs] ([MaKh], [TenKh], [Email], [Phone]) VALUES (8, N'Công ty MinhTien SoftWare', N'mtien@gmail.com', N'0992789')
INSERT [dbo].[khachHangs] ([MaKh], [TenKh], [Email], [Phone]) VALUES (9, N'Công ty cổ phần Thành Food AIA', N'thanhfd@gmail.com', N'0992789999')
INSERT [dbo].[khachHangs] ([MaKh], [TenKh], [Email], [Phone]) VALUES (12, N'Công ty STech', N'STe@gmail.com', N'09927899995')
INSERT [dbo].[khachHangs] ([MaKh], [TenKh], [Email], [Phone]) VALUES (13, N'Công ty thực phẩm WigA', N'STech@gmail.com', N'099278999')
SET IDENTITY_INSERT [dbo].[khachHangs] OFF
GO
SET IDENTITY_INSERT [dbo].[nhaCungCaps] ON 

INSERT [dbo].[nhaCungCaps] ([MaNcc], [TenNcc], [Email], [Sdt]) VALUES (6, N'Công ty cổ phần ThaiBev', N'hu@gmail.com', N'0998899')
INSERT [dbo].[nhaCungCaps] ([MaNcc], [TenNcc], [Email], [Sdt]) VALUES (7, N'Công ty cổ phần NightHouse', N'nhouse@yahoo.com.ex', N'09983879')
INSERT [dbo].[nhaCungCaps] ([MaNcc], [TenNcc], [Email], [Sdt]) VALUES (8, N'Công ty cổ phần Bếp Xanh', N'bepxanh@gmail.com', N'0998877')
INSERT [dbo].[nhaCungCaps] ([MaNcc], [TenNcc], [Email], [Sdt]) VALUES (15, N'Công ty TechNit', N'technit@gmail.com', N'099836879')
INSERT [dbo].[nhaCungCaps] ([MaNcc], [TenNcc], [Email], [Sdt]) VALUES (16, N'Công ty MilkPlus', N'milkplus@gmail.com.milk.explam.vns', N'0998379879')
SET IDENTITY_INSERT [dbo].[nhaCungCaps] OFF
GO
SET IDENTITY_INSERT [dbo].[phieuNhaps] ON 

INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (31, CAST(N'2023-05-23T00:00:00.0000000' AS DateTime2), 12, CAST(20280000.00 AS Decimal(18, 2)), 8, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (34, CAST(N'2023-05-24T00:00:00.0000000' AS DateTime2), 20, CAST(21650000.00 AS Decimal(18, 2)), 7, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (35, CAST(N'2023-05-24T00:00:00.0000000' AS DateTime2), 29, CAST(33600000.00 AS Decimal(18, 2)), 8, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (37, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 70, CAST(16544000.00 AS Decimal(18, 2)), 6, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (38, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 4, CAST(10000000.00 AS Decimal(18, 2)), 7, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (39, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 27, CAST(121500000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (40, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 28, CAST(5040000.00 AS Decimal(18, 2)), 16, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (41, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 46, CAST(12012000.00 AS Decimal(18, 2)), 6, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (42, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 28, CAST(107800000.00 AS Decimal(18, 2)), 15, N'17e017a5-a693-4296-bed2-51dd4283980a')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (43, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 30, CAST(135900000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (45, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 20, CAST(125000000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (46, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 10, CAST(1800000.00 AS Decimal(18, 2)), 16, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (47, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 30, CAST(9910000.00 AS Decimal(18, 2)), 6, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (48, CAST(N'2023-06-06T00:00:00.0000000' AS DateTime2), 47, CAST(247800000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (49, CAST(N'2023-06-06T00:00:00.0000000' AS DateTime2), 150, CAST(30405000.00 AS Decimal(18, 2)), 6, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (50, CAST(N'2023-04-06T00:00:00.0000000' AS DateTime2), 29, CAST(105700000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (51, CAST(N'2023-01-11T00:00:00.0000000' AS DateTime2), 13, CAST(79000000.00 AS Decimal(18, 2)), 15, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (52, CAST(N'2023-02-16T00:00:00.0000000' AS DateTime2), 30, CAST(9910000.00 AS Decimal(18, 2)), 6, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (53, CAST(N'2023-03-08T00:00:00.0000000' AS DateTime2), 12, CAST(6780000.00 AS Decimal(18, 2)), 8, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (54, CAST(N'2023-04-17T00:00:00.0000000' AS DateTime2), 10, CAST(1800000.00 AS Decimal(18, 2)), 16, N'154369ac-b958-4d14-99fa-d155ae727c61')
INSERT [dbo].[phieuNhaps] ([MaPN], [NgayLap], [TongSoLuong], [TongTien], [MaNcc], [UserId]) VALUES (55, CAST(N'2023-06-15T00:00:00.0000000' AS DateTime2), 14, CAST(43400000.00 AS Decimal(18, 2)), 7, N'154369ac-b958-4d14-99fa-d155ae727c61')
SET IDENTITY_INSERT [dbo].[phieuNhaps] OFF
GO
SET IDENTITY_INSERT [dbo].[phieuXuats] ON 

INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (9, CAST(N'2023-05-25T00:00:00.0000000' AS DateTime2), 41, CAST(5445000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (10, CAST(N'2023-06-01T00:00:00.0000000' AS DateTime2), 4, CAST(570000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (12, CAST(N'2023-06-01T00:00:00.0000000' AS DateTime2), 3, CAST(16500000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (14, CAST(N'2023-06-03T00:00:00.0000000' AS DateTime2), 9, CAST(40600000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (15, CAST(N'2023-06-03T00:00:00.0000000' AS DateTime2), 21, CAST(73500000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (16, CAST(N'2023-06-03T00:00:00.0000000' AS DateTime2), 2, CAST(7500000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (17, CAST(N'2023-06-03T00:00:00.0000000' AS DateTime2), 14, CAST(2580000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 9)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (18, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 9, CAST(38700000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (19, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 29, CAST(158100000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (20, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 23, CAST(1650000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (21, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 21, CAST(43600000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (22, CAST(N'2023-06-04T00:00:00.0000000' AS DateTime2), 12, CAST(59760000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 12)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (24, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 185, CAST(22530000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (25, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 22, CAST(111200000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (26, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 36, CAST(129400000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (27, CAST(N'2023-06-05T00:00:00.0000000' AS DateTime2), 15, CAST(51000000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (28, CAST(N'2022-06-09T00:00:00.0000000' AS DateTime2), 18, CAST(131000000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (29, CAST(N'2023-06-06T00:00:00.0000000' AS DateTime2), 10, CAST(41400000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (30, CAST(N'2023-04-12T00:00:00.0000000' AS DateTime2), 21, CAST(150150000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (31, CAST(N'2023-06-06T00:00:00.0000000' AS DateTime2), 29, CAST(227450000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (32, CAST(N'2023-01-18T00:00:00.0000000' AS DateTime2), 10, CAST(113500000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (34, CAST(N'2023-02-15T00:00:00.0000000' AS DateTime2), 340, CAST(50400000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (35, CAST(N'2023-04-11T00:00:00.0000000' AS DateTime2), 30, CAST(280500000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (36, CAST(N'2023-04-27T00:00:00.0000000' AS DateTime2), 24, CAST(94800000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (38, CAST(N'2023-03-30T00:00:00.0000000' AS DateTime2), 230, CAST(184150000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
INSERT [dbo].[phieuXuats] ([MaPX], [NgayLap], [TongSoLuong], [TongTien], [UserId], [MaKh]) VALUES (39, CAST(N'2023-09-24T00:00:00.0000000' AS DateTime2), 17, CAST(25810000.00 AS Decimal(18, 2)), N'154369ac-b958-4d14-99fa-d155ae727c61', 8)
SET IDENTITY_INSERT [dbo].[phieuXuats] OFF
GO
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'311ba530-e645-4bcb-830c-c98fa5535d48', N'Admin', N'ADMIN', N'637dd4d0-025e-4b7c-8c14-6d652e75701a')
INSERT [dbo].[Roles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'c28a9398-3d34-4bd4-a645-e5a06114d3a5', N'NhanVien', N'NHANVIEN', N'2c1c29f3-4514-4538-8d26-19cbb07e8e5a')
GO
SET IDENTITY_INSERT [dbo].[sanPhams] ON 

INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (13, N'Pessi Nhật Bản 2023', CAST(470000.00 AS Decimal(18, 2)), 83, N'qojdamli.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (15, N'CoCaCoLa Nhật', CAST(520000.00 AS Decimal(18, 2)), 171, N'fbgfei25.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (16, N'Bếp từ Mini BeKo279', CAST(5500000.00 AS Decimal(18, 2)), 0, N'1vsqdmbh.jpg', 9)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (18, N'Lò vi sóng Green9', CAST(2000000.00 AS Decimal(18, 2)), 0, N'orvclncb.jpg', 9)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (23, N'Nước tăng lực Carabao B1', CAST(240000.00 AS Decimal(18, 2)), 33, N'cobybnal.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (26, N'Bia Chang Thái Lan', CAST(460000.00 AS Decimal(18, 2)), 55, N'fkxqqzka.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (27, N'Robot dọn nhà Xiaomi G359', CAST(4550000.00 AS Decimal(18, 2)), 20, N'u2z2cuhn.jpg', 9)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (29, N'Bia SaiGon', CAST(270000.00 AS Decimal(18, 2)), 3, N'g3yrosvh.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (37, N'Bia G8 Nhập khẩu Thái Lan', CAST(450000.00 AS Decimal(18, 2)), 26, N'voqox122.jpg', 8)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (38, N'Sữa bột Grow', CAST(250000.00 AS Decimal(18, 2)), 28, N'woxkd44e.jpg', 12)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (39, N'Điện thoại Galaxy A50', CAST(5400000.00 AS Decimal(18, 2)), 21, N'uecqqga0.jpg', 9)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (40, N'IPhone X', CAST(9500000.00 AS Decimal(18, 2)), 0, N'd2zq4vzz.jpg', 1)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (41, N'Chuột G9', CAST(350000.00 AS Decimal(18, 2)), 1, N'yyxnlxhm.png', 1)
INSERT [dbo].[sanPhams] ([MaSp], [TenSp], [GiaBan], [SoLuongCo], [Photo], [MaDvt]) VALUES (42, N'TiVi Xiaomi MI TV P1 55 inch', CAST(18000000.00 AS Decimal(18, 2)), 0, N'yptxitnh.jpg', 9)
SET IDENTITY_INSERT [dbo].[sanPhams] OFF
GO
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'0632fdb9-13cf-4a27-9231-efcdbf613e91', N'311ba530-e645-4bcb-830c-c98fa5535d48')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'065e7ca6-27e4-4dad-9979-3036f57a9b73', N'311ba530-e645-4bcb-830c-c98fa5535d48')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'154369ac-b958-4d14-99fa-d155ae727c61', N'311ba530-e645-4bcb-830c-c98fa5535d48')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'96edef16-a6a9-432b-846f-5449f95d952b', N'311ba530-e645-4bcb-830c-c98fa5535d48')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'e9807e35-f95e-4c25-9cbe-ebcd154cd170', N'311ba530-e645-4bcb-830c-c98fa5535d48')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'0632fdb9-13cf-4a27-9231-efcdbf613e91', N'c28a9398-3d34-4bd4-a645-e5a06114d3a5')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'065e7ca6-27e4-4dad-9979-3036f57a9b73', N'c28a9398-3d34-4bd4-a645-e5a06114d3a5')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'154369ac-b958-4d14-99fa-d155ae727c61', N'c28a9398-3d34-4bd4-a645-e5a06114d3a5')
INSERT [dbo].[UserRoles] ([UserId], [RoleId]) VALUES (N'17e017a5-a693-4296-bed2-51dd4283980a', N'c28a9398-3d34-4bd4-a645-e5a06114d3a5')
GO
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'0632fdb9-13cf-4a27-9231-efcdbf613e91', N'Đặng Minh Tiến22222', N'2tmewhry.jpg', N'DangMinhTien2222', N'DANGMINHTIEN2222', N'm22@gmail.com', N'M22@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECnmOql+u0iuK57MgO+/J4usqbe1SsIPm3HP63SRN8qY5Rmmle/dAvPF3G36PY4jyA==', N'2ULKWGVEWVDGKT6TKNUVY6M37J5ZKQVA', N'cc41e334-2a25-44d8-b867-1f6f90e623ff', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'065e7ca6-27e4-4dad-9979-3036f57a9b73', N'Nguyễn Văn Thư', N'sjszvjp2.jpg', N'VanThuNg', N'VANTHUNG', N'thu@gmail.com', N'THU@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBy4HMy2fL+WeITOjw4TuoM9xcIcSGxSFYbTyo8JypwSvW7APcv9XWt3b2pyn1zHfQ==', N'YN35OQ4HDTNRDYRBHAISGBZN6OEAD7BO', N'388196c8-0dc5-4114-8984-cf33b27b863b', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'154369ac-b958-4d14-99fa-d155ae727c61', N'Đặng Minh Tiến', N'gdwhfegi.jpg', N'DangMinhTien', N'DANGMINHTIEN', N'mtien280168@gmail.com', N'MTIEN280168@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFB2aQXMkKVGm3/HN3x1RQuIAU5SDTCeHYQDK1WGxc5/NPM40RUr+8A32NNV0XWsmA==', N'LODFJDVOD6GQJTZLXQUVO4Z2UFBF6JTT', N'183b73d5-10ef-49ca-9845-9e5b4bedea87', N'0768373665', 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'17e017a5-a693-4296-bed2-51dd4283980a', N'Đặng Minh Tiến', N'vdzsdcy1.jpg', N'DangMinhTien28', N'DANGMINHTIEN28', N'minh2868@gmail.com', N'MINH2868@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEBAHMYzs4wTYjfB72ubPbXHpj+ZmuwwVVWyiezyGd6co+jK83PhSUxvA6SmBAhR/Iw==', N'OT6WTVRANBU7D7NGNKJ2O5JUTB2ZOLLR', N'fc1094f5-0c35-485e-98ad-9f8b65ca434e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'1882b370-14a5-4ef1-bdbb-a3638c17f95e', N'Đặng Minh Tiến', N'mrrqgkbo.jpg', N'DangMinhTien9', N'DANGMINHTIEN9', N'm9@gmail.com', N'M9@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEFfJhMTzZDkekuteSjw4HQvWGnNFpcpIvb5/Qdg/m8ezBdIDbgnSCRIeaF8zt1jgOA==', N'QWZPUSII5SKJXODR3RWNQHXOZL55AXFN', N'9f50f3f3-2fc3-4050-ab7a-c1452822ac25', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'4eb25fb7-6369-46d9-acc6-192b4becd66d', N'Cao Phượng Sơn', N'ylpzolaw.jpg', N'SonPhuong', N'SONPHUONG', N'caosonphuongg@gmail.com', N'CAOSONPHUONGG@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEHU53qdPHBqfuQDCufdc2+hpYCOLzEwQVN69mnFYmNbZzEzqTLbUTMs6ktln5Z5NHA==', N'TWXUY5P4DUKAMLQT2DLKA2LZIEBZZIQ3', N'f3704780-c92d-4af9-ab22-5a754ce407aa', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'6cb98522-0c22-4b65-80dc-de33c4ffe9eb', N'Đỗ Viết Trung', N'xzzar2ce.jpg', N'DoVietTrung2222', N'DOVIETTRUNG2222', N'dotrung08102002@gmail.com', N'DOTRUNG08102002@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEJbFeKehcxwBN3oG4E9dk/JBQO+GCaxBvzSwNBIMutJ5agGun7mJOF1a8UQpOid3YQ==', N'HGFD6VOT5NCFOGQ7JRJS6AQ6UH75TFOF', N'097bb13c-5e43-41e9-9411-bd9df45d3bac', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'78d9bd0e-9e94-45cd-9737-88d0206eae3f', N'Đặng Minh Tiến', N'p00txt2v.png', N'DangMinhTien2801', N'DANGMINHTIEN2801', N'mtien280109@gmail.com', N'MTIEN280109@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEA7cBMImAw3kXnPd6TaBa5S7kx5HwUw3yK5pLGdBFWXVEveNdLf51Y1mnwda3aX2+A==', N'P22LVZ4PRNEFUMEUVIBM57QZPON4NOZ3', N'46ba6921-5dad-4c3c-be36-ec2f36503c6d', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'7b851583-d756-4991-9b23-20a289ce19b9', N'Đào Văn Hiếu', N'cef4lkle.jpg', N'DaoHieu', N'DAOHIEU', N'daohieu16@gmail.com', N'DAOHIEU16@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAECCIhwj2Ap+bHQPIEnrEbXcg65eOuzbvHzp2xt0lxvgdKbOIQ4GACesYU+6LrLH8Zg==', N'VM3MVMANWRPVA6QJ5ISVCIZEU5K7KTCL', N'fac10e3a-0a76-4c9b-a02c-c880b1de2d46', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'96edef16-a6a9-432b-846f-5449f95d952b', N'admin', N'admin.png', N'admin', N'ADMIN', N'admin@gmail.com', N'ADMIN@GMAIL.COM', 1, N'AQAAAAEAACcQAAAAEGzMyl2uK0ockR0AdaUSao0TFYtYeb0q+D7q41CKJT7ncLBV9IN0QF8v9dj7MmC/RQ==', N'6VXKOCKSYOLZ3AYEOOVHWY57D57CVLCD', N'cf6a359a-5a10-4e6a-b23e-d05c2d12f237', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'bd613dba-9f76-406f-b501-8a4929446032', N'Đỗ Viết Trung', N'woxfza1p.jpg', N'minnnn9', N'MINNNN9', N'mi9@gmail.com', N'MI9@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEO4hAokLH/b1wvJokW8DMBJgj1fDxuacU0Qfg49ZPxITNwlWqCDn2gX+XRcr3uFZow==', N'PSKF2W6QCOBSALV4H7FJD6W5VPTGEXHZ', N'd5a73206-550b-4092-923f-15e410690df2', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c3e0a97b-60c6-45a9-ab55-451f43a6b872', N'Đặng Minh Tiến', N'nrjqprs1.jpg', N'DangMinhTien22222', N'DANGMINHTIEN22222', N'm@gmail.com', N'M@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPfHieS7B+GYOlUajwhvO+jX4ybCSx8jE7eUhNzC+zBC/xgnFqUVOdzuKGY4iJ5W4w==', N'2TOFE5D5MQKJEXJUDQQLPWFYBHGCWO4O', N'665b3d1c-2da0-4ecb-9dcd-ca3ea2517cde', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'e9807e35-f95e-4c25-9cbe-ebcd154cd170', N'Nguyễn Khánh Thọ', N'b2za1huo.jpg', N'NguyenKhanhTho', N'NGUYENKHANHTHO', N'khanhtho10122002@gmail.com', N'KHANHTHO10122002@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEPefUejib7vIDHzweyXUZcRPI2aFRdbHuNGudhdyJy6NaMFcPuJSVvTnmXTApp9DWA==', N'SI3TF6MJB5E6OJJYWL4PRRJILOUVLC6M', N'7ab4b10d-7afb-4c03-b720-ec43b08a6626', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Users] ([Id], [FullName], [PhotoAvatar], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'fff7ccdb-1fef-494e-aac4-9ba43c93c86f', N'Đặng Minh Tiến', N'ylcpybcg.jpg', N'DangMinhTien2809', N'DANGMINHTIEN2809', N'mtien280168oke@gmail.com', N'MTIEN280168OKE@GMAIL.COM', 0, N'AQAAAAEAACcQAAAAEAyHRjr0zdPiEld0A/bzMa7yKKHjgvfsHhMZg6RjJqMsBwnxjLGRsghyPn6cuXlKzA==', N'256CZISTXGS65CYGG3HA5BCVZFRZV2HN', N'0c80dc0e-e0ab-4c35-9138-999962517804', NULL, 0, 0, NULL, 1, 0)
GO
ALTER TABLE [dbo].[khachHangs] ADD  DEFAULT (N'') FOR [TenKh]
GO
ALTER TABLE [dbo].[chiTietNhaCungCaps]  WITH CHECK ADD  CONSTRAINT [FK_chiTietNhaCungCaps_nhaCungCaps_MaNcc] FOREIGN KEY([MaNcc])
REFERENCES [dbo].[nhaCungCaps] ([MaNcc])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietNhaCungCaps] CHECK CONSTRAINT [FK_chiTietNhaCungCaps_nhaCungCaps_MaNcc]
GO
ALTER TABLE [dbo].[chiTietNhaCungCaps]  WITH CHECK ADD  CONSTRAINT [FK_chiTietNhaCungCaps_sanPhams_MaSp] FOREIGN KEY([MaSp])
REFERENCES [dbo].[sanPhams] ([MaSp])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietNhaCungCaps] CHECK CONSTRAINT [FK_chiTietNhaCungCaps_sanPhams_MaSp]
GO
ALTER TABLE [dbo].[chiTietPhieuNhaps]  WITH CHECK ADD  CONSTRAINT [FK_chiTietPhieuNhaps_phieuNhaps_MaPN] FOREIGN KEY([MaPN])
REFERENCES [dbo].[phieuNhaps] ([MaPN])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietPhieuNhaps] CHECK CONSTRAINT [FK_chiTietPhieuNhaps_phieuNhaps_MaPN]
GO
ALTER TABLE [dbo].[chiTietPhieuNhaps]  WITH CHECK ADD  CONSTRAINT [FK_chiTietPhieuNhaps_sanPhams_MaSp] FOREIGN KEY([MaSp])
REFERENCES [dbo].[sanPhams] ([MaSp])
GO
ALTER TABLE [dbo].[chiTietPhieuNhaps] CHECK CONSTRAINT [FK_chiTietPhieuNhaps_sanPhams_MaSp]
GO
ALTER TABLE [dbo].[chiTietPhieuXuats]  WITH CHECK ADD  CONSTRAINT [FK_chiTietPhieuXuats_phieuXuats_MaPX] FOREIGN KEY([MaPX])
REFERENCES [dbo].[phieuXuats] ([MaPX])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[chiTietPhieuXuats] CHECK CONSTRAINT [FK_chiTietPhieuXuats_phieuXuats_MaPX]
GO
ALTER TABLE [dbo].[chiTietPhieuXuats]  WITH CHECK ADD  CONSTRAINT [FK_chiTietPhieuXuats_sanPhams_MaSp] FOREIGN KEY([MaSp])
REFERENCES [dbo].[sanPhams] ([MaSp])
GO
ALTER TABLE [dbo].[chiTietPhieuXuats] CHECK CONSTRAINT [FK_chiTietPhieuXuats_sanPhams_MaSp]
GO
ALTER TABLE [dbo].[phieuNhaps]  WITH CHECK ADD  CONSTRAINT [FK_phieuNhaps_nhaCungCaps_MaNcc] FOREIGN KEY([MaNcc])
REFERENCES [dbo].[nhaCungCaps] ([MaNcc])
GO
ALTER TABLE [dbo].[phieuNhaps] CHECK CONSTRAINT [FK_phieuNhaps_nhaCungCaps_MaNcc]
GO
ALTER TABLE [dbo].[phieuNhaps]  WITH CHECK ADD  CONSTRAINT [FK_phieuNhaps_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[phieuNhaps] CHECK CONSTRAINT [FK_phieuNhaps_Users_UserId]
GO
ALTER TABLE [dbo].[phieuXuats]  WITH CHECK ADD  CONSTRAINT [FK_phieuXuats_khachHangs_MaKh] FOREIGN KEY([MaKh])
REFERENCES [dbo].[khachHangs] ([MaKh])
GO
ALTER TABLE [dbo].[phieuXuats] CHECK CONSTRAINT [FK_phieuXuats_khachHangs_MaKh]
GO
ALTER TABLE [dbo].[phieuXuats]  WITH CHECK ADD  CONSTRAINT [FK_phieuXuats_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[phieuXuats] CHECK CONSTRAINT [FK_phieuXuats_Users_UserId]
GO
ALTER TABLE [dbo].[RoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_RoleClaims_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RoleClaims] CHECK CONSTRAINT [FK_RoleClaims_Roles_RoleId]
GO
ALTER TABLE [dbo].[sanPhams]  WITH CHECK ADD  CONSTRAINT [FK_sanPhams_donViTinhs_MaDvt] FOREIGN KEY([MaDvt])
REFERENCES [dbo].[donViTinhs] ([MaDvt])
GO
ALTER TABLE [dbo].[sanPhams] CHECK CONSTRAINT [FK_sanPhams_donViTinhs_MaDvt]
GO
ALTER TABLE [dbo].[UserClaims]  WITH CHECK ADD  CONSTRAINT [FK_UserClaims_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserClaims] CHECK CONSTRAINT [FK_UserClaims_Users_UserId]
GO
ALTER TABLE [dbo].[UserLogins]  WITH CHECK ADD  CONSTRAINT [FK_UserLogins_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserLogins] CHECK CONSTRAINT [FK_UserLogins_Users_UserId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Roles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[Roles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Roles_RoleId]
GO
ALTER TABLE [dbo].[UserRoles]  WITH CHECK ADD  CONSTRAINT [FK_UserRoles_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserRoles] CHECK CONSTRAINT [FK_UserRoles_Users_UserId]
GO
ALTER TABLE [dbo].[UserTokens]  WITH CHECK ADD  CONSTRAINT [FK_UserTokens_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[UserTokens] CHECK CONSTRAINT [FK_UserTokens_Users_UserId]
GO
