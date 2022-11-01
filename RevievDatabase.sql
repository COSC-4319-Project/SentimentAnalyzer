drop database Review;
create database Review;
use Review;

create table Login(
sId int primary key,
sName varchar(255),
sUser varchar(255),
sPassword varchar(255)
);
create table GReview(
RevNo int,
UId int,
TRev text,
NeoReview int,
ASINID varchar(255),
IDDate Date,
foreign key(UId) references Login(sId),
primary key(RevNo,UId,ASINID)
);

insert into Log1 (sId, sName, sUser, sPassword)
values (1, 'Ven Light', 'Vlig1',  'Password'), (2, 'Til S', 'TilS1', 'Password1');

select * from staff;

