USE [Crexta]
GO
/****** Object:  User [kaddet]    Script Date: 06/02/2011 00:14:19 ******/
CREATE USER [kaddet] FOR LOGIN [kaddet] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  User [crexta]    Script Date: 06/02/2011 00:14:19 ******/
CREATE USER [crexta] FOR LOGIN [crexta] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[APPLOGS]    Script Date: 06/02/2011 00:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[APPLOGS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) NOT NULL,
	[Level] [varchar](50) NOT NULL,
	[Logger] [varchar](255) NOT NULL,
	[Message] [varchar](4000) NOT NULL,
	[Exception] [varchar](2000) NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[VERSIONS]    Script Date: 06/02/2011 00:14:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VERSIONS](
	[Id] [int] NOT NULL,
	[Name] [varchar](16) NOT NULL,
	[Version] [varchar](16) NOT NULL,
 CONSTRAINT [PK_TBL_VERSION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE FUNCTION [dbo].[Split]
(
	@RowData nvarchar(2000),
	@SplitOn nvarchar(5)
)  
RETURNS @RtnValue table 
(
	Id int identity(1,1),
	Data nvarchar(100)
) 
AS  
BEGIN 
	Declare @Cnt int
	Set @Cnt = 1

	While (Charindex(@SplitOn,@RowData)>0)
	Begin
		Insert Into @RtnValue (data)
		Select 
			Data = ltrim(rtrim(Substring(@RowData,1,Charindex(@SplitOn,@RowData)-1)))

		Set @RowData = Substring(@RowData,Charindex(@SplitOn,@RowData)+1,len(@RowData))
		Set @Cnt = @Cnt + 1
	End
	
	Insert Into @RtnValue (data)
	Select Data = ltrim(rtrim(@RowData))

	Return
END
GO
/****** Object:  Table [dbo].[SEQUENCE]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SEQUENCE](
	[Type] [int] NOT NULL,
	[SubType] [int] NOT NULL,
	[Value] [int] NOT NULL,
 CONSTRAINT [PK_TBL_SEQUENCE_1] PRIMARY KEY CLUSTERED 
(
	[Type] ASC,
	[SubType] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RULES]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RULES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[Path] [varchar](256) NULL,
	[Data] [varbinary](max) NULL,
	[Date] [datetime] NULL,
	[IsLocked] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_RULES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CREXTOR_EXTENDED]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREXTOR_EXTENDED](
	[CrextorId] [int] NOT NULL,
	[ExtraDomains] [varchar](512) NULL,
	[SkipUrls] [varchar](512) NULL,
	[LogoPath] [varchar](256) NOT NULL,
 CONSTRAINT [PK_STORES_EXTENDED] PRIMARY KEY CLUSTERED 
(
	[CrextorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Code] [varchar](3) NOT NULL,
 CONSTRAINT [PK_TBL_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Desc] [varchar](128) NULL,
	[Tags] [varchar](128) NULL,
	[Flags] [smallint] NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_CATEGORIES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[BRANDS]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BRANDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Desc] [varchar](128) NULL,
	[Tags] [varchar](128) NULL,
	[Flags] [smallint] NULL,
	[LogoPath] [varchar](256) NULL,
 CONSTRAINT [PK_TBL_BRANDS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[LOGS]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[LOGS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Type] [int] NOT NULL,
	[SubType] [int] NULL,
	[RefId] [int] NULL,
	[Instance] [varchar](64) NOT NULL,
	[Machine] [varchar](64) NULL,
	[ExternalIp] [varchar](15) NULL,
	[LocalIp] [varchar](15) NULL,
	[Action] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[XField1] [varchar](64) NULL,
	[XField2] [varchar](64) NULL,
	[XField3] [varchar](64) NULL,
 CONSTRAINT [PK_TBL_LOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[KEYWORDS]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KEYWORDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [varchar](32) NOT NULL,
 CONSTRAINT [PK_TBL_KEYWORDS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DOWNLOADS]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DOWNLOADS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ViaWeb] [int] NOT NULL,
	[ViaService] [int] NOT NULL,
	[ClientId] [int] NULL,
	[Ip] [varchar](15) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_DOWNLOADS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RESOURCE_TYPES]    Script Date: 06/02/2011 00:14:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESOURCE_TYPES](
	[Id] [smallint] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Desc] [varchar](256) NULL,
 CONSTRAINT [PK_RESOURCE_TYPES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[LOGS_LogAction]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[LOGS_LogAction]
@Type int,
@SubType int,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64),
@Action int

AS

BEGIN TRAN

	INSERT INTO LOGS([Type],[SubType],[RefId],[Instance],[Machine],[ExternalIp],[LocalIp],[Action],[Date])
	VALUES(@Type, ISNULL(@SubType,0), @Refid, @Instance, @Machine, @ExternalIp, @LocalIp, @Action, GETDATE())

	IF @@ERROR<>0
		ROLLBACK TRAN
	ELSE
		COMMIT TRAN
GO
/****** Object:  Table [dbo].[CREXTORS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREXTORS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NULL,
	[CountryId] [int] NOT NULL,
	[ShortName] [varchar](32) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Tags] [varchar](64) NULL,
	[Url] [varchar](320) NOT NULL,
	[TotalProducts] [int] NULL,
	[LastCrawlStart] [datetime] NULL,
	[LastCrawlFinish] [datetime] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsCrawled] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[UseResources] [bit] NOT NULL,
	[Rating] [float] NOT NULL,
	[TotalVotes] [int] NOT NULL,
 CONSTRAINT [PK_TBL_STORES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CLIENTS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CLIENTS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[UniqueHash] [bigint] NOT NULL,
	[Guid] [varchar](64) NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[ExternalIp] [varchar](15) NOT NULL,
	[LocalIp] [varchar](15) NOT NULL,
	[Mac] [varchar](32) NOT NULL,
	[Instance] [smallint] NOT NULL,
	[CurrentMode] [tinyint] NOT NULL,
	[ItemCount] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[ServerId] [int] NOT NULL,
	[UselocalId] [bit] NOT NULL,
	[IsConnected] [bit] NOT NULL,
 CONSTRAINT [PK_TBL_CLIENTS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CITY]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CITY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[Tags] [varchar](128) NULL,
 CONSTRAINT [PK_TBL_CITY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_TBL_CITY] ON [dbo].[CITY] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TBL_CITY_1] ON [dbo].[CITY] 
(
	[Tags] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[CATEGORY_KEYWORDS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[CATEGORY_KEYWORDS](
	[CategoryId] [int] NOT NULL,
	[KwId] [int] NOT NULL,
	[Factor] [float] NOT NULL,
 CONSTRAINT [PK_TBL_CATEGORY_KEYWORDS] PRIMARY KEY CLUSTERED 
(
	[CategoryId] ASC,
	[KwId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[BRAND_KEYWORDS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[BRAND_KEYWORDS](
	[BrandId] [int] NOT NULL,
	[KwId] [int] NOT NULL,
	[Factor] [float] NOT NULL,
 CONSTRAINT [PK_TBL_BRANDKEYWORDS] PRIMARY KEY CLUSTERED 
(
	[BrandId] ASC,
	[KwId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RULE_BACKUPS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RULE_BACKUPS](
	[RuleId] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[Name] [varchar](128) NOT NULL,
	[Data] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_RULE_BACKUPS] PRIMARY KEY CLUSTERED 
(
	[RuleId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[SERVERS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[SERVERS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[UniqueHash] [bigint] NOT NULL,
	[Name] [varchar](32) NOT NULL,
	[ComputerName] [varchar](64) NOT NULL,
	[ExternalIp] [varchar](15) NOT NULL,
	[LocalIp] [varchar](15) NOT NULL,
	[Mac] [varchar](32) NOT NULL,
	[Instance] [smallint] NOT NULL,
	[Socket] [int] NOT NULL,
	[ClientCount] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_SERVERS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[SEQUENCE_GetPageIndex]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date, ,>
-- Description:	<Description, ,>
-- =============================================
CREATE FUNCTION [dbo].[SEQUENCE_GetPageIndex]
(
@Type int,
@SubType int = 0,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)
)
RETURNS int
AS
BEGIN

		DECLARE @PageIndex int

		SET @PageIndex = 0

		--Get current page index
		SELECT @PageIndex=[Value] 
		FROM [dbo].[SEQUENCE] WITH(HOLDLOCK)
		WHERE [Type] = @Type AND [SubType]=@SubType

		--Log action
		--EXEC LOGS_LogAction @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine, 1

		RETURN @PageIndex
END
GO
/****** Object:  Table [dbo].[URLQUEUE]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[URLQUEUE](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CrextorId] [int] NOT NULL,
	[ServerId] [int] NOT NULL,
	[ClientId] [int] NOT NULL,
	[UrlHash] [bigint] NOT NULL,
	[UrlHash1] [varchar](64) NOT NULL,
	[Url] [varchar](512) NOT NULL,
	[UrlMiniPart] [varchar](8) NULL,
	[RetryCount] [int] NOT NULL,
	[CrawlStart] [datetime] NULL,
	[CrawlFinish] [datetime] NULL,
	[LastUpdate] [datetime] NOT NULL,
	[IsCrawled] [bit] NOT NULL,
	[Priority] [float] NOT NULL,
 CONSTRAINT [PK_TBL_QUEUE] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
CREATE NONCLUSTERED INDEX [IX_TBL_URLQUEUE] ON [dbo].[URLQUEUE] 
(
	[UrlMiniPart] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_TBL_URLQUEUE_1] ON [dbo].[URLQUEUE] 
(
	[UrlHash] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
CREATE NONCLUSTERED INDEX [IX_URLQUEUE] ON [dbo].[URLQUEUE] 
(
	[UrlHash1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
/****** Object:  StoredProcedure [dbo].[SEQUENCE_SetPageIndex]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEQUENCE_SetPageIndex]
@Type int,
@SubType int = 0,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)

AS

BEGIN
	
	SET XACT_ABORT OFF;
	BEGIN TRAN

		--Get current page index
		UPDATE [dbo].[SEQUENCE] WITH(HOLDLOCK)
		SET [Value] = [Value] + 1
		WHERE [Type]=@Type AND [SubType]=@SubType

		--Log action
		EXEC LOGS_LogAction @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine, 2

		IF @@ERROR<>0
			ROLLBACK TRAN
		ELSE
			COMMIT TRAN

END
GO
/****** Object:  StoredProcedure [dbo].[SEQUENCE_ResetPageIndex]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[SEQUENCE_ResetPageIndex]
@Type int,
@SubType int = 0,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)

AS

BEGIN

	SET XACT_ABORT OFF;
	BEGIN TRAN

		--Get current page index
		UPDATE [dbo].[SEQUENCE] WITH(HOLDLOCK)
		SET [Value] = 1
		WHERE [Type]=@Type AND [SubType]=@SubType

		--Log action
		EXEC LOGS_LogAction @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine, 4

		IF @@ERROR<>0
			ROLLBACK TRAN
		ELSE
			COMMIT TRAN

END
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COMPANY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CityId] [int] NULL,
	[CountryId] [int] NULL,
	[Name] [varchar](64) NOT NULL,
	[Address1] [varchar](128) NOT NULL,
	[Address2] [varchar](128) NULL,
	[State] [varchar](32) NULL,
	[Phone] [varchar](15) NOT NULL,
	[Fax] [varchar](15) NOT NULL,
	[Ip] [varchar](15) NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CREXTOR_RESOURCES]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREXTOR_RESOURCES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CrextorId] [int] NOT NULL,
	[CategoryId] [int] NULL,
	[TypeId] [smallint] NOT NULL,
	[Name] [varchar](64) NOT NULL,
	[Url] [varchar](320) NOT NULL,
	[Order] [smallint] NOT NULL,
 CONSTRAINT [PK_STORE_RESOURCES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[DB_MAPPINGS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DB_MAPPINGS](
	[CompanyId] [int] NOT NULL,
	[FieldName] [varchar](64) NOT NULL,
	[FieldType] [varchar](32) NOT NULL,
 CONSTRAINT [PK_DB_MAPPINGS] PRIMARY KEY CLUSTERED 
(
	[CompanyId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetPageIndex]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREXTORS_GetPageIndex]
@PageSize int,
@Type int = 1,
@SubType int = 1,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)

AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRAN

		DECLARE @PageIndex int
		DECLARE @TotalCount int

		SET @PageIndex = -1

		--Get current page index
		EXEC @PageIndex = SEQUENCE_GetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine

		--Get total objects
		SELECT @TotalCount = Count([Id])
		FROM CREXTORS WITH(UPDLOCK)
		WHERE [IsActive] = 1

		IF ((@PageIndex - 1) * @PageSize + 1>@TotalCount)
		BEGIN
			--Reset page index
			EXEC SEQUENCE_ResetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine

			SET @PageIndex = 1
		END

		--increment page index
		IF @PageIndex>=0
			EXEC SEQUENCE_SetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine		

		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRAN
			
			RETURN 0
		END
		ELSE
		BEGIN
			COMMIT TRAN
			
			RETURN @PageIndex
		END
END
GO
/****** Object:  Table [dbo].[RESULTS]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESULTS](
	[CompanyId] [int] NOT NULL,
	[QueueId] [int] NOT NULL,
	[Result] [xml] NOT NULL,
	[ErrorCode] [varchar](10) NULL,
	[ErrorText] [varchar](512) NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_RESULTS] PRIMARY KEY CLUSTERED 
(
	[QueueId] ASC,
	[Date] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetPageIndex]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[URLQUEUE_GetPageIndex]
@PageSize int,
@Type int,
@SubType int,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)


AS

BEGIN

	SET NOCOUNT ON;

	BEGIN TRAN

		DECLARE @PageIndex int
		DECLARE @TotalCount int

		SET @PageIndex = -1

		--Get current page index
		EXEC @PageIndex = SEQUENCE_GetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine

		--Get total objects
		SELECT @TotalCount = Count([Id])
		FROM URLQUEUE WITH(UPDLOCK)
		WHERE ([IsCrawled] = 0 OR (DATEDIFF(hh, [CrawlFinish], GETDATE())>1))

		IF ((@PageIndex - 1) * @PageSize + 1>@TotalCount)
		BEGIN
			--Reset page index
			EXEC SEQUENCE_ResetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine

			SET @PageIndex = 1			
		END
		
		--increment page index
		IF @PageIndex>=0
			EXEC SEQUENCE_SetPageIndex @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine		

		IF @@ERROR<>0
		BEGIN
			ROLLBACK TRAN
			
			RETURN 0
		END
		ELSE
		BEGIN
			COMMIT TRAN
			
			RETURN @PageIndex
		END
END
GO
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetDataset]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[URLQUEUE_GetDataset]
@PageSize int,
@Type int,
@SubType int,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)

AS

BEGIN

	SET NOCOUNT ON;
	
	DECLARE @PageIndex int
	
	--Get current page index
	EXEC @PageIndex = URLQUEUE_GetPageIndex @PageSize, @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine

	IF @PageIndex=0
		SET @PageIndex = 1

	SELECT  [Id], [CrextorId], [Url]
	FROM     ( SELECT  ROW_NUMBER() OVER (ORDER BY [Id])
				 AS Row, [Id], [CrextorId], [url] FROM URLQUEUE WITH(HOLDLOCK)
				 WHERE ([IsCrawled] = 0 OR (DATEDIFF(hh, [CrawlFinish], GETDATE())>1)) )
				 AS UrlQueuesWithRowNumber
	WHERE  Row BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex*@PageSize

END
GO
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetDataset]    Script Date: 06/02/2011 00:14:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[CREXTORS_GetDataset]
@PageSize int,
@Type int,
@SubType int,
@Refid int,
@Instance varchar(64),
@ExternalIp varchar(15),
@LocalIp varchar(15),
@Machine varchar(64)

AS

BEGIN

	SET NOCOUNT ON;
	
	DECLARE @PageIndex int
	
	--Get current page index
	EXEC @PageIndex = CREXTORS_GetPageIndex @PageSize, @Type, @SubType, @Refid, @Instance, @ExternalIp, @LocalIp, @Machine
	
	IF @PageIndex=0
		SET @PageIndex = 1

	SELECT  [Id], [Name]
	FROM     (SELECT  ROW_NUMBER() OVER (ORDER BY [Id])
				 AS Row, [Id], [Name] FROM CREXTORS WITH(HOLDLOCK)
				 WHERE [IsActive] = 1 AND [IsCrawled] = 0 AND (DATEDIFF(hh, [LastCrawlFinish], GETDATE())>1 OR [LastCrawlFinish] IS NULL))
				 AS StoresWithRowNumber
	WHERE  Row BETWEEN (@PageIndex - 1) * @PageSize + 1 AND @PageIndex*@PageSize

END
GO
/****** Object:  Default [DF_TBL_SEQUENCE_value]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[SEQUENCE] ADD  CONSTRAINT [DF_TBL_SEQUENCE_value]  DEFAULT ((0)) FOR [Value]
GO
/****** Object:  Default [DF_TBL_RULES_date]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[RULES] ADD  CONSTRAINT [DF_TBL_RULES_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_RULES_locked]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[RULES] ADD  CONSTRAINT [DF_RULES_locked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_parentid]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_parentid]  DEFAULT ((-1)) FOR [ParentId]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_flags]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_flags]  DEFAULT ((0)) FOR [Flags]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_isactive]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_isactive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_TBL_BRANDS_flags]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[BRANDS] ADD  CONSTRAINT [DF_TBL_BRANDS_flags]  DEFAULT ((0)) FOR [Flags]
GO
/****** Object:  Default [DF_TBL_LOG_subtype]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_subtype]  DEFAULT ((0)) FOR [SubType]
GO
/****** Object:  Default [DF_TBL_LOG_refid]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_refid]  DEFAULT ((-1)) FOR [RefId]
GO
/****** Object:  Default [DF_TBL_LOG_date]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_dataextractor]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_dataextractor]  DEFAULT ((0)) FOR [ViaWeb]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_urlfounder]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_urlfounder]  DEFAULT ((0)) FOR [ViaService]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_date]    Script Date: 06/02/2011 00:14:24 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_STORES_countryid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_countryid]  DEFAULT ((1)) FOR [CountryId]
GO
/****** Object:  Default [DF_TBL_STORES_ispaid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_ispaid]  DEFAULT ((0)) FOR [IsPaid]
GO
/****** Object:  Default [DF_TBL_STORES_iscrawled]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_iscrawled]  DEFAULT ((0)) FOR [IsCrawled]
GO
/****** Object:  Default [DF_TBL_STORES_isactive]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_isactive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_STORES_useresources]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_STORES_useresources]  DEFAULT ((0)) FOR [UseResources]
GO
/****** Object:  Default [DF_TBL_STORES_rank]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_rank]  DEFAULT ((0)) FOR [Rating]
GO
/****** Object:  Default [DF_TBL_STORES_totalvotes]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_totalvotes]  DEFAULT ((0)) FOR [TotalVotes]
GO
/****** Object:  Default [DF_TBL_CLIENTS_countryid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_countryid]  DEFAULT ((1)) FOR [CountryId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_instance]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_instance]  DEFAULT ((1)) FOR [Instance]
GO
/****** Object:  Default [DF_TBL_CLIENTS_itemcount]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_itemcount]  DEFAULT ((0)) FOR [ItemCount]
GO
/****** Object:  Default [DF_TBL_CLIENTS_serverid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_serverid]  DEFAULT ((0)) FOR [ServerId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_preferlocalid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_preferlocalid]  DEFAULT ((0)) FOR [UselocalId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_isconnected]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_isconnected]  DEFAULT ((0)) FOR [IsConnected]
GO
/****** Object:  Default [DF_TBL_CATEGORY_KEYWORDS_factor]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] ADD  CONSTRAINT [DF_TBL_CATEGORY_KEYWORDS_factor]  DEFAULT ((0)) FOR [Factor]
GO
/****** Object:  Default [DF_TBL_BRANDKEYWORDS_factor]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS] ADD  CONSTRAINT [DF_TBL_BRANDKEYWORDS_factor]  DEFAULT ((0)) FOR [Factor]
GO
/****** Object:  Default [DF_RULE_BACKUPS_date]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RULE_BACKUPS] ADD  CONSTRAINT [DF_RULE_BACKUPS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_SERVERS_countryid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_countryid]  DEFAULT ((1)) FOR [CountryId]
GO
/****** Object:  Default [DF_TBL_SERVERS_instance]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_instance]  DEFAULT ((1)) FOR [Instance]
GO
/****** Object:  Default [DF_TBL_SERVERS_clientcount]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_clientcount]  DEFAULT ((0)) FOR [ClientCount]
GO
/****** Object:  Default [DF_TBL_SERVERS_active]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_active]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_TBL_SERVERS_date]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_serverid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_serverid]  DEFAULT ((-1)) FOR [ServerId]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_clientid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_clientid]  DEFAULT ((-1)) FOR [ClientId]
GO
/****** Object:  Default [DF_TBL_QUEUE_hash]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_QUEUE_hash]  DEFAULT ((-1)) FOR [UrlHash]
GO
/****** Object:  Default [DF_URLQUEUE_RetryCount]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_URLQUEUE_RetryCount]  DEFAULT ((0)) FOR [RetryCount]
GO
/****** Object:  Default [DF_TBL_QUEUE_iscrawled]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_QUEUE_iscrawled]  DEFAULT ((0)) FOR [IsCrawled]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_priority]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_priority]  DEFAULT ((0)) FOR [Priority]
GO
/****** Object:  Default [DF_COMPANY_CityId]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[COMPANY] ADD  CONSTRAINT [DF_COMPANY_CityId]  DEFAULT ((-1)) FOR [CityId]
GO
/****** Object:  Default [DF_COMPANY_CountryId]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[COMPANY] ADD  CONSTRAINT [DF_COMPANY_CountryId]  DEFAULT ((-1)) FOR [CountryId]
GO
/****** Object:  Default [DF_STORE_RESOURCES_categoryid]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_categoryid]  DEFAULT ((-1)) FOR [CategoryId]
GO
/****** Object:  Default [DF_STORE_RESOURCES_period]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_period]  DEFAULT ((5)) FOR [Url]
GO
/****** Object:  Default [DF_STORE_RESOURCES_order]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_order]  DEFAULT ((0)) FOR [Order]
GO
/****** Object:  Default [DF_TBL_RESULTS_CompanyId]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_CompanyId]  DEFAULT ((-1)) FOR [CompanyId]
GO
/****** Object:  Default [DF_TBL_RESULTS_ErrorCode]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_ErrorCode]  DEFAULT ((0)) FOR [ErrorCode]
GO
/****** Object:  Default [DF_TBL_RESULTS_ErrorText]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_ErrorText]  DEFAULT ('') FOR [ErrorText]
GO
/****** Object:  Default [DF_TBL_RESULTS_Date]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  ForeignKey [FK_STORES_RULES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH NOCHECK ADD  CONSTRAINT [FK_STORES_RULES] FOREIGN KEY([RuleId])
REFERENCES [dbo].[RULES] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTORS] NOCHECK CONSTRAINT [FK_STORES_RULES]
GO
/****** Object:  ForeignKey [FK_STORES_STORE_EXTENDED]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH NOCHECK ADD  CONSTRAINT [FK_STORES_STORE_EXTENDED] FOREIGN KEY([Id])
REFERENCES [dbo].[CREXTOR_EXTENDED] ([CrextorId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTORS] NOCHECK CONSTRAINT [FK_STORES_STORE_EXTENDED]
GO
/****** Object:  ForeignKey [FK_TBL_STORES_TBL_COUNTRY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_STORES_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CREXTORS] CHECK CONSTRAINT [FK_TBL_STORES_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_CLIENTS_TBL_COUNTRY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CLIENTS_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CLIENTS] CHECK CONSTRAINT [FK_TBL_CLIENTS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_CITY_TBL_COUNTRY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CITY]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CITY_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CITY] CHECK CONSTRAINT [FK_TBL_CITY_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([Id])
GO
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] CHECK CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS] FOREIGN KEY([KwId])
REFERENCES [dbo].[KEYWORDS] ([Id])
GO
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] CHECK CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_BRANDS] FOREIGN KEY([BrandId])
REFERENCES [dbo].[BRANDS] ([Id])
GO
ALTER TABLE [dbo].[BRAND_KEYWORDS] CHECK CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS] FOREIGN KEY([KwId])
REFERENCES [dbo].[KEYWORDS] ([Id])
GO
ALTER TABLE [dbo].[BRAND_KEYWORDS] CHECK CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_RULE_BACKUPS_RULES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RULE_BACKUPS]  WITH CHECK ADD  CONSTRAINT [FK_RULE_BACKUPS_RULES] FOREIGN KEY([RuleId])
REFERENCES [dbo].[RULES] ([Id])
GO
ALTER TABLE [dbo].[RULE_BACKUPS] CHECK CONSTRAINT [FK_RULE_BACKUPS_RULES]
GO
/****** Object:  ForeignKey [FK_TBL_SERVERS_TBL_COUNTRY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[SERVERS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_SERVERS_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[SERVERS] CHECK CONSTRAINT [FK_TBL_SERVERS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_QUEUE_TBL_STORES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_QUEUE_TBL_STORES] FOREIGN KEY([CrextorId])
REFERENCES [dbo].[CREXTORS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_QUEUE_TBL_STORES]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_CLIENTS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_URLQUEUE_TBL_CLIENTS] FOREIGN KEY([ClientId])
REFERENCES [dbo].[CLIENTS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_URLQUEUE_TBL_CLIENTS]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_SERVERS]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_URLQUEUE_TBL_SERVERS] FOREIGN KEY([ServerId])
REFERENCES [dbo].[SERVERS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_URLQUEUE_TBL_SERVERS]
GO
/****** Object:  ForeignKey [FK_COMPANY_CITY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[COMPANY]  WITH NOCHECK ADD  CONSTRAINT [FK_COMPANY_CITY] FOREIGN KEY([CityId])
REFERENCES [dbo].[CITY] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[COMPANY] NOCHECK CONSTRAINT [FK_COMPANY_CITY]
GO
/****** Object:  ForeignKey [FK_COMPANY_COUNTRY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[COMPANY]  WITH NOCHECK ADD  CONSTRAINT [FK_COMPANY_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[COMPANY] NOCHECK CONSTRAINT [FK_COMPANY_COUNTRY]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_CATEGORIES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH NOCHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_CATEGORIES] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] NOCHECK CONSTRAINT [FK_STORE_RESOURCES_CATEGORIES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_RESOURCE_TYPES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_RESOURCE_TYPES] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RESOURCE_TYPES] ([Id])
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] CHECK CONSTRAINT [FK_STORE_RESOURCES_RESOURCE_TYPES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_STORES]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_STORES] FOREIGN KEY([CrextorId])
REFERENCES [dbo].[CREXTORS] ([Id])
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] CHECK CONSTRAINT [FK_STORE_RESOURCES_STORES]
GO
/****** Object:  ForeignKey [FK_DB_MAPPINGS_COMPANY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[DB_MAPPINGS]  WITH CHECK ADD  CONSTRAINT [FK_DB_MAPPINGS_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[DB_MAPPINGS] CHECK CONSTRAINT [FK_DB_MAPPINGS_COMPANY]
GO
/****** Object:  ForeignKey [FK_RESULTS_COMPANY]    Script Date: 06/02/2011 00:14:28 ******/
ALTER TABLE [dbo].[RESULTS]  WITH CHECK ADD  CONSTRAINT [FK_RESULTS_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[RESULTS] CHECK CONSTRAINT [FK_RESULTS_COMPANY]
GO
