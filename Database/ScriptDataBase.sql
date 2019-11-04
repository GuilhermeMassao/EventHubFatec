IF NOT EXISTS (SELECT 1 FROM sys.databases WHERE name = 'EventHub')
BEGIN
   CREATE DATABASE EventHub
END
GO

IF EXISTS (SELECT 1 FROM sys.databases WHERE name = 'EventHub')
BEGIN
    USE EventHub

    IF OBJECT_ID(N'dbo.User', N'U') IS NULL
    BEGIN
        CREATE TABLE [dbo].[User] (
            Id INT IDENTITY(1, 1) NOT NULL,
            UserName VARCHAR(200) NOT NULL,
            Email VARCHAR(50) NOT NULL,
            UserPassword VARCHAR(50) NOT NULL,
            TwitterAcessTokenSecret VARCHAR(10) NULL,
            GoogleRefreshToken VARCHAR(10) NULL,
            TwitterAcessToken VARCHAR(200) NULL
        )

        /*Primary key*/
        ALTER TABLE [dbo].[User]
            ADD CONSTRAINT [PK_User] PRIMARY KEY CLUSTERED ([Id] ASC)
    END

    IF OBJECT_ID(N'dbo.PublicPlace', N'U') IS NULL
    BEGIN
        CREATE TABLE [dbo].[PublicPlace] (
            Id INT IDENTITY (1, 1) NOT NULL,
            PlaceName VARCHAR(20) NOT NULL 
        )

        /*Primary key*/
        ALTER TABLE [dbo].[PublicPlace]
            ADD CONSTRAINT [PK_PublicPlace] PRIMARY KEY CLUSTERED ([Id] ASC)
    END

    IF OBJECT_ID(N'dbo.Adress', N'U') IS NULL
    BEGIN
        CREATE TABLE [dbo].[Adress] (
            Id INT IDENTITY (1, 1) NOT NULL,
            PublicPlaceId INT NOT NULL,  -- Logradouro
            City VARCHAR(50) NOT NULL,
            UF VARCHAR(2) NOT NULL,
            CEP VARCHAR(10) NOT NULL,
            Neighborhood VARCHAR(50) NOT NULL, -- Bairro
            AdressComplement VARCHAR(50) NULL, -- Complemento
            AdressNumber VARCHAR(10) NOT NULL
        )

        /*Primary key*/
        ALTER TABLE [dbo].[Adress]
            ADD CONSTRAINT [PK_Adress] PRIMARY KEY CLUSTERED ([Id] ASC)

        /*Foreign key*/
        ALTER TABLE [Adress]
            ADD CONSTRAINT [FK_Adress_PublicPlace] FOREIGN KEY(PublicPlaceId) REFERENCES [PublicPlace](Id)
    END

    IF OBJECT_ID(N'dbo.Event', N'U') IS NULL
    BEGIN
        CREATE TABLE [dbo].[Event] (
            Id INT IDENTITY(1, 1) NOT NULL,
            UserId INT NOT NULL,
            AdressId INT NOT NULL,
            StartDate DATETIME NOT NULL,
            EndDate DATETIME NOT NULL,
            EventName VARCHAR(50),
            EventDescription VARCHAR(500),
        )
        
        /*Primary key*/
        ALTER TABLE [dbo].[Event]
            ADD CONSTRAINT [PK_Event] PRIMARY KEY CLUSTERED ([Id] ASC)

        /*Foreign keys*/
        ALTER TABLE [Event] 
            ADD CONSTRAINT [FK_Event_User] FOREIGN KEY(UserId) REFERENCES [User](Id),
                CONSTRAINT [FK_Event_adress] FOREIGN KEY(AdressId) REFERENCES [Adress](Id)
    END

    IF OBJECT_ID(N'dbo.EventSubscribers', N'U') IS NULL
    BEGIN
        CREATE TABLE [EventSubscribers] (
            Id INT IDENTITY (1, 1) NOT NULL,
            UserId INT NOT NULL,
            EventId INT NOT NULL
        )

        /*Primary key*/
        ALTER TABLE [dbo].[EventSubscribers]
            ADD CONSTRAINT [PK_EventSubscribers] PRIMARY KEY CLUSTERED ([Id] ASC)

        /*Foreign keys*/
        ALTER TABLE [EventSubscribers] 
            ADD CONSTRAINT [FK_EventSubscribers_User] FOREIGN KEY(UserId) REFERENCES [User](Id),
                CONSTRAINT [FK_EventSubscribers_Event] FOREIGN KEY(EventId) REFERENCES [Event](Id)
    END

    IF OBJECT_ID(N'dbo.GoogleCalendarSocialMarketing', N'U') IS NULL
    BEGIN
        CREATE TABLE [GoogleCalendarSocialMarketing] (
            Id INT IDENTITY(1, 1) NOT NULL,
            EventId INT NOT NULL,
            HashCalendar VARCHAR(30) NOT NULL,
            CalendarLink VARCHAR(10) NOT NULL
        )

        /*Primary key*/
        ALTER TABLE [dbo].[GoogleCalendarSocialMarketing]
            ADD CONSTRAINT [PK_GoogleCalendarSocialMarketing] PRIMARY KEY CLUSTERED ([Id] ASC)

        /*Foreign key*/
        ALTER TABLE [GoogleCalendarSocialMarketing] 
            ADD CONSTRAINT [FK_GoogleCalendarSocialMarketing_Event] FOREIGN KEY(EventId) REFERENCES [Event](Id) 
    END

    IF OBJECT_ID(N'dbo.TwitterSocialMarketing', N'U') IS NULL
    BEGIN
        CREATE TABLE [TwitterSocialMarketing](
            Id INT IDENTITY(1, 1) NOT NULL,
            TweetId VARCHAR(20) NOT NULL,
            ShortUrlTweet VARCHAR(30) NULL
        )

        /*Primary key*/
        ALTER TABLE [dbo].[TwitterSocialMarketing]
            ADD CONSTRAINT [PK_TwitterSocialMarketing] PRIMARY KEY CLUSTERED ([Id] ASC)
    END
END