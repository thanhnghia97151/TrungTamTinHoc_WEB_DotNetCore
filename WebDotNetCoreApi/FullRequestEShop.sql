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
	@Description nvarchar(max)
)
as
begin
	insert into Product (ProductName,Sku,Price,SaleOff,Material,ImageUrl,Description)
	values (@Name,@Sku,@Price,@SaleOff,@Material,@ImageUrl,@Description);
	set @ProductId = SCOPE_IDENTITY();
end
-- Khó chịu mối quan hệ nhiều - nhiều 
--drop table CategoryProduct;
create table CategoryProduct(
	CategoryId tinyint not null references Category(CategoryId),
	ProductId int not null references Product(ProductId)
)

select * from Category
select * from CategoryProduct


create proc EditProduct(
	@ProductId int,
	@ProductName nvarchar(128),
	@Sku varchar(16),
	@Price int,
	@SaleOff decimal = null,
	@Material nvarchar(32),
	@ImageUrl nvarchar(32),
	@Description nvarchar(max)
)
as

	update  Product set ProductName=@ProductName,Sku=@Sku,Price=@Price,SaleOff=@SaleOff,Material=@Material,ImageUrl=@ImageUrl,Description=@Description
	where ProductId =@ProductId;
go
--drop proc GetCategoryByProduct;
create proc GetCategoryByProduct(@Id int)
as
	select Category.*, iif(ProductId is null,0,1) as checked from Category left join CategoryProduct on Category.CategoryId=CategoryProduct.CategoryId
	 and ProductId = @Id;

	 exec GetCategoryByProduct @Id=1;

--drop proc GetProductByCategory
create proc GetProductByCategory(@Id tinyint)
as
	select * from Product join CategoryProduct
		on Product.ProductId=CategoryProduct.ProductId
		where CategoryId =@Id;
go
exec GetProductByCategory @Id=2;

select * from CategoryProduct

--drop proc ProductsRelation;
create proc ProductsRelation(
	
	@ProductId int
)
as
	select * from Product join CategoryProduct on
	Product.ProductId = CategoryProduct.ProductId
	and Product.ProductId<>@ProductId
	and CategoryId in (select CategoryId from CategoryProduct where ProductId=@ProductId)
	go
exec ProductsRelation @ProductId =1 

create table AutoSendMail(
	AutoSendMailId int not null primary key identity(1,1),
	Email varchar(64) not null,
	Subject nvarchar(64) not null,
	Body nvarchar(max) not null,
	SendDate datetime not null,
	IsSend bit not null default 0
)

insert into AutoSendMail(Email,Subject,Body,SendDate) values
	('nguyenthanhnghia0907@gmail.com',N'Auto Test Send Mail',N'Content for Email','2021/12/31 1:00:00'),
	('nguyenthanhnghia009007@gmail.com',N'Auto Test Send Mail',N'Content for Email','2021/12/31 13:00:00')

	insert into AutoSendMail(Email,Subject,Body,SendDate) values
	('ngynhi0907@gmail.com',N'Auto Test Send Mail',N'Content for Email','2021/12/31 18:00:00')
select * from AutoSendMail where IsSend =0 ;

--drop table Cart;
create table Cart(
	CartId varchar(32) not null,
	ProductId int not null,
	Quantity smallint not null,
	CartDate datetime not null default GETDATE(),
	primary key (CartId,ProductId)

)
-- drop proc AddCart;
create proc AddCart(
	@CartId varchar(32) ,
	@ProductId int,
	@Quantity smallint
)
as
	begin
		if exists(select * from Cart where CartId=@CartId and ProductId=@ProductId)
			update Cart set Quantity += @Quantity where CartId = @CartId and ProductId = @ProductId;
		else
			insert into Cart(CartId,ProductId,Quantity) values (@CartId,@ProductId,@Quantity)
	end
go
--drop proc GetCarts;
create proc GetCarts(@Id varchar(64))
as
begin
	select Cart.*,ProductName,Price,ImageUrl from Cart join Product on Cart.ProductId=Product.ProductId 
	where CartId = @Id;
end

select * from Cart
delete from Cart where CartId ='jz3wox37eaaqnzhlx9p7s1c49kfzqn4h' and ProductId=1
--drop table Member;
create table Member(
	MemberId varchar(64) not null primary key,
	UserName varchar(32) not null unique,
	Password varbinary(64) not null,
	Email varchar(64) not null,
	Gender bit not null

)

create table Role(
	RoleId uniqueidentifier not null primary key default NewId(),
	RoleName varchar(16) not null
)
--drop table MemberInRole;
create table MemberInRole(
	MemberId varchar(64) not null,
	RoleId uniqueIdentifier not null,
	Primary key (MemberId,RoleId)
)
select * from Member
select * from Member where UserName='nghia' 