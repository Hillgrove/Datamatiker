CREATE TABLE [dbo].[Customer] (
	[Id]				INT				NOT NULL,
	[Name]				NVARCHAR (50)	NOT NULL,
	[Phone_Number]		NVARCHAR (20)	NOT NULL,
	[Credit]			INT				NOT NULL
);

INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (1, 'John Doe', '123-456-7890', 1000);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (2, 'Jane Smith', '987-654-3210', 1500);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (3, 'Michael Johnson', '555-555-5555', 800);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (4, 'Emily Brown', '444-444-4444', 2000);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (5, 'David Wilson', '333-333-3333', 1200);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (6, 'Sarah Martinez', '222-222-2222', 1750);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (7, 'Chris Thompson', '111-111-1111', 900);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (8, 'Amanda Garcia', '999-999-9999', 1350);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (9, 'James Rodriguez', '777-777-7777', 1100);
INSERT INTO [dbo].[Customer] ([Id], [Name], [Phone_Number], [Credit]) VALUES (10, 'Jessica Lee', '666-666-6666', 1600);
