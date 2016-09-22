<Query Kind="Statements">
  <Connection>
    <ID>c0ee3044-e74f-44f3-8d29-fba1162ad617</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

var billCount = from w in Waiters select w.Bills.Count();
var mostBills = from waiter in Waiters where waiter.Bills.Count() == billCount.Max() select new{
	Name = waiter.FirstName + " " + waiter.LastName,
	Bills = waiter.Bills.Count()
};

mostBills.Dump();