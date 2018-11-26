use WorkShop
go
select Orders.ExecStartDate, coalesce(Masters.FullName, '-') as MasterName, Clients.FullName, Cars.Model
from Orders
left join Masters on Masters.ID = Orders.MasterID
join Clients on Clients.ID = Orders.ClientID
join Cars on Cars.ID = Orders.CarID
where Orders.Price is null
