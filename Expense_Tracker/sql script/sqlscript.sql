USE [Expense_Tracker]
GO
/****** Object:  Table [dbo].[Category]    Script Date: 7/19/2024 12:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Category](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Category] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Expense]    Script Date: 7/19/2024 12:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Expense](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[PersonId] [int] NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Amount] [float] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[ExpenseDate] [date] NOT NULL,
 CONSTRAINT [PK_Expense] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Person]    Script Date: 7/19/2024 12:46:56 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Person](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Email] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_Person] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Category] ON 

INSERT [dbo].[Category] ([Id], [Name]) VALUES (4, N'Groceries')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (5, N'Leisure')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (6, N'Electronics')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (7, N'Utilities')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (8, N'Clothing')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (9, N'Health')
INSERT [dbo].[Category] ([Id], [Name]) VALUES (10, N'Others')
SET IDENTITY_INSERT [dbo].[Category] OFF
GO
SET IDENTITY_INSERT [dbo].[Expense] ON 

INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (1, 1, N'test', 102.4, 5, CAST(N'2024-07-17' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (2, 1, N'Buy Phone', 21000, 6, CAST(N'2024-04-15' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (3, 1, N'Buy Phone', 21000, 6, CAST(N'2023-04-15' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (4, 1, N'Birthday cloths', 5000, 8, CAST(N'2024-06-10' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (5, 2, N'Home Groceries', 500, 4, CAST(N'2024-06-20' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (6, 1, N'Home Groceries', 500, 4, CAST(N'2024-06-20' AS Date))
INSERT [dbo].[Expense] ([Id], [PersonId], [Description], [Amount], [CategoryId], [ExpenseDate]) VALUES (7, 2, N'Home Groceries', 5200, 4, CAST(N'2023-06-20' AS Date))
SET IDENTITY_INSERT [dbo].[Expense] OFF
GO
SET IDENTITY_INSERT [dbo].[Person] ON 

INSERT [dbo].[Person] ([Id], [Email]) VALUES (1, N'abhishek.bhatt@tntra.io')
INSERT [dbo].[Person] ([Id], [Email]) VALUES (2, N'abhishekbhatt13402@gmail.com')
SET IDENTITY_INSERT [dbo].[Person] OFF
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Category_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Category] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Category_CategoryId]
GO
ALTER TABLE [dbo].[Expense]  WITH CHECK ADD  CONSTRAINT [FK_Expense_Person_PersonId] FOREIGN KEY([PersonId])
REFERENCES [dbo].[Person] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[Expense] CHECK CONSTRAINT [FK_Expense_Person_PersonId]
GO
