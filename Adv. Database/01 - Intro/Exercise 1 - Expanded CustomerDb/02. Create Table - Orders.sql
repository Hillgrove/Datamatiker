create table Orders(
	OrderId int identity(1,1) not null,
	CustomerId int not null,
	OrderDateTime datetime default getdate(),
	constraint PK_Orders primary key clustered (OrderId asc),
	constraint FK_Orders_Customer foreign key (CustomerId)
		references Customers(CustomerId)
)