create database WorkShop
go
use WorkShop
go
create table Clients(
ID int primary key identity not null,
FullName varchar(50) not null,
PhoneNumber varchar(10) not null
);

create table Cars(
ID int primary key identity not null,
Model varchar(50) not null,
[Year] date not null,
Number varchar(10) not null
);

create table Masters(
ID int primary key identity not null,
FullName varchar(50) not null,
PhoneNumber varchar(10) not null
);

create table Orders(
ID int primary key identity not null,
ClientID int not null references Clients(ID),
CarID int not null references Cars(ID),
MasterID int references Masters(ID) default '-',
ProblemInfo varchar(max),
Price int,
ExecStartDate date,
ExecEndDate date
);

create table OrderDetails(
ID int primary key identity not null,
OrderID int references Orders(ID),
Discount int,
Repeated bit
);