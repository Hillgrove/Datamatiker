--create procedure CustomerUpdateOtherTables
--as
--	delete from EnglishCustomers;
--	delete from DanishCustomers;
--	insert into DanishCustomers
--		select customerid, name, age from Customers
--		where Country = 'DK';
--	insert into EnglishCustomers
--		select name, age from Customers
--		where Country in (select Country from dbo.EnglishCountries());


--alter procedure CustomerUpdateOtherTables
--as
--	delete from EnglishCustomers;
--	delete from DanishCustomers;
--	insert into DanishCustomers
--		select customerid, name, age from Customers
--		where Country = 'DK';
--	insert into EnglishCustomers
--		select name, age from Customers
--		where Country in (select Country from dbo.EnglishCountries());
--	select COUNT(*) from DanishCustomers;
--	select COUNT(*) from EnglishCustomers;


--create procedure CreateDanishCustomer @name varchar(50), @Age int
--as
--	insert into Customers (Name, Age, Country)
--	values (@name, @Age, 'DK');


--exec CreateDanishCustomer @name = 'Britta', @age = 27


--alter procedure CreateDanishCustomer @name varchar(50), @age int
--as
--	declare @NewIdTable table (customerid int);
--	insert into Customers (Name, Age, Country)
--		output inserted.CustomerId into @NewIdTable
--		values (@name, @age, 'DK');
--	return (select top 1 Customerid from @NewIdTable)

--declare @NewId int;
--exec @newid = CreateDanishCustomer @name = 'BrittaNew', @age = 27
--select @newid


--alter procedure CreateDanishCustomer @name varchar(50), @age int, @newID int output
--as
--	declare @NewIdTable table (customerID int);
--	insert into customers (name, age, Country)
--		output inserted.customerid into @NewIdTable
--		values (@name, @age, 'DK');
--	set @newID = (select top 1 customerid from @NewIdTable)


--declare @NewId int;
--exec CreateDanishCustomer @Name = 'Britta', @Age = 27, @newId = @newid output
--select @newid


--exec sp_executesql
--N'select * from customers where age = @age', N'@age int', @age = 21


declare @StartIndex int = 0;
declare @EndIndex int = 10;
declare @Sql varchar(max);
declare @TempIndex int;

set @TempIndex = @StartIndex;
set @sql = @TempIndex;

while @TempIndex < @EndIndex
begin
	set @TempIndex += 1;
	set @Sql += ',' + cast(@TempIndex as varchar(100));
end;

exec ('select * from customers where customerid in (' + @sql + ')');