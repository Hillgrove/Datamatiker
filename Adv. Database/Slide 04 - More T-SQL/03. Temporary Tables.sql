--create table #Customers(
--	CustomerID int identity(1,1) not null,
--	Name varchar(50) not null,
--	Age int not null,
--	Country char(2) not null,
--	foreign key (CustomerID) references Customers(CustomerID),
--	constraint PK_TempCustomers primary key clustered(CustomerID asc)
--)


--Using a Cursor iterate the Customers table, and add all the 
--customers whose age is below 40 
--(using an if statement, not WHERE in the query)
--Then select the average age from the temporary table

create table #tempCustomers(
	Age int not null
)

declare @custAge int, @ageCriteria int = 40;

declare myCursor cursor for 
select Age from Customers;

open myCursor;
fetch next from myCursor into @custAge

while @@FETCH_STATUS = 0
begin
	if @custAge < @ageCriteria
	begin
		insert into #tempCustomers
		select @custAge
	end;
	fetch next from MyCursor into @custAge
end;	
close myCursor
deallocate myCursor

select avg(age) from #tempCustomers;

select avg(age) from customers
where age < 40;