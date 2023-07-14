select * from CustomerData

create or Alter procedure sp_insert
@Name varchar(90), 
@City varchar(90),
@Phone_Number bigint
as 
insert into CustomerData (Name,City,Phone_Number)values
(@Name,@City,@Phone_Number)
go

exec sp_insert 'shreya','Delhi',82828282

create procedure sp_display
as
select * from CustomerData
go
exec sp_display