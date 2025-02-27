--create view CountryInfo as
--	select count(*) as CustomerAmount, min(age) as MinimumAge, max(age) as MaximumAge, Country
--	from Customers
--	group by Country

--create view AllSpecifiedCustomers as
	--select *, 'Danish' as CustomerType
	--from DanishCustomers
	--union
	--select *, 'English' as CustomerType
	--from EnglishCustomers

--create view SpecifiedWithNormal as
--	select a.CustomerId, a.Age, a.CustomerType, customers.Country
--	from AllSpecifiedCustomers as a left join Customers
--	on a.CustomerId = customers.CustomerId

--alter view countryinfo with schemabinding as
--select count_big(*) as CustomerAmount, country
--	from dbo.Customers
--	group by country
--go

--create unique clustered index CountryInfo_Index
--	on CountryInfo (country);