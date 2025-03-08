--create trigger customerInsertTrigger
--	on Customers
--after insert
--as
--begin
--	set identity_insert DanishCustomers on;
--	insert into DanishCustomers (customerid, name, age)
--		select customerId, name, age from inserted where Country = 'DK';
--	set identity_insert DanishCustomer off;
--end;

--create table Log(
--	ID int identity(1,1) primary key not null,
--	LogDate datetime default getutcdate(),
--	OperationType varchar(10) not null,
--	Message varchar(8000) not null
--)

--create trigger TRG_CustomerInsertDeleteLog
--	on Customers
--	after insert, delete
--as
--begin
--	insert into log (logdate, operationType, [Message])
--	select getutcdate(), 'INSERTED',
--		'CustomerID: ' + CAST(CustomerID as varchar(250)) + 
--		' Name: ' + Name +
--		' Age: ' + CAST(age as varchar(3))
--	from inserted
--	union
--	select getutcdate(), 'DELETED',
--		'CustomerID: ' + CAST(CustomerID as varchar(250)) + 
--		' Name: ' + Name +
--		' Age: ' + CAST(age as varchar(3))
--	from deleted;
--end;

--insert into customers (name, age, country)
--values ('Lars Henriksen', 34, 'DK')

--delete from Customers
--where name = 'Lars Henriksen';

--select * from log;