
create table tblEmployee
(
id int primary key,
name varchar(20),
salary int,
gender varchar(20),
deptId int
);

create table tblEmployeeAudit
(
id int primary key identity(11,1),
AuditData varchar(max)
);

insert into tblEmployee values
(1,'santo',25000,'male',1),
(2,'lokesh',15000,'male',3),
(3,'nithim',25000,'male',2),
(4,'viji',20000,'female',1);

select * from tblEmployee;
select * from tblEmployeeAudit;

create trigger tr_tblEmployee_insert
on tblemployee
for insert
as
begin
declare @id int
select @id=id from inserted

insert into tblEmployeeAudit values
('new employee with id='+CAST(@id as varchar(5))+'is added at '+CAST(GetDate() as varchar(20)))
end

select * from tblEmployee;
select * from tblEmployeeAudit;
insert into tblEmployee values
(5,'shruthi',15000,'female',2);

create trigger tr_tblEployee_delete
on tblEmployee
for delete
as 
begin
declare @id int
select @id=id from deleted

insert into tblEmployeeAudit values
('employee with id= '+CAST(@id as varchar(5)) + 'deleted at ' + CAST(GETDATE() as varchar(20)))
end

select * from tblEmployee;
select * from tblEmployeeAudit;
delete from tblEmployee where id=5;

CREATE TRIGGER trg_PreventDropEmployee1
ON DATABASE
FOR DROP_TABLE
AS
BEGIN
    DECLARE @eventData XML = EVENTDATA();
 
    -- Extract object name and schema
    DECLARE @objName NVARCHAR(128) = @eventData.value('(/EVENT_INSTANCE/ObjectName)[1]', 'NVARCHAR(128)');
    DECLARE @schema NVARCHAR(128) = @eventData.value('(/EVENT_INSTANCE/SchemaName)[1]', 'NVARCHAR(128)');
 
    IF @objName = 'Employee' AND @schema = 'dbo'
    BEGIN
        PRINT 'Dropping the Employee table is not allowed!';
        ROLLBACK;
    END
END


CREATE TRIGGER trg_EmployeeUpdate
ON tblEmployee
FOR UPDATE
AS
BEGIN
DECLARE @EmployeeID INT;
DECLARE @OldFName NVARCHAR(100) , @NewFName NVARCHAR(100)
DECLARE @OldLName NVARCHAR(100) , @NewLName NVARCHAR(100)
DECLARE @OldSalary DECIMAL(10, 2), @NewSalary DECIMAL(10, 2)

DECLARE @AuditMessage NVARCHAR(MAX);

SELECT * INTO TempTable FROM inserted;

WHILE (EXISTS (SELECT EmployeeID FROM TempTable))
BEGIN
SET @AuditMessage =''
SELECT TOP 1 @EmployeeID = EmployeeID, 
    @NewFName = FirstName, 
    @NewLName = LastName, 
    @NewSalary = Salary
FROM TempTable;

SELECT @OldFName = FirstName, 
    @OldLName = LastName, 
    @OldSalary = Salary
FROM deleted WHERE EmployeeID = @EmployeeID

SET @AuditMessage = 'Employee with ID: ' + CAST(@EmployeeID AS VARCHAR(10)) + ' Changed ';

IF(OldFName <> NewFName)
BEGIN
    SET @AuditMessage = @AuditMessage + 'First Name changed from ' + @OldFName + ' to ' + @NewFName + '. ';
END
IF(OldLName <> NewLName)
BEGIN
    SET @AuditMessage = @AuditMessage + 'Last Name changed from ' + @OldLName + ' to ' + @NewLName + '. ';
END
IF(OldSalary <> NewSalary)
BEGIN
    SET @AuditMessage = @AuditMessage + 'Salary changed from ' + CAST(@OldSalary AS NVARCHAR(20)) + ' to ' + CAST(@NewSalary AS NVARCHAR(20)) + '. ';
END
END
END



--transactions
create table Customers
(
cid int primary key,
name varchar(100),
email varchar(100),
balance decimal(10,2)
);

CREATE TABLE Products
(
pid int primary key,
name varchar(100),
price decimal(10,2),
Qnty int
);

create table Orders
(
oid int primary key,
cid int,
odate datetime,
total decimal(10,2),
status varchar(20)
);

insert into Customers values
(1,'santo','santo@gmail.com',505.95),
(2,'viji','viji@gmail.com',2505.00),
(3,'shruthi','shruthi@gmail.com',4002.41);

INSERT INTO Products values
(101, 'Laptop', 250.00, 2),
(102, 'Mouse', 20.00, 5);

select * from Customers;
select * from Products;
select * from Orders;

begin transaction;
if(exists(select 1 from Products where pid=1 and Qnty>=1))
begin
--update product stock 
update Products set Qnty=Qnty-1 where pid=1;
--update customer balance
update Customers set balance=balance-299 where cid=1;

insert into Orders(oid,cid,odate,total,status) values (101,1,GETDATE(),299,'completed');

commit transaction;

end

--rollback transcation
begin tran
declare @totalcost decimal(10,2)=299*5

--check customer balance
if(exists(select 1 from Customers where cid=3 and balance>=@totalcost))
begin

update Products set Qnty=Qnty-5
where pid=1

update Customers set balance= balance-@totalcost
where cid=3

commit transaction
end
else
begin rollback transaction
print('insufficient balance');
end