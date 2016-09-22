<Query Kind="Expression">
  <Connection>
    <ID>7df2a8ce-e60b-4da4-b364-a1dde275f464</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//Sample of Entity subset & navigation from child to parent
//Code is C# and thus appropriate methods can be used
from c in Customers
where c.SupportRepIdEmployee.FirstName.Equals("Jane") && c.SupportRepIdEmployee.LastName.Equals("Peacock")
select new{
	Name = c.FirstName + " " + c.LastName,
	c.City,
	c.State,
	c.Phone,
	c.Email
}

//Aggregates
//Count() counts the number
//Sum() totals a specific field
from a in Albums
orderby a.Title
where a.Tracks.Count() > 0
select new{
	a.Title,
	Songs = a.Tracks.Count(),
	Price = a.Tracks.Sum(y => y.UnitPrice),
	AverageTrackLength = a.Tracks.Average(x => x.Milliseconds / 1000)
}

from mt in MediaTypes
select new{
	TrackName = mt.Name(),
	TrackCount = mt.Tracks.Count()
}