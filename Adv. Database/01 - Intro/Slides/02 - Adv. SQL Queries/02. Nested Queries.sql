select * from Orders
where OrderId in
(
	select OrderProducts.OrderId from OrderProducts
	where OrderProducts.ProductId in
	(
		select products.productid from products
		where products.ProductTypeId in
		(
			select producttypeid from ProductTypes
			where Name like '%Service%'
		)
	)
)

