use WorkShop
go
select dbo.Clients.FullName, dbo.Cars.Model, dbo.Orders.ExecStartDate 
from Orders
join Clients on Clients.ID = Orders.ClientID
join Cars on Cars.ID = Orders.CarID
where Orders.MasterID is null
order by ExecStartDate
