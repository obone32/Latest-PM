--***********************************************************
--UPDATE Stored Procedure for Employee table
--***********************************************************
GO

USE PMMS
GO

IF EXISTS (SELECT sys.objects.name FROM sys.objects INNER JOIN sys.schemas ON sys.objects.schema_id = sys.schemas.schema_id WHERE sys.objects.name = 'EmployeeUpdate'    and sys.objects.type = 'P') 
DROP PROCEDURE [EmployeeUpdate]
GO

CREATE PROCEDURE [EmployeeUpdate] 
      @NewFirstName varchar(8000)
     ,@NewLastName varchar(8000)
     ,@NewDOB datetime
     ,@NewDOJ datetime
     ,@NewGender varchar(8000)
     ,@NewEMail varchar(8000)
     ,@NewMobile varchar(8000)
     ,@NewAddress1 varchar(8000)
     ,@NewAddress2 varchar(8000)
     ,@NewSalary decimal(18,2)
     ,@NewSignatureURL varchar(8000)
     ,@NewCompanyID int
     ,@NewAddUserID int
     ,@NewAddDate datetime
     ,@NewArchiveUserID int
     ,@NewArchiveDate datetime
     ,@OldEmployeeID int
     ,@OldFirstName varchar(8000)
     ,@OldLastName varchar(8000)
     ,@OldDOB datetime
     ,@OldDOJ datetime
     ,@OldGender varchar(8000)
     ,@OldEMail varchar(8000)
     ,@OldMobile varchar(8000)
     ,@OldAddress1 varchar(8000)
     ,@OldAddress2 varchar(8000)
     ,@OldSalary decimal(18,2)
     ,@OldSignatureURL varchar(8000)
     ,@OldCompanyID int
     ,@OldAddUserID int
     ,@OldAddDate datetime
     ,@OldArchiveUserID int
     ,@OldArchiveDate datetime
     ,@ReturnValue int OUTPUT
AS
BEGIN

SET NOCOUNT ON

BEGIN TRANSACTION 

BEGIN TRY 

UPDATE [Employee]
SET
      [FirstName] = @NewFirstName
     ,[LastName] = @NewLastName
     ,[DOB] = @NewDOB
     ,[DOJ] = @NewDOJ
     ,[Gender] = @NewGender
     ,[EMail] = @NewEMail
     ,[Mobile] = @NewMobile
     ,[Address1] = @NewAddress1
     ,[Address2] = @NewAddress2
     ,[Salary] = @NewSalary
     ,[SignatureURL] = @NewSignatureURL
     ,[CompanyID] = @NewCompanyID
     ,[AddUserID] = @NewAddUserID
     ,[AddDate] = @NewAddDate
     ,[ArchiveUserID] = @NewArchiveUserID
     ,[ArchiveDate] = @NewArchiveDate
WHERE
     [EmployeeID] = @OldEmployeeID
AND [FirstName] = @OldFirstName
AND ((@OldLastName IS NULL AND [LastName] IS NULL) OR [LastName] = @OldLastName)
AND [DOB] = @OldDOB
AND [DOJ] = @OldDOJ
AND [Gender] = @OldGender
AND ((@OldEMail IS NULL AND [EMail] IS NULL) OR [EMail] = @OldEMail)
AND [Mobile] = @OldMobile
AND ((@OldAddress1 IS NULL AND [Address1] IS NULL) OR [Address1] = @OldAddress1)
AND ((@OldAddress2 IS NULL AND [Address2] IS NULL) OR [Address2] = @OldAddress2)
AND [Salary] = @OldSalary
AND ((@OldSignatureURL IS NULL AND [SignatureURL] IS NULL) OR [SignatureURL] = @OldSignatureURL)
AND [CompanyID] = @OldCompanyID
AND [AddUserID] = @OldAddUserID
AND [AddDate] = @OldAddDate
AND ((@OldArchiveUserID IS NULL AND [ArchiveUserID] IS NULL) OR [ArchiveUserID] = @OldArchiveUserID)
AND ((@OldArchiveDate IS NULL AND [ArchiveDate] IS NULL) OR [ArchiveDate] = @OldArchiveDate)

IF @@ROWCOUNT = 0
BEGIN
     ROLLBACK TRANSACTION
     SET @ReturnValue = 0
     RETURN @ReturnValue
END
ELSE
BEGIN
     COMMIT TRANSACTION
     SET @ReturnValue = 1
     RETURN @ReturnValue
END

END TRY

BEGIN CATCH
     DECLARE @Error_Message varchar(150)
     SET @Error_Message = ERROR_NUMBER() + ' ' + ERROR_MESSAGE()
     ROLLBACK TRANSACTION
     RAISERROR(@Error_Message,16,1)
      SET @ReturnValue = -1
      RETURN @ReturnValue
END CATCH

END
GO

GRANT EXECUTE ON [EmployeeUpdate] TO [Public]
GO
 
