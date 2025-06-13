create database Hexa_May_25
use Hexa_May_25

drop table empl
create table empl
(
id int identity(101,1),
name varchar(20),
gender varchar(10),
location varchar(50),
doj date,
salary money
)

insert into empl values
('Santo','Male','Kanyakumari','3-02-2025',25000),
('Lokesh','Male','Chennai','6-04-2025',25000),
('Nithim','Male','Banglore','1-12-2024',30000),
('Arun','Male','Coimbatore','10-03-2025',15000),
('Karthick','Male','Chennai','3-12-2024',25000),
('Viji','Female','Banglore','3-12-2024',17000),
('Shruthi','Female','Chennai','3-12-2024',15000)

select * from empl

create procedure usp_GetAllEmployees
as
begin
select * from empl
end

exec usp_GetAllEmployees

alter proc usp_GetAllEmployees
as
begin
select id,name,location,gender from empl
end

exec usp_GetAllEmployees

create proc usp_GetAllEmployeesbyID
(@empid as int)
as 
begin 
select * from empl where id=@empid
end

exec usp_GetAllEmployeesbyID 106

create proc usp_GetAllEmployeesbyGenderLocation
(@gen as varchar(10),@loc as varchar(20))
as 
begin 
select name,location from empl where gender=@gen and location=@loc
end

exec usp_GetAllEmployeesbyGenderLocation 'Male','Chennai'

alter proc usp_GetAllEmployeesbyGenderLocation
(@gen as varchar(10) = 'Male',
@loc as varchar(20))
as 
begin 
select name,location from empl where gender=@gen and location=@loc
end

exec usp_GetAllEmployeesbyGenderLocation @loc='Banglore'
exec usp_GetAllEmployeesbyGenderLocation @gen='Female',@loc='Chennai'

create proc usp_AddNewEmployee
(@name as varchar(20), 
@gen as varchar(10),
@loc as varchar(20))
as 
begin
insert into empl(name,gender,location) values(@name,@gen,@loc)
end

usp_AddNewEmployee @name='Nitish',@gen='Male',@loc='Erode'

select * from  empl

create proc usp_NoofEmployeeonLoc
(@loc as varchar(50),
@count as int out)
as 
begin
select count(@count) from empl group by @loc
end

declare @count out
exec usp_NoofEmployeeonLoc @count out
select @count
