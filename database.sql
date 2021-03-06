USE [MotorbikeDB]
GO
/****** Object:  Table [dbo].[BILL]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BILL](
	[BID] [int] NOT NULL,
	[CUSID] [int] NULL,
	[MOTOID] [int] NULL,
	[DATEBUY] [date] NULL,
	[QUANTITY] [int] NULL,
	[TOTALMONEY] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[BID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CUSTOMER]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CUSTOMER](
	[CUSID] [int] IDENTITY(1,1) NOT NULL,
	[FIRSTNAME] [varchar](50) NULL,
	[LASTNAME] [varchar](50) NULL,
	[IDCARD] [varchar](50) NULL,
	[PHONENUMBER] [varchar](50) NULL,
	[ADDRESSS] [varchar](50) NULL,
	[BID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[CUSID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEGREE]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEGREE](
	[DEGREEID] [int] NOT NULL,
	[DEGREENAME] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DEGREEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DEPARTMENT]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DEPARTMENT](
	[DEPARTMENTID] [int] NOT NULL,
	[DEPARTMENTNAME] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[DEPARTMENTID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[EMPLOYEE]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[EMPLOYEE](
	[EID] [int] IDENTITY(1,1) NOT NULL,
	[FIRSTNAME] [varchar](50) NULL,
	[LASTNAME] [varchar](50) NULL,
	[PHONENUMBER] [varchar](50) NULL,
	[ADDDRESSS] [varchar](50) NULL,
	[GENDER] [varchar](50) NULL,
	[DOB] [date] NULL,
	[PICTURE] [image] NULL,
	[IDCARD] [varchar](50) NULL,
	[DEGREEID] [int] NULL,
	[POSITIONID] [int] NULL,
	[DEPARTMENTID] [int] NULL,
	[INSURANCEID] [int] NULL,
PRIMARY KEY CLUSTERED 
(
	[EID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[INSURANCE]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[INSURANCE](
	[INSURANCEID] [int] IDENTITY(1,1) NOT NULL,
	[EID] [int] NULL,
	[ISSUEDBY] [varchar](50) NULL,
	[HOSPITAL] [varchar](50) NULL,
	[DATEBUY] [date] NULL,
	[EXPDATE] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[INSURANCEID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[Login]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Login](
	[Username] [varchar](50) NOT NULL,
	[Password] [varchar](50) NULL,
	[Authority] [varchar](50) NULL,
 CONSTRAINT [PK_Login] PRIMARY KEY CLUSTERED 
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[MOTORBIKE]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[MOTORBIKE](
	[MOTOID] [int] IDENTITY(1,1) NOT NULL,
	[MOTONAME] [varchar](50) NULL,
	[PICTURE] [image] NULL,
	[PRODUCER] [varchar](50) NULL,
	[CAPACITY] [int] NULL,
	[COLOR] [varchar](50) NULL,
	[PRICE] [float] NULL,
PRIMARY KEY CLUSTERED 
(
	[MOTOID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[POSITION]    Script Date: 29/05/2018 00:46:52 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[POSITION](
	[POSITIONID] [int] NOT NULL,
	[POSITIONNAME] [varchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[POSITIONID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD FOREIGN KEY([CUSID])
REFERENCES [dbo].[CUSTOMER] ([CUSID])
GO
ALTER TABLE [dbo].[BILL]  WITH CHECK ADD FOREIGN KEY([MOTOID])
REFERENCES [dbo].[MOTORBIKE] ([MOTOID])
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD FOREIGN KEY([DEGREEID])
REFERENCES [dbo].[DEGREE] ([DEGREEID])
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD FOREIGN KEY([DEPARTMENTID])
REFERENCES [dbo].[DEPARTMENT] ([DEPARTMENTID])
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD FOREIGN KEY([INSURANCEID])
REFERENCES [dbo].[INSURANCE] ([INSURANCEID])
GO
ALTER TABLE [dbo].[EMPLOYEE]  WITH CHECK ADD FOREIGN KEY([POSITIONID])
REFERENCES [dbo].[POSITION] ([POSITIONID])
GO
