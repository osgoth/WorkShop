use WorkShop

go

create procedure WithoutMaster
as
select dbo.Clients.FullName
	, dbo.Cars.Model
	, dbo.Orders.ExecStartDate 
from Orders
join Clients on Clients.ID = Orders.ClientID
join Cars on Cars.ID = Orders.CarID
where Orders.MasterID is null
order by ExecStartDate

go

create procedure WithoutPrice
as
select Orders.ExecStartDate
	, coalesce(Masters.FullName, '-') as MasterName
	, Clients.FullName, Cars.Model
from Orders
left join Masters on Masters.ID = Orders.MasterID
join Clients on Clients.ID = Orders.ClientID
join Cars on Cars.ID = Orders.CarID
where Orders.Price is null

go

create procedure YearReport
as
select Masters.FullName
	, count(Orders.ID) as OrderQua
	, coalesce(sum(Orders.Price),0) as SumTot
	, count(OrderDetails.Repeated) as RepeatedQua
	, DATENAME(month, Orders.ExecStartDate) as Month
from Masters
join Orders on Orders.MasterID = Masters.ID
left join OrderDetails on Orders.ID = OrderDetails.OrderID
where Year(ExecStartDate) = Year(GETDATE())
group by Masters.FullName
	, Orders.ExecStartDate
order by month(ExecStartDate) asc
	, Masters.FullName
