/****** Object:  User [Mactus]    Script Date: 07-12-2023 18:51:24 ******/
USE [master]
GO
PRINT 'Database=$(database)' 
PRINT 'User=$(uname)' ;
PRINT 'Password=$(password)' ;

PRINT 'creating database $(database)';

CREATE DATABASE $(database)
 CONTAINMENT = NONE
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC $(database).[dbo].[sp_fulltext_database] @action = 'enable'
end
GO

PRINT 'setting database options';

ALTER DATABASE $(database) SET ANSI_NULL_DEFAULT OFF 
ALTER DATABASE $(database) SET ANSI_NULLS OFF 
ALTER DATABASE $(database) SET ANSI_PADDING OFF 
ALTER DATABASE $(database) SET ANSI_WARNINGS OFF 
ALTER DATABASE $(database) SET ARITHABORT OFF 
ALTER DATABASE $(database) SET AUTO_CLOSE OFF 
ALTER DATABASE $(database) SET AUTO_SHRINK OFF 
ALTER DATABASE $(database) SET AUTO_UPDATE_STATISTICS ON 
ALTER DATABASE $(database) SET CURSOR_CLOSE_ON_COMMIT OFF 
ALTER DATABASE $(database) SET CURSOR_DEFAULT  GLOBAL 
ALTER DATABASE $(database) SET CONCAT_NULL_YIELDS_NULL OFF 
ALTER DATABASE $(database) SET NUMERIC_ROUNDABORT OFF 
ALTER DATABASE $(database) SET QUOTED_IDENTIFIER OFF 
ALTER DATABASE $(database) SET RECURSIVE_TRIGGERS OFF 
ALTER DATABASE $(database) SET  DISABLE_BROKER 
ALTER DATABASE $(database) SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
ALTER DATABASE $(database) SET DATE_CORRELATION_OPTIMIZATION OFF 
ALTER DATABASE $(database) SET TRUSTWORTHY OFF 
ALTER DATABASE $(database) SET ALLOW_SNAPSHOT_ISOLATION OFF 
ALTER DATABASE $(database) SET PARAMETERIZATION SIMPLE 
ALTER DATABASE $(database) SET READ_COMMITTED_SNAPSHOT OFF 
ALTER DATABASE $(database) SET HONOR_BROKER_PRIORITY OFF 
ALTER DATABASE $(database) SET RECOVERY FULL 
ALTER DATABASE $(database) SET  MULTI_USER 
ALTER DATABASE $(database) SET PAGE_VERIFY CHECKSUM  
ALTER DATABASE $(database) SET DB_CHAINING OFF 
ALTER DATABASE $(database) SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
ALTER DATABASE $(database) SET TARGET_RECOVERY_TIME = 60 SECONDS 
ALTER DATABASE $(database) SET DELAYED_DURABILITY = DISABLED 
ALTER DATABASE $(database) SET ACCELERATED_DATABASE_RECOVERY = OFF  
ALTER DATABASE $(database) SET QUERY_STORE = OFF
ALTER DATABASE $(database) SET  READ_WRITE 
GO

PRINT 'creating user $(uname)';

IF NOT EXISTS(SELECT principal_id FROM sys.server_principals WHERE name = '$(uname)') 
BEGIN
    CREATE LOGIN $(uname)
    WITH PASSWORD = '$(password)'
END

USE $(database)
if not exists(select * from sys.database_principals where name = '$(uname)')
BEGIN
	CREATE USER $(uname) FOR LOGIN $(uname) WITH DEFAULT_SCHEMA=[dbo]
END
GO

PRINT 'creating tables';

/****** Object:  Table [dbo].[TBL_DataGroups]    Script Date: 07-12-2023 18:51:24 ******/
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[TBL_DataGroups]') AND type in (N'U'))

BEGIN
CREATE TABLE [dbo].[TBL_DataGroups](
	[GroupID] [int] NOT NULL,
	[GroupName] [varchar](100) NULL,
	[GroupType] [int] NULL,
 CONSTRAINT [PK_TBL_DataGroups] PRIMARY KEY CLUSTERED 
(
	[GroupID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[TBL_DataGroups] ADD  CONSTRAINT [DF_TBL_DataGroups_GroupType]  DEFAULT ((0)) FOR [GroupType]
END

GO
/****** Object:  Table [dbo].[tbl_enumvalue]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_enumvalue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_enumvalue](
	[enumid] [int] NOT NULL,
	[enumvalue] [int] NOT NULL,
	[enumdesc] [varchar](50) NULL
) ON [PRIMARY]
END
GO
IF (Select count(*) from tbl_enumvalue)=0
BEGIN
INSERT [dbo].[tbl_enumvalue] ([enumid], [enumvalue], [enumdesc]) VALUES (1, 0, N'OFF ')
INSERT [dbo].[tbl_enumvalue] ([enumid], [enumvalue], [enumdesc]) VALUES (1, 1, N'ON ')
END
GO
/****** Object:  Table [dbo].[tbl_pointidname]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_pointidname]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_pointidname](
	[id] [int] NOT NULL,
	[pointname] [varchar](100) NULL,
 CONSTRAINT [PK_TBL_PointIDName] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
end
GO
/****** Object:  Table [dbo].[TBL_ReportAppConfig]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_ReportAppConfig]') AND type in (N'U'))
BEGIN

CREATE TABLE [dbo].[TBL_ReportAppConfig](
	[ID] [int] NOT NULL,
	[Code] [nvarchar](50) NULL,
	[Description] [varchar](200) NULL,
	[Value] [nvarchar](200) NULL,
	[Type] [int] NULL,
	[Used] [bit] NULL,
 CONSTRAINT [PK_TBL_PlantConfig] PRIMARY KEY CLUSTERED 
(
	[ID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
END
GO


IF (Select count(*) from tbl_ReportAppConfig)=0
BEGIN
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (1, N'PlantName', N'Plant Name (UI, Reports)', N'Mactus Automation Pvt Ltd', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (2, N'AppName', N'Name Displayed in the UI', N'EMS Reporting Tool', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (3, N'AppVersion', N'Version', N'Indusoft Report Version 1.0.x', 1, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (4, N'ReportMainHeaderName', N'First Line in the Header Report. This will be common for all reports generated.', N'ENVIRONMENT MONITORING SYSTEM', 1, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (5, N'InFileDir', N'Application Files Directory', N'C:\Users\arunn\Desktop', 3, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (6, N'OutFileDir', N'Output Files Directory', N'D:\Projects\Mactus\EMS_BMS_REPORT', 3, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (7, N'DateTimeForatString', N'Date Time Forat String', N'dd/MM/yyyy HH:mm:ss', 1, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (8, N'AutoReportRequired', N'Auto Report Required=1 and Not Required=0', N'0', 2, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (9, N'AutoReportStartHour', N'Report Start Time (Hours in 24 Hour Format)', N'13', 4, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (10, N'DataMissingText', N'Text To Replace Missing Data In Repot', N'****', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (11, N'PrintDataMissingError', N'Print Data MIssing Error', N'1', 2, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (12, N'GeneratedBy', N'Text to Pint in Report', N'Generated By:', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (13, N'GeneratedTime', N'Text To Print in Report', N'Generated Time:', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (14, N'PSpace', N'Space Between Generated By and Time in Portrait Document', N'                           ', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (15, N'LSpace', N'Space Between Generated By and Time in Portrait Document', N'                             ', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (16, N'EMSDBODBCLocation', N'EMS Syste Database Server Location (ODBC)', N'Driver={SQL Server};Server=localhost\SQLEXPRESS;Database=EBO_DB;UID=Mactus;PWD=Mactus@123', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (17, N'AlarmGroupColName', N'Alarm Group ID column name for Alarms Report', N'Al_Group', 1, 1)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (18, N'ReportHeaderAddress', N'ReportHeaderAddress tobe printed in second line', N'', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (19, N'DateTimeColForatString', N'Date Time Format For Date Time Column In The Report', N'dd/MM/yyyy HH:mm', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (20, N'PrintReviewTableEveryPage', N'Print Review Table on Every page (1) or At The End Of the Page (0)', N'0', 2, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (21, N'PrintAlmAckForAllAlarms', N'PrintAlmAckForAllAlarms', N'0', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (22, N'AddMeanKineticTempRow', N'AddMeanKineticTempRow', N'0', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (23, N'AutoReportRequired', N'AutoReportRequired', N'0', 1, 0)
INSERT [dbo].[TBL_ReportAppConfig] ([ID], [Code], [Description], [Value], [Type], [Used]) VALUES (24, N'AddLimitsTable', N'Add Min Max Value', N'1', 2, 1)

END
GO
/****** Object:  Table [dbo].[TBL_ReportColumns]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[TBL_ReportColumns]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBL_ReportColumns](
	[columnid] [int] NOT NULL,
	[ReportID] [int] NOT NULL,
	[ColNameInDB] [varchar](100) NOT NULL,
	[ColSeq] [int] NOT NULL,
	[ColType] [int] NOT NULL,
	[ColWidth] [float] NOT NULL,
	[ColFormat] [varchar](50) NOT NULL,
	[ColJust] [int] NULL,
	[ColHeader] [varchar](50) NULL,
	[LowCheck] [bit] NULL,
	[LowCheckType] [int] NULL,
	[LowCheckValue] [float] NULL,
	[HighCheck] [bit] NULL,
	[HighCheckType] [int] NULL,
	[HighCheckValue] [float] NULL,
	[SetPointCheck] [bit] NULL,
	[SetPointType] [int] NULL,
	[SetPointValue] [float] NULL,
	[ColTitle] [varchar](50) NULL,
	[enumid] [int] NULL,
	[colmerge] [int] NULL,
 CONSTRAINT [PK_TBL_ReportColumns] PRIMARY KEY CLUSTERED 
(
	[columnid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_ColType]  DEFAULT ((0)) FOR [ColType]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_ColWidth]  DEFAULT ((1)) FOR [ColWidth]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_ColJust]  DEFAULT ((1)) FOR [ColJust]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_LowCheck]  DEFAULT ((0)) FOR [LowCheck]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_LockCheckType]  DEFAULT ((0)) FOR [LowCheckType]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_LowCheckValue]  DEFAULT ((0)) FOR [LowCheckValue]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_HighCheck]  DEFAULT ((0)) FOR [HighCheck]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_HighCheckType]  DEFAULT ((0)) FOR [HighCheckType]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_HighCheckValue]  DEFAULT ((0)) FOR [HighCheckValue]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_SetPointCheck]  DEFAULT ((0)) FOR [SetPointCheck]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_SetPointType]  DEFAULT ((0)) FOR [SetPointType]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_SetPointValue]  DEFAULT ((0)) FOR [SetPointValue]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_enumid]  DEFAULT ((0)) FOR [enumid]
ALTER TABLE [dbo].[TBL_ReportColumns] ADD  CONSTRAINT [DF_TBL_ReportColumns_colmerge]  DEFAULT ((0)) FOR [colmerge]

END
GO
/****** Object:  Table [dbo].[tbl_reportedevents]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_reportedevents]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_reportedevents](
	[eventid] [int] NOT NULL,
	[description] [varchar](50) NOT NULL
) ON [PRIMARY]
END
GO

IF (Select count(*) from tbl_reportedevents)=0
BEGIN
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (2, N'')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (3, N'')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (10, N'')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (11, N'testing ')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (15, N'User Created')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (16, N'User Deleted')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (29, N'New Forced Value')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (30, N'Un Forced Value')
INSERT [dbo].[tbl_reportedevents] ([eventid], [description]) VALUES (9037, N'Signature Sucessful')
END
GO
/****** Object:  Table [dbo].[TBL_ReportGroups]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_enumvalue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBL_ReportGroups](
	[ExternalLogId] [int] NOT NULL,
	[ColumnName] [varchar](100) NOT NULL,
	[GroupName] [varchar](100) NOT NULL,
	[CategoryName] [varchar](100) NOT NULL
) ON [PRIMARY]
END
GO
/****** Object:  Table [dbo].[TBL_ReportsConfiguration]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_enumvalue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBL_ReportsConfiguration](
	[ReportID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateID] [int] NULL,
	[ReportType] [int] NULL,
	[AlmGroupID] [int] NULL,
	[ReportTitle] [varchar](100) NULL,
	[ReportHeader] [varchar](100) NULL,
	[GeneratedTime] [bit] NULL,
	[GeneratedBy] [bit] NULL,
	[FromToDatesPrinted] [bit] NULL,
	[DataTablename] [varchar](200) NULL,
	[TimeIntervalInMin] [int] NULL,
	[DataAggregationType] [int] NULL,
	[FromDate] [datetime] NULL,
	[ToDate] [datetime] NULL,
	[UserName] [varchar](100) NULL,
	[ReportToBeGenerated] [int] NULL,
	[OutputFileName] [varchar](300) NULL,
	[printalarmsprows1] [bit] NULL,
	[printminmaxrows1] [bit] NULL,
	[printalarmsprows] [bit] NULL,
	[printminmaxrows] [bit] NULL,
 CONSTRAINT [PK_TBL_ReportsConfiguration] PRIMARY KEY CLUSTERED 
(
	[ReportID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]

ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_TemplateID]  DEFAULT ((1)) FOR [TemplateID]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_ReportType]  DEFAULT ((0)) FOR [ReportType]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_AlmGroupID]  DEFAULT ((0)) FOR [AlmGroupID]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_GeneratedTime]  DEFAULT ((1)) FOR [GeneratedTime]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_GeneratedBy]  DEFAULT ((1)) FOR [GeneratedBy]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_FromToDatesPrinted]  DEFAULT ((1)) FOR [FromToDatesPrinted]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_TimeIntervalInSec]  DEFAULT ((60)) FOR [TimeIntervalInMin]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_DataAggregationType]  DEFAULT ((0)) FOR [DataAggregationType]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_ReportToBeGenerated]  DEFAULT ((0)) FOR [ReportToBeGenerated]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_PrintAlarmSpRow]  DEFAULT ((1)) FOR [printalarmsprows1]
ALTER TABLE [dbo].[TBL_ReportsConfiguration] ADD  CONSTRAINT [DF_TBL_ReportsConfiguration_PtintMinMaxRow]  DEFAULT ((1)) FOR [printminmaxrows1]

END
GO
/****** Object:  Table [dbo].[tbl_reportstatus]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[tbl_enumvalue]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[tbl_reportstatus](
	[id] [bigint] IDENTITY(1,1) NOT NULL,
	[reportid] [int] NULL,
	[fromdate] [datetime2](0) NULL,
	[todate] [datetime2](0) NULL,
	[intervalmin] [int] NULL,
	[username] [varchar](50) NULL,
	[outputfilename] [varchar](300) NULL,
	[status] [int] NULL,
	[progress] [int] NULL,
	[errormessage] [varchar](500) NULL,
	[filename] [varchar](300) NULL,
	[reporttitle] [varchar](200) NULL,
	[generatechart] [int] NULL,
 CONSTRAINT [tbl_reportstatus_pkey] PRIMARY KEY CLUSTERED 
(
	[id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[tbl_reportstatus] ADD  CONSTRAINT [DF_tbl_reportstatus_generatechart]  DEFAULT ((0)) FOR [generatechart]
END
GO
/****** Object:  Table [dbo].[TBL_ReportTemplates]    Script Date: 07-12-2023 18:51:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
IF  NOT EXISTS (SELECT * FROM sys.objects 
WHERE object_id = OBJECT_ID(N'[dbo].[TBL_ReportTemplates]') AND type in (N'U'))
BEGIN
CREATE TABLE [dbo].[TBL_ReportTemplates](
	[TemplateID] [int] IDENTITY(1,1) NOT NULL,
	[TemplateName] [varchar](200) NULL,
	[LandScape] [bit] NULL,
	[IsIconNeeded] [bit] NULL,
	[FooterTableCol1] [varchar](100) NULL,
	[FooterTableCol2] [varchar](100) NULL,
	[FooterTableCol3] [varchar](100) NULL,
	[Footer1] [varchar](50) NULL,
	[Footer2] [varchar](50) NULL,
	[Footer3] [varchar](50) NULL,
	[Footer4] [varchar](50) NULL,
	[TopBottomMargin] [float] NULL,
	[SideMargin] [float] NULL,
	[SideFactor] [float] NULL,
	[H1FontSize] [int] NULL,
	[H2FontSize] [int] NULL,
	[HFontSize] [int] NULL,
	[BodyFontSize] [int] NULL,
	[BodyHeaderFontSize] [int] NULL,
	[FooterFontSize] [int] NULL,
	[FontName] [int] NOT NULL,
	[HeaderPadding] [int] NULL,
	[BodyHeaderPadding] [int] NULL,
	[BodyPadding] [int] NULL,
	[FooterPadding] [int] NULL,
	[bodyheadermargin] [int] NULL,
 CONSTRAINT [PK_Table_1] PRIMARY KEY CLUSTERED 
(
	[TemplateID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_LandScape]  DEFAULT ((0)) FOR [LandScape]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_IsIconNeeded]  DEFAULT ((1)) FOR [IsIconNeeded]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FooterTableCol1]  DEFAULT ('ACTIVITY') FOR [FooterTableCol1]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FooterTableCol2]  DEFAULT ('NAME') FOR [FooterTableCol2]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FooterTableCol3]  DEFAULT ('SIGNATURE AND DATE') FOR [FooterTableCol3]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_Footer1]  DEFAULT ('REVIEWED BY USER') FOR [Footer1]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_Footer2]  DEFAULT ('REVIEWED BY QA') FOR [Footer2]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_TopBottomMargin]  DEFAULT ((30)) FOR [TopBottomMargin]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_SideMargin]  DEFAULT ((40)) FOR [SideMargin]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_H1FontSize]  DEFAULT ((14)) FOR [H1FontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_H2FontSize]  DEFAULT ((13)) FOR [H2FontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_HFontSize]  DEFAULT ((12)) FOR [HFontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_BodyFontSize]  DEFAULT ((9)) FOR [BodyFontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_BodyHeaderFontSize]  DEFAULT ((10)) FOR [BodyHeaderFontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FooterFontSize]  DEFAULT ((10)) FOR [FooterFontSize]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FontName]  DEFAULT ((2)) FOR [FontName]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_HeaderPadding]  DEFAULT ((6)) FOR [HeaderPadding]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_BodyHeaderPadding]  DEFAULT ((2)) FOR [BodyHeaderPadding]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_BodyPadding]  DEFAULT ((1)) FOR [BodyPadding]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_Table_1_FooterPadding]  DEFAULT ((3)) FOR [FooterPadding]
ALTER TABLE [dbo].[TBL_ReportTemplates] ADD  CONSTRAINT [DF_TBL_ReportTemplates_bodyheadermargin]  DEFAULT ((0)) FOR [bodyheadermargin]
END
GO
IF (Select count(*) from tbl_ReportTemplates)=0
BEGIN
SET IDENTITY_INSERT TBL_ReportTemplates ON
INSERT [dbo].[TBL_ReportTemplates] ([TemplateID], [TemplateName], [LandScape], [IsIconNeeded], [FooterTableCol1], [FooterTableCol2], [FooterTableCol3], [Footer1], [Footer2], [Footer3], [Footer4], [TopBottomMargin], [SideMargin], [SideFactor], [H1FontSize], [H2FontSize], [HFontSize], [BodyFontSize], [BodyHeaderFontSize], [FooterFontSize], [FontName], [HeaderPadding], [BodyHeaderPadding], [BodyPadding], [FooterPadding], [bodyheadermargin]) VALUES (1, N'ProtraitWiderMargin', 0, 1, N'ACTIVITY', N'NAME', N'SIGNATURE AND DATE', N'REVIEWED BY USER', N'REVIEWED BY QA', N'', N'', 30, 40, 79.9, 14, 13, 12, 9, 10, 11, 2, 6, 5, 3, 3, 0)
INSERT [dbo].[TBL_ReportTemplates] ([TemplateID], [TemplateName], [LandScape], [IsIconNeeded], [FooterTableCol1], [FooterTableCol2], [FooterTableCol3], [Footer1], [Footer2], [Footer3], [Footer4], [TopBottomMargin], [SideMargin], [SideFactor], [H1FontSize], [H2FontSize], [HFontSize], [BodyFontSize], [BodyHeaderFontSize], [FooterFontSize], [FontName], [HeaderPadding], [BodyHeaderPadding], [BodyPadding], [FooterPadding], [bodyheadermargin]) VALUES (2, N'LandScapeWiderMargin', 1, 1, N'ACTIVITY', N'NAME', N'SIGNATURE AND DATE', N'REVIEWED BY USER', N'REVIEWED BY QA', N'', N'', 30, 40, 85.7, 14, 13, 12, 9, 10, 11, 2, 6, 5, 3, 3, 0)
INSERT [dbo].[TBL_ReportTemplates] ([TemplateID], [TemplateName], [LandScape], [IsIconNeeded], [FooterTableCol1], [FooterTableCol2], [FooterTableCol3], [Footer1], [Footer2], [Footer3], [Footer4], [TopBottomMargin], [SideMargin], [SideFactor], [H1FontSize], [H2FontSize], [HFontSize], [BodyFontSize], [BodyHeaderFontSize], [FooterFontSize], [FontName], [HeaderPadding], [BodyHeaderPadding], [BodyPadding], [FooterPadding], [bodyheadermargin]) VALUES (3, N'ProtraitNarrowMargin', 0, 1, N'ACTIVITY', N'NAME', N'SIGNATURE AND DATE', N'REVIEWED BY USER', N'REVIEWED BY QA', N'', N'', 15, 15, 92.5, 14, 13, 12, 9, 10, 11, 2, 6, 5, 3, 3, 0)
INSERT [dbo].[TBL_ReportTemplates] ([TemplateID], [TemplateName], [LandScape], [IsIconNeeded], [FooterTableCol1], [FooterTableCol2], [FooterTableCol3], [Footer1], [Footer2], [Footer3], [Footer4], [TopBottomMargin], [SideMargin], [SideFactor], [H1FontSize], [H2FontSize], [HFontSize], [BodyFontSize], [BodyHeaderFontSize], [FooterFontSize], [FontName], [HeaderPadding], [BodyHeaderPadding], [BodyPadding], [FooterPadding], [bodyheadermargin]) VALUES (4, N'LandScapeNarrowMargin', 1, 1, N'ACTIVITY', N'NAME', N'SIGNATURE AND DATE', N'REVIEWED BY USER', N'REVIEWED BY QA', N'', N'', 15, 15, 94.7, 14, 13, 12, 9, 10, 11, 2, 6, 5, 3, 3, 0)
INSERT [dbo].[TBL_ReportTemplates] ([TemplateID], [TemplateName], [LandScape], [IsIconNeeded], [FooterTableCol1], [FooterTableCol2], [FooterTableCol3], [Footer1], [Footer2], [Footer3], [Footer4], [TopBottomMargin], [SideMargin], [SideFactor], [H1FontSize], [H2FontSize], [HFontSize], [BodyFontSize], [BodyHeaderFontSize], [FooterFontSize], [FontName], [HeaderPadding], [BodyHeaderPadding], [BodyPadding], [FooterPadding], [bodyheadermargin]) VALUES (5, N'TestSample', 1, 1, N'FooterTableCol1', N'FooterTableCol2', N'FooterTableCol3', N'Footer1', N'Footer2', N'Footer3', N'Footer4', 30, 40, 85.7, 14, 13, 12, 9, 10, 11, 2, 6, 5, 3, 3, -3)
SET IDENTITY_INSERT TBL_ReportTemplates OFF
END
GO
