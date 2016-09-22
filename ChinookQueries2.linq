<Query Kind="Statements">
  <Connection>
    <ID>7df2a8ce-e60b-4da4-b364-a1dde275f464</ID>
    <Persist>true</Persist>
    <Server>.\SQLEXPRESS</Server>
    <Database>Chinook</Database>
  </Connection>
</Query>

//When you need to use multiple steps to solve a problem, switch your language choice to either Statement or Program
//The results of each query will now be saved in a variable to be used in future queries

var maxcount = (from x in MediaTypes
	select x.Tracks.Count()).Max();
	
//To display the contents of a vriable in linqpad, you use .Dump()

maxcount.Dump();

//using a value in a previously created variable
var popularMediaType = from x in MediaTypes where x.Tracks.Count() == maxcount select new{Type = x.Name,TCount = x.Tracks.Count()};

popularMediaType.Dump();

//Can it be done as a complete query? Yes (not always the case)
//maxcount can be swapped with the query that created it's value in the first place.
//