<Query Kind="Expression">
  <Connection>
    <ID>c0ee3044-e74f-44f3-8d29-fba1162ad617</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

from i in Items
where i.CurrentPrice >= 5.00m
select new{
	i.Description, 
	i.Calories
}