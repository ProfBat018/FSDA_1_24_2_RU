use Academy_2;

alter table Student
add GroupId int foreign key references [Group](Id) on delete cascade;


CREATE TRIGGER CheckGroupStudentsCount on Student
FOR INSERT
AS
BEGIN
    IF (SELECT COUNT(*) FROM Student
        INNER JOIN [Group] on [Group].Id = Student.GroupId) >= 5
        print(N'Group is full!');
        ROLLBACK TRANSACTION;
END

drop trigger CheckGroupStudentsCount;

select * from Student

select * from People;

insert into People values ('John', 'Doe', '1990-01-01');
insert into People values ('Jane', 'Doe', '1990-01-01');
insert into People values ('Jack', 'Doe', '1990-01-01');
insert into People values ('Jill', 'Doe', '1990-01-01');

insert into Student (StudentNumber, PersonId, GroupId) values ('S12348', 7, 1)
insert into Student (StudentNumber, PersonId, GroupId) values ('S12349', 8, 1)
insert into Student (StudentNumber, PersonId, GroupId) values ('S12350', 9, 1)
insert into Student (StudentNumber, PersonId, GroupId) values ('S12351', 10, 1)

delete from Student
where PersonId = 10






