USE [SpendingReport]
GO
SET IDENTITY_INSERT [dbo].[Banks] ON 

GO
INSERT [dbo].[Banks] ([Id], [Name], [BankCode]) VALUES (1, N'Tatra Banka', '1100')
INSERT [dbo].[Banks] ([Id], [Name], [BankCode]) VALUES (2, N'Zuno', '7658')
INSERT [dbo].[Banks] ([Id], [Name], [BankCode]) VALUES (3, N'Poštová Banka', '5436')
GO
SET IDENTITY_INSERT [dbo].[Banks] OFF
GO
SET IDENTITY_INSERT [dbo].[PaymentTypes] ON 

GO
INSERT [dbo].[PaymentTypes] ([Id], [Name]) VALUES (1, N'Card Payment')
GO
INSERT [dbo].[PaymentTypes] ([Id], [Name]) VALUES (2, N'ATM withdrawall')
GO
INSERT [dbo].[PaymentTypes] ([Id], [Name]) VALUES (3, N'Cash Payment')
GO
SET IDENTITY_INSERT [dbo].[PaymentTypes] OFF
GO
SET IDENTITY_INSERT [dbo].[Types] ON 

GO
INSERT [dbo].[Types] ([Id], [TypeName]) VALUES (1, N'Credit')
GO
INSERT [dbo].[Types] ([Id], [TypeName]) VALUES (2, N'Debit')
GO
INSERT [dbo].[Types] ([Id], [TypeName]) VALUES (3, N'Not Defined')
GO
SET IDENTITY_INSERT [dbo].[Types] OFF
GO

SET IDENTITY_INSERT [dbo].[Users] ON 
GO
INSERT [dbo].[Users] ([Id]) VALUES (1)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF 
GO