-- Must propogate left joins as subsequence inner joins will override outer joins.
select Customers.Name, orderdatetime, Orders.OrderId, Products.Name, ProductTypes.Name
from Customers
left join Orders on Customers.CustomerId = Orders.CustomerId
left join OrderProducts on Orders.OrderId = OrderProducts.OrderId
left join Products on OrderProducts.ProductId = Products.ProductId
left join ProductTypes on Products.ProductTypeId = ProductTypes.ProductTypeId
order by customers.CustomerId, OrderDateTime