drop database Review;
create database Review;
use Review;

create table GReview(
RevNo int primary key,
TRev text,
NeoReview int
);
create table Login(
sId int primary key,
sName varchar(255),
sUser varchar(255),
sPassword varchar(255)
);
insert into Log1 (sId, sName, sUser, sPassword)
values (1, 'Ven Light', 'Vlig1',  'Password'), (2, 'Til S', 'TilS1', 'Password1');

select * from staff;

