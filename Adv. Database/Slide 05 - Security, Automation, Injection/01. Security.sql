--use CustomerDB
--exec sp_change_users_login @Action='Report';

--select p.name, p.sid
--from sys.database_principals p
--where p.type in ('G', 'S', 'U')
--and p.sid not in (select sid from sys.server_principals)
--and p.name not in (
--	'dbo', 'guest', 'INFORMATION_SCHEMA', 'sys', 'MS_DataCollectorInternalUser'
--);


--create procedure sp_get_all_orphaned_users
--as
--begin
--	declare @DbName nvarchar(255);
--	declare @SQL nvarchar(max);
--	declare @DbList table (Name nvarchar(255));
	
--	create table #ReturnTable (UserName nvarchar(255), UserSID varbinary(max));
	
--	insert into @DbList (Name)
--	select name from sys.databases
--	where name not in ('master', 'tempdb', 'model', 'msdb');

--	declare cur cursor for
--	select Name from @DbList;

--	open cur;
--	fetch next from cur into @DbName;

--	while @@FETCH_STATUS = 0
--	begin
--		Set @SQL =
--			N'use [' + @Dbname + N'];
--			insert into #ReturnTable (UserName, UserSID)
--			EXEC sp_change_users_login ''Report'';';

--		exec sp_executesql @sql;

--		fetch next from cur into @DbName;
--	end;

--	close cur;
--	deallocate cur;

--	select * from #ReturnTable

--	drop table #ReturnTable;
--end;