create table OrderProducts(
	OrderId int not null,
	ProductId int not null,
	Amount int default 1,
	constraint FK_OrderProducts_Orders foreign key (OrderId)
		references Orders(OrderId),
	constraint FK_OrderProducts_Products foreign key (ProductId)
		references Products(ProductId)
)