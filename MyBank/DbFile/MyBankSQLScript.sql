USE [master]
GO
/****** Object:  Database [MyBank]    Script Date: 6/29/2024 4:50:13 PM ******/
CREATE DATABASE [MyBank]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'MyBank', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyBank.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'MyBank_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\MyBank_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [MyBank] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [MyBank].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [MyBank] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [MyBank] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [MyBank] SET ARITHABORT OFF 
GO
ALTER DATABASE [MyBank] SET AUTO_CLOSE ON 
GO
ALTER DATABASE [MyBank] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [MyBank] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [MyBank] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [MyBank] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [MyBank] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [MyBank] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [MyBank] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [MyBank] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [MyBank] SET  ENABLE_BROKER 
GO
ALTER DATABASE [MyBank] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [MyBank] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [MyBank] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [MyBank] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [MyBank] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [MyBank] SET READ_COMMITTED_SNAPSHOT ON 
GO
ALTER DATABASE [MyBank] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [MyBank] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [MyBank] SET  MULTI_USER 
GO
ALTER DATABASE [MyBank] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [MyBank] SET DB_CHAINING OFF 
GO
ALTER DATABASE [MyBank] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [MyBank] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [MyBank] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [MyBank] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [MyBank] SET QUERY_STORE = ON
GO
ALTER DATABASE [MyBank] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [MyBank]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/29/2024 4:50:14 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 6/29/2024 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Account](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[accounttype] [int] NOT NULL,
	[Balance] [float] NOT NULL,
	[ExpiryTime] [datetime2](7) NOT NULL,
	[IsUsed] [bit] NOT NULL,
	[OTPValue] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyTransactions]    Script Date: 6/29/2024 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[MyTransactions](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[FromAccountId] [int] NOT NULL,
	[ToAccountId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[transactionType] [int] NOT NULL,
	[TimeStamp] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_MyTransactions] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 6/29/2024 4:50:14 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](max) NOT NULL,
	[LastName] [nvarchar](max) NOT NULL,
	[DOB] [date] NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
	[PhoneNumber] [nvarchar](max) NOT NULL,
	[Password] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240625121349_initial', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240625164358_UpdateMyTransactionstbl', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240626094739_UpdateMyTransactionstblRequiredField', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240627174512_AddPasswordFieldInPersontbl', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240628180735_AddOTPFieldsInAccounttbl', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsUsed], [OTPValue]) VALUES (6, 6, 0, 3719.9999999999995, CAST(N'2024-06-29T16:29:56.3707009' AS DateTime2), 0, N'vpsoAv')
INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsUsed], [OTPValue]) VALUES (7, 7, 1, 11921.550000000001, CAST(N'2024-06-29T16:40:38.4661211' AS DateTime2), 1, N'e096o2')
INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsUsed], [OTPValue]) VALUES (8, 8, 0, 7349.71, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'')
INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsUsed], [OTPValue]) VALUES (12, 10, 0, 11600.73, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'')
INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsUsed], [OTPValue]) VALUES (13, 14, 0, 9997, CAST(N'0001-01-01T00:00:00.0000000' AS DateTime2), 0, N'')
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[MyTransactions] ON 

INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (27, 8, 8, 8, 200.46, 0, CAST(N'2024-06-26T09:44:21.5260000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (31, 8, 8, 8, 20.25, 0, CAST(N'2024-06-26T10:21:30.1390000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (32, 7, 7, 7, 20.25, 1, CAST(N'2024-06-26T10:21:30.1390000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (33, 6, 6, 7, 50, 2, CAST(N'2024-06-26T10:39:11.3360000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (34, 7, 7, 8, 29, 2, CAST(N'2024-06-26T11:45:35.8880000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (39, 10, 12, 12, 1000, 0, CAST(N'2024-06-26T13:02:02.9170000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (40, 10, 12, 12, 10.5, 0, CAST(N'2024-06-26T13:02:02.9170000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (41, 10, 12, 12, 1000.5, 1, CAST(N'2024-06-26T13:02:02.9170000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (42, 10, 12, 12, 1000.25, 0, CAST(N'2024-06-26T13:02:02.9170000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (43, 10, 12, 6, 232, 2, CAST(N'2024-06-26T13:02:02.9170000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (45, 10, 12, 12, 200, 0, CAST(N'2024-06-27T10:46:03.0410000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (46, 10, 12, 12, 400.48, 0, CAST(N'2024-06-27T10:57:12.7500000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (47, 6, 6, 6, 32, 1, CAST(N'2024-06-27T11:01:32.5350000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (48, 6, 6, 6, 200, 1, CAST(N'2024-06-27T11:04:33.4940000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (49, 6, 6, 6, 10, 1, CAST(N'2024-06-27T11:15:57.7750000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (50, 6, 6, 7, 90, 2, CAST(N'2024-06-27T11:24:25.8970000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (51, 6, 6, 6, 1100, 0, CAST(N'2024-06-27T11:59:13.4100000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (52, 6, 6, 6, 900, 1, CAST(N'2024-06-27T11:59:13.4100000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (53, 6, 6, 7, 500, 2, CAST(N'2024-06-27T11:59:13.4100000' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (54, 7, 7, 7, 90.25, 0, CAST(N'2024-06-27T18:23:28.7088956' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (55, 7, 7, 7, 90.25, 1, CAST(N'2024-06-27T18:24:09.8888555' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (56, 14, 13, 13, 22.12, 0, CAST(N'2024-06-28T04:57:10.5227909' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (57, 14, 13, 13, 25.12, 1, CAST(N'2024-06-28T04:59:18.5436626' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (59, 6, 6, 7, 50.4, 2, CAST(N'2024-06-28T05:05:52.5379046' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (60, 7, 7, 7, 150.2, 0, CAST(N'2024-06-29T10:37:53.2049816' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (61, 6, 6, 6, 20.2, 0, CAST(N'2024-06-29T10:58:14.2201516' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (63, 6, 6, 6, 150.2, 0, CAST(N'2024-06-29T11:01:24.9356374' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (64, 7, 7, 7, 1130.2, 0, CAST(N'2024-06-29T11:16:42.1566940' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MyTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (6, N'Om', N'Bhatt', CAST(N'2002-04-13' AS Date), N'om13btempone@gmail.com', N'1234567890', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (7, N'Abhi', N'string', CAST(N'2024-06-26' AS Date), N'abhishek.bhatt@tntra.io', N'string', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (8, N'Dhaval', N'string', CAST(N'2024-06-26' AS Date), N'abhishek.bhatt@tntra.io', N'1111111111', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (9, N'abc', N'df', CAST(N'2024-06-26' AS Date), N'abhishek.bhatt@tntra.io', N'1111111111', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (10, N'Haard', N'Pandya', CAST(N'2024-06-26' AS Date), N'abhishek.bhatt@tntra.io', N'1212121212', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (11, N'admin', N'admin', CAST(N'2002-04-13' AS Date), N'admin@gmail.com', N'1234567890', N'1111')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (14, N'string', N'string', CAST(N'2024-06-28' AS Date), N'abhishek.bhatt@tntra.io', N'string', N'string')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
/****** Object:  Index [IX_Account_PersonId]    Script Date: 6/29/2024 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_Account_PersonId] ON [dbo].[Account]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MyTransactions_FromAccountId]    Script Date: 6/29/2024 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_MyTransactions_FromAccountId] ON [dbo].[MyTransactions]
(
	[FromAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MyTransactions_PersonId]    Script Date: 6/29/2024 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_MyTransactions_PersonId] ON [dbo].[MyTransactions]
(
	[PersonId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_MyTransactions_ToAccountId]    Script Date: 6/29/2024 4:50:14 PM ******/
CREATE NONCLUSTERED INDEX [IX_MyTransactions_ToAccountId] ON [dbo].[MyTransactions]
(
	[ToAccountId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [ExpiryTime]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsUsed]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (N'') FOR [OTPValue]
GO
ALTER TABLE [dbo].[MyTransactions] ADD  DEFAULT ((0)) FOR [FromAccountId]
GO
ALTER TABLE [dbo].[MyTransactions] ADD  DEFAULT ((0)) FOR [ToAccountId]
GO
ALTER TABLE [dbo].[Person] ADD  DEFAULT (N'') FOR [Password]
GO
ALTER TABLE [dbo].[Account]  WITH CHECK ADD  CONSTRAINT [FK_Account_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Account] CHECK CONSTRAINT [FK_Account_Person_PersonId]
GO
ALTER TABLE [dbo].[MyTransactions]  WITH CHECK ADD  CONSTRAINT [FK_MyTransactions_Account_FromAccountId] FOREIGN KEY([FromAccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[MyTransactions] CHECK CONSTRAINT [FK_MyTransactions_Account_FromAccountId]
GO
ALTER TABLE [dbo].[MyTransactions]  WITH CHECK ADD  CONSTRAINT [FK_MyTransactions_Account_ToAccountId] FOREIGN KEY([ToAccountId])
REFERENCES [dbo].[Account] ([Id])
GO
ALTER TABLE [dbo].[MyTransactions] CHECK CONSTRAINT [FK_MyTransactions_Account_ToAccountId]
GO
ALTER TABLE [dbo].[MyTransactions]  WITH CHECK ADD  CONSTRAINT [FK_MyTransactions_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[MyTransactions] CHECK CONSTRAINT [FK_MyTransactions_Person_PersonId]
GO
USE [master]
GO
ALTER DATABASE [MyBank] SET  READ_WRITE 
GO
