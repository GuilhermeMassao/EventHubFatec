-- Geração de Modelo físico
-- Sql ANSI 2003 - brModelo.

/*DROP DATABASE EventHub;

select * from Usuario;
insert into Usuario (Id, Senha, Email, Nome) values (1, '123','admin@email.com','Admin');
create database EventHub
go

use EventHub
go*/

create database EventHub
go
Use EventHub
go

CREATE TABLE Usuario (
Id INTEGER PRIMARY KEY IDENTITY,
Senha VARCHAR(50),
TwitterAcessTokenSecret VARCHAR(10),
GoogleRefreshToken VARCHAR(10),
Email VARCHAR(50),
Nome VARCHAR(200),
TwitterAcessToken VARCHAR(200)
)

CREATE TABLE Eventos (
Id INTEGER PRIMARY KEY IDENTITY,
DataFim DATETIME,
DataInicio DATETIME,
NomeEvento VARCHAR(50),
Descricao VARCHAR(500),
IdUsuario INTEGER,
FOREIGN KEY(IdUsuario) REFERENCES Usuario (Id)
)

CREATE TABLE InscritosEvento (
Id INTEGER PRIMARY KEY IDENTITY,
IdUsuario INTEGER,
IdEvento INTEGER,
FOREIGN KEY(IdUsuario) REFERENCES Usuario (Id),
FOREIGN KEY(IdEvento) REFERENCES Eventos (Id)
)

CREATE TABLE Divulgacao (
Descricao VARCHAR(2000),
Title VARCHAR(50),
Fonte VARCHAR(10),
Id INTEGER PRIMARY KEY IDENTITY,
DataAlteração VARCHAR(10),
Texto VARCHAR(2000),
IdTweet INTEGER,
IdAgenda INTEGER,
IdEvento INTEGER,
FOREIGN KEY(IdEvento) REFERENCES Eventos (Id)
)

CREATE TABLE EnderecoEvento (
Cidade VARCHAR(10),
Logradouro VARCHAR(10),
Bairro VARCHAR(50),
Estado VARCHAR(10),
Id INTEGER PRIMARY KEY IDENTITY,
Complemento VARCHAR(50),
CEP VARCHAR(10),
Número VARCHAR(10),
IdEvento INTEGER,
FOREIGN KEY(IdEvento) REFERENCES Eventos (Id)
)

