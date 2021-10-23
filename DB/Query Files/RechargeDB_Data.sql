use Recharge;

--Modified Query
alter table Plans alter column plan_name varchar(20);


---OPERATOR
select * from Operator;

insert into Operator values('Jio'),('Airtel'),('VodafoneI'),('BSNL');

---PLANS

------------------------------JIO-----------------------------------------
--PopularPlans
insert into Plans values('2 GB/DAY Packs','Unlimited 112GB & Disney+ Hotstar',598,56,'Popular Plans',1000);

insert into Plans values
('2 GB/DAY Packs','730 GB UNLIMITED',2399,365,'Popular Plans',1000),
('2 GB/DAY Packs','168 GB UNLIMITED',599,84,'Popular Plans',1000),
('2 GB/DAY Packs','112 GB UNLIMITED',444,56,'Popular Plans',1000),
('2 GB/DAY Packs','56 GB UNLIMITED',249,28,'Popular Plans',1000);

insert into Plans values
('1.5 GB/DAY Packs','Unlimited 131GB & Disney+ Hotstar',777,84,'Popular Plans',1000),
('1.5 GB/DAY Packs','504 GB UNLIMITED',2122,336,'Popular Plans',1000),
('1.5 GB/DAY Packs','126 GB UNLIMITED',555,84,'Popular Plans',1000),
('1.5 GB/DAY Packs','84 GB UNLIMITED',399,56,'Popular Plans',1000),
('1.5 GB/DAY Packs','42 GB UNLIMITED',199,28,'Popular Plans',1000);

insert into Plans values
('1 GB/DAY Packs','24 GB UNLIMITED',149,24,'Popular Plans',1000);


insert into Plans values
('Long Term','350 GB UNLIMITED',4999,360,'Popular Plans',1000);

insert into Plans values
('3 GB/DAY Packs','Unlimited 90GB & Disney+ Hotstar',401,28,'Popular Plans',1000),
('3 GB/DAY Packs','252 GB UNLIMITED',999,84,'Popular Plans',1000);


--Top-Up
insert into Plans values
('1000 Talktime','Rs 844.46  Talktime',1000,365,'Top-Up',1000),
('500 Talktime','Rs 420.73  Talktime',500,365,'Top-Up',1000),
('100 Talktime','Rs 81.75  Talktime',100,365,'Top-Up',1000),
('50 Talktime','Rs 39.37   Talktime',50,365,'Top-Up',1000),
('20 Talktime','Rs 14.95  Talktime',20,365,'Top-Up',1000),
('10 Talktime','Rs 7.47   Talktime',10,365,'Top-Up',1000);

---4G Datavoucher
insert into Plans values
('Disney Hotstar packs','240GB & Disney+ Hotstar',1208,240,'4G Data Voucher',1000),
('Disney Hotstar packs','200GB & Disney+ Hotstar',1004,120,'4G Data Voucher',1000),
('Disney Hotstar packs','Unlimited 72 GB+ 6000 minutes Jio to Non-Jio',612,28,'4G Data Voucher',1000);

insert into Plans values
('Work from Home packs','Unlimited 50 GB',251,30,'4G Data Voucher',1000),
('Work from Home packs','Unlimited 40 GB',201,30,'4G Data Voucher',1000),
('Work from Home packs','Unlimited 30 GB',151,30,'4G Data Voucher',1000);


insert into Plans values
('Add on','Unlimited 800 MB + 75 Minutes Jio to Non-Jio',11,28,'4G Data Voucher',1000),
('Add on','Unlimited 2 GB + 200 Minutes Jio to Non-Jio',21,28,'4G Data Voucher',1000),
('Add on','Unlimited 6 GB + 500 Minutes Jio to Non-Jio',51,28,'4G Data Voucher',1000),
('Add on','Unlimited 12 GB + 1000 Minutes Jio to Non-Jio',101,28,'4G Data Voucher',1000);

---International Roaming
insert into Plans values
('InFlight Connectivity','250 MB data, 100 mins Outgoing Voice Calls and 100 SMS',499,1,'International Roaming',1000),
('InFlight Connectivity','500 MB data, 100 mins Outgoing Voice Calls and 100 SMS',999,1,'International Roaming',1000),

('Value WiFi Calling','Rs 933.20  IR usage',1102,28,'International Roaming',1000),
('Value WiFi Calling','Rs 1018.64  IR usage',1202,28,'International Roaming',1000),

('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',575,1,'International Roaming',1000),
('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',2875,7,'International Roaming',1000),
('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',5751,30,'International Roaming',1000);
-------------------------------------------------------------------------------------------------------------


------------------AIRTEL---------------------------
---POPULAR PLANS

insert into Plans values
('1 GB/DAY Packs','Rs.129 Truly Unlimited Calls',129,28,'Popular Plans',1001),

('1.5 GB/DAY Packs','Rs.598 Truly Unlimited Calls',598,84,'Popular Plans',1001),
('1.5 GB/DAY Packs','Rs.399 Truly Unlimited Calls',399,56,'Popular Plans',1001),
('1.5 GB/DAY Packs','Rs.289 Truly Unlimited Calls',289,28,'Popular Plans',1001),

('2 GB/DAY Packs','Rs.2698 Truly Unlimited Calls',2698,365,'Popular Plans',1001),
('2 GB/DAY Packs','Rs.449 Truly Unlimited Calls',449,56,'Popular Plans',1001),
('2 GB/DAY Packs','Rs.349 Truly Unlimited Calls',349,28,'Popular Plans',1001),

('3 GB/DAY Packs','Rs.558 Truly Unlimited Calls',558,56,'Popular Plans',1001),
('3 GB/DAY Packs','Rs.448 Truly Unlimited Calls',448,28,'Popular Plans',1001);



--Top-Up

insert into Plans values
('1000 Talktime','Rs 960  Talktime',1000,365,'Top-Up',1001),
('500 Talktime','Rs 480  Talktime',500,365,'Top-Up',1001),
('100 Talktime','Rs 82  Talktime',100,28,'Top-Up',1001),
('20 Talktime','Rs 15  Talktime',20,28,'Top-Up',1001),
('10 Talktime','Rs 7  Talktime',10,28,'Top-Up',1001);


---4G Data Voucher

insert into Plans values
('Airtel Xstream','250GB & Airtel Xstream',1208,240,'4G Data Voucher',1001),
('Airtel Xstream','120GB & Airtel Xstream',1004,120,'4G Data Voucher',1001);

insert into Plans values
('Work from Home packs','Unlimited 50 GB',251,30,'4G Data Voucher',1001),
('Work from Home packs','Unlimited 40 GB',201,30,'4G Data Voucher',1001),
('Work from Home packs','Unlimited 30 GB',151,30,'4G Data Voucher',1001),

('Add on','Unlimited 900 MB ',11,28,'4G Data Voucher',1001),
('Add on','Unlimited 3 GB ',21,28,'4G Data Voucher',1001),
('Add on','Unlimited 7 GB ',51,28,'4G Data Voucher',1001);

select * from Plans;

---International Roaming
insert into Plans values
('InFlight Connectivity','350 MB data, 100 mins Outgoing Voice Calls and 100 SMS',499,1,'International Roaming',1001),
('InFlight Connectivity','600 MB data, 100 mins Outgoing Voice Calls and 100 SMS',999,1,'International Roaming',1001),

('Value WiFi Calling','Rs 1033.20  IR usage',1102,28,'International Roaming',1001),
('Value WiFi Calling','Rs 1118.64  IR usage',1202,28,'International Roaming',1001),

('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',575,1,'International Roaming',1001),
('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',2875,7,'International Roaming',1001),
('Unlimited WiFi Calling','Unlimited Incoming and Outgoing Voice Calls, Data & SMS',5751,30,'International Roaming',1001);

select * from Plans;
-------------------------------------------------------------------------------------------------------------

-----USER -----

select * from Users;

insert into 
Users(name,phone_number,email,dob,city,state,pincode,password)
values 
('Rajagurunathan','9994366160','raj@gmail.com','2004-01-22','Coimbatore','Tamilnadu',641028,'Raj@123');







---ADMIN----

select * from Admin;

insert into Admin values
('Rajagurunathan','Rajagurunathan@123'),
('Saravana','Saravana@123'),
('Naveeth','Naveeth@123');


------ TRANSACTIONS -----

select * from Transactions;

insert into Transactions values
('2020-10-08',1002,111,1000,'9994366160','success');


insert into Transactions values
('2020-10-08',1002,189,1000,'9360530521','success');

select * from Admin;
select * from Operator;
select * from Users;
select * from Plans;
select * from Transactions;
