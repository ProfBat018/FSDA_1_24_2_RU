
select * from [Group];

select distinct People.Name from People;

select top 3 * from People;

-- select P.Name from Student as S
-- inner join dbo.People P on P.Id = S.PersonId
-- group by P.Name
--
--
-- select P.Name from Student as S
-- inner join dbo.People P on P.Id = S.PersonId


select * from dbo.[Group]



select [Group].GroupNumber from [Group]
inner join dbo.Student S on [Group].Id = S.GroupId
inner join dbo.People P on S.PersonId = P.Id
group by [Group].GroupNumber


select AVG(SP.Point) as AvgPoint, G.GroupNumber from Student
inner join dbo.[Group] G on G.Id = Student.GroupId
inner join dbo.Faculty F on F.Id = G.FacultyId
inner join dbo.Subject S on F.Id = S.FacultyId
inner join dbo.StudentPoint SP on Student.Id = SP.StudentId
group by G.GroupNumber



select COUNT(Student.Id), F.FacultyName, G.GroupNumber from Student
inner join [Group] as G on G.Id = Student.GroupId
inner join dbo.Faculty F on F.Id = G.FacultyId
group by G.GroupNumber, F.FacultyName

select * from Student


DECLARE @StudentCount int = (select count(*) from Student)
DECLARE @Id int = 1

while @Id <= @StudentCount
begin
    insert into Student values((select StudentNumber from Student where Id = @Id), (select PersonId from Student where Id = @Id), 2);
    set @Id = @Id + 1
end



select * from Subject;
select * from Student;
select * from [Group];
select * from StudentPoint;

select * from Faculty;

alter table Subject
add FacultyId int foreign key references Faculty(Id) default 1;






