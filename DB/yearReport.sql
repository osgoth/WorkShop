use WorkShop
go
select Masters.FullName
	, count(Orders.ID) as OrderQua
	, coalesce(sum(Orders.Price),0) as SumTot
	, count(OrderDetails.Repeated) as RepeatedQua
	, DATENAME(month, Orders.ExecEndDate) as Month
from Masters
join Orders on Orders.MasterID = Masters.ID
left join OrderDetails on Orders.ID = OrderDetails.OrderID
where Year(ExecEndDate) = Year(GETDATE())
group by Masters.FullName
	, Orders.ExecEndDate
order by month(ExecEndDate) asc
	, Masters.FullName