select * from Transactions



select Top 1 U.name,O.operator_name,T.phone_number,P.plan_name,P.plan_description,P.amount,P.validity,T.date_time
from Transactions as T inner join Users as U on T.userid = U.userid 
inner join Plans as P on T.plan_id = P.plan_id
inner join Operator as O on T.operator_id = O.operator_id
where T.phone_number = '960026700' and U.userid = 1008
order by T.date_time desc;

select * from Transactions where userid = 1008 order by date_time desc;

update Users set balance = balance + 12000 where userid = 1007;

update Users set email = 'saravanakumar.cs17@bitsathy.ac.in' where userid = 1007;

alter table Users alter column email varchar(250)
alter table Users alter column password varchar(250)

select * from Users where userid = 1008

select * from Plans where plan_id = 139

insert into Transactions values('2028-08-28',1005,139,1000,'987543210','now 3 boom');
