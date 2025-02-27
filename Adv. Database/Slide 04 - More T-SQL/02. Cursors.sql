--declare @currentID int, @currentName varchar(max);

--declare myCursor cursor for
--select customerid, name from Customers;

--open myCursor;
--fetch next from myCursor into @currentID, @CurrentName

--while @@FETCH_STATUS = 0
--begin
--	select @currentId, @currentName;
--	fetch next from myCursor into @currentID, @currentName
--end;

--close myCursor;
--deallocate myCursor;


declare @lowestAge int = 999, @highestAge int = 0, @sumAge int = 0, @currentAge int;
declare myCursor cursor for
select age from customers;

open myCursor;
fetch next from myCursor into @currentAge;

while @@FETCH_STATUS = 0
begin
	if @currentAge < @lowestAge set @lowestAge = @currentAge
	if @currentAge > @highestAge set @highestAge = @currentAge
	set @sumAge += @currentAge;
	
	fetch next from myCursor into @currentAge;
end;

close myCursor;
deallocate myCursor;

select @lowestAge as LowestAge
select @highestAge as HighestAge
select @sumAge as SumAge