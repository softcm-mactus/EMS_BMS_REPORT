
IF  NOT EXISTS (
	SELECT * FROM sys.objects 
	WHERE object_id = OBJECT_ID(N'[dbo].[TBL_ReportGroups]') AND type in (N'U'))
BEGIN
CREATE TABLE dbo.TBL_ReportGroups(
	ExternalLogId int NOT NULL,
	ColumnName VARCHAR(200) NOT NULL,
	GroupName VARCHAR(100) NOT NULL,
	CategoryName VARCHAR(100) NOT NULL,
);
END

Alter table dbo.[TBL_ReportColumns]
ADD 
	MinAllowedValue [float] NULL;

Alter table dbo.[TBL_ReportColumns]
ADD 
	MaxAllowedValue [float] NULL;

GO
