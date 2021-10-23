
 select TOP 1 U.userid,U.name,O.operator_name,T.phone_number,P.plan_name,P.plan_description,P.amount,P.validity,T.date_time as RechargedDate from Operator as O full outer join Plans as P on O.operator_id = P.operator_id full outer join Transactions as T
on P.plan_id = T.plan_id
full outer join Users as U on T.userid = U.userid
where T.userid=1005 and T.phone_number ='987543210'
order by t.date_time desc;

select * from Plans;

select * from Transactions;

insert into Transactions values('2023-01-05',1002,186,1000,'6666666666','perfect');

insert into Transactions values('2023-02-05',1002,186,1000,'9994366160','just now');

insert into Transactions values('2023-02-05',1002,105,1000,'9191919191','not mine');

insert into Transactions values('2027-08-01',1002,105,1000,'9191919191','mine');

insert into Transactions values('2027-08-01',1002,143,1000,'9994366160','its mine');

insert into Transactions values('2027-08-01',1005,105,1000,'987543210','Success');

select * from Users;
select * from Plans;
select * from Transactions;
select * from Operator;
select * from Admin;