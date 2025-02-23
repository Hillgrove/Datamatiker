begin transaction
declare @customerCount int = (select COUNT(customerId) from Customers);
declare @deletedCustomers int = 0;

while @customerCount > 6
begin
	delete from Customers where CustomerId = (select MAX(CustomerId) from Customers);
	set @deletedCustomers += 1;
	set @customerCount -= 1;
end;

select 'Loop deleted ' + CAST(@deletedCustomers as varchar(8)) + ' customers';

if @deletedCustomers > 2
begin
	select 'Rollback' as ActionTaken;
	rollback;
end;
else
begin
	select 'Commit - but not really' as ActionTaken;
	rollback; --should be COMMIT according to exercise
end;