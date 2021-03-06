
/****** Object:  Table [dbo].[Comments]    Script Date: 09/21/2020 05:43:00 PM ******/
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
	[IsDeleted] [bit] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Comment] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Tickets]    Script Date: 09/21/2020 05:43:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tickets](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Priority] [nvarchar](50) NULL,
	[Title] [nvarchar](1000) NULL,
	[Content] [nvarchar](max) NULL,
	[ImageUrl] [nvarchar](1000) NULL,
	[Status] [bit] NULL,
	[IsItRead] [bit] NULL,
	[CreateDate] [datetime] NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_Ticket] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Users]    Script Date: 09/21/2020 05:43:00 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[ID] [int] IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](1000) NULL,
	[FullName] [nvarchar](1000) NULL,
	[Password] [nvarchar](1000) NULL,
	[Mail] [nvarchar](100) NULL,
	[Role] [nvarchar](50) NULL,
	[IsDeleted] [bit] NULL,
	[DeleteDate] [datetime] NULL,
 CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (76, 63, 31, CAST(0x0000AC3C011F7409 AS DateTime), N'Res enim concurrent contrariae. Vide, quantum, inquam, fallare, Torquate. Sed haec quidem liberius ab eo dicuntur et saepius. Si quicquam extra virtutem habeatur in bonis. Nunc haec primum fortasse audientis servire debemus. Scrupulum, inquam, abeunti; Certe nihil nisi quod possit ipsum propter se iure laudari. Ergo, si semel tristior effectus est, hilara vita amissa est? Facile pateremur, qui etiam nunc agendi aliquid discendique causa prope contra naturam vígillas suscipere soleamus. Quippe: habes enim a rhetoribus;

Aliter enim nosmet ipsos nosse non possumus. Illi enim inter se dissentiunt. Dic in quovis conventu te omnia facere, ne doleas. Quis istud possit, inquit, negare? Quae duo sunt, unum facit. Cur tantas regiones barbarorum pedibus obiit, tot maria transmisit? Oculorum, inquit Plato, est in nobis sensus acerrimus, quibus sapientiam non cernimus. Haec mihi videtur delicatior, ut ita dicam, molliorque ratio, quam virtutis vis gravitasque postulat. Nam quid possumus facere melius? Nunc ita separantur, ut disiuncta sint, quo nihil potest esse perversius. Nummus in Croesi divitiis obscuratur, pars est tamen divitiarum.', 0, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (77, 63, 31, CAST(0x0000AC3C011F7F9D AS DateTime), N'Quid enim ab antiquis ex eo genere, quod ad disserendum valet, praetermissum est? Itaque ab his ordiamur. Si enim ad populum me vocas, eum. Ut pulsi recurrant? Quae similitudo in genere etiam humano apparet. Ratio quidem vestra sic cogit. Nummus in Croesi divitiis obscuratur, pars est tamen divitiarum.', 0, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (78, 63, 1, CAST(0x0000AC3C012B6652 AS DateTime), N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Laboro autem non sine causa; Nunc vides, quid faciat. An hoc usque quaque, aliter in vita? Quae si potest singula consolando levare, universa quo modo sustinebit? Itaque hic ipse iam pridem est reiectus; Duo Reges: constructio interrete. Aliud est enim poëtarum more verba fundere, aliud ea, quae dicas, ratione et arte distinguere. Ille incendat? Quaesita enim virtus est, non quae relinqueret naturam, sed quae tueretur. De malis autem et bonis ab iis animalibus, quae nondum depravata sint, ait optime iudicari.

Inde igitur, inquit, ordiendum est. Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant. Facit enim ille duo seiuncta ultima bonorum, quae ut essent vera, coniungi debuerunt; Venit ad extremum; Mihi enim erit isdem istis fortasse iam utendum. Comprehensum, quod cognitum non habet?', 0, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (79, 63, 31, CAST(0x0000AC3C0102D960 AS DateTime), N'Si longus, levis dictata sunt. Et tamen ego a philosopho, si afferat eloquentiam, non asperner, si non habeat, non admodum flagitem. Neque solum ea communia, verum etiam paria esse dixerunt. Quia dolori non voluptas contraria est, sed doloris privatio.', 0, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (80, 63, 31, CAST(0x0000AC3C010DA488 AS DateTime), N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Qui non moveatur et offensione turpitudinis et comprobatione honestatis? Idcirco enim non desideraret, quia, quod dolore caret, id in voluptate est. An est aliquid per se ipsum flagitiosum, etiamsi nulla comitetur infamia? Negat enim summo bono afferre incrementum diem. Quasi vero, inquit, perpetua oratio rhetorum solum, non etiam philosophorum sit. Omnia contraria, quos etiam insanos esse vultis.', 0, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (81, 63, 1, CAST(0x0000AC3D00F66257 AS DateTime), N'test 123', 1, NULL)
GO
INSERT [dbo].[Comments] ([ID], [TicketID], [UserID], [CreateDate], [Explanation], [IsDeleted], [DeleteDate]) VALUES (82, 64, 31, CAST(0x0000AC3D00F6B962 AS DateTime), N'ds fdfs df sdfsd', 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Tickets] ON 

GO
INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate], [IsDeleted], [DeleteDate]) VALUES (63, 31, N'High', N'#Team 1 - Yellowstone National Park Project', N'Lorem ipsum dolor sit amet, consectetur adipiscing elit. Laboro autem non sine causa; Nunc vides, quid faciat. An hoc usque quaque, aliter in vita? Quae si potest singula consolando levare, universa quo modo sustinebit? Itaque hic ipse iam pridem est reiectus; Duo Reges: constructio interrete. Aliud est enim poëtarum more verba fundere, aliud ea, quae dicas, ratione et arte distinguere. Ille incendat? Quaesita enim virtus est, non quae relinqueret naturam, sed quae tueretur. De malis autem et bonis ab iis animalibus, quae nondum depravata sint, ait optime iudicari.

Inde igitur, inquit, ordiendum est. Hoc etsi multimodis reprehendi potest, tamen accipio, quod dant. Facit enim ille duo seiuncta ultima bonorum, quae ut essent vera, coniungi debuerunt; Venit ad extremum; Mihi enim erit isdem istis fortasse iam utendum. Comprehensum, quod cognitum non habet?', N'/Content/img/Ticket/b054458c622449e9a3f11a9402f453da.jpg', 1, 0, CAST(0x0000AC3C011F43E8 AS DateTime), 0, NULL)
GO
INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate], [IsDeleted], [DeleteDate]) VALUES (64, 31, N'High', N'test123', N'sdf sf sdf sds dfsd', N'/Content/img/Ticket/58b07bd5913d44f1a1a65be91a202fa6.png', 1, 0, CAST(0x0000AC3D00F6AC31 AS DateTime), 0, NULL)
GO
INSERT [dbo].[Tickets] ([ID], [UserID], [Priority], [Title], [Content], [ImageUrl], [Status], [IsItRead], [CreateDate], [IsDeleted], [DeleteDate]) VALUES (65, 12, N'High', N'Hola', N'Comma esta!', N'/Content/img/Ticket/1c5daea181884848baf2c022c02707d3.jpg', 1, 0, CAST(0x0000AC3D0116C871 AS DateTime), 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Tickets] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

GO
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role], [IsDeleted], [DeleteDate]) VALUES (1, N'admin', N'Admin Demo', N'rXEil9SzItyNMcTTB953PyuB67wSxvenDhBDfAOleQg=', N'admin@demo.com', N'Admin', 0, NULL)
GO
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role], [IsDeleted], [DeleteDate]) VALUES (12, N'demo', N'User Demo', N'eMiBcsgpkSRFWVXhObnmW2ohwCJJDqCWKPwbyxxa3f0=', N'user@demo.com', N'User', 0, NULL)
GO
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role], [IsDeleted], [DeleteDate]) VALUES (13, N'hakan', N'Hakan Ilgar', N'rXEil9SzItyNMcTTB953PyuB67wSxvenDhBDfAOleQg=', N'hakan@demo.com', N'User', 1, CAST(0x0000AC3D0115EC3E AS DateTime))
GO
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role], [IsDeleted], [DeleteDate]) VALUES (31, N'john', N'John Doe', N'ZrvWt17EXifRqr8pQ4SpDlzp7jgnqc57Msdo8k2fyHk=', N'john@demo.com', N'User', 0, NULL)
GO
INSERT [dbo].[Users] ([ID], [Username], [FullName], [Password], [Mail], [Role], [IsDeleted], [DeleteDate]) VALUES (94, N'hakan', N'hakan', N'8c+lldY65UiH1pNwLCz4och7oHavCPTzW3QVFo8bFDo=', N'hakan@hakan.com', N'User', 0, NULL)
GO
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
ALTER TABLE [dbo].[Comments] ADD  CONSTRAINT [DF_Comments_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Tickets] ADD  CONSTRAINT [DF_Tickets_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_User_Role]  DEFAULT ('User') FOR [Role]
GO
ALTER TABLE [dbo].[Users] ADD  CONSTRAINT [DF_Users_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
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
