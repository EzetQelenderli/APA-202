CREATE DATABASE Company;
use Company
Create table Employees(
Id int Primary key identity ,
[Name] nvarchar(20)   not null, 
Surname nvarchar(50) not null,
Age int ,
Salary decimal(11,2), 
Position nvarchar(30),
IsDeleted bit default 0,
CitiesId int foreign  key references Cities(Id)
);
 
create table Cities(
Id int primary key identity,
[Name] nvarchar(20)  not null,
CountriesId int foreign key references Countries(Id)
)

create table Countries(
Id int primary key identity,
[Name] nvarchar(20)  not null,)

insert into Countries (Name) 
values
('Azerbaijan'), 
('Turkey'), 
('USA'), 
('Germany');

insert into Cities (Name, CountriesId) 
values
('Baku', 1),    
('Istanbul', 2), 
('New York', 3), 
('Berlin', 4);

insert into Employees (Name, Surname, Age, Salary, Position, IsDeleted, CitiesId) 
values 
('Ali', 'Aliyev', 28, 2500, 'Developer', 0, 1),      
('Ayşe', 'Yılmaz', 24, 1800, 'Reception', 0, 2),    
('John', 'Doe', 35, 4500, 'Manager', 0, 3),         
('Hans', 'Müller', 30, 2200, 'Reception', 1, 4);

Select E.Name, E.Surname, Ci.Name as CiTyName ,C.Name as CountriesName from  Employees as E
join Cities as Ci
on CitiesId=Ci.Id
join Countries as C
on CountriesId=C.Id

Select E.Name, E.Surname, Ci.Name as CiTyName ,C.Name as CountriesName from  Employees as E
join Cities as Ci
on CitiesId=Ci.Id
join Countries as C
on CountriesId=C.Id
where E.Salary>2000

select ci.Name as City, C.Name as Country 
from Cities as  ci
join Countries as C on ci.CountriesId = C.Id;

select e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted, ci.Name as City, C.Name AS Country 
FROM Employees e
join Cities ci on e.CitiesId = ci.Id
join Countries C on ci.CountriesId = C.Id
where e.Position = 'Reception';

select e.Name, e.Surname, e.Age, e.Salary, e.Position, e.IsDeleted,e.Id, ci.Name as City, C.Name AS Country 
FROM Employees e
join Cities ci on e.CitiesId = ci.Id
join Countries C on ci.CountriesId = C.Id
where e.Position = 'Reception';

Select E.Name, E.Surname, Ci.Name as CiTyName ,C.Name as CountriesName from  Employees as E
join Cities as Ci
on CitiesId=Ci.Id
join Countries as C
on CountriesId=C.Id
where E.IsDeleted=1
