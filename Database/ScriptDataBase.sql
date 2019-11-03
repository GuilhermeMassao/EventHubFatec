CREATE DATABASE EventHub
go

Use EventHub
go

CREATE TABLE [User] (
    Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    UserName VARCHAR(200) NOT NULL,
    Email VARCHAR(50) NOT NULL,
    UserPassword VARCHAR(50) NOT NULL,
    TwitterAcessTokenSecret VARCHAR(10) NULL,
    GoogleRefreshToken VARCHAR(10) NULL,
    TwitterAcessToken VARCHAR(200) NULL
)

CREATE TABLE [PublicPlace] (
    Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    placeName VARCHAR(20) NOT NULL 
)

CREATE TABLE [Adress] (
    Id INTEGER PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    PublicPlaceId INT NOT NULL,  -- Logradouro
    City VARCHAR(50) NOT NULL,
    UF VARCHAR(2) NOT NULL,
    CEP VARCHAR(10) NOT NULL,
    Neighborhood VARCHAR(50) NOT NULL, -- Bairro
    AdressComplement VARCHAR(50) NULL, -- Complemento
    AdressNumber VARCHAR(10) NOT NULL
)

ALTER TABLE [Adress]
    ADD CONSTRAINT [FK_Adress_PublicPlace] FOREIGN KEY(PublicPlaceId) REFERENCES [PublicPlace](Id)

CREATE TABLE [Event] (
    Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    UserId INT NOT NULL,
    AdressId INT NOT NULL,
    StartDate DATETIME NOT NULL,
    EndDate DATETIME NOT NULL,
    EventName VARCHAR(50),
    EventDescription VARCHAR(500),
)

ALTER TABLE [Event] 
    ADD CONSTRAINT [FK_Event_User] FOREIGN KEY(UserId) REFERENCES [User](Id),
        CONSTRAINT [FK_Event_adress] FOREIGN KEY(AdressId) REFERENCES [Adress](Id)

CREATE TABLE [EventSubscribers] (
    Id INT PRIMARY KEY IDENTITY (1, 1) NOT NULL,
    UserId INT NOT NULL,
    EventId INT NOT NULL
)

ALTER TABLE [EventSubscribers] 
    ADD CONSTRAINT [FK_EventSubscribers_User] FOREIGN KEY(UserId) REFERENCES [User](Id),
        CONSTRAINT [FK_EventSubscribers_Event] FOREIGN KEY(EventId) REFERENCES [Event](Id)

CREATE TABLE [GoogleCalendarSocialMarketing] (
    Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    EventId INT NOT NULL,
    HashCalendar VARCHAR(30) NOT NULL,
    CalendarLink VARCHAR(10) NOT NULL
)

ALTER TABLE [GoogleCalendarSocialMarketing] 
    ADD CONSTRAINT [FK_GoogleCalendarSocialMarketing_Event] FOREIGN KEY(EventId) REFERENCES [Event](Id) 

CREATE TABLE [TwitterSocialMarketing](
    Id INT PRIMARY KEY IDENTITY(1, 1) NOT NULL,
    TweetId VARCHAR(20) NOT NULL,
    ShortUrlTweet VARCHAR(30) NULL
)
