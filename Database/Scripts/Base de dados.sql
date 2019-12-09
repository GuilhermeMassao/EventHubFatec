
--select * from PublicPlace

insert into [dbo].[User] values(
'Guilherme Massao',
'guilhermemassao@gmail.com',
'1234',
null,null,null,
1
)
go
insert into [dbo].[User] values(
'Rodrigo Soares',
'rodrigo@gmail.com',
'1234',
null,null,null,
1
)
go
insert into [dbo].[User] values(
'Gleber Michel',
'gleber@gmail.com',
'1234',
null,null,null,
1
)
go
insert into [dbo].[User] values(
'fabio Furquim',
'fabio@gmail.com',
'1234',
null,null,null,
1
)
go
insert into [dbo].[User] values(
'Matheu Salles',
'salles@gmail.com',
'1234',
null,null,null,
1
)
select  * from [dbo].[User]



go
insert into Adress(PublicPlaceId, PlaceName,City,UF,CEP,Neighborhood,AdressComplement,AdressNumber,ActiveAdress) values(
2,
'jundiai',
'9 de Julho ',
'sp',
'1320856',
'Centro',
'ao lado do shopping',
'3333',
1
)
select * from Adress
go
insert into Adress(PublicPlaceId, PlaceName,City,UF,CEP,Neighborhood,AdressComplement,AdressNumber,ActiveAdress) values(
2,
'Bras Cardoso',
'Sao Paulo',
'sp',
'1320856',
'Bairro vila nova',
'Farmacia central',
'3333',
1
)
go
insert into Adress(PublicPlaceId, PlaceName,City,UF,CEP,Neighborhood,AdressComplement,AdressNumber,ActiveAdress) values(
2,
'Travessal Sul',
'Ilha Solteira',
'sp',
'1320856',
'Bairro Concentimento',
'Unesp',
'3333',
1
)
go
insert into Adress(PublicPlaceId, PlaceName,City,UF,CEP,Neighborhood,AdressComplement,AdressNumber,ActiveAdress) values(
2,
'Nova York',
'NY',
'1320856',
'Lighten Neighborhood',
'central Park',
'3333',
1
)
select * from Adress
go
--update Event set EventDescription = 'user2' ,EventShortDescription='user2 short desc', EventName = 'user2 event name' where id >17

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Guilherme Massao'
select @adressId = Id from [dbo].[Adress] a where a.City = 'jundiai'
set @inicio = DATEADD(MONTH, 1, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,3,@inicio),
'Feira Italiana.',
'Feira Italiana.',
'Feira que sera realizada em celebração da cultura italiana.',
30,
1
)
go


declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Guilherme Massao'
select @adressId = Id from [dbo].[Adress] a where a.City = 'jundiai'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'Baile Empresa.',
'Baile Empresa.',
'Baile de comemoração de 20 anos da empresa.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Rodrigo Soares'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Sao Paulo'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'evento de confraternizacao.',
'evento de confraternizacao.',
'evento de confraternizacao da empresa.',
30,
1
)

go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Rodrigo Soares'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Sao Paulo'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'Paraquedas.',
'Paraquedas.',
'Paraquedas em grupo.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Gleber Michel'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Ilha Solteira'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'tiroleza.',
'tiroleza.',
'evento de tiroleza promovendo a organizacao contra cancer infantial POCA.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Gleber Michel'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Ilha Solteira'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'tekwondo comunitario.',
'tekwondo comunitario.',
'tekwondo comunitario para a vila.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'fabio Furquim'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Ilha Solteira'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'Outback.',
'Outback.',
'Outback em grupo.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Matheu Salles'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Nova York'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'Visita ao museu de nova york.',
'Visita ao museu de nova york.',
'Convite às pessoas proxima para presença em visita ao museu de nova york.',
30,
1
)
go

declare  @inicio date
declare @ownerId int
declare @adressId int
select @ownerId = Id from [dbo].[user] u where u.UserName = 'Matheu Salles'
select @adressId = Id from [dbo].[Adress] a where a.City = 'Nova York'
set @inicio = DATEADD(MONTH, 2, GETDATE())
insert into Event(UserOwnerId,AdressId,StartDate,EndDate,EventName,EventShortDescription,EventDescription,TicketsLimit,ActiveEvent) values(
@ownerId,
@adressId,
@inicio,
DATEADD(DAY,4,@inicio),
'Fogos.',
'Fogos.',
'Visão para os Fogos de artificio.',
30,
1
)
select  * from [dbo].[Event]





--delete from [dbo].[Event]
--delete from Adress 
--delete from [dbo].[user]
