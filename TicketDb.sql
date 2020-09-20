USE [NilexTicketProject]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 09/20/2020 06:54:05 AM ******/
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
/****** Object:  Table [dbo].[Tickets]    Script Date: 09/20/2020 06:54:05 AM ******/
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
/****** Object:  Table [dbo].[Users]    Script Date: 09/20/2020 06:54:05 AM ******/
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
	[Role] [nvarchar](50) NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation]) VALUES (73, 62, 31, CAST(0x0000AC3C006DD79F AS DateTime), N'hola everyone')
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation]) VALUES (74, 62, 31, CAST(0x0000AC3C006F9278 AS DateTime), N'fds fsd f')
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation]) VALUES (75, 62, 31, CAST(0x0000AC3C006F94FD AS DateTime), N'gfgfgf')
SET IDENTITY_INSERT [dbo].[Comments] OFF
SET IDENTITY_INSERT [dbo].[Tickets] ON 

INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate]) VALUES (62, 31, N'High', N'Lorem Ipsum', N'ds da das da sdas dasd as', N'/Content/img/Ticket/cc46f877420a4d4bb270f5f85555137b.jpg', 1, 0, CAST(0x0000AC3C006DA124 AS DateTime))
SET IDENTITY_INSERT [dbo].[Tickets] OFF
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role]) VALUES (1, N'admin', N'Admin Demo', N'1234', N'admin@demo.com', N'Admin')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role]) VALUES (12, N'demo', N'User Demo', N'1234', N'user@demo.com', N'User')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role]) VALUES (13, N'hakan', N'Hakan Ilgar', N'1234', N'hakan@demo.com', N'User')
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role]) VALUES (31, N'john', N'John Doe', N'1234', N'john@demo.com', N'User')
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
