create table Products(
	ProductId int identity(1,1) not null,
	Name varchar(20) not null,
	ProductTypeId int not null,
	constraint PK_Products primary key clustered (ProductId asc),
	constraint FK_Products_ProductTypes foreign key (ProductTypeId) references ProductTypes(ProductTypeId)
)