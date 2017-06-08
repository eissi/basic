
CREATE TABLE dbo.AvailabilityCheck
(
AvailabilityIndicator bit NOT NULL CONSTRAINT DF_AvailabilityCheck_AvailabilityIndicator DEFAULT (1),
CONSTRAINT PK_AvailabilityCheck PRIMARY KEY (AvailabilityIndicator),
CONSTRAINT CK_AvailabilityCheck_AvailabilityIndicator CHECK (AvailabilityIndicator = 1),
);
GO
 
CREATE PROCEDURE dbo.spCheckDbAvailability
AS
SET XACT_ABORT, NOCOUNT ON;
 
BEGIN TRANSACTION;
 
INSERT INTO dbo.AvailabilityCheck (AvailabilityIndicator)
DEFAULT VALUES;
 
EXEC sys.sp_flush_log;
 
SELECT AvailabilityIndicator
FROM dbo.AvailabilityCheck;
 
ROLLBACK;

drop table AvailabilityCheck

SELECT * FROM INFORMATION_SCHEMA.TABLES 

exec dbo.spCheckDbAvailability