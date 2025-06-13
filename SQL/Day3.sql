create table AccA
(
id int primary key,
bal decimal(10,2)
);

create table AccB
(
id int primary key,
bal decimal(10,2)
);

insert into AccA values (1,1000.00);
insert into AccB values (1,2000.00);

select * from AccA;
select * from AccB;

begin tran

update AccA set bal=bal-100 where id=1;
waitfor delay '00:00:05';
update AccB set bal=bal+100 where id=1;

commit

begin tran

update AccB set bal=bal-200 where id=1;
waitfor delay '00:00:05';
update AccA set bal=bal+200 where id=1;

commit

