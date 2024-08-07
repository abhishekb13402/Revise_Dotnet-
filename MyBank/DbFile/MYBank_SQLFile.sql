USE [MyBank]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/4/2024 5:17:18 PM ******/
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
/****** Object:  Table [dbo].[Account]    Script Date: 7/4/2024 5:17:18 PM ******/
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
	[IsOTPVerify] [bit] NOT NULL,
	[OTPValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_Account] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[MyTransactions]    Script Date: 7/4/2024 5:17:18 PM ******/
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
/****** Object:  Table [dbo].[Person]    Script Date: 7/4/2024 5:17:18 PM ******/
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
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240701052822_UPOTPValueSetAllowNull', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240701070716_ADDUPIsOTPUserdIsOTPVerifyField', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240701084952_RemoveColIsOTPUsed', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[Account] ON 

INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsOTPVerify], [OTPValue]) VALUES (37, 41, 0, 2732, CAST(N'2024-07-04T15:30:39.1378822' AS DateTime2), 0, NULL)
INSERT [dbo].[Account] ([Id], [PersonId], [accounttype], [Balance], [ExpiryTime], [IsOTPVerify], [OTPValue]) VALUES (38, 42, 0, 3520, CAST(N'2024-07-02T11:17:38.9736661' AS DateTime2), 0, NULL)
SET IDENTITY_INSERT [dbo].[Account] OFF
GO
SET IDENTITY_INSERT [dbo].[MyTransactions] ON 

INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (87, 41, 37, 37, 20, 0, CAST(N'2024-07-02T05:44:06.0355099' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (88, 41, 37, 37, 20, 1, CAST(N'2024-07-02T05:44:58.0628595' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (89, 41, 37, 38, 20, 2, CAST(N'2024-07-02T05:47:18.7187166' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (90, 41, 37, 37, 50, 0, CAST(N'2024-07-02T05:53:29.1683021' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (92, 41, 37, 37, 10, 0, CAST(N'2024-07-03T12:46:02.5918482' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (93, 41, 37, 37, 20, 0, CAST(N'2024-07-03T12:50:24.1934415' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (94, 41, 37, 37, 25, 0, CAST(N'2024-07-03T12:54:28.0008035' AS DateTime2))
INSERT [dbo].[MyTransactions] ([Id], [PersonId], [FromAccountId], [ToAccountId], [Amount], [transactionType], [TimeStamp]) VALUES (95, 41, 37, 37, 147, 0, CAST(N'2024-07-04T09:59:11.6798046' AS DateTime2))
SET IDENTITY_INSERT [dbo].[MyTransactions] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (36, N'Admin', N'Admin', CAST(N'2024-07-01' AS Date), N'abhishek.bhatt@tntra.io', N'1212121212', N'string')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (41, N'Abhishek', N'Bhatt', CAST(N'2024-07-02' AS Date), N'abhishekbhatt13402@gmail.com', N'1111111111', N'string')
INSERT [dbo].[Person] ([Id], [FirstName], [LastName], [DOB], [Email], [PhoneNumber], [Password]) VALUES (42, N'Om', N'Bhatt', CAST(N'2024-07-02' AS Date), N'abhishek.bhatt@tntra.io', N'1111111111', N'string')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT ('0001-01-01T00:00:00.0000000') FOR [ExpiryTime]
GO
ALTER TABLE [dbo].[Account] ADD  DEFAULT (CONVERT([bit],(0))) FOR [IsOTPVerify]
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
