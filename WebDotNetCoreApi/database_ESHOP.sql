USE [master]
GO
/****** Object:  Database [EShop]    Script Date: 2/21/2022 9:32:41 PM ******/
CREATE DATABASE [EShop]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'EShop', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EShop.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'EShop_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\EShop_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [EShop] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [EShop].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [EShop] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [EShop] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [EShop] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [EShop] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [EShop] SET ARITHABORT OFF 
GO
ALTER DATABASE [EShop] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [EShop] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [EShop] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [EShop] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [EShop] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [EShop] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [EShop] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [EShop] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [EShop] SET  ENABLE_BROKER 
GO
ALTER DATABASE [EShop] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [EShop] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [EShop] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [EShop] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [EShop] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [EShop] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [EShop] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [EShop] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [EShop] SET  MULTI_USER 
GO
ALTER DATABASE [EShop] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [EShop] SET DB_CHAINING OFF 
GO
ALTER DATABASE [EShop] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [EShop] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [EShop] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [EShop] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [EShop] SET QUERY_STORE = OFF
GO
USE [EShop]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[AddressId] [int] IDENTITY(1,1) NOT NULL,
	[MemberId] [varchar](64) NOT NULL,
	[WardId] [varchar](64) NOT NULL,
	[AddressName] [nvarchar](128) NOT NULL,
	[FullName] [varchar](64) NOT NULL,
	[Phone] [varchar](16) NOT NULL,
	[IsDefault] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AddressId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AutoSendMail]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AutoSendMail](
	[AutoSendMailId] [int] IDENTITY(1,1) NOT NULL,
	[Email] [varchar](64) NOT NULL,
	[Subject] [nvarchar](64) NOT NULL,
	[Body] [nvarchar](max) NOT NULL,
	[SendDate] [datetime] NOT NULL,
	[IsSend] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[AutoSendMailId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Cart]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Cart](
	[CartId] [varchar](32) NOT NULL,
	[ProductId] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL,
	[CartDate] [datetime] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CartId] ASC,
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[CategoryId] [tinyint] IDENTITY(1,1) NOT NULL,
	[CategoryName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CategoryProduct]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CategoryProduct](
	[CategoryId] [tinyint] NOT NULL,
	[ProductId] [int] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[District]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[District](
	[DistrictId] [smallint] NOT NULL,
	[ProvinceId] [smallint] NOT NULL,
	[DistrictName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[DistrictId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Invoice]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoice](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[IncoiceDate] [datetime] NOT NULL,
	[AddressId] [int] NOT NULL,
	[MemberId] [varchar](64) NOT NULL,
	[StatusInvoiceId] [tinyint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[InvoiceDetail]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceDetail](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[ProductId] [int] NOT NULL,
	[Price] [int] NOT NULL,
	[Quantity] [smallint] NOT NULL
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Member]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Member](
	[MemberId] [varchar](64) NOT NULL,
	[UserName] [varchar](32) NOT NULL,
	[Password] [varbinary](64) NOT NULL,
	[Email] [varchar](64) NOT NULL,
	[Gender] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MemberInRole]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MemberInRole](
	[MemberId] [varchar](64) NOT NULL,
	[RoleId] [uniqueidentifier] NOT NULL,
	[IsDeleted] [bit] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[MemberId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Product]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Product](
	[ProductId] [int] IDENTITY(1,1) NOT NULL,
	[ProductName] [nvarchar](128) NOT NULL,
	[Sku] [varchar](16) NOT NULL,
	[Price] [int] NOT NULL,
	[SaleOff] [decimal](18, 0) NULL,
	[Material] [nvarchar](32) NOT NULL,
	[ImageUrl] [nvarchar](32) NOT NULL,
	[Description] [nvarchar](max) NULL,
PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Province]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Province](
	[ProvinceId] [smallint] NOT NULL,
	[ProvinceName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[ProvinceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Role]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Role](
	[RoleId] [uniqueidentifier] NOT NULL,
	[RoleName] [varchar](16) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[StatusInvoice]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[StatusInvoice](
	[StatusInvoiceId] [tinyint] IDENTITY(1,1) NOT NULL,
	[StatusInvoiceName] [nvarchar](32) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[StatusInvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ward]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ward](
	[WardId] [int] NOT NULL,
	[DistrictId] [smallint] NOT NULL,
	[WardName] [nvarchar](64) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[WardId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 

INSERT [dbo].[Address] ([AddressId], [MemberId], [WardId], [AddressName], [FullName], [Phone], [IsDefault]) VALUES (5, N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', N'1', N'45h4 nguyen anh thu', N'Nghia', N'3452452', 1)
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[AutoSendMail] ON 

INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (1, N'nguyenthanhnghia0907@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T00:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (2, N'nguyenthanhnghia009007@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T18:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (3, N'ngynhi0907@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T18:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (4, N'nguyenthanhnghia0907@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T01:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (5, N'nguyenthanhnghia009007@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T13:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (6, N'nguyenthanhnghia0907@gmail.com', N'Auto Test Send Mail', N'Content for Email', CAST(N'2021-12-31T12:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (7, N'nguyenthanhnghia0907@gmail.com', N'ABc', N'NGUYEN THNAH NGHIA', CAST(N'2022-02-02T23:00:00.000' AS DateTime), 1)
INSERT [dbo].[AutoSendMail] ([AutoSendMailId], [Email], [Subject], [Body], [SendDate], [IsSend]) VALUES (8, N'nguyenthanhnghia0907@gmail.com', N'ABcfcdf', N'dsaffafdsf', CAST(N'2022-02-02T23:47:00.000' AS DateTime), 1)
SET IDENTITY_INSERT [dbo].[AutoSendMail] OFF
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (1, N'Name')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (2, N'Nữ')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (3, N'Name')
INSERT [dbo].[Category] ([CategoryId], [CategoryName]) VALUES (4, N'Nữ')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
INSERT [dbo].[CategoryProduct] ([CategoryId], [ProductId]) VALUES (1, 1)
INSERT [dbo].[CategoryProduct] ([CategoryId], [ProductId]) VALUES (2, 2)
INSERT [dbo].[CategoryProduct] ([CategoryId], [ProductId]) VALUES (1, 4)
INSERT [dbo].[CategoryProduct] ([CategoryId], [ProductId]) VALUES (1, 5)
INSERT [dbo].[CategoryProduct] ([CategoryId], [ProductId]) VALUES (4, 3)
GO
INSERT [dbo].[District] ([DistrictId], [ProvinceId], [DistrictName]) VALUES (1, 1, N'Quận 1')
INSERT [dbo].[District] ([DistrictId], [ProvinceId], [DistrictName]) VALUES (2, 1, N'Quận Tân Bình')
INSERT [dbo].[District] ([DistrictId], [ProvinceId], [DistrictName]) VALUES (3, 1, N'Quận 3')
INSERT [dbo].[District] ([DistrictId], [ProvinceId], [DistrictName]) VALUES (4, 1, N'Quận 10')
GO
INSERT [dbo].[Invoice] ([InvoiceId], [IncoiceDate], [AddressId], [MemberId], [StatusInvoiceId]) VALUES (N'7d0b699f-de7f-4997-ac39-0db056c80aaf', CAST(N'2022-02-21T16:19:56.780' AS DateTime), 5, N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', 1)
INSERT [dbo].[Invoice] ([InvoiceId], [IncoiceDate], [AddressId], [MemberId], [StatusInvoiceId]) VALUES (N'eed8bdf9-1af1-4c50-addb-c8be4c00eaf6', CAST(N'2022-02-21T17:07:30.567' AS DateTime), 5, N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', 1)
GO
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Price], [Quantity]) VALUES (N'7d0b699f-de7f-4997-ac39-0db056c80aaf', 1, 232323, 1)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Price], [Quantity]) VALUES (N'eed8bdf9-1af1-4c50-addb-c8be4c00eaf6', 1, 232323, 1)
INSERT [dbo].[InvoiceDetail] ([InvoiceId], [ProductId], [Price], [Quantity]) VALUES (N'eed8bdf9-1af1-4c50-addb-c8be4c00eaf6', 2, 34343, 1)
GO
INSERT [dbo].[Member] ([MemberId], [UserName], [Password], [Email], [Gender]) VALUES (N'102611808190504993465', N'nguyenthanhnghia0907@gmail.com', 0x2125CA7BEB997B6B58361C4CDB4AAB270C7FF51F992E3FE7639F9962E5091E4C0770DA308864FDC1CFF841BADCF46D73A570B74C7F21735D6674A56068FB5FBD, N'nguyenthanhnghia0907@gmail.com', 0)
INSERT [dbo].[Member] ([MemberId], [UserName], [Password], [Email], [Gender]) VALUES (N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', N'nghia', 0x0DE3A978E51771783C088E5D31154CA7BDADFF9FF588CF6823FFB19B50138F049BF62F71D51BD772BC394264E5614C7176E411D8A6441F850E90462F17967DBB, N'nguyenthanhnghia0907@gmail.com', 0)
INSERT [dbo].[Member] ([MemberId], [UserName], [Password], [Email], [Gender]) VALUES (N'i6a92yvb3es2q16gvu67vztdhoc6jz9q644jikcf82ypf16rvqxbzk99fcvwh3p9', N'tai', 0xF4582B9CE73DCA85E787DA25909AECBBB24D7C060DD5BA3B65953E37C7DDB0FA6C084068AD3AD6CE1DA4C2506FD08447C7DC3B15BAA963F62624EBD67E302046, N'tai@gmail.com', 0)
INSERT [dbo].[Member] ([MemberId], [UserName], [Password], [Email], [Gender]) VALUES (N'r97a3bku02dk55xb120ssnfaejjwl1kn9yhkudq895pm5wfnaav2p1qgc5stdudr', N'nguyenthanhnghia009007@gmail.com', 0x9FAC2CFF8D38BD01C250A0F780C10868AE71C619126787448FCBACBEFF46791F9C10BE6658C5BF87D9F03E4DB0A11FD1E749FAE1010B0F08D9B1552078872D36, N'nguyenthanhnghia009007@gmail.com', 0)
INSERT [dbo].[Member] ([MemberId], [UserName], [Password], [Email], [Gender]) VALUES (N'x72re62tvgvxlt4w4x3a8c3zbtnl3tpw43loquj3898s12juu1psjtbhniu8xzv6', N'thang', 0x6C7ACD25D8FC490ACBA31DB6050ADC8B72728DE110785286EF971341B97DA4B05FB97B5620855E5B23AD8E9C76FE38F33178897FDD761578847D436FA6B1C772, N'abc@gmail.com', 1)
GO
INSERT [dbo].[MemberInRole] ([MemberId], [RoleId], [IsDeleted]) VALUES (N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', N'de69c741-432a-4e35-ab03-48afa37511ea', 0)
INSERT [dbo].[MemberInRole] ([MemberId], [RoleId], [IsDeleted]) VALUES (N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', N'b0609227-5ed3-4f9f-9bf8-632e0b2d9cba', 0)
INSERT [dbo].[MemberInRole] ([MemberId], [RoleId], [IsDeleted]) VALUES (N'b6ylvo9bq9ml12m7bv4xwvyk91ptlj61571lptzpmvjnj3dlk8ej82dgl9po0ikj', N'344b1aa4-9ec2-44e9-9021-86ef17b64d40', 0)
GO
SET IDENTITY_INSERT [dbo].[Product] ON 

INSERT [dbo].[Product] ([ProductId], [ProductName], [Sku], [Price], [SaleOff], [Material], [ImageUrl], [Description]) VALUES (1, N'Test 22', N'2323233', 232323, CAST(0 AS Decimal(18, 0)), N'Vải', N'kffya3ajlpf264r4re1u4yp9w8w4.jpg', N'&lt;p&gt;Nguyễn Thanh Nghĩa jdjdjdjdjdjddjdjdjdjdjdjghĩa jdjdjdjdjdjddjdjdjdjdjdj&lt;/p&gt;&lt;p&gt;ghĩa jdjdjdjdjdjddjdjdjdjdjdj&lt;/p&gt;&lt;p&gt;ghĩa jdjdjdjdjdjddjdjdjdjdjdjghĩa jdjdjdjdjdjddjdjdjdjdjdjghĩa jdjdjdjdjdjddjdjdjdjdjdj&lt;/p&gt;&lt;p&gt;ghĩa jdjdjdjdjdjddjdjdjdjdjdj&lt;/p&gt;&lt;p&gt;ghĩa jdjdjdjd&lt;span style="color:#ff6633;"&gt;jdjddjdjdjdjdjdj&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="color:#ff6633;"&gt;ghĩa jdjdjdjdjdjddjdjdjdjdjdjghĩa jdjdjdjdjdjddjdjdjd&lt;/span&gt;jdjdj&lt;/p&gt;')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Sku], [Price], [SaleOff], [Material], [ImageUrl], [Description]) VALUES (2, N'Nghia', N'2323233', 34343, CAST(0 AS Decimal(18, 0)), N'Vải', N'l3anorq99b73th0x2dvf9hepcpjc.jpg', N'&lt;p&gt;fafas&lt;/p&gt;&lt;p&gt;fda&lt;/p&gt;&lt;p&gt;fd&lt;/p&gt;&lt;p&gt;afd&lt;/p&gt;&lt;p&gt;af&lt;/p&gt;&lt;p&gt;sda&lt;span style="text-decoration:underline;"&gt;&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="text-decoration:underline;"&gt;fdafdafd&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="text-decoration:underline;"&gt;ds&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="text-decoration:underline;"&gt;faasdf&lt;strong&gt;&lt;/strong&gt;&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="text-decoration:underline;"&gt;&lt;strong&gt;fddas&lt;/strong&gt;&lt;/span&gt;&lt;/p&gt;&lt;p&gt;&lt;span style="text-decoration:underline;"&gt;&lt;strong&gt;f&lt;/strong&gt;&lt;/span&gt;&lt;/p&gt;')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Sku], [Price], [SaleOff], [Material], [ImageUrl], [Description]) VALUES (3, N'One Piece', N'2231321', 0, CAST(0 AS Decimal(18, 0)), N'Pirate', N'0s0js4n99mioxyhfz9udgodl98wp.jpg', N'&lt;span style="color:#3300cc;"&gt;abcdef&lt;/span&gt;')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Sku], [Price], [SaleOff], [Material], [ImageUrl], [Description]) VALUES (4, N'Thêm mới', N'2334', 5, CAST(0 AS Decimal(18, 0)), N'Vải', N'522tycn5vazyeu2j6ytl4ht3yeyw.PNG', N'afdfds')
INSERT [dbo].[Product] ([ProductId], [ProductName], [Sku], [Price], [SaleOff], [Material], [ImageUrl], [Description]) VALUES (5, N'Them lien quan', N'2323233', 8, CAST(0 AS Decimal(18, 0)), N'Vải', N'mgi4im5ogo9d36hpgg3dsotcz6tr.png', N'gsgf')
SET IDENTITY_INSERT [dbo].[Product] OFF
GO
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (1, N'TpHCM')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (2, N'Đồng Nai')
INSERT [dbo].[Province] ([ProvinceId], [ProvinceName]) VALUES (3, N'Bình Phước')
GO
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'de69c741-432a-4e35-ab03-48afa37511ea', N'Admin')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'b0609227-5ed3-4f9f-9bf8-632e0b2d9cba', N'Member')
INSERT [dbo].[Role] ([RoleId], [RoleName]) VALUES (N'344b1aa4-9ec2-44e9-9021-86ef17b64d40', N'Customer')
GO
SET IDENTITY_INSERT [dbo].[StatusInvoice] ON 

INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (1, N'Processing')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (2, N'Accessing')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (3, N'Shopping')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (4, N'Cancel')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (5, N'Successfully')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (6, N'Processing')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (7, N'Accessing')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (8, N'Shopping')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (9, N'Cancel')
INSERT [dbo].[StatusInvoice] ([StatusInvoiceId], [StatusInvoiceName]) VALUES (10, N'Successfully')
SET IDENTITY_INSERT [dbo].[StatusInvoice] OFF
GO
INSERT [dbo].[Ward] ([WardId], [DistrictId], [WardName]) VALUES (1, 1, N'Phường Dakao')
INSERT [dbo].[Ward] ([WardId], [DistrictId], [WardName]) VALUES (2, 1, N'Phường Bến Nghé')
INSERT [dbo].[Ward] ([WardId], [DistrictId], [WardName]) VALUES (3, 4, N'Phương 6')
INSERT [dbo].[Ward] ([WardId], [DistrictId], [WardName]) VALUES (4, 4, N'Phương 5')
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [UQ__Member__C9F2845668202F87]    Script Date: 2/21/2022 9:32:41 PM ******/
ALTER TABLE [dbo].[Member] ADD UNIQUE NONCLUSTERED 
(
	[UserName] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Address] ADD  DEFAULT ((0)) FOR [IsDefault]
GO
ALTER TABLE [dbo].[AutoSendMail] ADD  DEFAULT ((0)) FOR [IsSend]
GO
ALTER TABLE [dbo].[Cart] ADD  DEFAULT (getdate()) FOR [CartDate]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (newid()) FOR [InvoiceId]
GO
ALTER TABLE [dbo].[Invoice] ADD  DEFAULT (getdate()) FOR [IncoiceDate]
GO
ALTER TABLE [dbo].[MemberInRole] ADD  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Role] ADD  DEFAULT (newid()) FOR [RoleId]
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([CategoryId])
GO
ALTER TABLE [dbo].[CategoryProduct]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[District]  WITH CHECK ADD FOREIGN KEY([ProvinceId])
REFERENCES [dbo].[Province] ([ProvinceId])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([AddressId])
REFERENCES [dbo].[Address] ([AddressId])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([MemberId])
REFERENCES [dbo].[Member] ([MemberId])
GO
ALTER TABLE [dbo].[Invoice]  WITH CHECK ADD FOREIGN KEY([StatusInvoiceId])
REFERENCES [dbo].[StatusInvoice] ([StatusInvoiceId])
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoice] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceDetail]  WITH CHECK ADD FOREIGN KEY([ProductId])
REFERENCES [dbo].[Product] ([ProductId])
GO
ALTER TABLE [dbo].[Ward]  WITH CHECK ADD FOREIGN KEY([DistrictId])
REFERENCES [dbo].[District] ([DistrictId])
GO
/****** Object:  StoredProcedure [dbo].[AddCart]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddCart](
	@CartId varchar(32) ,
	@ProductId int,
	@Quantity smallint
)
as
	begin
		if exists(select * from Cart where CartId=@CartId and ProductId=@ProductId)
			update Cart set Quantity += @Quantity where CartId = @CartId and ProductId = @ProductId;
		else
			insert into Cart(CartId,ProductId,Quantity) values (@CartId,@ProductId,@Quantity)
	end
GO
/****** Object:  StoredProcedure [dbo].[AddInvoice]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddInvoice](
	@InvoiceId uniqueidentifier,
	@MemberId varchar(64),
	@AddressId int,
	@StatusInvoiceId tinyint,
	@CartId varchar(32)
)as
begin
	insert into Invoice(InvoiceId,AddressId,StatusInvoiceId,MemberId) values (@InvoiceId, @AddressId, @StatusInvoiceId,@MemberId);
	insert into InvoiceDetail(InvoiceId,ProductId,Quantity,Price)
		select @InvoiceId, Cart.ProductId, Cart.Quantity, Product.Price from Cart join Product 
		on Cart.ProductId = Product.ProductId and CartId =@CartId;
	delete from Cart where CartId =@CartId;
end
GO
/****** Object:  StoredProcedure [dbo].[AddMemberInRole]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddMemberInRole](
	@MemberId varchar(64),
	@RoleId uniqueidentifier
)
as
begin
	if	exists(select * from MemberInRole where MemberId = @MemberId and RoleId =@RoleId)
		update MemberInRole set IsDeleted = ~IsDeleted where MemberId = @MemberId and RoleId = @RoleId;
	else 
		insert into MemberInRole (MemberId,RoleId) values (@MemberId,@RoleId);
end
GO
/****** Object:  StoredProcedure [dbo].[AddProduct]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[AddProduct](
	@ProductId int out,
	@Name nvarchar(128),
	@Sku varchar(16),
	@Price int,
	@SaleOff decimal = null,
	@Material nvarchar(32),
	@ImageUrl nvarchar(32),
	@Description nvarchar(max)
)
as
begin
	insert into Product (ProductName,Sku,Price,SaleOff,Material,ImageUrl,Description)
	values (@Name,@Sku,@Price,@SaleOff,@Material,@ImageUrl,@Description);
	set @ProductId = SCOPE_IDENTITY();
end
GO
/****** Object:  StoredProcedure [dbo].[EditProduct]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create proc [dbo].[EditProduct](
	@ProductId int,
	@ProductName nvarchar(128),
	@Sku varchar(16),
	@Price int,
	@SaleOff decimal = null,
	@Material nvarchar(32),
	@ImageUrl nvarchar(32),
	@Description nvarchar(max)
)
as

	update  Product set ProductName=@ProductName,Sku=@Sku,Price=@Price,SaleOff=@SaleOff,Material=@Material,ImageUrl=@ImageUrl,Description=@Description
	where ProductId =@ProductId;
GO
/****** Object:  StoredProcedure [dbo].[GetAddressesByMember]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetAddressesByMember](@Id varchar(64))
as
	select Address.*,DistrictName,WardName,ProvinceName
			from Address join Ward on Address.WardId = Ward.WardId
			join District on Ward.DistrictId = District.DistrictId
			join Province on District.ProvinceId = Province.ProvinceId
			where MemberId =@Id;
GO
/****** Object:  StoredProcedure [dbo].[GetCarts]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCarts](@Id varchar(64))
as
begin
	select Cart.*,ProductName,Price,ImageUrl from Cart join Product on Cart.ProductId=Product.ProductId 
	where CartId = @Id;
end
GO
/****** Object:  StoredProcedure [dbo].[GetCategoryByProduct]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetCategoryByProduct](@Id int)
as
	select Category.*, iif(ProductId is null,0,1) as checked from Category left join CategoryProduct on Category.CategoryId=CategoryProduct.CategoryId
	 and ProductId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[GetProductByCategory]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetProductByCategory](@Id tinyint)
as
	select * from Product join CategoryProduct
		on Product.ProductId=CategoryProduct.ProductId
		where CategoryId =@Id;
GO
/****** Object:  StoredProcedure [dbo].[GetRoleNamesByMember]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetRoleNamesByMember](@Id varchar(64))
as
	select RoleName from Role join MemberInRole on Role.RoleId = MemberInRole.RoleId and MemberId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[GetRolesByMember]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[GetRolesByMember](@Id varchar(64))
as
	select Role.*,iif(MemberId is null,0,1) as Checked from Role left join MemberInRole on Role.RoleId=MemberInRole.RoleId and MemberId = @Id;
GO
/****** Object:  StoredProcedure [dbo].[ProductsRelation]    Script Date: 2/21/2022 9:32:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
create proc [dbo].[ProductsRelation](
	
	@ProductId int
)
as
	select * from Product join CategoryProduct on
	Product.ProductId = CategoryProduct.ProductId
	and Product.ProductId<>@ProductId
	and CategoryId in (select CategoryId from CategoryProduct where ProductId=@ProductId)
GO
USE [master]
GO
ALTER DATABASE [EShop] SET  READ_WRITE 
GO
