insert into DanishCustomers
select customerid, name, age
from Customers
where Country = 'DK'