use Recharge;

select U.userid,U.name,O.operator_name,U.phone_number,P.plan_name,P.plan_description,P.amount,T.date_time as RechargedDate from Operator as O full outer join Plans as P on O.operator_id = P.operator_id full outer join Transactions as T
on P.plan_id = T.plan_id
full outer join Users as U on T.userid = U.userid
where T.userid=1002;