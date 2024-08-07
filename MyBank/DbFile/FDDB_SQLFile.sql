USE [MyBank_FDDB]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 7/4/2024 5:18:09 PM ******/
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
/****** Object:  Table [dbo].[CustomerFDDetails]    Script Date: 7/4/2024 5:18:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CustomerFDDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[AccountId] [int] NOT NULL,
	[Amount] [float] NOT NULL,
	[Plan] [nvarchar](max) NOT NULL,
	[StartDate] [date] NOT NULL,
	[EndDate] [date] NOT NULL,
	[MaturityAmount] [float] NOT NULL,
	[FDDetailsId] [int] NULL,
	[TotalAmount] [float] NOT NULL,
 CONSTRAINT [PK_CustomerFDDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[FDDetails]    Script Date: 7/4/2024 5:18:09 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[FDDetails](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FDPlan] [nvarchar](max) NOT NULL,
	[Year] [float] NOT NULL,
	[Percentage] [decimal](18, 2) NOT NULL,
 CONSTRAINT [PK_FDDetails] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240703091315_FDInitial', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240703123741_UpdateFDDetailsPercentageCol', N'8.0.6')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240704093808_AddColTotalAmount', N'8.0.6')
GO
SET IDENTITY_INSERT [dbo].[CustomerFDDetails] ON 

INSERT [dbo].[CustomerFDDetails] ([Id], [AccountId], [Amount], [Plan], [StartDate], [EndDate], [MaturityAmount], [FDDetailsId], [TotalAmount]) VALUES (10, 1, 5555, N'A', CAST(N'2024-07-04' AS Date), CAST(N'2025-07-04' AS Date), 416.625, NULL, 5971.625)
INSERT [dbo].[CustomerFDDetails] ([Id], [AccountId], [Amount], [Plan], [StartDate], [EndDate], [MaturityAmount], [FDDetailsId], [TotalAmount]) VALUES (11, 1, 5555, N'B', CAST(N'2024-07-04' AS Date), CAST(N'2026-07-04' AS Date), 6467.38, NULL, 12022.380000000001)
INSERT [dbo].[CustomerFDDetails] ([Id], [AccountId], [Amount], [Plan], [StartDate], [EndDate], [MaturityAmount], [FDDetailsId], [TotalAmount]) VALUES (12, 1, 5555, N'C', CAST(N'2024-07-04' AS Date), CAST(N'2029-07-04' AS Date), 8179.96, NULL, 13734.96)
SET IDENTITY_INSERT [dbo].[CustomerFDDetails] OFF
GO
SET IDENTITY_INSERT [dbo].[FDDetails] ON 

INSERT [dbo].[FDDetails] ([Id], [FDPlan], [Year], [Percentage]) VALUES (1, N'A', 1, CAST(7.50 AS Decimal(18, 2)))
INSERT [dbo].[FDDetails] ([Id], [FDPlan], [Year], [Percentage]) VALUES (2, N'B', 2, CAST(7.75 AS Decimal(18, 2)))
INSERT [dbo].[FDDetails] ([Id], [FDPlan], [Year], [Percentage]) VALUES (3, N'C', 5, CAST(7.80 AS Decimal(18, 2)))
INSERT [dbo].[FDDetails] ([Id], [FDPlan], [Year], [Percentage]) VALUES (4, N'D', 1, CAST(0.05 AS Decimal(18, 2)))
SET IDENTITY_INSERT [dbo].[FDDetails] OFF
GO
ALTER TABLE [dbo].[CustomerFDDetails] ADD  DEFAULT ((0.0000000000000000e+000)) FOR [TotalAmount]
GO
ALTER TABLE [dbo].[CustomerFDDetails]  WITH CHECK ADD  CONSTRAINT [FK_CustomerFDDetails_FDDetails_FDDetailsId] FOREIGN KEY([FDDetailsId])
REFERENCES [dbo].[FDDetails] ([Id])
GO
ALTER TABLE [dbo].[CustomerFDDetails] CHECK CONSTRAINT [FK_CustomerFDDetails_FDDetails_FDDetailsId]
GO
