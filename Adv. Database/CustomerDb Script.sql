CREATE DATABASE [CustomerDB]
GO

USE [CustomerDB]

CREATE TABLE [Customers](
	[CustomerID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Age] [int] NOT NULL,
	[Country] [char](2) NOT NULL,
  CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerID] ASC)
)

SET IDENTITY_INSERT [dbo].[Customers] ON 

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (1, N'Kendra', 18, N'US')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (2, N'Corrina', 21, N'UK')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (3, N'Alysa', 29, N'DE')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (4, N'Karla', 19, N'UK')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (5, N'Joi', 30, N'DE')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (6, N'Hector', 45, N'DE')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (7, N'Eleanora', 34, N'US')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (8, N'Tori', 51, N'US')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (9, N'Kevin', 64, N'DK')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (10, N'Michael', 26, N'DK')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (11, N'Ulla', 55, N'DK')

INSERT INTO [dbo].[Customers] ([CustomerID], [Name], [Age], [Country]) VALUES (12, N'Bent', 22, N'DK')

SET IDENTITY_INSERT [dbo].[Customers] OFF

