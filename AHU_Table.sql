USE [Mactus_MaivaEMSConfiguration]
GO

CREATE TABLE dbo.TBL_ReportGroups(
	ExternalLogId int NOT NULL,
	ColumnName VARCHAR(200) NOT NULL,
	GroupName VARCHAR(100) NOT NULL,
	CategoryName VARCHAR(100) NOT NULL,
);
GO
