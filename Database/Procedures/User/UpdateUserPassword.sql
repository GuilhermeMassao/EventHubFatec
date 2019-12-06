USE [EventHub]
GO
/****** Object:  StoredProcedure [dbo].[UpdateUserPassword]    Script Date: 05/12/2019 23:51:03 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[UpdateUserPassword]
    @Id INT,
    @UserPassword VARCHAR(15)
AS

SET NOCOUNT ON

BEGIN
    UPDATE 
        [dbo].[User]
    SET
        UserPassword = @UserPassword
    WHERE
        Id = @Id
END