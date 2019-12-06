USE [EventHub]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserInformation]    Script Date: 05/12/2019 23:50:45 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateUserInformation]
    @Id INT,
    @UserName VARCHAR(50),
    @Email VARCHAR(50)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        UserName = @UserName,
        Email = @Email
    WHERE
        Id = @Id
END