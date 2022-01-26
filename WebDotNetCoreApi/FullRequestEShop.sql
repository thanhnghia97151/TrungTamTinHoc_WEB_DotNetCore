create database EShop
go
drop table Category;
create table Category(
	CategoryId tinyint not null primary key identity(1,1),
	CategoryName nvarchar(64)not null
)

insert into Category(CategoryName) values 
	(N'Name'),(N'Nữ')
go
 drop table Product;
create table Product(
	ProductId int not null primary key identity(1,1) ,
	ProductName nvarchar(128) not null,
	Sku varchar(16) not null,
	Price int not null,
	SaleOff decimal,
	Material nvarchar(32) not null,
	ImageUrl nvarchar(32) not null,
	Description nvarchar(max)
);

insert into Product(ProductName,Sku,Price,SaleOff,Material,ImageUrl,Description) values
	(N'Áo mới Cà Mau','23221122',15000,null,N'Vải Cotton',N'Chưa có',N'Chưa có')

create table CategoryProduct(
	CategoryId tinyint not null references Category(CategoryId),
	ProductId int not null references Product(ProductId)
)

