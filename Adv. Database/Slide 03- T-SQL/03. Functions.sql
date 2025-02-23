--create function GetCustomerCount()
--returns int
--as
--begin
--	return (select COUNT(*) from Customers);
--end;


--alter function dbo.GetCustomerCount(@MinAge int, @MaxAge int)
--returns int
--as
--begin
--	return (select COUNT(*) from Customers
--	where Age between @MinAge and @MaxAge)
--end;


--create function GetCustomerCountGroups()
--returns table
--as
--	return select COUNT(*) as CustomerCount, Country
--		   from Customers
--		   group by Country;


--create function EnglishCountries()
--returns table
--as
--	return select 'UK' as Country union select 'US' as Country


--create function EnglishCountries()
--returns @myTable table (Country char(2))
--as
--begin
--	insert into @mytable
--	values ('UK'), ('US')
--	return;
--end

select * from EnglishCountries();