USE [master]
GO
/****** Object:  Database [SchoolManagement_DB]    Script Date: 5/6/2017 12:04:29 AM ******/
CREATE DATABASE [SchoolManagement_DB]
GO
USE [SchoolManagement_DB]
GO
/****** Object:  Table [dbo].[CHQ_ChequeCancellations_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHQ_ChequeCancellations_Details](
	[ChqCancel_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cheque_ID] [numeric](18, 0) NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy_ID] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[CancelledDate] [date] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CHQ_ChequeCancellations_Details] PRIMARY KEY CLUSTERED 
(
	[ChqCancel_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHQ_ChequeClearances_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHQ_ChequeClearances_Details](
	[ChqClearance_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cheque_ID] [numeric](18, 0) NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[ClearedDate] [date] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_CHQ_ChequeClearances_Details] PRIMARY KEY CLUSTERED 
(
	[ChqClearance_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHQ_ChequeDeposits_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHQ_ChequeDeposits_Details](
	[Deposit_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cheque_ID] [numeric](18, 0) NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[DepositDate] [date] NULL,
	[AccountNo] [varchar](50) NULL,
	[IsActive] [bit] NOT NULL,
	[CancelledBy_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_CHQ_ChequeDeposits_Details] PRIMARY KEY CLUSTERED 
(
	[Deposit_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHQ_ChequeReturns_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CHQ_ChequeReturns_Details](
	[ChqReturn_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Cheque_ID] [numeric](18, 0) NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[ReturnedDate] [date] NULL,
 CONSTRAINT [PK_ChequeReturns] PRIMARY KEY CLUSTERED 
(
	[ChqReturn_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[CHQ_Cheques_Master]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHQ_Cheques_Master](
	[Cheque_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Section_ID] [smallint] NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[InwardDate] [date] NULL,
	[ChequeNo] [varchar](100) NULL,
	[Bank] [varchar](100) NULL,
	[ChqAmount] [numeric](18, 2) NULL,
	[Remarks] [varchar](500) NULL,
	[ChqStatus_ID] [int] NULL,
	[IsActive] [bit] NULL,
 CONSTRAINT [PK_ChequeDetails] PRIMARY KEY CLUSTERED 
(
	[Cheque_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHQ_ChequeStatus_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHQ_ChequeStatus_Lookup](
	[ChqStatus_ID] [smallint] NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CHQ_ChequeStatus_Lookup] PRIMARY KEY CLUSTERED 
(
	[ChqStatus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CHQ_DeletedCheque_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CHQ_DeletedCheque_Details](
	[Cheque_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NULL,
	[Section_ID] [smallint] NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[EnteredBy] [numeric](18, 0) NULL,
	[Login_ID] [numeric](18, 0) NULL,
	[InwardDate] [date] NULL,
	[ChequeNo] [varchar](100) NULL,
	[Bank] [varchar](100) NULL,
	[ChqAmount] [numeric](18, 2) NULL,
	[Remarks] [varchar](500) NULL,
	[ChqStatus_ID] [int] NULL,
	[DeletedBy_ID] [numeric](18, 0) NULL,
 CONSTRAINT [PK_DeletedChequeDetails] PRIMARY KEY CLUSTERED 
(
	[Cheque_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_Languages_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_Languages_Lookup](
	[Language_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__GEN_Langu__IsAct__1DE57479]  DEFAULT ((1)),
 CONSTRAINT [PK_GEN_Languages_Lookup] PRIMARY KEY CLUSTERED 
(
	[Language_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_Religions_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_Religions_Lookup](
	[Religion_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__GEN_Relig__IsAct__20C1E124]  DEFAULT ((1)),
 CONSTRAINT [PK_GEN_Religions_Lookup] PRIMARY KEY CLUSTERED 
(
	[Religion_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_Sections_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_Sections_Lookup](
	[Section_Id] [smallint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_GEN_Sections_Lookup] PRIMARY KEY CLUSTERED 
(
	[Section_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_Standards_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_Standards_Lookup](
	[Standard_Id] [smallint] NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Section_Id] [int] NULL,
 CONSTRAINT [PK_GEN_Standards_Lookup] PRIMARY KEY CLUSTERED 
(
	[Standard_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_StudentCategory_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_StudentCategory_Lookup](
	[Category_Id] [smallint] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__GEN_Stude__IsAct__276EDEB3]  DEFAULT ((1)),
 CONSTRAINT [PK_GEN_StudentCategory_Lookup] PRIMARY KEY CLUSTERED 
(
	[Category_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[GEN_UserCredentials_Master]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[GEN_UserCredentials_Master](
	[User_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[Password] [nvarchar](50) NOT NULL,
	[SystemRole_ID] [smallint] NOT NULL,
	[EnteredOn] [datetimeoffset](0) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedOn] [datetimeoffset](0) NOT NULL,
 CONSTRAINT [PK_EMP_UserCredentials_Master] PRIMARY KEY CLUSTERED 
(
	[User_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[GEN_UserLogin_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[GEN_UserLogin_Details](
	[Login_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[User_ID] [numeric](18, 0) NOT NULL,
	[LoginTime] [datetimeoffset](0) NOT NULL,
	[LogoutTime] [datetimeoffset](0) NULL,
	[HostName] [varchar](50) NULL,
 CONSTRAINT [PK_GEN_UserLogin_Details] PRIMARY KEY CLUSTERED 
(
	[Login_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[PEM_AssignedPermissions_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[PEM_AssignedPermissions_Details](
	[Permission_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Page_ID] [numeric](18, 0) NOT NULL,
	[SystemRole_ID] [smallint] NOT NULL,
	[EnteredOn] [datetimeoffset](0) NOT NULL,
	[GrantWrite] [bit] NOT NULL,
	[GrantDelete] [bit] NOT NULL,
	[EnteredBy_ID] [numeric](18, 0) NOT NULL,
	[LastModifiedOn] [datetimeoffset](0) NULL,
 CONSTRAINT [PK_SYS_AssignedPermissions_Details] PRIMARY KEY CLUSTERED 
(
	[Permission_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[PEM_PageEnumerator_Master]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[PEM_PageEnumerator_Master](
	[Page_ID] [numeric](18, 0) NOT NULL,
	[Name] [varchar](50) NOT NULL,
	[Description] [varchar](300) NULL,
	[EnteredOn] [datetimeoffset](0) NOT NULL,
	[IsActive] [bit] NOT NULL,
	[LastModifiedOn] [datetimeoffset](0) NOT NULL,
 CONSTRAINT [PK_SYS_Page_Master] PRIMARY KEY CLUSTERED 
(
	[Page_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STUD_AcademicStatus_Lookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STUD_AcademicStatus_Lookup](
	[AcaStatus_ID] [smallint] NOT NULL,
	[StatusName] [varchar](50) NOT NULL,
 CONSTRAINT [PK_CHQ_AcademicStatus_Lookup] PRIMARY KEY CLUSTERED 
(
	[AcaStatus_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STUD_DetainingOrPromotions_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[STUD_DetainingOrPromotions_Details](
	[ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[Student_ID] [numeric](18, 0) NOT NULL,
	[LastAcadDetail_ID] [numeric](18, 0) NOT NULL,
	[CurrentAcadDetail_ID] [numeric](18, 0) NOT NULL,
	[Status_ID] [int] NULL,
	[EnteredBy] [numeric](18, 0) NOT NULL,
	[Login_ID] [numeric](18, 0) NOT NULL,
 CONSTRAINT [PK_DetainingOrPromotions] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[STUD_StudentAcademic_Details]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STUD_StudentAcademic_Details](
	[AcademicDet_ID] [numeric](18, 0) IDENTITY(1,1) NOT NULL,
	[RegNo] [varchar](100) NOT NULL,
	[Student_ID] [numeric](18, 0) NOT NULL,
	[Section_ID] [int] NULL,
	[Standard_ID] [smallint] NULL,
	[Division] [smallint] NULL,
	[AcademicYearStart] [int] NULL,
	[AcademicYearEnd] [int] NULL,
	[Remarks] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_StudentAcademicDetails] PRIMARY KEY CLUSTERED 
(
	[AcademicDet_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[STUD_Students_Master]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[STUD_Students_Master](
	[Student_ID] [numeric](18, 0) NOT NULL,
	[RegNo] [varchar](100) NULL,
	[Gender] [char](1) NULL,
	[Name] [nvarchar](100) NULL,
	[Surname] [nvarchar](100) NULL,
	[FatherName] [nvarchar](100) NULL,
	[MotherName] [nvarchar](100) NULL,
	[MotherTongue] [nvarchar](100) NULL,
	[Religion] [nvarchar](100) NULL,
	[Caste] [nvarchar](100) NULL,
	[Religion_ID] [int] NULL,
	[Language_ID] [int] NULL,
	[Category_ID] [int] NULL,
	[DOB] [date] NULL,
	[CurrentAcaDetail_ID] [numeric](18, 0) NULL,
	[CurrentStd_ID] [int] NULL,
	[CurrentDiv] [varchar](5) NULL,
	[Address] [varchar](500) NULL,
	[Mobile1] [varchar](15) NULL,
	[Mobile2] [varchar](15) NULL,
	[Mobile3] [varchar](15) NULL,
	[HomePh] [varchar](15) NULL,
	[WorkPh] [varchar](15) NULL,
	[Email] [varchar](50) NULL,
	[RFIDTag] [varchar](max) NULL,
	[AadharNo] [varchar](100) NULL,
	[PrimaryContact] [varchar](100) NULL,
	[StudPhoto] [varbinary](max) NULL,
	[Remarks] [varchar](max) NULL,
	[IsActive] [bit] NOT NULL,
	[EnteredBy_ID] [numeric](18, 0) NOT NULL,
	[EnteredOn] [datetimeoffset](0) NULL,
	[LastModifiedBy_ID] [numeric](18, 0) NOT NULL,
	[LastModifiedOn] [datetimeoffset](0) NULL,
 CONSTRAINT [PK_Students] PRIMARY KEY CLUSTERED 
(
	[Student_ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO
/****** Object:  View [dbo].[AcademicStatusLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AcademicStatusLookup]    AS    SELECT * FROM STUD_AcademicStatus_Lookup


GO
/****** Object:  View [dbo].[AssignedPermissionsDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[AssignedPermissionsDetails]    AS    SELECT * FROM PEM_AssignedPermissions_Details


GO
/****** Object:  View [dbo].[ChequeCancellationsDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequeCancellationsDetails]    AS    SELECT * FROM CHQ_ChequeCancellations_Details


GO
/****** Object:  View [dbo].[ChequeClearancesDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequeClearancesDetails]    AS    SELECT * FROM CHQ_ChequeClearances_Details


GO
/****** Object:  View [dbo].[ChequeDepositsDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequeDepositsDetails]    AS    SELECT * FROM CHQ_ChequeDeposits_Details


GO
/****** Object:  View [dbo].[ChequeReturnsDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequeReturnsDetails]    AS    SELECT * FROM CHQ_ChequeReturns_Details


GO
/****** Object:  View [dbo].[ChequesMaster]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequesMaster]    AS    SELECT * FROM CHQ_Cheques_Master


GO
/****** Object:  View [dbo].[ChequeStatusLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ChequeStatusLookup]    AS    SELECT * FROM CHQ_ChequeStatus_Lookup


GO
/****** Object:  View [dbo].[DeletedChequeDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DeletedChequeDetails]    AS    SELECT * FROM CHQ_DeletedCheque_Details


GO
/****** Object:  View [dbo].[DetainingOrPromotionsDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[DetainingOrPromotionsDetails]    AS    SELECT * FROM STUD_DetainingOrPromotions_Details


GO
/****** Object:  View [dbo].[LanguagesLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[LanguagesLookup]
AS
SELECT        Language_Id, Name, IsActive
FROM            dbo.GEN_Languages_Lookup



GO
/****** Object:  View [dbo].[PageEnumeratorMaster]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[PageEnumeratorMaster]    AS    SELECT * FROM PEM_PageEnumerator_Master


GO
/****** Object:  View [dbo].[ReligionsLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[ReligionsLookup]
AS
SELECT        dbo.GEN_Religions_Lookup.*
FROM            dbo.GEN_Religions_Lookup



GO
/****** Object:  View [dbo].[SectionsLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[SectionsLookup]
AS
SELECT        dbo.GEN_Sections_Lookup.*
FROM            dbo.GEN_Sections_Lookup



GO
/****** Object:  View [dbo].[StandardsLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StandardsLookup]
AS
SELECT        dbo.GEN_Standards_Lookup.*
FROM            dbo.GEN_Standards_Lookup



GO
/****** Object:  View [dbo].[StudentAcademicDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentAcademicDetails]    AS    SELECT * FROM STUD_StudentAcademic_Details


GO
/****** Object:  View [dbo].[StudentCategoryLookup]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentCategoryLookup]
AS
SELECT        dbo.GEN_StudentCategory_Lookup.*
FROM            dbo.GEN_StudentCategory_Lookup



GO
/****** Object:  View [dbo].[StudentsMaster]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[StudentsMaster]    AS    SELECT * FROM STUD_Students_Master


GO
/****** Object:  View [dbo].[UserCredentialsMaster]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserCredentialsMaster]    AS    SELECT * FROM GEN_UserCredentials_Master


GO
/****** Object:  View [dbo].[UserLoginDetails]    Script Date: 5/6/2017 12:04:29 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE VIEW [dbo].[UserLoginDetails]    AS    SELECT * FROM GEN_UserLogin_Details


GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (0, N'Deleted')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (1, N'Cheque Recieved')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (2, N'Deposited')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (3, N'Returned')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (4, N'Cancelled')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (5, N'Cleared')
GO
INSERT [dbo].[CHQ_ChequeStatus_Lookup] ([ChqStatus_ID], [StatusName]) VALUES (6, N'Mapped To Reciept')
GO
SET IDENTITY_INSERT [dbo].[GEN_Languages_Lookup] ON 

GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (1, N'Hindi', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (2, N'Marathi', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (3, N'Malayalam', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (4, N'English', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (5, N'Assamese', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (6, N'Bengali', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (7, N'Gujarathi', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (8, N'Kannada', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (9, N'Kashmiri', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (10, N'Konkani', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (11, N'Manipuri', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (12, N'Nepali', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (13, N'Odia', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (14, N'Punjabi', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (15, N'Sindhi', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (16, N'Tamil', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (17, N'Telungu', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (18, N'Tulu', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (19, N'Urudu', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (20, N'NA', 1)
GO
INSERT [dbo].[GEN_Languages_Lookup] ([Language_Id], [Name], [IsActive]) VALUES (21, N'Marwadi', 1)
GO
SET IDENTITY_INSERT [dbo].[GEN_Languages_Lookup] OFF
GO
SET IDENTITY_INSERT [dbo].[GEN_Religions_Lookup] ON 

GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (1, N'Budhist', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (2, N'Christian', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (3, N'Hindu', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (4, N'Islam', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (5, N'Jain', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (6, N'Parsi', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (7, N'Sikh', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (8, N'Zoroastrian', 1)
GO
INSERT [dbo].[GEN_Religions_Lookup] ([Religion_Id], [Name], [IsActive]) VALUES (9, N'NA', 1)
GO
SET IDENTITY_INSERT [dbo].[GEN_Religions_Lookup] OFF
GO
INSERT [dbo].[GEN_Sections_Lookup] ([Section_Id], [Name], [IsActive]) VALUES (0, N'KG', 1)
GO
INSERT [dbo].[GEN_Sections_Lookup] ([Section_Id], [Name], [IsActive]) VALUES (1, N'Primary', 1)
GO
INSERT [dbo].[GEN_Sections_Lookup] ([Section_Id], [Name], [IsActive]) VALUES (2, N'Secondary', 1)
GO
INSERT [dbo].[GEN_Sections_Lookup] ([Section_Id], [Name], [IsActive]) VALUES (3, N'Others', 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (1, N'1', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (2, N'2', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (3, N'3', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (4, N'4', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (5, N'5', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (6, N'6', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (7, N'7', 1, 1)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (8, N'8', 1, 2)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (9, N'9', 1, 2)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (10, N'10', 1, 2)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (11, N'11', 1, 3)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (12, N'12', 1, 3)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (100, N'Nursery', 1, 0)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (101, N'Junior KG', 1, 0)
GO
INSERT [dbo].[GEN_Standards_Lookup] ([Standard_Id], [Name], [IsActive], [Section_Id]) VALUES (102, N'Senior KG', 1, 0)
GO
SET IDENTITY_INSERT [dbo].[GEN_StudentCategory_Lookup] ON 

GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (1, N'Open', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (2, N'SC', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (3, N'SBC', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (4, N'ST', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (5, N'NT', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (6, N'NT-C', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (7, N'NT-D', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (8, N'OBC', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (9, N'VJ-A', 1)
GO
INSERT [dbo].[GEN_StudentCategory_Lookup] ([Category_Id], [Name], [IsActive]) VALUES (10, N'NA', 1)
GO
SET IDENTITY_INSERT [dbo].[GEN_StudentCategory_Lookup] OFF
GO
INSERT [dbo].[STUD_AcademicStatus_Lookup] ([AcaStatus_ID], [StatusName]) VALUES (1, N'Promoted')
GO
INSERT [dbo].[STUD_AcademicStatus_Lookup] ([AcaStatus_ID], [StatusName]) VALUES (2, N'Detained')
GO
ALTER TABLE [dbo].[CHQ_ChequeCancellations_Details] ADD  CONSTRAINT [DF_ChequeCancellations_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[CHQ_ChequeClearances_Details] ADD  CONSTRAINT [DF_ChequeClearances_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[CHQ_ChequeDeposits_Details] ADD  CONSTRAINT [DF_ChequeDeposits_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[CHQ_Cheques_Master] ADD  CONSTRAINT [DF_ChequeDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserCredentials_Master] ADD  CONSTRAINT [DF_EMP_UserCredentials_Master_EnteredOn]  DEFAULT (sysdatetimeoffset()) FOR [EnteredOn]
GO
ALTER TABLE [dbo].[GEN_UserCredentials_Master] ADD  CONSTRAINT [DF_EMP_UserCredentials_Master_Active]  DEFAULT ((10)) FOR [IsActive]
GO
ALTER TABLE [dbo].[GEN_UserCredentials_Master] ADD  CONSTRAINT [DF_EMP_UserCredentials_Master_LastModifiedOn]  DEFAULT (sysdatetimeoffset()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[PEM_AssignedPermissions_Details] ADD  CONSTRAINT [DF_SYS_AssignedPermissions_Details_EnteredOn]  DEFAULT (sysdatetimeoffset()) FOR [EnteredOn]
GO
ALTER TABLE [dbo].[PEM_AssignedPermissions_Details] ADD  CONSTRAINT [DF_SYS_AssignedPermissions_Details_GrantWrite]  DEFAULT ((0)) FOR [GrantWrite]
GO
ALTER TABLE [dbo].[PEM_AssignedPermissions_Details] ADD  CONSTRAINT [DF_SYS_AssignedPermissions_Details_GrantDelete]  DEFAULT ((0)) FOR [GrantDelete]
GO
ALTER TABLE [dbo].[PEM_PageEnumerator_Master] ADD  CONSTRAINT [DF_SYS_Page_Master_EnteredOn]  DEFAULT (sysdatetimeoffset()) FOR [EnteredOn]
GO
ALTER TABLE [dbo].[PEM_PageEnumerator_Master] ADD  CONSTRAINT [DF_SYS_Page_Master_Active]  DEFAULT ((10)) FOR [IsActive]
GO
ALTER TABLE [dbo].[PEM_PageEnumerator_Master] ADD  CONSTRAINT [DF_SYS_Page_Master_LastModifiedOn]  DEFAULT (sysdatetimeoffset()) FOR [LastModifiedOn]
GO
ALTER TABLE [dbo].[STUD_StudentAcademic_Details] ADD  CONSTRAINT [DF_StudentAcademicDetails_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
ALTER TABLE [dbo].[STUD_Students_Master] ADD  CONSTRAINT [DF_Students_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GEN_Languages_Lookup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LanguagesLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'LanguagesLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GEN_Religions_Lookup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReligionsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'ReligionsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GEN_Sections_Lookup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SectionsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'SectionsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GEN_Standards_Lookup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StandardsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StandardsLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPane1', @value=N'[0E232FF0-B466-11cf-A24F-00AA00A3EFFF, 1.00]
Begin DesignProperties = 
   Begin PaneConfigurations = 
      Begin PaneConfiguration = 0
         NumPanes = 4
         Configuration = "(H (1[40] 4[20] 2[20] 3) )"
      End
      Begin PaneConfiguration = 1
         NumPanes = 3
         Configuration = "(H (1 [50] 4 [25] 3))"
      End
      Begin PaneConfiguration = 2
         NumPanes = 3
         Configuration = "(H (1 [50] 2 [25] 3))"
      End
      Begin PaneConfiguration = 3
         NumPanes = 3
         Configuration = "(H (4 [30] 2 [40] 3))"
      End
      Begin PaneConfiguration = 4
         NumPanes = 2
         Configuration = "(H (1 [56] 3))"
      End
      Begin PaneConfiguration = 5
         NumPanes = 2
         Configuration = "(H (2 [66] 3))"
      End
      Begin PaneConfiguration = 6
         NumPanes = 2
         Configuration = "(H (4 [50] 3))"
      End
      Begin PaneConfiguration = 7
         NumPanes = 1
         Configuration = "(V (3))"
      End
      Begin PaneConfiguration = 8
         NumPanes = 3
         Configuration = "(H (1[56] 4[18] 2) )"
      End
      Begin PaneConfiguration = 9
         NumPanes = 2
         Configuration = "(H (1 [75] 4))"
      End
      Begin PaneConfiguration = 10
         NumPanes = 2
         Configuration = "(H (1[66] 2) )"
      End
      Begin PaneConfiguration = 11
         NumPanes = 2
         Configuration = "(H (4 [60] 2))"
      End
      Begin PaneConfiguration = 12
         NumPanes = 1
         Configuration = "(H (1) )"
      End
      Begin PaneConfiguration = 13
         NumPanes = 1
         Configuration = "(V (4))"
      End
      Begin PaneConfiguration = 14
         NumPanes = 1
         Configuration = "(V (2))"
      End
      ActivePaneConfig = 0
   End
   Begin DiagramPane = 
      Begin Origin = 
         Top = 0
         Left = 0
      End
      Begin Tables = 
         Begin Table = "GEN_StudentCategory_Lookup"
            Begin Extent = 
               Top = 6
               Left = 38
               Bottom = 119
               Right = 208
            End
            DisplayFlags = 280
            TopColumn = 0
         End
      End
   End
   Begin SQLPane = 
   End
   Begin DataPane = 
      Begin ParameterDefaults = ""
      End
   End
   Begin CriteriaPane = 
      Begin ColumnWidths = 11
         Column = 1440
         Alias = 900
         Table = 1170
         Output = 720
         Append = 1400
         NewValue = 1170
         SortType = 1350
         SortOrder = 1410
         GroupBy = 1350
         Filter = 1350
         Or = 1350
         Or = 1350
         Or = 1350
      End
   End
End
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCategoryLookup'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_DiagramPaneCount', @value=1 , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'VIEW',@level1name=N'StudentCategoryLookup'
GO
USE [master]
GO
ALTER DATABASE [SchoolManagement_DB] SET  READ_WRITE 
GO
