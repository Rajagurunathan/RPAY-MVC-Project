select * from Users;
select * from Plans;
select * from Operator;
select * from Transactions;


--Transaction & Update check
select * from Transactions where userid = 1005;
select * from Users where userid = 1005;


--update money
update Users set balance = balance + 10000 where userid = 1005;


select * from Plans where operator_id = 1003 and amount = 1008

--get balance
select balance from Users where userid = 1005

--get operatorid
select operator_id from Operator where operator_name = 'Airtel';

--get planid
select plan_id from Plans where plan_type = 'Popular Plans' and plan_name = '2 GB/DAY Packs' and amount = 598;

--add transaction
insert into Transactions values('2020-11-29',1005,100,1001,'9876543210','Rajaguru');