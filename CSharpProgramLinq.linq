<Query Kind="Program">
  <Connection>
    <ID>c0ee3044-e74f-44f3-8d29-fba1162ad617</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

void Main()
{
	var maxBillCount = (from x in Waiters select x.Bills.Count()).Max();
	var BestWaiter = from x in Waiters
					where x.Bills.Count() == maxBillCount
					select new{
						Name = x.FirstName + ", " + x.LastName
					};
	BestWaiter.Dump();
	var WaiterBills = from x in Waiters
					orderby x.LastName, x.FirstName
					select new{
						Name = x.FirstName + ", " + x.LastName,
						TotalBillCount = x.Bills.Count(),
						BillInfo = (from y in Bills where y.BillItems.Count() > 0 select new{
							y.BillID,
							y.BillDate,
							y.TableID,
							Total = y.BillItems.Sum(b => b.SalePrice * b.Quantity)
						})
					};
	WaiterBills.Dump();
}