create database Recharge

use Recharge

create table Users(
userid int primary key IDENTITY(1000,1) ,
name varchar(20),
phone_number varchar(10),
email varchar(25),
dob date,
city varchar(20),
state varchar(20),
pincode varchar(6),
password varchar(20),
balance int default 0
);



drop table Users; 

select * from Users;


create table Operator(
operator_id int primary key IDENTITY(3000,1) ,
operator_name varchar(20)
);

select * from Operator;


create table Plans(
plan_id int primary key IDENTITY(100,1) ,
plan_name varchar(20),
plan_description varchar(250),
amount int,
validity int,
plan_type varchar(100),
operator_id int references Operator(operator_id));

select * from Plans;

create table Transactions(
transaction_id int primary key IDENTITY(1,1),
date_time date,
userid int references Users(userid),
plan_id int references Plans(plan_id),
operator_id int references Operator(operator_id),
phone_number varchar(20),
status varchar(20)
);


select * from Transactions;


create table Admin(
admin_id int primary key IDENTITY(1,1),
admin_name varchar(20),
admin_password varchar(20)
);

select * from Admin;



