use Recharge

select * from Plans

select T.userid,P.plan_id,P.plan_name,P.plan_description,P.amount,P.validity,P.plan_type,P.operator_id from Plans as P inner join Transactions as T on P.plan_id = T.plan_id where userid = 1002;