USE [EventHub]
GO
/****** Object:  StoredProcedure [dbo].[SelectUserById]    Script Date: 05/12/2019 23:19:22 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO

create PROCEDURE [dbo].[SelectUserById]
    @Id INT
AS

SET TRANSACTION ISOLATION LEVEL READ UNCOMMITTED
SET NOCOUNT ON

BEGIN
    SELECT
        UserName,
        Email,
        UserPassword
    FROM
        [dbo].[User]
    WHERE
        Id = @Id
	AND ActiveUser = 1;
END