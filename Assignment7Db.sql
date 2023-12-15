create database LibraryDb

use LibraryDb

create table Books(
Bookid int primary key,
Title nvarchar(20)not null,
Author nvarchar(20) not null,
Genre nvarchar(20) not null,
Quantity int)

insert into Books values(1,'The Hidden Hindu','Akshat Gupta','Frictional',3)

select * from Books