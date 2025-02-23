declare @avgAge decimal(5,2) = (select AVG(cast(age as decimal(3,0))) from Customers);
declare @maxAge decimal(3,0) = (select max(age) from customers);
declare @ageDifference decimal(5,2) = @maxAge - @avgAge;

select @avgAge as AverageAge;
select @maxAge as MaxAge;

if @ageDifference > 25.0
begin
	select 'You have a big age diffence of ' + cast(@ageDifference as varchar(6));
end;
else
begin
	select 'Your age difference of ' + cast(@ageDifference as varchar(6)) + ' is acceptable';
end;