use WorkShop
go
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