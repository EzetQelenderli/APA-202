create database CompanyMM
use CompanyMM

create table Employees (
    EmployeeID int primary key identity,
    FirstName nvarchar(50) NOT NULL,
    LastName nvarchar(50) NOT NULL,
    BirthDate date,
    Email nvarchar(100) UNIQUE NOT NULL,
    constraint CHK_BirthDate CHECK (BirthDate > '1980-11-05')
)

create table Projects (
    ProjectID int primary key identity,
    ProjectName nvarchar(100) NOT NULL,
    StartDate date NOT NULL,
    EndDate date,
    constraint CHK_Dates check (EndDate IS NULL OR EndDate >= StartDate)
)
create table EmployeeProjects (
    EmployeeID int,
    ProjectID int,
    AssignedDate DATE DEFAULT GETDATE(),
    primary key(EmployeeID, ProjectID),
     foreign key (EmployeeID) references Employees(EmployeeID) on delete cascade,
    foreign key (ProjectID) references Projects(ProjectID)on delete cascade
)
insert into Employees (FirstName, LastName, BirthDate, Email)
VALUES 
('Anar', 'Məmmədov', '1990-05-10', 'anar.m@company.com'),
('Leyla', 'Eliyeva', '1995-08-15', 'leyla.a@company.com'),
('Reşad', 'Hesenov', '1988-03-22', 'rashad.h@company.com'),
('Günel', 'Quliyeva', '1992-12-05', 'gunel.q@company.com'),
('Fuad', 'Seferov', '1994-01-30', 'fuad.s@company.com');

insert into Projects (ProjectName, StartDate, EndDate)
values 
('Mobil Bank Tətbiqi', '2024-01-10', '2024-12-20'),
('Kiber Təhlükəsizlik', '2024-02-01', '2024-05-15'),
('Süni İntellekt', '2024-03-15', NULL);

insert into EmployeeProjects (EmployeeID, ProjectID, AssignedDate)
values 
(1, 1, '01-05-2024'),
(2, 1, '01-05-2024'),
(3, 2, '02-20-2024'),
(4, 3, '03-05-2024'),
(5, 3, '03-05-2024');

select * from Employees
select * from Projects

select E.FirstName, E.LastName from Employees as E
join EmployeeProjects as Ep
on E.EmployeeID=Ep.EmployeeID
join Projects as P
on P.ProjectID=Ep.ProjectID

select e.FirstName, e.LastName, count (ep.ProjectID) as ProjectCount
from Employees as e
join EmployeeProjects as ep on e.EmployeeID = ep.EmployeeID
 group by e.EmployeeID, e.FirstName, e.LastName

select e.FirstName, e.LastName, count(ep.ProjectID) as ProjectCount
from Employees as e
join EmployeeProjects as ep on e.EmployeeID = ep.EmployeeID
group by e.EmployeeID, e.FirstName, e.LastName
having count(ep.ProjectID) > 2

create view EmployeeProjectView as
select
    e.EmployeeID, 
    (e.FirstName + ' ' + e.LastName) AS FullName, 
    p.ProjectID, 
    p.ProjectName, 
    ep.AssignedDate
from Employees as e
join EmployeeProjects as ep on e.EmployeeID = ep.EmployeeID
join Projects as p on ep.ProjectID = p.ProjectID


select * from EmployeeProjectView  where EmployeeID = 1;

create procedure sp_AssignEmployeeToProject 
    @empId int, 
    @projId int
as
Begin
    if not exists (select 1 from EmployeeProjects where EmployeeID = @empId AND ProjectID = @projId)
    Begin
        insert into EmployeeProjects (EmployeeID, ProjectID)
        values (@empId, @projId);
    End
End


create function fn_GetProjectCount(@empId int) 
returns int
as
Begin
    DECLARE @p_count int;
    SELECT @p_count = count(*) from EmployeeProjects where EmployeeID = @empId;
    return @p_count;
End

select FirstName, LastName, dbo.fn_GetProjectCount(EmployeeID) as TotalProjects 
from Employees

exec sp_AssignEmployeeToProject @empId = 2, @projId = 2

delete from EmployeeProjects where EmployeeID = 5

select * from EmployeeProjectView
