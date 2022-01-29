create database EShop
go
--drop table Category;
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
--drop proc AddProduct;
create proc AddProduct(
	@ProductId int out,
	@Name nvarchar(128),
	@Sku varchar(16),
	@Price int,
	@SaleOff decimal = null,
	@Material nvarchar(32),
	@ImageUrl nvarchar(32),
	@Description nvarchar(256)
)
as
begin
	insert into Product (ProductName,Sku,Price,SaleOff,Material,ImageUrl,Description)
	values (@Name,@Sku,@Price,@SaleOff,@Material,@ImageUrl,@Description);
	set @ProductId = SCOPE_IDENTITY();
end
-- Khó chịu mối quan hệ nhiều - nhiều 
create table CategoryProduct(
	CategoryId tinyint not null references Category(CategoryId),
	ProductId int not null references Product(ProductId)
)

select * from Category
select * from CategoryProduct