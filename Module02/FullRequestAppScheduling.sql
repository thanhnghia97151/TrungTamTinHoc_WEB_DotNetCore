 

 --drop proc GetProfessorsByMoudleId
 --go
create proc GetProfessorsByMoudleId(@Id int)
as

Select * from Professor join ModuleProfessor
on Professor.Professor_Id = ModuleProfessor.ProfessorId
and ModuleId = @Id;
go

Exec GetProfessorsByMoudleId @Id =1;
select * from Professor
select * from ModuleProfessor

--drop proc GetProfessorsNotInMoudle
--go
create proc GetProfessorsNotInMoudle(@Id int)
as
select * from Professor where Professor_Id not in 
	(select ProfessorId from ModuleProfessor where  ModuleId = @Id);
go

exec GetProfessorsNotInMoudle @Id = 1;


select * from Professor where Professor_Id not in 
	(select ProfessorId from ModuleProfessor where  ModuleId != 1);



create proc GetProfessorsChecked(@Id int)
as
	select Professor.*, CAST(IIF(ModuleId is null,0,1)as bit) Checked from Professor
	left join ModuleProfessor
	on Professor.Professor_Id = ModuleProfessor.ProfessorId
	and ModuleId = @Id;
go

exec GetProfessorsChecked @Id =1;

create table [Group] 
(
	GroupId int not null primary key,
	GroupSize smallint not null
);

create table ModuleGroup
(
	ModuleId int not null references Module(ModuleId),
	GroupId int not null references [Group](GroupId),
	 primary key (ModuleId,GroupId)
);

insert into [Group] (GroupId,GroupSize) values 
	(1,2),(2,3)
select * from [Group]
select * from ModuleGroup
select * from Module
select * from ModuleProfessor


bulk insert ModuleGroup from "path" with (FORMAT='csv',firstrow =2,Fieldterminator=',',rowterminator='0x0A');-- add file csv
delete from ModuleGroup 

create table Class
(
	ClassId int not null primary key,
	ProfessorId int not null references Professor(Professor_Id),
	ModuleId int not null references Module(ModuleId),
	RoomId int not null references Room(RoomId),
	GroupId int not null references [Group](GroupId),
	TimeslotId  int not null references Timeslot(TimeslotId)
);



create table Member(
	MemberId char(32) not null primary key,
	Username varchar(32) not null unique,
	Password varbinary(64) not null,
	Email varchar(32) not null,
	Gender bit not null
)

select * from Member

create table [Role]
(
	RoleId uniqueidentifier not null primary key Default NewId(),
	RoleName varchar(32) not null unique
)

create table MemberInRole
(
	MemberId char(32) not null references Member (MemberId),
	RoleId uniqueidentifier not null references [Role](RoleId),
	IsDeleted Bit not null default 0,
	primary key (MemberId,RoleId)
)

--drop proc GetRolesByMember
go
create proc GetRolesByMember(@Id char(32))
as
	select Role.*, cast(iif(MemberId is null,0,1) as bit) as Checked from  [Role] left join MemberInRole
	on [Role].RoleId = MemberInRole.RoleId
	and MemberId = @Id and IsDeleted=0;
go

select * from [Role]

exec GetRolesByMember @Id='F43236A0-ACFF-4A61-61A5-08D9A0516746';

create proc SaveMemberInRole(@MemberId char(32), @RoleId uniqueidentifier)
as
	begin
		if	exists(select * from MemberInRole where MemberId=@MemberId and RoleId =@RoleId)
			update MemberInRole set IsDeleted =~IsDeleted  where MemberId = @MemberId and RoleId =@RoleId;
		else 
			insert into MemberInRole (MemberId,RoleId) values (@MemberId,@RoleId);
	end
go



select * from Role

--drop proc GetRolesByMemberId;
go
create proc GetRolesByMemberId(@Id char(32))
as
	select Role.* from Role join MemberInRole on Role.RoleId = MemberInRole.RoleId
	where MemberId =@Id and IsDeleted=0;
go
exec GetRolesByMemberId

select * from Member
select * from Role
select * from MemberInRole
select * from Access

alter table Member add Token varchar(32)
select * from Member
select * from District

--drop table Access; 
go
Create table Access(
	AccessId uniqueidentifier not null primary key default newid(),
	AcessName nvarchar(32) not null,
	RoleId uniqueidentifier not null references [Role](RoleId),
	Url varchar(64) not null
);
select * from Ward

drop proc GetAccessesByMemberId;
create proc GetAccessesByMemberId(@Id char(32))
as
	select Access.* from Access join MemberInRole on Access.RoleId = MemberInRole.RoleId
	and IsDeleted = 0 and MemberId = @Id
go
select * from Member
exec GetAccessesByMemberId @Id = 'zjzej8jfncj8rlxmxmuf5uj64b7sbj89'


drop table Superstore;
create table Superstore
(
	RowId int not null primary key,
	OrderId nvarchar(100),
	OrderDate datetime,
	ShipDate datetime,
	ShipMode nvarchar(100),
	CustomerId nvarchar(100),
	CustomerName nvarchar(100),
	Segment nvarchar(100),
	Country nvarchar(100),
	City nvarchar(100),
	State nvarchar(100),
	PostalCode nvarchar(100),
	Region nvarchar(100),
	ProductId nvarchar(100),
	Category nvarchar(100),
	SubCategory nvarchar(100),
	ProductName nvarchar(1000),
	Sales decimal(10,2),
	Quantity int,
	Discount decimal(10,2),
	Profit decimal(10,2)
)
select * from Superstore

create proc StatisticSalesByRegion
as
	select Region as Name,Sum(Sales) as Total from Superstore group by Region;
go
exec StatisticSalesByRegion;
go
/*public int RowId { get; set; }
        public string OrderId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ShipDate { get; set; }
        public string ShipMode { get; set; }
        public string CustomerId { get; set; }
        public string CustomerName { get; set; }
        public string Segment { get; set; }
        public string Country { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        //public string PostalCode { get; set; }
        public string Region { get; set; }
        public string ProductId { get; set; }
        public string Category { get; set; }
        public string SubCategory { get; set; }
        public string ProductName { get; set; }
        public double Sales { get; set; }
        public int Quantity { get; set; }
        public double Discount { get; set; }
        public double Profit { get; set; }*/
drop table Image
create table Image
(
		ImageId uniqueidentifier not null primary key,
		ImageOriginal nvarchar(64) not null,
		ImageUrl nvarchar(64) not null,
		ImageType nvarchar(32) not null,
		ImageSize bigint not null
)
select * from Image

create table Category
(
	CategoryId int not null primary key identity(1,1),
	CategoryName nvarchar(64) not null,
	ParentId int references Category(CategoryId)
)
drop table Pdf;
create table TestPdf(
	PdfId int not null primary key identity(1,1),
	PdfUrl varchar(32) not null,
	PdfSize bigint not null
);
select * from Pdf