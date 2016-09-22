<Query Kind="Expression">
  <Connection>
    <ID>c0ee3044-e74f-44f3-8d29-fba1162ad617</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>eRestaurant</Database>
  </Connection>
</Query>

//muli-column group
//grouping data in a local dataset for further processing.
//.key allows you to access values stored in the group
//If there are multiple group columns, they must be in a anonymous datatype
//to create a DTO type collection, you can use .TOList() on the temp data set.

from food in Items
    group food by new {food.MenuCategoryID, food.CurrentPrice} into tempdataset
	select new{
		MenuCategoryID = tempdataset.Key.MenuCategoryID,
		CurrentPrice = tempdataset.Key.CurrentPrice,
		FoodItems = from x in tempdataset 
					select new{
						ItemID = x.ItemID,
						Description = x.Description,
						TimesServed = x.BillItems.Count()
					}
	}