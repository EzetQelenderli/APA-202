
----create database Company 
----use  Company
create table Employees (
EmployeeID int ,
FirstName nvarchar(50)
,LastName nvarchar(50)
,Email nvarchar(100)
, PhoneNumber nvarchar(20)
,HireDate date
,JobTitle nvarchar(100)
, Salary decimal(18,2)
,Department  nvarchar(50)
);
insert into Employees
values
(1, 'Anar', 'Memmedov', 'anar.m@company.com', '+994501112233', '2023-01-15', 'Software Engineer', 2500.00, 'IT')
insert into Employees
values
(2, 'Lale', 'Eliyeva', 'lale.a@company.com', '+994552223344', '2022-05-20', 'HR Manager', 1800.50, 'Human Resources')
insert into Employees
values
(3, 'Resad', 'Hesenov', 'reshad.h@company.com', '+994703334455', '2021-11-10', 'Data Analyst', 2200.00, 'Data Science')
insert into Employees
values
(4, 'Günel', 'Veliyeva', 'gunel.v@company.com', '+994504445566', '2023-03-01', 'Designer', 1600.00, 'Marketing')
insert into Employees
values
(5, 'Orxan', 'Qasımov', 'orxan.q@company.com', '+994556667788', '2020-08-25', 'Sales Lead', 1950.75, 'Sales');
select * from Employees
select FirstName,LastName,Salary from Employees where Salary>2000
select FirstName,LastName,Department from Employees where Department='IT'
select * from Employees order by salary desc
select Firstname,Salary from Employees
select FirstName,LastName,HireDate from Employees where Year(HireDate)>2020
select FirstName,LastName,Email from Employees where Email='%company.az'
select max(Salary) as MaxSalary from Employees
select min(Salary) as MinSalary from Employees
select avg(Salary) as AverageSalary from Employees
select Count(*) as EmployeesCount from Employees
select sum(Salary)  as SumSalary from Employees
select Department ,Count(*) as CountEmployees from Employees
group by Department
select Department, max(Salary) as MaxSalary from Employees
group by Department
select Department, avg(Salary) as AverageSalary from Employees
group by Department
update Employees set Salary=2800 where EmployeeID=1
update Employees set Salary=Salary*1.1 where Department='IT'
update Employees set JobTitle='HR Manager' where EmployeeID=4
delete from  Employees where EmployeeID=5
insert into Employees
values
(5, 'Azer', 'Eliyev', 'azer.m@company.com', '+994501er12233', '2023-01-16', 'Software Engineer', 600.00, 'IT')
delete from  Employees where Salary<1500
select * from Employees where FirstName Like'%a%'
select * from Employees where Salary between 2000 AND 2500; 
select * from Employees where Department IN ('IT',  'Data Science')