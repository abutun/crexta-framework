USE [Crexta]
GO
ALTER TABLE [dbo].[BRAND_KEYWORDS] DROP CONSTRAINT [DF_TBL_BRANDKEYWORDS_factor]
GO
ALTER TABLE [dbo].[BRANDS] DROP CONSTRAINT [DF_TBL_BRANDS_flags]
GO
ALTER TABLE [dbo].[CATEGORIES] DROP CONSTRAINT [DF_TBL_CATEGORIES_parentid]
GO
ALTER TABLE [dbo].[CATEGORIES] DROP CONSTRAINT [DF_TBL_CATEGORIES_flags]
GO
ALTER TABLE [dbo].[CATEGORIES] DROP CONSTRAINT [DF_TBL_CATEGORIES_isactive]
GO
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] DROP CONSTRAINT [DF_TBL_CATEGORY_KEYWORDS_factor]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_countryid]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_instance]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_itemcount]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_serverid]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_preferlocalid]
GO
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [DF_TBL_CLIENTS_isconnected]
GO
ALTER TABLE [dbo].[COMPANY] DROP CONSTRAINT [DF_COMPANY_CityId]
GO
ALTER TABLE [dbo].[COMPANY] DROP CONSTRAINT [DF_COMPANY_CountryId]
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [DF_STORE_RESOURCES_categoryid]
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [DF_STORE_RESOURCES_period]
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [DF_STORE_RESOURCES_order]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_TBL_STORES_ispaid]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_TBL_STORES_iscrawled]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_TBL_STORES_isactive]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_STORES_useresources]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_TBL_STORES_rank]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_CREXTORS_Priority]
GO
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [DF_TBL_STORES_totalvotes]
GO
ALTER TABLE [dbo].[DOWNLOADS] DROP CONSTRAINT [DF_TBL_DOWNLOADS_dataextractor]
GO
ALTER TABLE [dbo].[DOWNLOADS] DROP CONSTRAINT [DF_TBL_DOWNLOADS_urlfounder]
GO
ALTER TABLE [dbo].[DOWNLOADS] DROP CONSTRAINT [DF_TBL_DOWNLOADS_date]
GO
ALTER TABLE [dbo].[LOGS] DROP CONSTRAINT [DF_TBL_LOG_subtype]
GO
ALTER TABLE [dbo].[LOGS] DROP CONSTRAINT [DF_TBL_LOG_refid]
GO
ALTER TABLE [dbo].[LOGS] DROP CONSTRAINT [DF_TBL_LOG_date]
GO
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [DF_TBL_RESULTS_CompanyId]
GO
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [DF_TBL_RESULTS_ErrorCode]
GO
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [DF_TBL_RESULTS_ErrorText]
GO
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [DF_TBL_RESULTS_Date]
GO
ALTER TABLE [dbo].[RULE_BACKUPS] DROP CONSTRAINT [DF_RULE_BACKUPS_date]
GO
ALTER TABLE [dbo].[RULES] DROP CONSTRAINT [DF_TBL_RULES_date]
GO
ALTER TABLE [dbo].[RULES] DROP CONSTRAINT [DF_RULES_locked]
GO
ALTER TABLE [dbo].[SEQUENCE] DROP CONSTRAINT [DF_TBL_SEQUENCE_value]
GO
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [DF_TBL_SERVERS_countryid]
GO
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [DF_TBL_SERVERS_instance]
GO
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [DF_TBL_SERVERS_clientcount]
GO
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [DF_TBL_SERVERS_active]
GO
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [DF_TBL_SERVERS_date]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_TBL_URLQUEUE_serverid]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_TBL_URLQUEUE_clientid]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_TBL_QUEUE_hash]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_URLQUEUE_RetryCount]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_TBL_QUEUE_iscrawled]
GO
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [DF_TBL_URLQUEUE_priority]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS] DROP CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS] DROP CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] DROP CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] DROP CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CITY_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CITY] DROP CONSTRAINT [FK_TBL_CITY_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_CLIENTS_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] DROP CONSTRAINT [FK_TBL_CLIENTS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_COMPANY_CITY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY] DROP CONSTRAINT [FK_COMPANY_CITY]
GO
/****** Object:  ForeignKey [FK_COMPANY_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY] DROP CONSTRAINT [FK_COMPANY_COUNTRY]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_CATEGORIES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [FK_STORE_RESOURCES_CATEGORIES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_RESOURCE_TYPES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [FK_STORE_RESOURCES_RESOURCE_TYPES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_STORES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] DROP CONSTRAINT [FK_STORE_RESOURCES_STORES]
GO
/****** Object:  ForeignKey [FK_CREXTORS_COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [FK_CREXTORS_COMPANY]
GO
/****** Object:  ForeignKey [FK_CREXTORS_RULES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [FK_CREXTORS_RULES]
GO
/****** Object:  ForeignKey [FK_STORES_STORE_EXTENDED]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] DROP CONSTRAINT [FK_STORES_STORE_EXTENDED]
GO
/****** Object:  ForeignKey [FK_DB_FIELDS_COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[DB_FIELDS] DROP CONSTRAINT [FK_DB_FIELDS_COMPANY]
GO
/****** Object:  ForeignKey [FK_RESULTS_COMPANY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [FK_RESULTS_COMPANY]
GO
/****** Object:  ForeignKey [FK_RESULTS_URLQUEUE]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] DROP CONSTRAINT [FK_RESULTS_URLQUEUE]
GO
/****** Object:  ForeignKey [FK_RULE_BACKUPS_RULES]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULE_BACKUPS] DROP CONSTRAINT [FK_RULE_BACKUPS_RULES]
GO
/****** Object:  ForeignKey [FK_RULES_COMPANY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULES] DROP CONSTRAINT [FK_RULES_COMPANY]
GO
/****** Object:  ForeignKey [FK_TBL_SERVERS_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] DROP CONSTRAINT [FK_TBL_SERVERS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_QUEUE_TBL_STORES]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [FK_TBL_QUEUE_TBL_STORES]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_CLIENTS]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [FK_TBL_URLQUEUE_TBL_CLIENTS]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_SERVERS]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] DROP CONSTRAINT [FK_TBL_URLQUEUE_TBL_SERVERS]
GO
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetDataset]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[URLQUEUE_GetDataset]
GO
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[URLQUEUE_GetPageIndex]
GO
/****** Object:  Table [dbo].[RESULTS]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[RESULTS]
GO
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetDataset]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[CREXTORS_GetDataset]
GO
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[CREXTORS_GetPageIndex]
GO
/****** Object:  Table [dbo].[CREXTOR_RESOURCES]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CREXTOR_RESOURCES]
GO
/****** Object:  Table [dbo].[URLQUEUE]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[URLQUEUE]
GO
/****** Object:  Table [dbo].[RULE_BACKUPS]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[RULE_BACKUPS]
GO
/****** Object:  Table [dbo].[CREXTORS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CREXTORS]
GO
/****** Object:  Table [dbo].[DB_FIELDS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[DB_FIELDS]
GO
/****** Object:  Table [dbo].[RULES]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[RULES]
GO
/****** Object:  StoredProcedure [dbo].[SEQUENCE_ResetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[SEQUENCE_ResetPageIndex]
GO
/****** Object:  StoredProcedure [dbo].[SEQUENCE_SetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[SEQUENCE_SetPageIndex]
GO
/****** Object:  Table [dbo].[COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[COMPANY]
GO
/****** Object:  Table [dbo].[BRAND_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[BRAND_KEYWORDS]
GO
/****** Object:  Table [dbo].[CATEGORY_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CATEGORY_KEYWORDS]
GO
/****** Object:  Table [dbo].[CITY]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CITY]
GO
/****** Object:  Table [dbo].[CLIENTS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CLIENTS]
GO
/****** Object:  StoredProcedure [dbo].[LOGS_LogAction]    Script Date: 06/05/2011 22:32:35 ******/
DROP PROCEDURE [dbo].[LOGS_LogAction]
GO
/****** Object:  Table [dbo].[SERVERS]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[SERVERS]
GO
/****** Object:  UserDefinedFunction [dbo].[SEQUENCE_GetPageIndex]    Script Date: 06/05/2011 22:32:39 ******/
DROP FUNCTION [dbo].[SEQUENCE_GetPageIndex]
GO
/****** Object:  Table [dbo].[APPLOGS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[APPLOGS]
GO
/****** Object:  Table [dbo].[VERSIONS]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[VERSIONS]
GO
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 06/05/2011 22:32:39 ******/
DROP FUNCTION [dbo].[Split]
GO
/****** Object:  Table [dbo].[SEQUENCE]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[SEQUENCE]
GO
/****** Object:  Table [dbo].[RESOURCE_TYPES]    Script Date: 06/05/2011 22:32:38 ******/
DROP TABLE [dbo].[RESOURCE_TYPES]
GO
/****** Object:  Table [dbo].[DOWNLOADS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[DOWNLOADS]
GO
/****** Object:  Table [dbo].[KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[KEYWORDS]
GO
/****** Object:  Table [dbo].[LOGS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[LOGS]
GO
/****** Object:  Table [dbo].[BRANDS]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[BRANDS]
GO
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CATEGORIES]
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[COUNTRY]
GO
/****** Object:  Table [dbo].[CREXTOR_EXTENDED]    Script Date: 06/05/2011 22:32:37 ******/
DROP TABLE [dbo].[CREXTOR_EXTENDED]
GO
/****** Object:  User [crexta]    Script Date: 06/05/2011 22:32:39 ******/
DROP USER [crexta]
GO
USE [master]
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [##MS_PolicyEventProcessingLogin##]
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [##MS_PolicyTsqlExecutionLogin##]
GO
/****** Object:  Login [ACTIVEBUILDER\ahmet]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [ACTIVEBUILDER\ahmet]
GO
/****** Object:  Login [BUILTIN\Administrators]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [BUILTIN\Administrators]
GO
/****** Object:  Login [crexta]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [crexta]
GO
/****** Object:  Login [kaddet]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [kaddet]
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [NT AUTHORITY\SYSTEM]
GO
/****** Object:  Login [NT SERVICE\MSSQL$SQL2008]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [NT SERVICE\MSSQL$SQL2008]
GO
/****** Object:  Login [NT SERVICE\SQLAgent$SQL2008]    Script Date: 06/05/2011 22:32:39 ******/
DROP LOGIN [NT SERVICE\SQLAgent$SQL2008]
GO
/****** Object:  Login [##MS_PolicyEventProcessingLogin##]    Script Date: 06/05/2011 22:32:39 ******/
/* For security reasons the login is created disabled and with a random password. */
CREATE LOGIN [##MS_PolicyEventProcessingLogin##] WITH PASSWORD=N'mÚ.ÞxÎ®2Í[9|Øßl8°½~¥)2·2', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyEventProcessingLogin##] DISABLE
GO
/****** Object:  Login [##MS_PolicyTsqlExecutionLogin##]    Script Date: 06/05/2011 22:32:39 ******/
/* For security reasons the login is created disabled and with a random password. */
CREATE LOGIN [##MS_PolicyTsqlExecutionLogin##] WITH PASSWORD=N'úþ_¨½}.ÜÇd¶<¸p»«¹óàps¤Å', DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=ON
GO
ALTER LOGIN [##MS_PolicyTsqlExecutionLogin##] DISABLE
GO
/****** Object:  Login [ACTIVEBUILDER\ahmet]    Script Date: 06/05/2011 22:32:39 ******/
CREATE LOGIN [ACTIVEBUILDER\ahmet] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [BUILTIN\Administrators]    Script Date: 06/05/2011 22:32:39 ******/
CREATE LOGIN [BUILTIN\Administrators] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [crexta]    Script Date: 06/05/2011 22:32:39 ******/
/* For security reasons the login is created disabled and with a random password. */
CREATE LOGIN [crexta] WITH PASSWORD=N'a@eU·¯À9ö()UÐä§Ë¸¢¸%0÷úÂ', DEFAULT_DATABASE=[Crexta], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [crexta] DISABLE
GO
/****** Object:  Login [kaddet]    Script Date: 06/05/2011 22:32:39 ******/
/* For security reasons the login is created disabled and with a random password. */
CREATE LOGIN [kaddet] WITH PASSWORD=N'í¤C*¦i&óHµÌx1«mF+
þì°', DEFAULT_DATABASE=[Kaddet], DEFAULT_LANGUAGE=[us_english], CHECK_EXPIRATION=OFF, CHECK_POLICY=OFF
GO
ALTER LOGIN [kaddet] DISABLE
GO
/****** Object:  Login [NT AUTHORITY\SYSTEM]    Script Date: 06/05/2011 22:32:39 ******/
CREATE LOGIN [NT AUTHORITY\SYSTEM] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\MSSQL$SQL2008]    Script Date: 06/05/2011 22:32:39 ******/
CREATE LOGIN [NT SERVICE\MSSQL$SQL2008] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
/****** Object:  Login [NT SERVICE\SQLAgent$SQL2008]    Script Date: 06/05/2011 22:32:39 ******/
CREATE LOGIN [NT SERVICE\SQLAgent$SQL2008] FROM WINDOWS WITH DEFAULT_DATABASE=[master], DEFAULT_LANGUAGE=[us_english]
GO
USE [Crexta]
GO
/****** Object:  User [crexta]    Script Date: 06/05/2011 22:32:39 ******/
CREATE USER [crexta] FOR LOGIN [crexta] WITH DEFAULT_SCHEMA=[dbo]
GO
/****** Object:  Table [dbo].[CREXTOR_EXTENDED]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREXTOR_EXTENDED](
	[CrextorId] [int] NOT NULL,
	[ExtraDomains] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
	[SkipUrls] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
	[LogoPath] [varchar](256) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_STORES_EXTENDED] PRIMARY KEY CLUSTERED 
(
	[CrextorId] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[COUNTRY](
	[Id] [int] NOT NULL,
	[Name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[Code] [varchar](3) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_TBL_COUNTRY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[COUNTRY] ([Id], [Name], [Code]) VALUES (1, N'Türkiye', N'90')
/****** Object:  Table [dbo].[CATEGORIES]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CATEGORIES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NOT NULL,
	[Name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Desc] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
	[Tags] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
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
SET IDENTITY_INSERT [dbo].[CATEGORIES] ON
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (1, -1, N'Bilgisayar', N'Bilgisayar', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (2, -1, N'Kitap', N'Kitap', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (3, -1, N'Elektronik', N'Elektronik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (4, -1, N'Hediye', N'Hediye', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (5, -1, N'Bebek & Çocuk', N'Bebek & Çocuk', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (6, -1, N'Film & Müzik', N'Film & Müzik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (7, -1, N'Ayakkabi', N'Ayakkabi', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (8, -1, N'Taki & Mücevher', N'Taki & Mücevher', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (9, -1, N'Saglik & Güzellik', N'Saglik & Güzellik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (10, -1, N'Saat', N'Saat', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (11, -1, N'Spor & Fitness', N'Spor & Fitness', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (12, -1, N'Ev Tekstili', N'Ev Tekstili', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (13, -1, N'Bahçe & Hirdavat', N'Bahçe & Hirdavat', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (14, -1, N'Hobi & Oyun', N'Hobi & Oyun', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (15, -1, N'Telefon', N'Telefon', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (16, -1, N'Otomobil', N'Otomobil', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (17, -1, N'Ev & Mutfak', N'Ev & Mutfak', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (18, 1, N'Yazilim', N'Yazilim', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (19, 1, N'Donanim', N'Donanim', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (20, 1, N'Oyun', N'Oyun', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (21, 1, N'Dizistü Bilgisayar', N'Dizistü Bilgisayar', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (22, 1, N'Mini Dizüstü Bilgisayar', N'Mini Dizüstü Bilgisayar', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (23, 3, N'Kamera', N'Kamera', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (24, 3, N'Fotograf Makinasi', N'Fotograf Makinasi', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (25, 3, N'Televizyon', N'Televizyon', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (26, 3, N'MP3 Çalar', N'MP3 Çalar', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (27, 4, N'Hediyelik Esya', N'Hediyelik Esya', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (28, 4, N'Çiçek', N'Çiçek', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (29, 5, N'Bebek', N'Bebek', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (30, 5, N'Çocuk', N'Çocuk', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (31, 6, N'Film & TV', N'Film & TV', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (32, 6, N'BLue Ray', N'BLue Ray', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (33, 6, N'Müzik', N'Müzik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (34, 9, N'Kozmetik', N'Kozmetik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (35, 9, N'Kisisel Bakim', N'Kisisel Bakim', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (36, 9, N'Medikal', N'Medikal', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (37, 11, N'Fitness & Kondisyon', N'Fitness & Kondisyon', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (38, 11, N'Spor Giyim', N'Spor Giyim', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (39, 14, N'Oyun - PC', N'Oyun - PC', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (40, 14, N'Oyun - Nintendo Wii', N'Oyun - Nintendo Wii', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (41, 14, N'Oyun - Playstation 2', N'Oyun - Playstation 2', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (42, 14, N'Oyun - Playstation 3', N'Oyun - Playstation 3', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (43, 14, N'Oyun - PSP', N'Oyun - PSP', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (44, 14, N'Oyun - XBox 360', N'Oyun - XBox 360', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (45, 14, N'Oyun Konsolu', N'Oyun Konsolu', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (46, 18, N'Ofis', N'Ofis', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (47, 18, N'Güvenlik', N'Güvenlik', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (48, 18, N'Isletim Sistemi', N'Isletim Sistemi', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (49, 19, N'Anakart', N'Anakart', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (50, 19, N'Bellek', N'Bellek', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (51, 19, N'Islemci', N'Islemci', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (52, 19, N'Ekran Karti', N'Ekran Karti', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (53, 19, N'TV Karti', N'TV Karti', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (54, 19, N'Sabit Disk', N'Sabit Disk', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (55, 19, N'Ses Karti', N'Ses Karti', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (56, 19, N'Hoparlör', N'Hoparlör', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (57, 19, N'Kasa', N'Kasa', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (58, 19, N'Tarayici', N'Tarayici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (59, 19, N'Yazici', N'Yazici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (60, 19, N'Monitör', N'Monitör', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (61, 19, N'Kamera', N'Kamera', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (62, 19, N'Fare & Mouse', N'Fare & Mouse', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (63, 19, N'Klavye', N'Klavye', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (64, 19, N'DVD Okuyucu', N'DVD Okuyucu', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (65, 19, N'DVD Yazici', N'DVD Yazici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (66, 19, N'CD Okuyucu', N'CD Okuyucu', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (67, 19, N'CD Yazici', N'CD Yazici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (68, 59, N'Lazer Yazici', N'Lazer Yazici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (69, 59, N'Mürekkep Püskürtmeli', N'Mürekkep Püskürtmeli', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (70, 59, N'Nokta Vuruslu Yazici', N'Nokta Vuruslu Yazici', N'', 0, 1)
INSERT [dbo].[CATEGORIES] ([Id], [ParentId], [Name], [Desc], [Tags], [Flags], [IsActive]) VALUES (71, -1, N'Bilinmeyen', N'Bilinmeyen', NULL, 1024, 1)
SET IDENTITY_INSERT [dbo].[CATEGORIES] OFF
/****** Object:  Table [dbo].[BRANDS]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[BRANDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[Desc] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
	[Tags] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
	[Flags] [smallint] NULL,
	[LogoPath] [varchar](256) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_TBL_BRANDS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[BRANDS] ON
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (1, N'A4Tech', N'', N'A4Tech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (2, N'Acer', N'', N'Acer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (3, N'Activa', N'', N'Activa', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (4, N'Activision', N'', N'Activision', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (5, N'Acura', N'', N'Acura', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (6, N'A-Data', N'', N'A-Data', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (7, N'Adidas', N'', N'Adidas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (8, N'Adler', N'', N'Adler', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (9, N'AEG', N'', N'AEG', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (10, N'Aerocool', N'', N'Aerocool', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (11, N'Agfa', N'', N'Agfa', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (12, N'Aidata', N'', N'Aidata', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (13, N'AirOSpace', N'', N'AirOSpace', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (14, N'Airfel', N'', N'Airfel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (15, N'Airties', N'', N'Airties', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (16, N'Akasa', N'', N'Akasa', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (17, N'Akfil', N'', N'Akfil', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (18, N'Aksu', N'', N'Aksu', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (19, N'Alfacell', N'', N'Alfacell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (20, N'Alpin', N'', N'Alpin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (21, N'Alps', N'', N'Alps', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (22, N'AltecLansing', N'', N'AltecLansing', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (23, N'Altinbasak', N'', N'Altinbasak', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (24, N'Altis', N'', N'Altis', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (25, N'Altus', N'', N'Altus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (26, N'AMD', N'', N'AMD', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (27, N'Ameda', N'', N'Ameda', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (28, N'Annovi Reverberi', N'', N'Annovi Reverberi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (29, N'Anycool', N'', N'Anycool', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (30, N'AOC', N'', N'AOC', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (31, N'Aopen', N'', N'Aopen', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (32, N'APC', N'', N'APC', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (33, N'Apple', N'', N'Apple', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (34, N'Aran', N'', N'Aran', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (35, N'Archos', N'', N'Archos', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (36, N'Arçelik', N'', N'Arçelik', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (37, N'Arex', N'', N'Arex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (38, N'Ariston', N'', N'Ariston', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (39, N'Arnica', N'', N'Arnica', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (40, N'Arzum', N'', N'Arzum', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (41, N'Aselsan', N'', N'Aselsan', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (42, N'Asus', N'', N'Asus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (43, N'Atari', N'', N'Atari', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (44, N'Atlanta', N'', N'Atlanta', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (45, N'Attlas', N'', N'Attlas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (46, N'Auer', N'', N'Auer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (47, N'Ave', N'', N'Ave', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (48, N'Avent', N'', N'Avent', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (49, N'Avermedia', N'', N'Avermedia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (50, N'Axle', N'', N'Axle', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (51, N'Aytunç', N'', N'Aytunç', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (52, N'Aztech', N'', N'Aztech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (53, N'Baby 2 Go', N'', N'Baby 2 Go', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (54, N'BabyBjörn', N'', N'BabyBjörn', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (55, N'Babyhope', N'', N'Babyhope', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (56, N'Babyliss', N'', N'Babyliss', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (57, N'Baymak', N'', N'Baymak', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (58, N'Bebedor', N'', N'Bebedor', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (59, N'BebeSounds', N'', N'BebeSounds', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (60, N'Bebiccio', N'', N'Bebiccio', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (61, N'Beko', N'', N'Beko', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (62, N'BenQ', N'', N'BenQ', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (63, N'BenQ Siemens', N'', N'BenQ Siemens', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (64, N'Besttel', N'', N'Besttel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (65, N'Bestway', N'', N'Bestway', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (66, N'Besiktas', N'', N'Besiktas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (67, N'Beurer', N'', N'Beurer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (68, N'BFG', N'', N'BFG', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (69, N'Bianchi', N'', N'Bianchi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (70, N'Bigboy', N'', N'Bigboy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (71, N'Bigtop', N'', N'Bigtop', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (72, N'Bioder', N'', N'Bioder', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (73, N'Biostar', N'', N'Biostar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (74, N'Bioxcin', N'', N'Bioxcin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (75, N'Biozone', N'', N'Biozone', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (76, N'Black&Decker', N'', N'Black&Decker', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (77, N'BlackBerry', N'', N'BlackBerry', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (78, N'Blizzard', N'', N'Blizzard', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (79, N'BlueHouse', N'', N'BlueHouse', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (80, N'Bonie', N'', N'Bonie', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (81, N'Bosch', N'', N'Bosch', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (82, N'Botech', N'', N'Botech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (83, N'Botoliss', N'', N'Botoliss', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (84, N'Braun', N'', N'Braun', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (85, N'Bright', N'', N'Bright', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (86, N'Britax-Römer', N'', N'Britax-Römer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (87, N'Bross', N'', N'Bross', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (88, N'Brother', N'', N'Brother', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (89, N'BSE', N'', N'BSE', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (90, N'Buderus', N'', N'Buderus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (91, N'Busso', N'', N'Busso', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (92, N'Calvin Klein', N'', N'Calvin Klein', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (93, N'Camel', N'', N'Camel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (94, N'Canon', N'', N'Canon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (95, N'Canyon', N'', N'Canyon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (96, N'Capcom', N'', N'Capcom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (97, N'Carllevis', N'', N'Carllevis', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (98, N'Cartel', N'', N'Cartel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (99, N'Casio', N'', N'Casio', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (100, N'Casper', N'', N'Casper', 0, NULL)
GO
print 'Processed 100 total records'
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (101, N'CCS', N'', N'CCS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (102, N'Celluless', N'', N'Celluless', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (103, N'Cenix', N'', N'Cenix', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (104, N'Cerruti', N'', N'Cerruti', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (105, N'Ceta Form', N'', N'Ceta Form', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (106, N'Chicco', N'', N'Chicco', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (107, N'Citizen', N'', N'Citizen', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (108, N'Clarion', N'', N'Clarion', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (109, N'Classone', N'', N'Classone', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (110, N'Club 3D', N'', N'Club 3D', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (111, N'Codegen', N'', N'Codegen', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (112, N'Comfort', N'', N'Comfort', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (113, N'Concord', N'', N'Concord', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (114, N'Connect 3D', N'', N'Connect 3D', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (115, N'Conti', N'', N'Conti', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (116, N'Cooler Master', N'', N'Cooler Master', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (117, N'Corsair', N'', N'Corsair', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (118, N'CoWon', N'', N'CoWon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (119, N'Crea', N'', N'Crea', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (120, N'Creative', N'', N'Creative', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (121, N'Crystal Baby', N'', N'Crystal Baby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (122, N'CVS', N'', N'CVS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (123, N'Cybex', N'', N'Cybex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (124, N'Dalin', N'', N'Dalin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (125, N'Dane-Elec', N'', N'Dane-Elec', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (126, N'Darphin', N'', N'Darphin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (127, N'Datron', N'', N'Datron', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (128, N'Days In Colours', N'', N'Days In Colours', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (129, N'DDF', N'', N'DDF', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (130, N'Debbie Meyer', N'', N'Debbie Meyer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (131, N'Dell', N'', N'Dell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (132, N'Delonghi', N'', N'Delonghi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (133, N'Demirdöküm', N'', N'Demirdöküm', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (134, N'Dente', N'', N'Dente', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (135, N'Deowell', N'', N'Deowell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (136, N'Dewalt', N'', N'Dewalt', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (137, N'Dexter', N'', N'Dexter', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (138, N'Diesel', N'', N'Diesel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (139, N'Digiframe', N'', N'Digiframe', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (140, N'Digimax', N'', N'Digimax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (141, N'Dinar', N'', N'Dinar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (142, N'Diriteks', N'', N'Diriteks', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (143, N'Disney', N'', N'Disney', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (144, N'DKNY', N'', N'DKNY', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (145, N'D-Link', N'', N'D-Link', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (146, N'Dockers', N'', N'Dockers', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (147, N'Dolce&Gabbana', N'', N'Dolce&Gabbana', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (148, N'Dolfinus', N'', N'Dolfinus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (149, N'Dolphins', N'', N'Dolphins', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (150, N'Dophia', N'', N'Dophia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (151, N'Dr. Brown''s', N'', N'Dr. Brown''s', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (152, N'DreamBox', N'', N'DreamBox', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (153, N'Dremel', N'', N'Dremel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (154, N'Dunlop', N'', N'Dunlop', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (155, N'Duru', N'', N'Duru', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (156, N'Dynamic', N'', N'Dynamic', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (157, N'Dyson', N'', N'Dyson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (158, N'E.C.A.', N'', N'E.C.A.', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (159, N'EA Games', N'', N'EA Games', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (160, N'ECS', N'', N'ECS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (161, N'Edimax', N'', N'Edimax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (162, N'Eidos', N'', N'Eidos', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (163, N'Einhell', N'', N'Einhell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (164, N'Electrolux', N'', N'Electrolux', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (165, N'Ellezza', N'', N'Ellezza', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (166, N'Elta', N'', N'Elta', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (167, N'Emporio Armani', N'', N'Emporio Armani', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (168, N'Epila', N'', N'Epila', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (169, N'Epson', N'', N'Epson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (170, N'E-Sky', N'', N'E-Sky', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (171, N'Esprit', N'', N'Esprit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (172, N'Everest', N'', N'Everest', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (173, N'e-view', N'', N'e-view', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (174, N'Exper', N'', N'Exper', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (175, N'Fakir', N'', N'Fakir', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (176, N'Fantom', N'', N'Fantom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (177, N'Fasttrack', N'', N'Fasttrack', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (178, N'Felix', N'', N'Felix', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (179, N'Fenerbahçe', N'', N'Fenerbahçe', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (180, N'Ferrari', N'', N'Ferrari', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (181, N'Firefly', N'', N'Firefly', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (182, N'Fisher Price', N'', N'Fisher Price', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (183, N'Fitnit', N'', N'Fitnit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (184, N'Florit Home', N'', N'Florit Home', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (185, N'Forex', N'', N'Forex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (186, N'Forsa', N'', N'Forsa', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (187, N'For-X', N'', N'For-X', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (188, N'Fossil', N'', N'Fossil', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (189, N'Foxconn', N'', N'Foxconn', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (190, N'Freebox', N'', N'Freebox', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (191, N'Frisby', N'', N'Frisby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (192, N'Fujifilm', N'', N'Fujifilm', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (193, N'Fujitsu', N'', N'Fujitsu', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (194, N'Fujitsu Siemens', N'', N'Fujitsu Siemens', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (195, N'Galanz', N'', N'Galanz', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (196, N'Galatasaray', N'', N'Galatasaray', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (197, N'Garmin', N'', N'Garmin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (198, N'Gecube', N'', N'Gecube', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (199, N'Geek', N'', N'Geek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (200, N'General Mobile', N'', N'General Mobile', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (201, N'Genius', N'', N'Genius', 0, NULL)
GO
print 'Processed 200 total records'
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (202, N'GF Ferre', N'', N'GF Ferre', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (203, N'Gigabyte', N'', N'Gigabyte', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (204, N'Gogo', N'', N'Gogo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (205, N'Golden Royal', N'', N'Golden Royal', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (206, N'Goldmaster', N'', N'Goldmaster', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (207, N'Goodman', N'', N'Goodman', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (208, N'Gökay', N'', N'Gökay', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (209, N'Graco', N'', N'Graco', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (210, N'Gramaltin', N'', N'Gramaltin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (211, N'Groowy', N'', N'Groowy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (212, N'Guess', N'', N'Guess', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (213, N'Gutto', N'', N'Gutto', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (214, N'Hamilton', N'', N'Hamilton', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (215, N'Harman Kardon', N'', N'Harman Kardon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (216, N'Harward', N'', N'Harward', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (217, N'Hasbro Intertoy', N'', N'Hasbro Intertoy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (218, N'Hauck', N'', N'Hauck', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (219, N'Hauppauge', N'', N'Hauppauge', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (220, N'HIS', N'', N'HIS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (221, N'Hi-Level', N'', N'Hi-Level', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (222, N'Hiper', N'', N'Hiper', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (223, N'Hitachi', N'', N'Hitachi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (224, N'Hobby', N'', N'Hobby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (225, N'Hobbyzone', N'', N'Hobbyzone', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (226, N'Hometech', N'', N'Hometech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (227, N'Hoover', N'', N'Hoover', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (228, N'HP', N'', N'HP', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (229, N'HTC', N'', N'HTC', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (230, N'Hyundai', N'', N'Hyundai', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (231, N'I Watch', N'', N'I Watch', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (232, N'Icf', N'', N'Icf', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (233, N'Icoo', N'', N'Icoo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (234, N'Igia', N'', N'Igia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (235, N'Ilvina', N'', N'Ilvina', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (236, N'Inca', N'', N'Inca', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (237, N'Indesit', N'', N'Indesit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (238, N'Infinity', N'', N'Infinity', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (239, N'InFocus', N'', N'InFocus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (240, N'Inform', N'', N'Inform', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (241, N'Inno3D', N'', N'Inno3D', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (242, N'Intel', N'', N'Intel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (243, N'Intex', N'', N'Intex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (244, N'Iqua', N'', N'Iqua', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (245, N'Issimo', N'', N'Issimo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (246, N'Iklim', N'', N'Iklim', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (247, N'i-mate', N'', N'i-mate', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (248, N'Izeltas', N'', N'Izeltas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (249, N'Jabra', N'', N'Jabra', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (250, N'Jackline', N'', N'Jackline', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (251, N'Jacques Lemans', N'', N'Jacques Lemans', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (252, N'Jameson', N'', N'Jameson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (253, N'Jane', N'', N'Jane', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (254, N'Jeep', N'', N'Jeep', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (255, N'Jetway', N'', N'Jetway', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (256, N'JVC', N'', N'JVC', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (257, N'Jwin', N'', N'Jwin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (258, N'Kamosonic', N'', N'Kamosonic', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (259, N'Karel', N'', N'Karel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (260, N'Kenwood', N'', N'Kenwood', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (261, N'King', N'', N'King', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (262, N'Kingston', N'', N'Kingston', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (263, N'Koala', N'', N'Koala', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (264, N'Kodak', N'', N'Kodak', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (265, N'Konami', N'', N'Konami', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (266, N'Kontorland', N'', N'Kontorland', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (267, N'Korkmaz', N'', N'Korkmaz', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (268, N'Kraft', N'', N'Kraft', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (269, N'Krups', N'', N'Krups', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (270, N'Kumtel', N'', N'Kumtel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (271, N'Kymaro', N'', N'Kymaro', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (272, N'Labtec', N'', N'Labtec', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (273, N'Lacie', N'', N'Lacie', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (274, N'Lacoste', N'', N'Lacoste', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (275, N'Laguna Home', N'', N'Laguna Home', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (276, N'Lanaform', N'', N'Lanaform', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (277, N'Lansinoh', N'', N'Lansinoh', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (278, N'Laxon', N'', N'Laxon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (279, N'Leica', N'', N'Leica', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (280, N'Lemon', N'', N'Lemon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (281, N'Leno Home', N'', N'Leno Home', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (282, N'Lenovo', N'', N'Lenovo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (283, N'Levis', N'', N'Levis', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (284, N'Lexia', N'', N'Lexia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (285, N'Lexmark', N'', N'Lexmark', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (286, N'LG', N'', N'LG', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (287, N'Licop', N'', N'Licop', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (288, N'Liebert', N'', N'Liebert', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (289, N'Lindam', N'', N'Lindam', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (290, N'Linksys', N'', N'Linksys', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (291, N'Liteon', N'', N'Liteon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (292, N'Logitech', N'', N'Logitech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (293, N'Longines', N'', N'Longines', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (294, N'Lorus', N'', N'Lorus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (295, N'Luxell', N'', N'Luxell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (296, N'Maclaren', N'', N'Maclaren', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (297, N'Macrolife', N'', N'Macrolife', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (298, N'Magellan', N'', N'Magellan', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (299, N'Magnum', N'', N'Magnum', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (300, N'Maisonette', N'', N'Maisonette', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (301, N'Majoli', N'', N'Majoli', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (302, N'Makita', N'', N'Makita', 0, NULL)
GO
print 'Processed 300 total records'
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (303, N'Mamas&Papas', N'', N'Mamas&Papas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (304, N'Manfrotto', N'', N'Manfrotto', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (305, N'Marvella Home', N'', N'Marvella Home', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (306, N'Maxi-Cosi', N'', N'Maxi-Cosi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (307, N'Maxima', N'', N'Maxima', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (308, N'Maxtor', N'', N'Maxtor', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (309, N'Medela', N'', N'Medela', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (310, N'Mehtap', N'', N'Mehtap', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (311, N'Microsoft', N'', N'Microsoft', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (312, N'Midea', N'', N'Midea', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (313, N'Mikrobox', N'', N'Mikrobox', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (314, N'Mink', N'', N'Mink', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (315, N'Minton', N'', N'Minton', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (316, N'Mio', N'', N'Mio', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (317, N'Mitsubishi', N'', N'Mitsubishi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (318, N'Momentus', N'', N'Momentus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (319, N'Monster', N'', N'Monster', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (320, N'Montana', N'', N'Montana', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (321, N'Motorola', N'', N'Motorola', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (322, N'Moulinex', N'', N'Moulinex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (323, N'MSI', N'', N'MSI', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (324, N'Murad', N'', N'Murad', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (325, N'Mustek', N'', N'Mustek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (326, N'Mutsy', N'', N'Mutsy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (327, N'MyGuide', N'', N'MyGuide', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (328, N'Myphone', N'', N'Myphone', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (329, N'Nacar', N'', N'Nacar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (330, N'Naughty Dog', N'', N'Naughty Dog', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (331, N'Nautica', N'', N'Nautica', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (332, N'Navia', N'', N'Navia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (333, N'Navigo', N'', N'Navigo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (334, N'Navitech', N'', N'Navitech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (335, N'Navking', N'', N'Navking', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (336, N'NEC', N'', N'NEC', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (337, N'Neonato', N'', N'Neonato', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (338, N'Neonode', N'', N'Neonode', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (339, N'Neopuntia', N'', N'Neopuntia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (340, N'Neovo', N'', N'Neovo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (341, N'Netmaster', N'', N'Netmaster', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (342, N'Next', N'', N'Next', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (343, N'NG', N'', N'NG', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (344, N'Mobile', N'', N'Mobile', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (345, N'Nikon', N'', N'Nikon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (346, N'Nilfisk', N'', N'Nilfisk', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (347, N'Nintendo', N'', N'Nintendo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (348, N'Nokia', N'', N'Nokia', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (349, N'Nuby', N'', N'Nuby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (350, N'Nuk', N'', N'Nuk', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (351, N'Nuslank', N'', N'Nuslank', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (352, N'OCZ', N'', N'OCZ', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (353, N'Odak', N'', N'Odak', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (354, N'Odema', N'', N'Odema', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (355, N'Oem', N'', N'Oem', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (356, N'Ogatech', N'', N'Ogatech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (357, N'Okay', N'', N'Okay', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (358, N'Oki', N'', N'Oki', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (359, N'Olivetti', N'', N'Olivetti', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (360, N'Olympus', N'', N'Olympus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (361, N'Omron', N'', N'Omron', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (362, N'Optoma', N'', N'Optoma', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (363, N'Orbit Baby', N'', N'Orbit Baby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (364, N'Oregon', N'', N'Oregon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (365, N'Orient', N'', N'Orient', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (366, N'Orite', N'', N'Orite', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (367, N'Ortoy', N'', N'Ortoy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (368, N'Osawa', N'', N'Osawa', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (369, N'Othello', N'', N'Othello', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (370, N'Örtüm', N'', N'Örtüm', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (371, N'Özdilek', N'', N'Özdilek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (372, N'Packard Bell', N'', N'Packard Bell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (373, N'Palit', N'', N'Palit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (374, N'Palm', N'', N'Palm', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (375, N'Panasonic', N'', N'Panasonic', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (376, N'Patchwork', N'', N'Patchwork', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (377, N'Peg', N'', N'Peg', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (378, N'Perego', N'', N'Perego', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (379, N'PenPower', N'', N'PenPower', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (380, N'Pentax', N'', N'Pentax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (381, N'Perfetto', N'', N'Perfetto', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (382, N'Petrix', N'', N'Petrix', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (383, N'Philips', N'', N'Philips', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (384, N'Phonex', N'', N'Phonex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (385, N'Pierre Cardin', N'', N'Pierre Cardin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (386, N'Pigeon', N'', N'Pigeon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (387, N'Pikatel', N'', N'Pikatel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (388, N'Pilsan', N'', N'Pilsan', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (389, N'Pioneer', N'', N'Pioneer', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (390, N'Piranha', N'', N'Piranha', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (391, N'Platinium', N'', N'Platinium', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (392, N'Plextor', N'', N'Plextor', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (393, N'Plustek', N'', N'Plustek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (394, N'Pny Quadro', N'', N'Pny Quadro', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (395, N'Point of View', N'', N'Point of View', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (396, N'Polylingua', N'', N'Polylingua', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (397, N'PowerColor', N'', N'PowerColor', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (398, N'Powercom', N'', N'Powercom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (399, N'Powersonic', N'', N'Powersonic', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (400, N'Powerway', N'', N'Powerway', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (401, N'Praticbaby', N'', N'Praticbaby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (402, N'Premaxx', N'', N'Premaxx', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (403, N'Premier', N'', N'Premier', 0, NULL)
GO
print 'Processed 400 total records'
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (404, N'Primi Sogni', N'', N'Primi Sogni', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (405, N'Pro2000', N'', N'Pro2000', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (406, N'Profilo', N'', N'Profilo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (407, N'Prolysus', N'', N'Prolysus', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (408, N'Provital', N'', N'Provital', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (409, N'Pulsar', N'', N'Pulsar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (410, N'Puma', N'', N'Puma', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (411, N'Qtek', N'', N'Qtek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (412, N'Quake', N'', N'Quake', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (413, N'Quantum', N'', N'Quantum', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (414, N'Queen', N'', N'Queen', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (415, N'Raidmax', N'', N'Raidmax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (416, N'Raks', N'', N'Raks', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (417, N'Ramar', N'', N'Ramar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (418, N'Recaro', N'', N'Recaro', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (419, N'Reebok', N'', N'Reebok', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (420, N'Regal', N'', N'Regal', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (421, N'Rejene', N'', N'Rejene', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (422, N'Remington', N'', N'Remington', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (423, N'Rising Star', N'', N'Rising Star', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (424, N'Romanson', N'', N'Romanson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (425, N'Rowenta', N'', N'Rowenta', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (426, N'Safety 1st', N'', N'Safety 1st', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (427, N'Sagem', N'', N'Sagem', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (428, N'Saitek', N'', N'Saitek', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (429, N'Salvolin', N'', N'Salvolin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (430, N'Samsung', N'', N'Samsung', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (431, N'SanDisk', N'', N'SanDisk', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (432, N'Sansui', N'', N'Sansui', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (433, N'Sanyo', N'', N'Sanyo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (434, N'Sapphire', N'', N'Sapphire', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (435, N'Sarev', N'', N'Sarev', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (436, N'SBS', N'', N'SBS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (437, N'Scarlett', N'', N'Scarlett', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (438, N'Seagate', N'', N'Seagate', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (439, N'Sebago', N'', N'Sebago', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (440, N'Sega', N'', N'Sega', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (441, N'Seiko', N'', N'Seiko', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (442, N'Seikon', N'', N'Seikon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (443, N'Sein', N'', N'Sein', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (444, N'Sennheiser', N'', N'Sennheiser', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (445, N'Seoul', N'', N'Seoul', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (446, N'Severin', N'', N'Severin', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (447, N'Sevi Bebe', N'', N'Sevi Bebe', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (448, N'Sharp', N'', N'Sharp', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (449, N'Shiny', N'', N'Shiny', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (450, N'Siemens', N'', N'Siemens', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (451, N'Sigma', N'', N'Sigma', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (452, N'Simtel', N'', N'Simtel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (453, N'Sinbo', N'', N'Sinbo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (454, N'Skil', N'', N'Skil', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (455, N'Sky Face', N'', N'Sky Face', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (456, N'Skystar', N'', N'Skystar', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (457, N'Skytech', N'', N'Skytech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (458, N'Smart Media', N'', N'Smart Media', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (459, N'Smartbebe', N'', N'Smartbebe', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (460, N'Smartdisk', N'', N'Smartdisk', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (461, N'Snopy', N'', N'Snopy', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (462, N'Sonay', N'', N'Sonay', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (463, N'Sony', N'', N'Sony', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (464, N'Sony Ericsson', N'', N'Sony Ericsson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (465, N'Southwing', N'', N'Southwing', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (466, N'Space Bag', N'', N'Space Bag', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (467, N'Space', N'', N'Space', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (468, N'Saver', N'', N'Saver', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (469, N'Sparkle', N'', N'Sparkle', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (470, N'Speedlink', N'', N'Speedlink', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (471, N'Storchenmühle', N'', N'Storchenmühle', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (472, N'Stork', N'', N'Stork', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (473, N'Stormax', N'', N'Stormax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (474, N'Storway', N'', N'Storway', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (475, N'Sunny', N'', N'Sunny', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (476, N'Sunny Baby', N'', N'Sunny Baby', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (477, N'Super Wrench', N'', N'Super Wrench', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (478, N'Süsler', N'', N'Süsler', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (479, N'Swatch', N'', N'Swatch', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (480, N'Sweat', N'', N'Sweat', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (481, N'Swivel', N'', N'Swivel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (482, N'Sweeper', N'', N'Sweeper', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (483, N'Syma', N'', N'Syma', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (484, N'Tabe', N'', N'Tabe', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (485, N'Taç', N'', N'Taç', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (486, N'Take 2', N'', N'Take 2', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (487, N'Tefal', N'', N'Tefal', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (488, N'Terraillon', N'', N'Terraillon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (489, N'Tesan', N'', N'Tesan', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (490, N'The First Years', N'', N'The First Years', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (491, N'Thermaltake', N'', N'Thermaltake', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (492, N'Thomas', N'', N'Thomas', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (493, N'Thomson', N'', N'Thomson', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (494, N'THQ', N'', N'THQ', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (495, N'Tigex', N'', N'Tigex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (496, N'Timberland', N'', N'Timberland', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (497, N'Timex', N'', N'Timex', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (498, N'Tissot', N'', N'Tissot', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (499, N'Tobi', N'', N'Tobi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (500, N'Tommy Hilfiger', N'', N'Tommy Hilfiger', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (501, N'TomTom', N'', N'TomTom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (502, N'Topcom', N'', N'Topcom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (503, N'Toshiba', N'', N'Toshiba', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (504, N'Transcend', N'', N'Transcend', 0, NULL)
GO
print 'Processed 500 total records'
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (505, N'Traxx', N'', N'Traxx', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (506, N'Trends For Kids', N'', N'Trends For Kids', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (507, N'Trident', N'', N'Trident', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (508, N'Triumph Adler', N'', N'Triumph Adler', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (509, N'Tropik', N'', N'Tropik', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (510, N'True Cover', N'', N'True Cover', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (511, N'Trust', N'', N'Trust', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (512, N'Ttec', N'', N'Ttec', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (513, N'TTN Mobile', N'', N'TTN Mobile', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (514, N'Tunçmatik', N'', N'Tunçmatik', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (515, N'Turkcell', N'', N'Turkcell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (516, N'TV', N'', N'TV', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (517, N'Twings', N'', N'Twings', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (518, N'Twinmos', N'', N'Twinmos', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (519, N'Ufo', N'', N'Ufo', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (520, N'Ugur', N'', N'Ugur', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (521, N'US Robotics', N'', N'US Robotics', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (522, N'Utax', N'', N'Utax', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (523, N'Uydu', N'', N'Uydu', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (524, N'Ümit', N'', N'Ümit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (525, N'Valera', N'', N'Valera', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (526, N'Veito', N'', N'Veito', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (527, N'Velform', N'', N'Velform', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (528, N'Velsoft', N'', N'Velsoft', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (529, N'Verbatim', N'', N'Verbatim', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (530, N'Veritech', N'', N'Veritech', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (531, N'Vestel', N'', N'Vestel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (532, N'Victoria', N'', N'Victoria', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (533, N'Viessmann', N'', N'Viessmann', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (534, N'ViewSonic', N'', N'ViewSonic', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (535, N'Visko Love', N'', N'Visko Love', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (536, N'Vivendi', N'', N'Vivendi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (537, N'Vivol Vodafone', N'', N'Vivol Vodafone', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (538, N'Voit', N'', N'Voit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (539, N'Weewell', N'', N'Weewell', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (540, N'Wentto', N'', N'Wentto', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (541, N'Western Digital', N'', N'Western Digital', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (542, N'Whirlpool', N'', N'Whirlpool', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (543, N'White', N'', N'White', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (544, N'Westinghouse', N'', N'Westinghouse', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (545, N'Windisk', N'', N'Windisk', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (546, N'Wizzit', N'', N'Wizzit', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (547, N'WND', N'', N'WND', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (548, N'Wonderlift', N'', N'Wonderlift', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (549, N'Woon', N'', N'Woon', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (550, N'Xeon Smartcare', N'', N'Xeon Smartcare', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (551, N'Xerox', N'', N'Xerox', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (552, N'Xetec', N'', N'Xetec', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (553, N'Xpertvision', N'', N'Xpertvision', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (554, N'XS', N'', N'XS', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (555, N'York', N'', N'York', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (556, N'Zanetti', N'', N'Zanetti', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (557, N'Zanussi', N'', N'Zanussi', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (558, N'Zen', N'', N'Zen', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (559, N'Zoom', N'', N'Zoom', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (560, N'Zotac', N'', N'Zotac', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (561, N'Zyxel', N'', N'Zyxel', 0, NULL)
INSERT [dbo].[BRANDS] ([Id], [Name], [Desc], [Tags], [Flags], [LogoPath]) VALUES (562, N'Markasiz', NULL, N'Markasiz', 1024, NULL)
SET IDENTITY_INSERT [dbo].[BRANDS] OFF
/****** Object:  Table [dbo].[LOGS]    Script Date: 06/05/2011 22:32:37 ******/
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
	[Instance] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Machine] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[ExternalIp] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[LocalIp] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[Action] [int] NOT NULL,
	[Date] [datetime] NOT NULL,
	[XField1] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[XField2] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[XField3] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_TBL_LOG] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[LOGS] ON
INSERT [dbo].[LOGS] ([Id], [Type], [SubType], [RefId], [Instance], [Machine], [ExternalIp], [LocalIp], [Action], [Date], [XField1], [XField2], [XField3]) VALUES (2015, 2, -1, 2, N'1', N'ORION', NULL, NULL, 80, CAST(0x00009ED2014032D6 AS DateTime), N'', N'', NULL)
INSERT [dbo].[LOGS] ([Id], [Type], [SubType], [RefId], [Instance], [Machine], [ExternalIp], [LocalIp], [Action], [Date], [XField1], [XField2], [XField3]) VALUES (2016, 2, -1, 2, N'1', N'ORION', NULL, NULL, 70, CAST(0x00009ED300AA89C5 AS DateTime), N'IP (remote) : 127.0.0.1', N'Port : 3366', NULL)
INSERT [dbo].[LOGS] ([Id], [Type], [SubType], [RefId], [Instance], [Machine], [ExternalIp], [LocalIp], [Action], [Date], [XField1], [XField2], [XField3]) VALUES (2017, 2, -1, 2, N'1', N'ORION', NULL, NULL, 80, CAST(0x00009ED300AAA16C AS DateTime), N'', N'', NULL)
INSERT [dbo].[LOGS] ([Id], [Type], [SubType], [RefId], [Instance], [Machine], [ExternalIp], [LocalIp], [Action], [Date], [XField1], [XField2], [XField3]) VALUES (2018, 2, -1, 2, N'1', N'ORION', NULL, NULL, 80, CAST(0x00009ED300AAA4F5 AS DateTime), N'', N'', NULL)
SET IDENTITY_INSERT [dbo].[LOGS] OFF
/****** Object:  Table [dbo].[KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[KEYWORDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Keyword] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_TBL_KEYWORDS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[KEYWORDS] ON
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2082, N'a4tech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2083, N'acer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2084, N'activa')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2085, N'activision')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2086, N'acura')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2087, N'a-data')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2088, N'adidas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2089, N'adler')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2090, N'aeg')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2091, N'aerocool')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2092, N'agfa')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2093, N'aidata')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2094, N'airospace')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2095, N'airfel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2096, N'airties')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2097, N'akasa')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2098, N'akfil')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2099, N'aksu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2100, N'alfacell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2101, N'alpin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2102, N'alps')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2103, N'alteclansing')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2104, N'altinbasak')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2105, N'altis')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2106, N'altus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2107, N'amd')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2108, N'ameda')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2109, N'annovi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2110, N'reverberi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2111, N'anycool')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2112, N'aoc')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2113, N'aopen')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2114, N'apc')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2115, N'apple')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2116, N'aran')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2117, N'archos')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2118, N'arçelik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2119, N'arex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2120, N'ariston')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2121, N'arnica')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2122, N'arzum')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2123, N'aselsan')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2124, N'asus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2125, N'atari')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2126, N'atlanta')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2127, N'attlas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2128, N'auer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2129, N'ave')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2130, N'avent')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2131, N'avermedia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2132, N'axle')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2133, N'aytunç')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2134, N'aztech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2135, N'baby')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2136, N'go')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2137, N'babybjörn')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2138, N'babyhope')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2139, N'babyliss')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2140, N'baymak')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2141, N'bebedor')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2142, N'bebesounds')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2143, N'bebiccio')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2144, N'beko')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2145, N'benq')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2146, N'siemens')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2147, N'besttel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2148, N'bestway')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2149, N'besiktas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2150, N'beurer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2151, N'bfg')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2152, N'bianchi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2153, N'bigboy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2154, N'bigtop')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2155, N'bioder')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2156, N'biostar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2157, N'bioxcin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2158, N'biozone')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2159, N'black&decker')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2160, N'blackberry')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2161, N'blizzard')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2162, N'bluehouse')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2163, N'bonie')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2164, N'bosch')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2165, N'botech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2166, N'botoliss')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2167, N'braun')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2168, N'bright')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2169, N'britax-römer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2170, N'bross')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2171, N'brother')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2172, N'bse')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2173, N'buderus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2174, N'busso')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2175, N'calvin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2176, N'klein')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2177, N'camel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2178, N'canon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2179, N'canyon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2180, N'capcom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2181, N'carllevis')
GO
print 'Processed 100 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2182, N'cartel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2183, N'casio')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2184, N'casper')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2185, N'ccs')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2186, N'celluless')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2187, N'cenix')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2188, N'cerruti')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2189, N'ceta')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2190, N'form')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2191, N'chicco')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2192, N'citizen')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2193, N'clarion')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2194, N'classone')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2195, N'club')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2196, N'3d')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2197, N'codegen')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2198, N'comfort')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2199, N'concord')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2200, N'connect')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2201, N'conti')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2202, N'cooler')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2203, N'master')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2204, N'corsair')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2205, N'cowon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2206, N'crea')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2207, N'creative')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2208, N'crystal')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2209, N'cvs')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2210, N'cybex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2211, N'dalin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2212, N'dane-elec')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2213, N'darphin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2214, N'datron')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2215, N'days')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2216, N'in')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2217, N'in')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2218, N'colours')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2219, N'ddf')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2220, N'debbie')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2221, N'meyer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2222, N'dell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2223, N'delonghi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2224, N'demirdöküm')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2225, N'dente')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2226, N'deowell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2227, N'dewalt')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2228, N'dexter')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2229, N'diesel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2230, N'digiframe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2231, N'digimax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2232, N'dinar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2233, N'diriteks')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2234, N'disney')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2235, N'dkny')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2236, N'd-link')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2237, N'dockers')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2238, N'dolce&gabbana')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2239, N'dolfinus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2240, N'dolphins')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2241, N'dophia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2242, N'dr.')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2243, N'brown''s')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2244, N'dreambox')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2245, N'dremel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2246, N'dunlop')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2247, N'duru')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2248, N'dynamic')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2249, N'dyson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2250, N'e.c.a.')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2251, N'ea')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2252, N'games')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2253, N'ecs')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2254, N'edimax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2255, N'eidos')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2256, N'einhell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2257, N'electrolux')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2258, N'ellezza')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2259, N'elta')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2260, N'emporio')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2261, N'armani')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2262, N'epila')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2263, N'epson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2264, N'e-sky')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2265, N'esprit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2266, N'everest')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2267, N'e-view')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2268, N'exper')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2269, N'fakir')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2270, N'fantom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2271, N'fasttrack')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2272, N'felix')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2273, N'fenerbahçe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2274, N'ferrari')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2275, N'firefly')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2276, N'fisher')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2277, N'price')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2278, N'fitnit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2279, N'florit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2280, N'home')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2281, N'forex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2282, N'forsa')
GO
print 'Processed 200 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2283, N'for-x')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2284, N'fossil')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2285, N'foxconn')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2286, N'freebox')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2287, N'frisby')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2288, N'fujifilm')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2289, N'fujitsu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2290, N'galanz')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2291, N'galatasaray')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2292, N'garmin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2293, N'gecube')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2294, N'geek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2295, N'general')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2296, N'mobile')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2297, N'genius')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2298, N'gf')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2299, N'ferre')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2300, N'gigabyte')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2301, N'gogo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2302, N'golden')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2303, N'royal')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2304, N'goldmaster')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2305, N'goodman')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2306, N'gökay')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2307, N'graco')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2308, N'gramaltin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2309, N'groowy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2310, N'guess')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2311, N'gutto')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2312, N'hamilton')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2313, N'harman')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2314, N'kardon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2315, N'harward')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2316, N'hasbro')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2317, N'intertoy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2318, N'intertoy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2319, N'hauck')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2320, N'hauppauge')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2321, N'his')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2322, N'his')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2323, N'hi-level')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2324, N'hiper')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2325, N'hitachi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2326, N'hobby')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2327, N'hobbyzone')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2328, N'hometech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2329, N'hoover')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2330, N'hp')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2331, N'htc')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2332, N'hyundai')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2333, N'watch')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2334, N'icf')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2335, N'icf')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2336, N'icoo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2337, N'icoo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2338, N'igia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2339, N'igia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2340, N'ilvina')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2341, N'ilvina')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2342, N'inca')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2343, N'inca')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2344, N'indesit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2345, N'indesit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2346, N'infinity')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2347, N'infinity')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2348, N'infocus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2349, N'infocus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2350, N'inform')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2351, N'inform')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2352, N'inno3d')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2353, N'inno3d')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2354, N'intel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2355, N'intel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2356, N'intex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2357, N'intex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2358, N'iqua')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2359, N'iqua')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2360, N'issimo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2361, N'issimo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2362, N'iklim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2363, N'i-mate')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2364, N'izeltas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2365, N'jabra')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2366, N'jackline')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2367, N'jacques')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2368, N'lemans')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2369, N'jameson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2370, N'jane')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2371, N'jeep')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2372, N'jetway')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2373, N'jvc')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2374, N'jwin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2375, N'kamosonic')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2376, N'karel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2377, N'kenwood')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2378, N'king')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2379, N'kingston')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2380, N'koala')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2381, N'kodak')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2382, N'konami')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2383, N'kontorland')
GO
print 'Processed 300 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2384, N'korkmaz')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2385, N'kraft')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2386, N'krups')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2387, N'kumtel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2388, N'kymaro')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2389, N'labtec')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2390, N'lacie')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2391, N'lacoste')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2392, N'laguna')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2393, N'lanaform')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2394, N'lansinoh')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2395, N'laxon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2396, N'leica')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2397, N'lemon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2398, N'leno')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2399, N'lenovo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2400, N'levis')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2401, N'lexia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2402, N'lexmark')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2403, N'lg')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2404, N'licop')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2405, N'liebert')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2406, N'lindam')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2407, N'linksys')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2408, N'liteon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2409, N'logitech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2410, N'longines')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2411, N'lorus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2412, N'luxell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2413, N'maclaren')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2414, N'macrolife')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2415, N'magellan')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2416, N'magnum')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2417, N'maisonette')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2418, N'majoli')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2419, N'makita')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2420, N'mamas&papas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2421, N'manfrotto')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2422, N'marvella')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2423, N'maxi-cosi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2424, N'maxima')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2425, N'maxtor')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2426, N'medela')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2427, N'mehtap')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2428, N'microsoft')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2429, N'midea')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2430, N'mikrobox')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2431, N'mink')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2432, N'minton')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2433, N'mio')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2434, N'mitsubishi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2435, N'momentus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2436, N'monster')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2437, N'montana')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2438, N'motorola')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2439, N'moulinex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2440, N'msi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2441, N'msi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2442, N'murad')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2443, N'mustek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2444, N'mutsy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2445, N'myguide')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2446, N'myphone')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2447, N'nacar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2448, N'naughty')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2449, N'dog')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2450, N'nautica')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2451, N'navia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2452, N'navigo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2453, N'navitech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2454, N'navking')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2455, N'nec')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2456, N'neonato')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2457, N'neonode')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2458, N'neopuntia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2459, N'neovo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2460, N'netmaster')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2461, N'next')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2462, N'ng')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2463, N'nikon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2464, N'nilfisk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2465, N'nintendo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2466, N'nokia')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2467, N'nuby')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2468, N'nuk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2469, N'nuslank')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2470, N'ocz')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2471, N'odak')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2472, N'odema')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2473, N'oem')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2474, N'ogatech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2475, N'okay')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2476, N'oki')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2477, N'olivetti')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2478, N'olympus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2479, N'omron')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2480, N'optoma')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2481, N'orbit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2482, N'oregon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2483, N'orient')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2484, N'orite')
GO
print 'Processed 400 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2485, N'ortoy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2486, N'osawa')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2487, N'othello')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2488, N'örtüm')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2489, N'özdilek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2490, N'packard')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2491, N'bell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2492, N'palit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2493, N'palm')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2494, N'panasonic')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2495, N'patchwork')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2496, N'peg')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2497, N'perego')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2498, N'penpower')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2499, N'pentax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2500, N'perfetto')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2501, N'petrix')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2502, N'philips')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2503, N'phonex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2504, N'pierre')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2505, N'cardin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2506, N'pigeon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2507, N'pikatel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2508, N'pilsan')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2509, N'pioneer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2510, N'piranha')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2511, N'platinium')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2512, N'plextor')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2513, N'plustek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2514, N'pny')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2515, N'quadro')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2516, N'point')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2517, N'of')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2518, N'view')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2519, N'polylingua')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2520, N'powercolor')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2521, N'powercom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2522, N'powersonic')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2523, N'powerway')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2524, N'praticbaby')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2525, N'premaxx')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2526, N'premier')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2527, N'primi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2528, N'sogni')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2529, N'pro2000')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2530, N'profilo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2531, N'prolysus')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2532, N'provital')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2533, N'pulsar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2534, N'puma')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2535, N'qtek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2536, N'quake')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2537, N'quantum')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2538, N'queen')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2539, N'raidmax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2540, N'raks')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2541, N'ramar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2542, N'recaro')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2543, N'reebok')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2544, N'regal')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2545, N'rejene')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2546, N'remington')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2547, N'rising')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2548, N'star')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2549, N'romanson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2550, N'rowenta')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2551, N'safety')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2552, N'1st')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2553, N'sagem')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2554, N'saitek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2555, N'salvolin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2556, N'samsung')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2557, N'sandisk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2558, N'sansui')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2559, N'sanyo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2560, N'sapphire')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2561, N'sarev')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2562, N'sbs')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2563, N'scarlett')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2564, N'seagate')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2565, N'sebago')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2566, N'sega')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2567, N'seiko')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2568, N'seikon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2569, N'sein')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2570, N'sennheiser')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2571, N'seoul')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2572, N'severin')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2573, N'sevi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2574, N'bebe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2575, N'sharp')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2576, N'shiny')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2577, N'sigma')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2578, N'simtel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2579, N'sinbo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2580, N'skil')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2581, N'sky')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2582, N'face')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2583, N'skystar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2584, N'skytech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2585, N'smart')
GO
print 'Processed 500 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2586, N'media')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2587, N'smartbebe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2588, N'smartdisk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2589, N'snopy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2590, N'sonay')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2591, N'sony')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2592, N'ericsson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2593, N'southwing')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2594, N'space')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2595, N'bag')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2596, N'saver')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2597, N'sparkle')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2598, N'speedlink')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2599, N'storchenmühle')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2600, N'stork')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2601, N'stormax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2602, N'storway')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2603, N'sunny')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2604, N'super')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2605, N'wrench')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2606, N'süsler')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2607, N'swatch')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2608, N'sweat')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2609, N'swivel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2610, N'sweeper')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2611, N'syma')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2612, N'tabe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2613, N'taç')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2614, N'take')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2615, N'tefal')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2616, N'terraillon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2617, N'tesan')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2618, N'the')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2619, N'first')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2620, N'years')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2621, N'thermaltake')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2622, N'thomas')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2623, N'thomson')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2624, N'thq')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2625, N'tigex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2626, N'timberland')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2627, N'timex')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2628, N'tissot')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2629, N'tobi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2630, N'tommy')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2631, N'hilfiger')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2632, N'tomtom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2633, N'topcom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2634, N'toshiba')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2635, N'transcend')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2636, N'traxx')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2637, N'trends')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2638, N'for')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2639, N'kids')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2640, N'trident')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2641, N'triumph')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2642, N'tropik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2643, N'true')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2644, N'cover')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2645, N'trust')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2646, N'ttec')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2647, N'ttn')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2648, N'tunçmatik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2649, N'turkcell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2650, N'tv')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2651, N'twings')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2652, N'twinmos')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2653, N'ufo')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2654, N'ugur')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2655, N'us')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2656, N'robotics')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2657, N'utax')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2658, N'uydu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2659, N'ümit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2660, N'valera')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2661, N'veito')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2662, N'velform')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2663, N'velsoft')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2664, N'verbatim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2665, N'veritech')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2666, N'vestel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2667, N'victoria')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2668, N'viessmann')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2669, N'viewsonic')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2670, N'visko')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2671, N'love')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2672, N'vivendi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2673, N'vivol')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2674, N'vodafone')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2675, N'voit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2676, N'weewell')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2677, N'wentto')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2678, N'western')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2679, N'digital')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2680, N'whirlpool')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2681, N'white')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2682, N'westinghouse')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2683, N'windisk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2684, N'wizzit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2685, N'wnd')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2686, N'wonderlift')
GO
print 'Processed 600 total records'
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2687, N'woon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2688, N'xeon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2689, N'smartcare')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2690, N'xerox')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2691, N'xetec')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2692, N'xpertvision')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2693, N'xs')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2694, N'york')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2695, N'zanetti')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2696, N'zanussi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2697, N'zen')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2698, N'zoom')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2699, N'zotac')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2700, N'zyxel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2701, N'markasiz')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2702, N'bilgisayar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2703, N'kitap')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2704, N'elektronik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2705, N'hediye')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2706, N'bebek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2707, N'çocuk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2708, N'film')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2709, N'müzik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2710, N'ayakkabi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2711, N'taki')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2712, N'mücevher')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2713, N'saglik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2714, N'güzellik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2715, N'saat')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2716, N'spor')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2717, N'fitness')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2718, N'ev')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2719, N'tekstili')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2720, N'bahçe')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2721, N'hirdavat')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2722, N'hobi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2723, N'oyun')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2724, N'telefon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2725, N'otomobil')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2726, N'mutfak')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2727, N'yazilim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2728, N'donanim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2729, N'dizistü')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2730, N'mini')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2731, N'dizüstü')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2732, N'kamera')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2733, N'fotograf')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2734, N'makinasi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2735, N'televizyon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2736, N'mp3')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2737, N'çalar')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2738, N'hediyelik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2739, N'esya')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2740, N'çiçek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2741, N'blue')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2742, N'ray')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2743, N'kozmetik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2744, N'kisisel')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2745, N'bakim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2746, N'medikal')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2747, N'kondisyon')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2748, N'giyim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2749, N'pc')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2750, N'wii')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2751, N'playstation')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2752, N'psp')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2753, N'xbox')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2754, N'360')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2755, N'konsolu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2756, N'ofis')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2757, N'güvenlik')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2758, N'isletim')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2759, N'sistemi')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2760, N'anakart')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2761, N'bellek')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2762, N'islemci')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2763, N'ekran')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2764, N'karti')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2765, N'sabit')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2766, N'disk')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2767, N'ses')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2768, N'hoparlör')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2769, N'kasa')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2770, N'tarayici')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2771, N'yazici')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2772, N'monitör')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2773, N'fare')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2774, N'mouse')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2775, N'klavye')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2776, N'dvd')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2777, N'okuyucu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2778, N'cd')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2779, N'lazer')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2780, N'mürekkep')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2781, N'püskürtmeli')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2782, N'nokta')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2783, N'vuruslu')
INSERT [dbo].[KEYWORDS] ([Id], [Keyword]) VALUES (2784, N'bilinmeyen')
SET IDENTITY_INSERT [dbo].[KEYWORDS] OFF
/****** Object:  Table [dbo].[DOWNLOADS]    Script Date: 06/05/2011 22:32:37 ******/
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
	[Ip] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
	[Date] [datetime] NOT NULL,
 CONSTRAINT [PK_TBL_DOWNLOADS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RESOURCE_TYPES]    Script Date: 06/05/2011 22:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RESOURCE_TYPES](
	[Id] [smallint] NOT NULL,
	[Name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[Desc] [varchar](256) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_RESOURCE_TYPES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[RESOURCE_TYPES] ([Id], [Name], [Desc]) VALUES (1, N'RSS', NULL)
INSERT [dbo].[RESOURCE_TYPES] ([Id], [Name], [Desc]) VALUES (2, N'ATOM', NULL)
INSERT [dbo].[RESOURCE_TYPES] ([Id], [Name], [Desc]) VALUES (3, N'XML', NULL)
/****** Object:  Table [dbo].[SEQUENCE]    Script Date: 06/05/2011 22:32:38 ******/
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
INSERT [dbo].[SEQUENCE] ([Type], [SubType], [Value]) VALUES (1, 1, 0)
INSERT [dbo].[SEQUENCE] ([Type], [SubType], [Value]) VALUES (1, 2, 0)
INSERT [dbo].[SEQUENCE] ([Type], [SubType], [Value]) VALUES (2, 0, 0)
INSERT [dbo].[SEQUENCE] ([Type], [SubType], [Value]) VALUES (3, 0, 0)
/****** Object:  UserDefinedFunction [dbo].[Split]    Script Date: 06/05/2011 22:32:39 ******/
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
/****** Object:  Table [dbo].[VERSIONS]    Script Date: 06/05/2011 22:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[VERSIONS](
	[Id] [int] NOT NULL,
	[Name] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
	[Version] [varchar](16) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_TBL_VERSION] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[VERSIONS] ([Id], [Name], [Version]) VALUES (1, N'MainList', N'1.1.0.0')
INSERT [dbo].[VERSIONS] ([Id], [Name], [Version]) VALUES (2, N'Client', N'1.1.0.0')
INSERT [dbo].[VERSIONS] ([Id], [Name], [Version]) VALUES (3, N'Server', N'1.1.0.0')
INSERT [dbo].[VERSIONS] ([Id], [Name], [Version]) VALUES (4, N'Explorer', N'1.1.0.0')
/****** Object:  Table [dbo].[APPLOGS]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[APPLOGS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Date] [datetime] NOT NULL,
	[Thread] [varchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
	[Level] [varchar](50) COLLATE Latin1_General_CI_AS NOT NULL,
	[Logger] [varchar](255) COLLATE Latin1_General_CI_AS NOT NULL,
	[Message] [varchar](4000) COLLATE Latin1_General_CI_AS NOT NULL,
	[Exception] [varchar](2000) COLLATE Latin1_General_CI_AS NULL
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  UserDefinedFunction [dbo].[SEQUENCE_GetPageIndex]    Script Date: 06/05/2011 22:32:39 ******/
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
/****** Object:  Table [dbo].[SERVERS]    Script Date: 06/05/2011 22:32:38 ******/
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
	[Name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[ComputerName] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[ExternalIp] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[LocalIp] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[Mac] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
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
SET IDENTITY_INSERT [dbo].[SERVERS] ON
INSERT [dbo].[SERVERS] ([Id], [CountryId], [UniqueHash], [Name], [ComputerName], [ExternalIp], [LocalIp], [Mac], [Instance], [Socket], [ClientCount], [IsActive], [Date]) VALUES (1, 1, 61098372136, N'Paladin', N'PALADIN', N'89.19.13.244', N'89.19.13.244', N'005056986D88', 1, 3366, 0, 0, CAST(0x00009D99002114DF AS DateTime))
INSERT [dbo].[SERVERS] ([Id], [CountryId], [UniqueHash], [Name], [ComputerName], [ExternalIp], [LocalIp], [Mac], [Instance], [Socket], [ClientCount], [IsActive], [Date]) VALUES (2, 1, 62125101590, N'Orion', N'ORION', N'127.0.0.1', N'127.0.0.1', N'001A730ADDDE', 1, 3366, 0, 1, CAST(0x00009EA20168F775 AS DateTime))
SET IDENTITY_INSERT [dbo].[SERVERS] OFF
/****** Object:  StoredProcedure [dbo].[LOGS_LogAction]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  Table [dbo].[CLIENTS]    Script Date: 06/05/2011 22:32:37 ******/
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
	[Guid] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[ExternalIp] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[LocalIp] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[Mac] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
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
SET IDENTITY_INSERT [dbo].[CLIENTS] ON
INSERT [dbo].[CLIENTS] ([Id], [CountryId], [UniqueHash], [Guid], [Name], [ExternalIp], [LocalIp], [Mac], [Instance], [CurrentMode], [ItemCount], [Date], [ServerId], [UselocalId], [IsConnected]) VALUES (1, 1, 62466672209, N'fc4812c6-14bf-465e-8647-9018c9add678', N'ORION', N'192.168.2.5', N'192.168.2.5', N'0017084B52FB', 1, 1, 0, CAST(0x00009DA0018107B6 AS DateTime), 5, 0, 0)
INSERT [dbo].[CLIENTS] ([Id], [CountryId], [UniqueHash], [Guid], [Name], [ExternalIp], [LocalIp], [Mac], [Instance], [CurrentMode], [ItemCount], [Date], [ServerId], [UselocalId], [IsConnected]) VALUES (12, 1, 62763721181, N'e2d6b9fd-53cd-4955-8179-e27a73a87213', N'ORION', N'10.212.4.42', N'10.212.4.42', N'001A730ADDDE', 1, 1, 0, CAST(0x00009E78015E7690 AS DateTime), 1, 0, 0)
INSERT [dbo].[CLIENTS] ([Id], [CountryId], [UniqueHash], [Guid], [Name], [ExternalIp], [LocalIp], [Mac], [Instance], [CurrentMode], [ItemCount], [Date], [ServerId], [UselocalId], [IsConnected]) VALUES (13, 1, 64082195661, N'32b41520-7475-458d-a719-efc648a4af00', N'ORION', N'10.212.4.42', N'10.212.4.42', N'001A730ADDDE', 2, 2, 0, CAST(0x00009E78015EDB42 AS DateTime), 1, 0, 0)
SET IDENTITY_INSERT [dbo].[CLIENTS] OFF
/****** Object:  Table [dbo].[CITY]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CITY](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CountryId] [int] NOT NULL,
	[Name] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[Tags] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
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
/****** Object:  Table [dbo].[CATEGORY_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
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
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (1, 2702, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (2, 2703, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (3, 2704, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (4, 2705, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (5, 2706, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (5, 2707, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (6, 2708, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (6, 2709, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (7, 2710, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (8, 2711, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (8, 2712, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (9, 2713, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (9, 2714, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (10, 2715, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (11, 2716, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (11, 2717, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (12, 2718, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (12, 2719, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (13, 2720, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (13, 2721, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (14, 2722, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (14, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (15, 2724, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (16, 2725, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (17, 2718, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (17, 2726, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (18, 2727, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (19, 2728, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (20, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (21, 2702, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (21, 2729, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (22, 2702, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (22, 2730, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (22, 2731, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (23, 2732, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (24, 2733, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (24, 2734, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (25, 2735, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (26, 2736, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (26, 2737, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (27, 2738, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (27, 2739, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (28, 2740, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (29, 2706, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (30, 2707, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (31, 2650, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (31, 2708, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (32, 2741, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (32, 2742, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (33, 2709, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (34, 2743, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (35, 2744, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (35, 2745, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (36, 2746, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (37, 2717, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (37, 2747, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (38, 2716, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (38, 2748, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (39, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (39, 2749, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (40, 2465, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (40, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (40, 2750, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (41, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (41, 2751, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (42, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (42, 2751, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (43, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (43, 2752, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (44, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (44, 2753, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (44, 2754, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (45, 2723, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (45, 2755, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (46, 2756, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (47, 2757, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (48, 2758, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (48, 2759, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (49, 2760, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (50, 2761, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (51, 2762, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (52, 2763, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (52, 2764, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (53, 2650, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (53, 2764, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (54, 2765, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (54, 2766, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (55, 2764, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (55, 2767, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (56, 2768, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (57, 2769, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (58, 2770, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (59, 2771, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (60, 2772, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (61, 2732, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (62, 2773, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (62, 2774, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (63, 2775, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (64, 2776, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (64, 2777, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (65, 2771, 1000)
GO
print 'Processed 100 total records'
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (65, 2776, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (66, 2777, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (66, 2778, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (67, 2771, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (67, 2778, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (68, 2771, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (68, 2779, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (69, 2780, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (69, 2781, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (70, 2771, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (70, 2782, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (70, 2783, 1000)
INSERT [dbo].[CATEGORY_KEYWORDS] ([CategoryId], [KwId], [Factor]) VALUES (71, 2784, 1000)
/****** Object:  Table [dbo].[BRAND_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
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
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (1, 2082, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (2, 2083, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (3, 2084, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (4, 2085, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (5, 2086, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (6, 2087, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (7, 2088, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (8, 2089, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (9, 2090, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (10, 2091, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (11, 2092, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (12, 2093, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (13, 2094, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (14, 2095, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (15, 2096, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (16, 2097, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (17, 2098, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (18, 2099, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (19, 2100, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (20, 2101, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (21, 2102, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (22, 2103, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (23, 2104, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (24, 2105, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (25, 2106, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (26, 2107, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (27, 2108, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (28, 2109, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (28, 2110, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (29, 2111, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (30, 2112, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (31, 2113, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (32, 2114, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (33, 2115, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (34, 2116, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (35, 2117, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (36, 2118, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (37, 2119, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (38, 2120, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (39, 2121, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (40, 2122, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (41, 2123, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (42, 2124, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (43, 2125, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (44, 2126, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (45, 2127, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (46, 2128, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (47, 2129, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (48, 2130, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (49, 2131, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (50, 2132, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (51, 2133, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (52, 2134, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (53, 2135, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (53, 2136, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (54, 2137, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (55, 2138, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (56, 2139, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (57, 2140, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (58, 2141, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (59, 2142, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (60, 2143, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (61, 2144, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (62, 2145, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (63, 2145, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (63, 2146, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (64, 2147, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (65, 2148, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (66, 2149, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (67, 2150, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (68, 2151, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (69, 2152, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (70, 2153, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (71, 2154, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (72, 2155, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (73, 2156, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (74, 2157, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (75, 2158, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (76, 2159, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (77, 2160, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (78, 2161, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (79, 2162, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (80, 2163, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (81, 2164, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (82, 2165, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (83, 2166, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (84, 2167, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (85, 2168, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (86, 2169, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (87, 2170, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (88, 2171, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (89, 2172, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (90, 2173, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (91, 2174, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (92, 2175, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (92, 2176, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (93, 2177, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (94, 2178, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (95, 2179, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (96, 2180, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (97, 2181, 1000)
GO
print 'Processed 100 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (98, 2182, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (99, 2183, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (100, 2184, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (101, 2185, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (102, 2186, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (103, 2187, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (104, 2188, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (105, 2189, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (105, 2190, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (106, 2191, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (107, 2192, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (108, 2193, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (109, 2194, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (110, 2195, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (110, 2196, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (111, 2197, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (112, 2198, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (113, 2199, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (114, 2196, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (114, 2200, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (115, 2201, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (116, 2202, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (116, 2203, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (117, 2204, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (118, 2205, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (119, 2206, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (120, 2207, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (121, 2135, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (121, 2208, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (122, 2209, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (123, 2210, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (124, 2211, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (125, 2212, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (126, 2213, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (127, 2214, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (128, 2215, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (128, 2216, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (128, 2217, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (128, 2218, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (129, 2219, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (130, 2220, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (130, 2221, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (131, 2222, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (132, 2223, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (133, 2224, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (134, 2225, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (135, 2226, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (136, 2227, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (137, 2228, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (138, 2229, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (139, 2230, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (140, 2231, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (141, 2232, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (142, 2233, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (143, 2234, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (144, 2235, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (145, 2236, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (146, 2237, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (147, 2238, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (148, 2239, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (149, 2240, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (150, 2241, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (151, 2242, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (151, 2243, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (152, 2244, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (153, 2245, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (154, 2246, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (155, 2247, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (156, 2248, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (157, 2249, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (158, 2250, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (159, 2251, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (159, 2252, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (160, 2253, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (161, 2254, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (162, 2255, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (163, 2256, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (164, 2257, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (165, 2258, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (166, 2259, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (167, 2260, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (167, 2261, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (168, 2262, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (169, 2263, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (170, 2264, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (171, 2265, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (172, 2266, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (173, 2267, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (174, 2268, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (175, 2269, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (176, 2270, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (177, 2271, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (178, 2272, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (179, 2273, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (180, 2274, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (181, 2275, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (182, 2276, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (182, 2277, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (183, 2278, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (184, 2279, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (184, 2280, 1000)
GO
print 'Processed 200 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (185, 2281, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (186, 2282, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (187, 2283, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (188, 2284, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (189, 2285, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (190, 2286, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (191, 2287, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (192, 2288, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (193, 2289, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (194, 2146, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (194, 2289, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (195, 2290, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (196, 2291, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (197, 2292, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (198, 2293, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (199, 2294, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (200, 2295, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (200, 2296, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (201, 2297, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (202, 2298, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (202, 2299, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (203, 2300, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (204, 2301, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (205, 2302, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (205, 2303, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (206, 2304, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (207, 2305, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (208, 2306, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (209, 2307, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (210, 2308, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (211, 2309, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (212, 2310, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (213, 2311, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (214, 2312, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (215, 2313, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (215, 2314, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (216, 2315, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (217, 2316, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (217, 2317, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (217, 2318, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (218, 2319, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (219, 2320, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (220, 2321, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (220, 2322, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (221, 2323, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (222, 2324, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (223, 2325, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (224, 2326, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (225, 2327, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (226, 2328, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (227, 2329, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (228, 2330, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (229, 2331, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (230, 2332, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (231, 2333, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (232, 2334, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (232, 2335, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (233, 2336, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (233, 2337, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (234, 2338, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (234, 2339, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (235, 2340, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (235, 2341, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (236, 2342, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (236, 2343, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (237, 2344, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (237, 2345, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (238, 2346, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (238, 2347, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (239, 2348, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (239, 2349, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (240, 2350, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (240, 2351, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (241, 2352, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (241, 2353, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (242, 2354, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (242, 2355, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (243, 2356, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (243, 2357, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (244, 2358, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (244, 2359, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (245, 2360, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (245, 2361, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (246, 2362, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (247, 2363, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (248, 2364, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (249, 2365, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (250, 2366, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (251, 2367, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (251, 2368, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (252, 2369, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (253, 2370, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (254, 2371, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (255, 2372, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (256, 2373, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (257, 2374, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (258, 2375, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (259, 2376, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (260, 2377, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (261, 2378, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (262, 2379, 1000)
GO
print 'Processed 300 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (263, 2380, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (264, 2381, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (265, 2382, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (266, 2383, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (267, 2384, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (268, 2385, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (269, 2386, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (270, 2387, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (271, 2388, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (272, 2389, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (273, 2390, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (274, 2391, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (275, 2280, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (275, 2392, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (276, 2393, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (277, 2394, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (278, 2395, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (279, 2396, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (280, 2397, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (281, 2280, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (281, 2398, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (282, 2399, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (283, 2400, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (284, 2401, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (285, 2402, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (286, 2403, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (287, 2404, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (288, 2405, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (289, 2406, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (290, 2407, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (291, 2408, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (292, 2409, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (293, 2410, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (294, 2411, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (295, 2412, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (296, 2413, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (297, 2414, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (298, 2415, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (299, 2416, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (300, 2417, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (301, 2418, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (302, 2419, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (303, 2420, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (304, 2421, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (305, 2280, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (305, 2422, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (306, 2423, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (307, 2424, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (308, 2425, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (309, 2426, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (310, 2427, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (311, 2428, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (312, 2429, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (313, 2430, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (314, 2431, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (315, 2432, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (316, 2433, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (317, 2434, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (318, 2435, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (319, 2436, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (320, 2437, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (321, 2438, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (322, 2439, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (323, 2440, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (323, 2441, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (324, 2442, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (325, 2443, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (326, 2444, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (327, 2445, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (328, 2446, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (329, 2447, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (330, 2448, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (330, 2449, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (331, 2450, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (332, 2451, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (333, 2452, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (334, 2453, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (335, 2454, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (336, 2455, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (337, 2456, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (338, 2457, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (339, 2458, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (340, 2459, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (341, 2460, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (342, 2461, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (343, 2462, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (344, 2296, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (345, 2463, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (346, 2464, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (347, 2465, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (348, 2466, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (349, 2467, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (350, 2468, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (351, 2469, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (352, 2470, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (353, 2471, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (354, 2472, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (355, 2473, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (356, 2474, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (357, 2475, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (358, 2476, 1000)
GO
print 'Processed 400 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (359, 2477, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (360, 2478, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (361, 2479, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (362, 2480, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (363, 2135, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (363, 2481, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (364, 2482, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (365, 2483, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (366, 2484, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (367, 2485, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (368, 2486, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (369, 2487, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (370, 2488, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (371, 2489, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (372, 2490, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (372, 2491, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (373, 2492, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (374, 2493, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (375, 2494, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (376, 2495, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (377, 2496, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (378, 2497, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (379, 2498, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (380, 2499, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (381, 2500, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (382, 2501, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (383, 2502, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (384, 2503, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (385, 2504, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (385, 2505, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (386, 2506, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (387, 2507, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (388, 2508, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (389, 2509, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (390, 2510, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (391, 2511, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (392, 2512, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (393, 2513, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (394, 2514, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (394, 2515, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (395, 2516, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (395, 2517, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (395, 2518, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (396, 2519, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (397, 2520, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (398, 2521, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (399, 2522, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (400, 2523, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (401, 2524, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (402, 2525, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (403, 2526, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (404, 2527, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (404, 2528, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (405, 2529, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (406, 2530, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (407, 2531, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (408, 2532, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (409, 2533, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (410, 2534, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (411, 2535, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (412, 2536, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (413, 2537, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (414, 2538, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (415, 2539, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (416, 2540, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (417, 2541, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (418, 2542, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (419, 2543, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (420, 2544, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (421, 2545, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (422, 2546, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (423, 2547, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (423, 2548, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (424, 2549, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (425, 2550, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (426, 2551, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (426, 2552, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (427, 2553, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (428, 2554, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (429, 2555, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (430, 2556, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (431, 2557, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (432, 2558, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (433, 2559, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (434, 2560, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (435, 2561, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (436, 2562, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (437, 2563, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (438, 2564, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (439, 2565, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (440, 2566, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (441, 2567, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (442, 2568, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (443, 2569, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (444, 2570, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (445, 2571, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (446, 2572, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (447, 2573, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (447, 2574, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (448, 2575, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (449, 2576, 1000)
GO
print 'Processed 500 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (450, 2146, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (451, 2577, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (452, 2578, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (453, 2579, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (454, 2580, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (455, 2581, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (455, 2582, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (456, 2583, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (457, 2584, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (458, 2585, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (458, 2586, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (459, 2587, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (460, 2588, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (461, 2589, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (462, 2590, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (463, 2591, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (464, 2591, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (464, 2592, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (465, 2593, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (466, 2594, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (466, 2595, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (467, 2594, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (468, 2596, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (469, 2597, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (470, 2598, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (471, 2599, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (472, 2600, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (473, 2601, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (474, 2602, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (475, 2603, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (476, 2135, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (476, 2603, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (477, 2604, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (477, 2605, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (478, 2606, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (479, 2607, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (480, 2608, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (481, 2609, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (482, 2610, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (483, 2611, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (484, 2612, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (485, 2613, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (486, 2614, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (487, 2615, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (488, 2616, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (489, 2617, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (490, 2618, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (490, 2619, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (490, 2620, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (491, 2621, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (492, 2622, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (493, 2623, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (494, 2624, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (495, 2625, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (496, 2626, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (497, 2627, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (498, 2628, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (499, 2629, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (500, 2630, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (500, 2631, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (501, 2632, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (502, 2633, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (503, 2634, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (504, 2635, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (505, 2636, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (506, 2637, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (506, 2638, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (506, 2639, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (507, 2640, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (508, 2089, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (508, 2641, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (509, 2642, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (510, 2643, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (510, 2644, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (511, 2645, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (512, 2646, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (513, 2296, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (513, 2647, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (514, 2648, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (515, 2649, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (516, 2650, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (517, 2651, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (518, 2652, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (519, 2653, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (520, 2654, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (521, 2655, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (521, 2656, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (522, 2657, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (523, 2658, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (524, 2659, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (525, 2660, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (526, 2661, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (527, 2662, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (528, 2663, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (529, 2664, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (530, 2665, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (531, 2666, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (532, 2667, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (533, 2668, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (534, 2669, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (535, 2670, 1000)
GO
print 'Processed 600 total records'
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (535, 2671, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (536, 2672, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (537, 2673, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (537, 2674, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (538, 2675, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (539, 2676, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (540, 2677, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (541, 2678, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (541, 2679, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (542, 2680, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (543, 2681, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (544, 2682, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (545, 2683, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (546, 2684, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (547, 2685, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (548, 2686, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (549, 2687, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (550, 2688, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (550, 2689, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (551, 2690, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (552, 2691, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (553, 2692, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (554, 2693, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (555, 2694, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (556, 2695, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (557, 2696, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (558, 2697, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (559, 2698, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (560, 2699, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (561, 2700, 1000)
INSERT [dbo].[BRAND_KEYWORDS] ([BrandId], [KwId], [Factor]) VALUES (562, 2701, 1000)
/****** Object:  Table [dbo].[COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
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
	[Name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Address1] [varchar](128) COLLATE Latin1_General_CI_AS NOT NULL,
	[Address2] [varchar](128) COLLATE Latin1_General_CI_AS NULL,
	[State] [varchar](32) COLLATE Latin1_General_CI_AS NULL,
	[Phone] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[Fax] [varchar](15) COLLATE Latin1_General_CI_AS NOT NULL,
	[Ip] [varchar](15) COLLATE Latin1_General_CI_AS NULL,
 CONSTRAINT [PK_COMPANY] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[COMPANY] ON
INSERT [dbo].[COMPANY] ([Id], [CityId], [CountryId], [Name], [Address1], [Address2], [State], [Phone], [Fax], [Ip]) VALUES (1, -1, -1, N'Crexta Demo', N'Demo', NULL, NULL, N'11111111', N'1111111', NULL)
SET IDENTITY_INSERT [dbo].[COMPANY] OFF
/****** Object:  StoredProcedure [dbo].[SEQUENCE_SetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  StoredProcedure [dbo].[SEQUENCE_ResetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  Table [dbo].[RULES]    Script Date: 06/05/2011 22:32:38 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[RULES](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
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
SET IDENTITY_INSERT [dbo].[RULES] ON
INSERT [dbo].[RULES] ([Id], [CompanyId], [Name], [Path], [Data], [Date], [IsLocked]) VALUES (2, 1, N'test', N'', 0x0001000000FFFFFFFF01000000000000000C02000000444372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C0501000000234372657874612E436F6D6D6F6E2E437261776C657252756C65436F6C6C656374696F6E0500000009635F56657273696F6E06635F4E616D650E635F52756C65526F6F745061746807635F4F776E65720A635F52756C654C697374000101020308840153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C657252756C652C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D020000000100000006030000000474657374060400000010433A5C4372657874615C52756C65735C0A09050000000405000000840153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C657252756C652C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E0400001B4372657874612E436F6D6D6F6E2E437261776C657252756C655B5D02000000080809060000000100000005000000070600000000010000000400000004194372657874612E436F6D6D6F6E2E437261776C657252756C650200000009070000000D030507000000194372657874612E436F6D6D6F6E2E437261776C657252756C650D00000009635F56657273696F6E06635F4E616D650F635F55524C4D61746368526567657812635F436F6E6E656374696F6E537472696E6715635F496E6E657253514C436F6D6D616E645465787413635F44617461626173655461626C654E616D6510635F496E6E65724572726F725465787410635F496E6E65724572726F72436F64650C635F496E6E65724572726F720B635F4372697465726961730C635F437265617465446174650C635F4C6173745570646174650B635F436C69636B4974656D000101010101010000040000040808012F4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724372697465726961436F6C6C656374696F6E020000000D0D2D4372657874612E436F6D6D6F6E2E437261776C65722E43726974657269614974656D732E436C69636B4974656D02000000020000000100000006080000000474657374060900000006746574736574060A00000000090A000000060B0000000474657374060C000000024F4B0000000000090D0000002036930BA4EFCD882036930BA4EFCD880A050D0000002F4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724372697465726961436F6C6C656374696F6E0200000009635F56657273696F6E0A635F52756C654C697374000308900153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269612C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D0200000001000000090E000000040E000000900153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269612C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E040000274372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269615B5D020000000808090F0000000000000004000000070F00000000010000000400000004254372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724372697465726961020000000D040B, CAST(0x00009EF70017045A AS DateTime), 0)
SET IDENTITY_INSERT [dbo].[RULES] OFF
/****** Object:  Table [dbo].[DB_FIELDS]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[DB_FIELDS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CompanyId] [int] NOT NULL,
	[FieldName] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[FieldType] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
 CONSTRAINT [PK_DB_FIELDS] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[CREXTORS]    Script Date: 06/05/2011 22:32:37 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[CREXTORS](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RuleId] [int] NULL,
	[CompanyId] [int] NOT NULL,
	[ShortName] [varchar](32) COLLATE Latin1_General_CI_AS NOT NULL,
	[Name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Tags] [varchar](64) COLLATE Latin1_General_CI_AS NULL,
	[Url] [varchar](320) COLLATE Latin1_General_CI_AS NOT NULL,
	[TotalItems] [int] NULL,
	[LastCrawlStart] [datetime] NULL,
	[LastCrawlFinish] [datetime] NULL,
	[IsPaid] [bit] NOT NULL,
	[IsCrawled] [bit] NULL,
	[IsActive] [bit] NOT NULL,
	[UseResources] [bit] NOT NULL,
	[Rating] [float] NOT NULL,
	[Priority] [float] NULL,
	[TotalVotes] [int] NOT NULL,
 CONSTRAINT [PK_TBL_STORES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  Table [dbo].[RULE_BACKUPS]    Script Date: 06/05/2011 22:32:38 ******/
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
INSERT [dbo].[RULE_BACKUPS] ([RuleId], [Date], [Name], [Data]) VALUES (2, CAST(0x00009EF700175D81 AS DateTime), N'test', 0x0001000000FFFFFFFF01000000000000000C02000000444372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C0501000000234372657874612E436F6D6D6F6E2E437261776C657252756C65436F6C6C656374696F6E0500000009635F56657273696F6E06635F4E616D650E635F52756C65526F6F745061746807635F4F776E65720A635F52756C654C697374000101020308840153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C657252756C652C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D020000000100000006030000000474657374060400000010433A5C4372657874615C52756C65735C0A09050000000405000000840153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C657252756C652C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E0400001B4372657874612E436F6D6D6F6E2E437261776C657252756C655B5D02000000080809060000000100000002000000070600000000010000000400000004194372657874612E436F6D6D6F6E2E437261776C657252756C650200000009070000000D030507000000194372657874612E436F6D6D6F6E2E437261776C657252756C650D00000009635F56657273696F6E06635F4E616D650F635F55524C4D61746368526567657812635F436F6E6E656374696F6E537472696E6715635F496E6E657253514C436F6D6D616E645465787413635F44617461626173655461626C654E616D6510635F496E6E65724572726F725465787410635F496E6E65724572726F72436F64650C635F496E6E65724572726F720B635F4372697465726961730C635F437265617465446174650C635F4C6173745570646174650B635F436C69636B4974656D000101010101010000040000040808012F4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724372697465726961436F6C6C656374696F6E020000000D0D2D4372657874612E436F6D6D6F6E2E437261776C65722E43726974657269614974656D732E436C69636B4974656D02000000020000000100000006080000000474657374060900000006746574736574060A00000000090A000000060B0000000474657374060C000000024F4B0000000000090D0000002036930BA4EFCD882036930BA4EFCD880A050D0000002F4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724372697465726961436F6C6C656374696F6E0200000009635F56657273696F6E0A635F52756C654C697374000308900153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269612C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D0200000001000000090E000000040E000000900153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269612C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E040000274372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269615B5D020000000808090F0000000100000001000000070F00000000010000000400000004254372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269610200000009100000000D030510000000254372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269611400000009635F56657273696F6E06635F4E616D6509635F584669656C64490A635F584669656C6449490B635F584669656C644949490C635F436F6C756D6E4E616D6505635F55524C0D635F44656661756C74546578740C635F436F6C756D6E547970650E635F436F6C756D6E4C656E67746811635F55707065724361736556616C75657311635F4C6F7765724361736556616C75657311635F53747269704153434949436F6465730F635F436C65617248544D4C5461677312635F436C656172576869746553706163657313635F436C65617248544D4C436F6D6D656E747311635F436C6561725363726970745461677310635F55736555524C466F724D6174636818635F457865637574696F6E506970656C696E654974656D730D635F4578636C7564654C6973740001010101010101030000000000000000000404081F53797374656D2E556E69747953657269616C697A6174696F6E486F6C646572080101010101010101334372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269614974656D436F6C6C656374696F6E02000000324372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C697374436F6C6C656374696F6E0200000002000000020000000611000000056A6B73646606120000000006130000000006140000000006150000000970726F647563746964090A0000000617000000022D3109180000000000000000000000000000000919000000091A00000004180000001F53797374656D2E556E69747953657269616C697A6174696F6E486F6C64657203000000044461746109556E697479547970650C417373656D626C794E616D6501000108061B0000000C53797374656D2E496E74333204000000061C0000004B6D73636F726C69622C2056657273696F6E3D342E302E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D623737613563353631393334653038390519000000334372657874612E436F6D6D6F6E2E437261776C65722E437261776C657243726974657269614974656D436F6C6C656374696F6E0200000009635F56657273696F6E0A635F52756C654C697374000308A00153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E496E74657266616365732E49437261776C657243726974657269614974656D2C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D0200000001000000091D000000051A000000324372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C697374436F6C6C656374696F6E0200000009635F56657273696F6E0A635F52756C654C697374000308930153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C6973742C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D0200000001000000091E000000041D000000A00153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E496E74657266616365732E49437261776C657243726974657269614974656D2C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E040000374372657874612E436F6D6D6F6E2E437261776C65722E496E74657266616365732E49437261776C657243726974657269614974656D5B5D020000000808091F0000000300000003000000041E000000930153797374656D2E436F6C6C656374696F6E732E47656E657269632E4C69737460315B5B4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C6973742C204372657874612E436F6D6D6F6E2C2056657273696F6E3D312E312E302E302C2043756C747572653D6E65757472616C2C205075626C69634B6579546F6B656E3D6E756C6C5D5D03000000065F6974656D73055F73697A65085F76657273696F6E0400002A4372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C6973745B5D02000000080809200000000000000000000000071F00000000010000000400000004354372657874612E436F6D6D6F6E2E437261776C65722E496E74657266616365732E49437261776C657243726974657269614974656D020000000921000000092200000009230000000A072000000000010000000000000004284372657874612E436F6D6D6F6E2E437261776C65722E437261776C65724578636C7564654C6973740200000005210000002D4372657874612E436F6D6D6F6E2E437261776C65722E43726974657269614974656D732E436C69636B4974656D0A00000009635F56657273696F6E06635F4E616D6508635F4C696E6B49440A635F4C696E6B546578740B635F4D757374436C69636B0D635F57616974466F72416A617815635F57616974466F72446F63756D656E744C6F616418635F48696465496E6E657242726F7773657257696E646F770A635F4C696E6B547970650D635F42726F7773657254797065000101010000000004040801010101294372657874612E436F6D6D6F6E2E437261776C65722E456E756D732E436C69636B4974656D5479706502000000274372657874612E436F6D6D6F6E2E437261776C65722E456E756D732E42726F77736572547970650200000002000000020000000624000000056A6B736466062500000000062600000001640000000105D9FFFFFF294372657874612E436F6D6D6F6E2E437261776C65722E456E756D732E436C69636B4974656D54797065010000000776616C75655F5F0008020000000000000005D8FFFFFF274372657874612E436F6D6D6F6E2E437261776C65722E456E756D732E42726F7773657254797065010000000776616C75655F5F000802000000000000000522000000314372657874612E436F6D6D6F6E2E437261776C65722E43726974657269614974656D732E426173696348544D4C4974656D0700000009625F56657273696F6E06625F4E616D650B625F48544D4C426567696E09625F48544D4C456E640E625F526573756C745072656669780A625F456E64436F756E7415625F557365526573756C74417348746D6C4E6F64650001010101000008080102000000010000000629000000056A6B736466062A000000026466062B00000000062C00000000000000000005230000003A4372657874612E436F6D6D6F6E2E437261776C65722E43726974657269614974656D732E48544D4C4E6F6465436F6C6C656374696F6E4974656D0600000009685F56657273696F6E06685F4E616D6507685F587061746811685F526573756C744E6F6465496E64657814685F52657475726E4F6E6C794E6F64655465787410685F52657475726E416C6C4E6F646573000101000000080801010200000001000000062D000000056A6B736466062E000000037364660000000000000B)
/****** Object:  Table [dbo].[URLQUEUE]    Script Date: 06/05/2011 22:32:38 ******/
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
	[UrlHash1] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Url] [varchar](512) COLLATE Latin1_General_CI_AS NOT NULL,
	[UrlMiniPart] [varchar](8) COLLATE Latin1_General_CI_AS NULL,
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
/****** Object:  Table [dbo].[CREXTOR_RESOURCES]    Script Date: 06/05/2011 22:32:37 ******/
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
	[Name] [varchar](64) COLLATE Latin1_General_CI_AS NOT NULL,
	[Url] [varchar](320) COLLATE Latin1_General_CI_AS NOT NULL,
	[Order] [smallint] NOT NULL,
 CONSTRAINT [PK_STORE_RESOURCES] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  StoredProcedure [dbo].[CREXTORS_GetDataset]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  Table [dbo].[RESULTS]    Script Date: 06/05/2011 22:32:38 ******/
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
	[ErrorCode] [varchar](10) COLLATE Latin1_General_CI_AS NULL,
	[ErrorText] [varchar](512) COLLATE Latin1_General_CI_AS NULL,
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
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetPageIndex]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  StoredProcedure [dbo].[URLQUEUE_GetDataset]    Script Date: 06/05/2011 22:32:35 ******/
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
/****** Object:  Default [DF_TBL_BRANDKEYWORDS_factor]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS] ADD  CONSTRAINT [DF_TBL_BRANDKEYWORDS_factor]  DEFAULT ((0)) FOR [Factor]
GO
/****** Object:  Default [DF_TBL_BRANDS_flags]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRANDS] ADD  CONSTRAINT [DF_TBL_BRANDS_flags]  DEFAULT ((0)) FOR [Flags]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_parentid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_parentid]  DEFAULT ((-1)) FOR [ParentId]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_flags]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_flags]  DEFAULT ((0)) FOR [Flags]
GO
/****** Object:  Default [DF_TBL_CATEGORIES_isactive]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORIES] ADD  CONSTRAINT [DF_TBL_CATEGORIES_isactive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_TBL_CATEGORY_KEYWORDS_factor]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] ADD  CONSTRAINT [DF_TBL_CATEGORY_KEYWORDS_factor]  DEFAULT ((0)) FOR [Factor]
GO
/****** Object:  Default [DF_TBL_CLIENTS_countryid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_countryid]  DEFAULT ((1)) FOR [CountryId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_instance]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_instance]  DEFAULT ((1)) FOR [Instance]
GO
/****** Object:  Default [DF_TBL_CLIENTS_itemcount]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_itemcount]  DEFAULT ((0)) FOR [ItemCount]
GO
/****** Object:  Default [DF_TBL_CLIENTS_serverid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_serverid]  DEFAULT ((0)) FOR [ServerId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_preferlocalid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_preferlocalid]  DEFAULT ((0)) FOR [UselocalId]
GO
/****** Object:  Default [DF_TBL_CLIENTS_isconnected]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS] ADD  CONSTRAINT [DF_TBL_CLIENTS_isconnected]  DEFAULT ((0)) FOR [IsConnected]
GO
/****** Object:  Default [DF_COMPANY_CityId]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY] ADD  CONSTRAINT [DF_COMPANY_CityId]  DEFAULT ((-1)) FOR [CityId]
GO
/****** Object:  Default [DF_COMPANY_CountryId]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY] ADD  CONSTRAINT [DF_COMPANY_CountryId]  DEFAULT ((-1)) FOR [CountryId]
GO
/****** Object:  Default [DF_STORE_RESOURCES_categoryid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_categoryid]  DEFAULT ((-1)) FOR [CategoryId]
GO
/****** Object:  Default [DF_STORE_RESOURCES_period]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_period]  DEFAULT ((5)) FOR [Url]
GO
/****** Object:  Default [DF_STORE_RESOURCES_order]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES] ADD  CONSTRAINT [DF_STORE_RESOURCES_order]  DEFAULT ((0)) FOR [Order]
GO
/****** Object:  Default [DF_TBL_STORES_ispaid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_ispaid]  DEFAULT ((0)) FOR [IsPaid]
GO
/****** Object:  Default [DF_TBL_STORES_iscrawled]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_iscrawled]  DEFAULT ((0)) FOR [IsCrawled]
GO
/****** Object:  Default [DF_TBL_STORES_isactive]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_isactive]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_STORES_useresources]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_STORES_useresources]  DEFAULT ((0)) FOR [UseResources]
GO
/****** Object:  Default [DF_TBL_STORES_rank]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_rank]  DEFAULT ((0)) FOR [Rating]
GO
/****** Object:  Default [DF_CREXTORS_Priority]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_CREXTORS_Priority]  DEFAULT ((0)) FOR [Priority]
GO
/****** Object:  Default [DF_TBL_STORES_totalvotes]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS] ADD  CONSTRAINT [DF_TBL_STORES_totalvotes]  DEFAULT ((0)) FOR [TotalVotes]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_dataextractor]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_dataextractor]  DEFAULT ((0)) FOR [ViaWeb]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_urlfounder]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_urlfounder]  DEFAULT ((0)) FOR [ViaService]
GO
/****** Object:  Default [DF_TBL_DOWNLOADS_date]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[DOWNLOADS] ADD  CONSTRAINT [DF_TBL_DOWNLOADS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_LOG_subtype]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_subtype]  DEFAULT ((0)) FOR [SubType]
GO
/****** Object:  Default [DF_TBL_LOG_refid]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_refid]  DEFAULT ((-1)) FOR [RefId]
GO
/****** Object:  Default [DF_TBL_LOG_date]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[LOGS] ADD  CONSTRAINT [DF_TBL_LOG_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_RESULTS_CompanyId]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_CompanyId]  DEFAULT ((-1)) FOR [CompanyId]
GO
/****** Object:  Default [DF_TBL_RESULTS_ErrorCode]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_ErrorCode]  DEFAULT ((0)) FOR [ErrorCode]
GO
/****** Object:  Default [DF_TBL_RESULTS_ErrorText]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_ErrorText]  DEFAULT ('') FOR [ErrorText]
GO
/****** Object:  Default [DF_TBL_RESULTS_Date]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS] ADD  CONSTRAINT [DF_TBL_RESULTS_Date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_RULE_BACKUPS_date]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULE_BACKUPS] ADD  CONSTRAINT [DF_RULE_BACKUPS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_RULES_date]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULES] ADD  CONSTRAINT [DF_TBL_RULES_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_RULES_locked]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULES] ADD  CONSTRAINT [DF_RULES_locked]  DEFAULT ((0)) FOR [IsLocked]
GO
/****** Object:  Default [DF_TBL_SEQUENCE_value]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SEQUENCE] ADD  CONSTRAINT [DF_TBL_SEQUENCE_value]  DEFAULT ((0)) FOR [Value]
GO
/****** Object:  Default [DF_TBL_SERVERS_countryid]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_countryid]  DEFAULT ((1)) FOR [CountryId]
GO
/****** Object:  Default [DF_TBL_SERVERS_instance]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_instance]  DEFAULT ((1)) FOR [Instance]
GO
/****** Object:  Default [DF_TBL_SERVERS_clientcount]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_clientcount]  DEFAULT ((0)) FOR [ClientCount]
GO
/****** Object:  Default [DF_TBL_SERVERS_active]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_active]  DEFAULT ((0)) FOR [IsActive]
GO
/****** Object:  Default [DF_TBL_SERVERS_date]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS] ADD  CONSTRAINT [DF_TBL_SERVERS_date]  DEFAULT (getdate()) FOR [Date]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_serverid]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_serverid]  DEFAULT ((-1)) FOR [ServerId]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_clientid]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_clientid]  DEFAULT ((-1)) FOR [ClientId]
GO
/****** Object:  Default [DF_TBL_QUEUE_hash]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_QUEUE_hash]  DEFAULT ((-1)) FOR [UrlHash]
GO
/****** Object:  Default [DF_URLQUEUE_RetryCount]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_URLQUEUE_RetryCount]  DEFAULT ((0)) FOR [RetryCount]
GO
/****** Object:  Default [DF_TBL_QUEUE_iscrawled]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_QUEUE_iscrawled]  DEFAULT ((0)) FOR [IsCrawled]
GO
/****** Object:  Default [DF_TBL_URLQUEUE_priority]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE] ADD  CONSTRAINT [DF_TBL_URLQUEUE_priority]  DEFAULT ((0)) FOR [Priority]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_BRANDS] FOREIGN KEY([BrandId])
REFERENCES [dbo].[BRANDS] ([Id])
GO
ALTER TABLE [dbo].[BRAND_KEYWORDS] CHECK CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_BRANDS]
GO
/****** Object:  ForeignKey [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[BRAND_KEYWORDS]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS] FOREIGN KEY([KwId])
REFERENCES [dbo].[KEYWORDS] ([Id])
GO
ALTER TABLE [dbo].[BRAND_KEYWORDS] CHECK CONSTRAINT [FK_TBL_BRANDKEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([Id])
GO
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] CHECK CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_CATEGORY_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CATEGORY_KEYWORDS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS] FOREIGN KEY([KwId])
REFERENCES [dbo].[KEYWORDS] ([Id])
GO
ALTER TABLE [dbo].[CATEGORY_KEYWORDS] CHECK CONSTRAINT [FK_TBL_CATEGORY_KEYWORDS_TBL_KEYWORDS]
GO
/****** Object:  ForeignKey [FK_TBL_CITY_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CITY]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CITY_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CITY] CHECK CONSTRAINT [FK_TBL_CITY_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_CLIENTS_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CLIENTS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_CLIENTS_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[CLIENTS] CHECK CONSTRAINT [FK_TBL_CLIENTS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_COMPANY_CITY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY]  WITH NOCHECK ADD  CONSTRAINT [FK_COMPANY_CITY] FOREIGN KEY([CityId])
REFERENCES [dbo].[CITY] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[COMPANY] NOCHECK CONSTRAINT [FK_COMPANY_CITY]
GO
/****** Object:  ForeignKey [FK_COMPANY_COUNTRY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[COMPANY]  WITH NOCHECK ADD  CONSTRAINT [FK_COMPANY_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[COMPANY] NOCHECK CONSTRAINT [FK_COMPANY_COUNTRY]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_CATEGORIES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH NOCHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_CATEGORIES] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[CATEGORIES] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] NOCHECK CONSTRAINT [FK_STORE_RESOURCES_CATEGORIES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_RESOURCE_TYPES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_RESOURCE_TYPES] FOREIGN KEY([TypeId])
REFERENCES [dbo].[RESOURCE_TYPES] ([Id])
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] CHECK CONSTRAINT [FK_STORE_RESOURCES_RESOURCE_TYPES]
GO
/****** Object:  ForeignKey [FK_STORE_RESOURCES_STORES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTOR_RESOURCES]  WITH CHECK ADD  CONSTRAINT [FK_STORE_RESOURCES_STORES] FOREIGN KEY([CrextorId])
REFERENCES [dbo].[CREXTORS] ([Id])
GO
ALTER TABLE [dbo].[CREXTOR_RESOURCES] CHECK CONSTRAINT [FK_STORE_RESOURCES_STORES]
GO
/****** Object:  ForeignKey [FK_CREXTORS_COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH CHECK ADD  CONSTRAINT [FK_CREXTORS_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[CREXTORS] CHECK CONSTRAINT [FK_CREXTORS_COMPANY]
GO
/****** Object:  ForeignKey [FK_CREXTORS_RULES]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH NOCHECK ADD  CONSTRAINT [FK_CREXTORS_RULES] FOREIGN KEY([RuleId])
REFERENCES [dbo].[RULES] ([Id])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTORS] NOCHECK CONSTRAINT [FK_CREXTORS_RULES]
GO
/****** Object:  ForeignKey [FK_STORES_STORE_EXTENDED]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[CREXTORS]  WITH NOCHECK ADD  CONSTRAINT [FK_STORES_STORE_EXTENDED] FOREIGN KEY([Id])
REFERENCES [dbo].[CREXTOR_EXTENDED] ([CrextorId])
NOT FOR REPLICATION
GO
ALTER TABLE [dbo].[CREXTORS] NOCHECK CONSTRAINT [FK_STORES_STORE_EXTENDED]
GO
/****** Object:  ForeignKey [FK_DB_FIELDS_COMPANY]    Script Date: 06/05/2011 22:32:37 ******/
ALTER TABLE [dbo].[DB_FIELDS]  WITH CHECK ADD  CONSTRAINT [FK_DB_FIELDS_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[DB_FIELDS] CHECK CONSTRAINT [FK_DB_FIELDS_COMPANY]
GO
/****** Object:  ForeignKey [FK_RESULTS_COMPANY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS]  WITH CHECK ADD  CONSTRAINT [FK_RESULTS_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[RESULTS] CHECK CONSTRAINT [FK_RESULTS_COMPANY]
GO
/****** Object:  ForeignKey [FK_RESULTS_URLQUEUE]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RESULTS]  WITH CHECK ADD  CONSTRAINT [FK_RESULTS_URLQUEUE] FOREIGN KEY([QueueId])
REFERENCES [dbo].[URLQUEUE] ([Id])
GO
ALTER TABLE [dbo].[RESULTS] CHECK CONSTRAINT [FK_RESULTS_URLQUEUE]
GO
/****** Object:  ForeignKey [FK_RULE_BACKUPS_RULES]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULE_BACKUPS]  WITH CHECK ADD  CONSTRAINT [FK_RULE_BACKUPS_RULES] FOREIGN KEY([RuleId])
REFERENCES [dbo].[RULES] ([Id])
GO
ALTER TABLE [dbo].[RULE_BACKUPS] CHECK CONSTRAINT [FK_RULE_BACKUPS_RULES]
GO
/****** Object:  ForeignKey [FK_RULES_COMPANY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[RULES]  WITH CHECK ADD  CONSTRAINT [FK_RULES_COMPANY] FOREIGN KEY([CompanyId])
REFERENCES [dbo].[COMPANY] ([Id])
GO
ALTER TABLE [dbo].[RULES] CHECK CONSTRAINT [FK_RULES_COMPANY]
GO
/****** Object:  ForeignKey [FK_TBL_SERVERS_TBL_COUNTRY]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[SERVERS]  WITH CHECK ADD  CONSTRAINT [FK_TBL_SERVERS_TBL_COUNTRY] FOREIGN KEY([CountryId])
REFERENCES [dbo].[COUNTRY] ([Id])
GO
ALTER TABLE [dbo].[SERVERS] CHECK CONSTRAINT [FK_TBL_SERVERS_TBL_COUNTRY]
GO
/****** Object:  ForeignKey [FK_TBL_QUEUE_TBL_STORES]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_QUEUE_TBL_STORES] FOREIGN KEY([CrextorId])
REFERENCES [dbo].[CREXTORS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_QUEUE_TBL_STORES]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_CLIENTS]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_URLQUEUE_TBL_CLIENTS] FOREIGN KEY([ClientId])
REFERENCES [dbo].[CLIENTS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_URLQUEUE_TBL_CLIENTS]
GO
/****** Object:  ForeignKey [FK_TBL_URLQUEUE_TBL_SERVERS]    Script Date: 06/05/2011 22:32:38 ******/
ALTER TABLE [dbo].[URLQUEUE]  WITH NOCHECK ADD  CONSTRAINT [FK_TBL_URLQUEUE_TBL_SERVERS] FOREIGN KEY([ServerId])
REFERENCES [dbo].[SERVERS] ([Id])
GO
ALTER TABLE [dbo].[URLQUEUE] CHECK CONSTRAINT [FK_TBL_URLQUEUE_TBL_SERVERS]
GO
