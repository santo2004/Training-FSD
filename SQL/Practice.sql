use Hexa_May_25;

--create few tables with few attributes
create table stud
(
id int identity(101,1),
name varchar(20),
age int,
loc varchar(20),
course varchar(20)
);


create table course
(
cid int identity(201,1),
cname varchar(20)
);

--inserting records into tables
insert into course values
('Java'),
('C#'),
('Python');

insert into stud values
('Santo',21,'Kanyakumari',202),
('Shruthi',21,'Satur',201),
('Nitish',21,'Erode',203),
('Viji',21,'Villupuram',201);

--displaying the tables
select * from course;
select * from stud;

--displaying few records by joining tables
select s.id,s.name,s.loc,c.cname 
from stud s
join 
course c
on s.course=c.cid
where s.course=201;

--procedures without paramters
create proc DisplayStudByCourseID201
as 
begin
select s.id,s.name,s.loc,c.cname 
from stud s
join 
course c
on s.course=c.cid
where s.course=201;
end

exec DisplayStudByCourseID201

--procedure with parameters
create proc DisplayStudByCourseID
(@id as int)
as 
begin
select s.id,s.name,s.loc,c.cname 
from stud s
join 
course c
on s.course=c.cid
where s.course=@id;
end

exec DisplayStudByCourseID 202
exec DisplayStudByCourseID 203
exec DisplayStudByCourseID 201

--out parameter
create proc GetStudentCountByCourse
@cid int,
@total int output
as
begin
    select @total = count(*) from stud where course = @cid;
end

declare @count int;
exec GetStudentCountByCourse 201, @count output;
print @count;


--insert procedure
create proc AddStudent
@name varchar(20),
@age int,
@loc varchar(20),
@cid int
as
begin
    insert into stud(name, age, loc, course)
    values (@name, @age, @loc, @cid);
end

exec AddStudent 'Lokesh',21,'Chennai',202;
select * from stud;

--update procedure
create proc UpdateStudentLocation
@sid int,
@newloc varchar(20)
as
begin
    update stud set loc = @newloc where id = @sid;
end

exec UpdateStudentLocation 105, 'Pondicherry';
select * from stud;

CREATE PROCEDURE GetStudentCountByCourse
    @cid INT,
    @total INT OUTPUT
AS
BEGIN
    SELECT @total = COUNT(*) FROM stud WHERE course = @cid;
END

--creating a procedure to display records with their course name
create proc DisplayAllStudRec
as 
begin
select s.id,s.name,c.cname 
from stud s
join 
course c
on s.course=c.cid;
end

exec DisplayAllStudRec;

--creating a procedure with course more than one
create proc CourseMoreThanOne
as 
begin
SELECT course, COUNT(*) AS NoOfStud
FROM stud
GROUP BY course
HAVING COUNT(*) > 1;
end

CourseMoreThanOne;

--with out parameter
CREATE PROCEDURE CourseMoreThanOneWithOutPara
(@count INT OUTPUT)
AS
BEGIN
SELECT @count = COUNT(*) 
FROM 
(
SELECT course
FROM stud
GROUP BY course
HAVING COUNT(*) > 1
) AS Sub;
END

DECLARE @result INT;
EXEC CourseMoreThanOneWithOutPara @result OUTPUT;
SELECT @result;

DROP PROCEDURE CourseMoreThanOneWithOutPara;

