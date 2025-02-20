create table ProductTypes(
	ProductTypeId int identity(1,1) not null,
	Name varchar(50) not null,
	constraint PK_ProductTypes primary key clustered (ProductTypeId asc)
)