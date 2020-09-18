USE [NilexTicketProject]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 09/18/2020 11:16:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[TicketID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[CreateDate] [datetime] NULL,
	[Explanation] [nvarchar](max) NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 09/18/2020 11:16:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Priority] [nvarchar](50) NULL,
	[Title] [nvarchar](150) NULL,
	[Content] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](200) NULL,
	[Status] [bit] NULL,
	[IsItRead] [bit] NULL,
	[CreateDate] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/18/2020 11:16:06 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](100) NULL,
	[FullName] [nvarchar](30) NULL,
	[Password] [nvarchar](20) NULL,
	[Mail] [nvarchar](100) NULL,
	[Birthdate] [nvarchar](50) NULL,
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate]) VALUES (57, 12, N'Yüksek', N'as das', N' das fds d ', N'/Content/img/Ticket/9c1d2ca1217b4cbcbb365bdae7deee13.png', 1, 0, CAST(0x0000AC3A016C0ACA AS DateTime))
INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate]) VALUES (58, 12, N'Low', N'csadd sds', N'f gdsg sdggg', N'/Content/img/Ticket/c85243f2525541d6997f8abf0191262d.png', 1, 0, CAST(0x0000AC3A0170D8F3 AS DateTime))
SET IDENTITY_INSERT [dbo].[Tickets] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (1, N'Serkanparlak81', N'Serkan Parlak', N'1234', N'serkanparlak27108@hotmail.com', N'', N'Admin')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (2, N'Ahmetungor42', N'Ahmet Üngören', N'1234', N'ahmetungor421@hotmail.com', NULL, N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (3, N'Selcukbayramm', N'Selçuk Bayram', N'selcuk42', N'selcukbayramm@gmail.com', NULL, N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (4, N'Yusufprlkk', N'Yusuf Parlak', N'ysfprlk', N'yusufprlk@windowslive.com', NULL, N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (5, N'Veliyigit34', N'Veli Yiğit', N'veli34', N'veliyigit34@gmail.com', NULL, N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (7, N'asd', N'Oktay', N'asd', N'saldmf@hotmail.com', N'13.6.1938', N'Admin')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (8, N'zxc', N'Ahmet Kerim', N'zxc', N'klasfn@hotma', N'2.4.1929', N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (9, N'asdkjnc', N'Ahmet', N'asd', N'klasfn@hotmae', N'2.4.1929', N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (10, N'abdi', N'Abdi Şakrak', N'qwer', N'adbi@gmail', N'16.11.1936', N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (11, N'mikail42', N'mikail', N'1234', N'adbi@gmaild', N'13.5.1931', N'Kullanıcı')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Birthdate], [Role]) VALUES (12, N'qwe', N'qwe ewq', N'qwe', N'qwe@htm.com', NULL, N'Kullanıcı')
SET IDENTITY_INSERT [dbo].[Users] OFF
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_Role]  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Tickets] FOREIGN KEY([TicketID])
REFERENCES [dbo].[Tickets] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Tickets]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users]
GO
ALTER TABLE [dbo].[Tickets]  WITH CHECK ADD  CONSTRAINT [FK_Tickets_Users] FOREIGN KEY([UserID])
REFERENCES [dbo].[Users] ([ID])
GO
ALTER TABLE [dbo].[Tickets] CHECK CONSTRAINT [FK_Tickets_Users]
GO
