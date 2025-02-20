select customerid, name, age
into EnglishCustomers
from Customers
where Country in ('US', 'UK')