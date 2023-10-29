CREATE DATABASE LabExchange; 

USE [LabExchange] 

GO

CREATE TABLE dbo.tblTestTypeCategory (
	TestTypeCategoryId tinyint IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	TestTypeCategory varchar(20) NOT NULL
); 

CREATE TABLE dbo.tblTestType (
	TestTypeId int IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	TestTypeName varchar(100) NOT NULL, 
	TestTypeCategoryId tinyint NOT NULL FOREIGN KEY REFERENCES dbo.tblTestTypeCategory(TestTypeCategoryId), 
	TestTypeNormalValues varchar(4000) NOT NULL, 
	IsAbnormalValuesCritical bit DEFAULT(0) NOT NULL, 
	IsValidTestType bit DEFAULT(0) NOT NULL, 
	ApiUserId int NOT NULL, 
	RecordValidFrom datetime2 GENERATED ALWAYS AS ROW START NOT NULL,
    RecordValidTo datetime2 GENERATED ALWAYS AS ROW END NOT NULL,
    PERIOD FOR SYSTEM_TIME (RecordValidFrom, RecordValidTo)
)
WITH (SYSTEM_VERSIONING = ON); 

CREATE TABLE dbo.tblVendor (
	VendorId int IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	VendorName varchar(250) NOT NULL, 
	VendorStreetAddress1 varchar(250) NOT NULL, 
	VendorStreetAddress2 varchar(250) NULL, 
	VendorCity varchar(100) NULL, 
	VendorState char(2) NOT NULL, 
	VendorZipCode varchar(10) NOT NULL, 
	VendorPhone varchar(10) NOT NULL, 
	VendorExtension varchar(10) NULL, 
	ApiUserId int NOT NULL, 
	RecordValidFrom datetime2 GENERATED ALWAYS AS ROW START NOT NULL,
    RecordValidTo datetime2 GENERATED ALWAYS AS ROW END NOT NULL,
    PERIOD FOR SYSTEM_TIME (RecordValidFrom, RecordValidTo)
)
WITH (SYSTEM_VERSIONING = ON); 

CREATE TABLE dbo.tblTestResult (
	TestResultId bigint IDENTITY(1,1) PRIMARY KEY NOT NULL, 
	VendorResultId varchar(100) NOT NULL, 
	SubmissionDateTime datetime NOT NULL, 
	ResultGenerationDateTime datetime NOT NULL, 
	PatientMedicalRecordNum varchar(24) NOT NULL, 
	PatientDateOfBirth date NOT NULL, 
	ResultTestTypeId int NOT NULL FOREIGN KEY REFERENCES dbo.tblTestType(TestTypeId), 
	VendorId int NOT NULL FOREIGN KEY REFERENCES dbo.tblVendor(VendorId), 
	TestResultShortDescription varchar(250), 
	TestResultNotes varchar(8000), 
	FlagForReview bit DEFAULT(0), 
	IsValidTestResult bit DEFAULT(0), 
	ApiUserId int NOT NULL, 
	RecordValidFrom datetime2 GENERATED ALWAYS AS ROW START NOT NULL,
    RecordValidTo datetime2 GENERATED ALWAYS AS ROW END NOT NULL,
    PERIOD FOR SYSTEM_TIME (RecordValidFrom, RecordValidTo)
)
WITH (SYSTEM_VERSIONING = ON); 


SET IDENTITY_INSERT dbo.tblTestTypeCategory ON

INSERT INTO dbo.tblTestTypeCategory (TestTypeCategoryId, TestTypeCategory)
VALUES (1, 'Urine'), 
(2, 'Blood'), 
(3, 'Biopsy'), 
(4, 'Swab'), 
(5, 'CT'), 
(6, 'MRI'), 
(7, 'XRay')

SET IDENTITY_INSERT dbo.tblTestTypeCategory OFF