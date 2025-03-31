use master;
go
drop database if exists borbeniAvioni;
go
create database borbeniAvioni collate Croatian_CI_AS; 
go
use borbeniAvioni;
go

create table drzave(
sifra int not null primary key identity(1,1),
naziv varchar (50) not null
);

create table proizvodaci(
sifra int not null primary key identity(1,1),
naziv varchar (50) not null,
drzava int not null references drzave(sifra),
datumOsnivanja datetime
);

create table avioni(
sifra int not null primary key identity(1,1),
naziv varchar (50) not null,
proizvodac int not null references proizvodaci(sifra),
klasa varchar (50) not null,
datumPrvogLeta datetime not null,
model varchar (25),
export bit
);

insert into drzave
(naziv) values
-- 1
('Sjedinjene Američke Države'),
-- 2
('Rusija'),
-- 3
('Francuska');

insert into proizvodaci
(naziv, drzava, datumOsnivanja) values
('Lockheed Martin',1,'1995-03-15'),
('Suhoj',2, null),
('Dassault Avijacija',3, null);

insert into avioni
(naziv, proizvodac, klasa, datumPrvogLeta) values
('F-35 Lightning',1, 'višenamjenski borbeni zrakoplov', '2006-12-15'),
('Su-27 Flanker',2, 'višenamjenski borbeni zrakoplov', '1977-05-20'),
('Dassault Rafale',3, 'višenamjenski borbeni zrakoplov', '1991-05-19');


