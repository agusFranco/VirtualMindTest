CREATE DATABASE VirtualMind
GO

USE [VirtualMind]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 7/10/2016 00:18:51 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	[Email] [nvarchar](50) NULL,
	[Password] [nvarchar](8) NULL,
 CONSTRAINT [PK_dbo.Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (6, N'Agustin', N'Franco', N'agustinfranco15@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (7, N'Nicolas', N'Franco', N'nicolasfranco@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (8, N'Edgardo', N'Franco', N'Edgardofranco@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (9, N'Liliana', N'Franco', N'lilianafranco15@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (10, N'Julieta', N'Franco', N'julietafranco15@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (11, N'Javier', N'Sosa', N'javier.sosa@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (12, N'Lucas', N'Sosa', N'lucas.sosa@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (13, N'Benjamin', N'Perez', N'b.perez@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (14, N'Pablo', N'Perez', N'pablo.p.perez@gmail.com', N'123456')
INSERT [dbo].[Users] ([Id], [Name], [LastName], [Email], [Password]) VALUES (15, N'Armando', N'EstebanQuito', N'armandoestebanquito@gmail.com', N'123456')
SET IDENTITY_INSERT [dbo].[Users] OFF
