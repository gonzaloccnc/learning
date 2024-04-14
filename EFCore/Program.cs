using EFCoreD;
using EFCoreD.Context;

string cnxString = "Host=localhost; Username=gonza; Password=gonzalo123; Database=native_dotnet";

/*
await using var cnx = new NpgsqlConnection(cnxString);
await cnx.OpenAsync();

//"INSERT INTO customers (firstname, surnames, age, frequency) VALUES ($1, $2, $3, $4);" < -parameters
//"INSERT INTO customers (firstname, surnames, age, frequency) VALUES (@p1, @p2, @p3, @p4);" < -positional and named placeholders

await using (var cmd = cnx.CreateCommand())
{
  cmd.CommandText = "INSERT INTO customers (firstname, surnames, age, frequency) VALUES (@p1, @p2, @p3, @p4);";
  cmd.Parameters.AddWithValue("p1", "GONZALO");
  cmd.Parameters.AddWithValue("p2", "MANCO GARCIA");
  cmd.Parameters.AddWithValue("p3", 21);
  cmd.Parameters.AddWithValue("p4", 2);
  var rows = await cmd.ExecuteNonQueryAsync();
  Console.WriteLine($"rows affected: {rows}");
}

try
{
  await using (var cmd = new NpgsqlCommand("SELECT CONCAT(firstname, ' ', surnames), age FROM customers;", cnx))
  await using (var reader = await cmd.ExecuteReaderAsync())
  {
    while (await reader.ReadAsync())
      Console.WriteLine($"{reader.GetString(0)} {reader.GetInt16(1)}");
  }
}
catch (Exception e)
{
  Console.WriteLine(e.Message);
}
*/

/*
var psql = new NativeConnection(cnxString);

await psql.Connect();

var rows = await psql.InsertCustomer(new Customer("Pepe", "Mundil", 19, 1));
var customers = await psql.ReadCustomers();
Console.WriteLine($"total rows affected: {rows}");

customers.ForEach(c =>
  Console.WriteLine($"fullname: {c.Fullname}, age: {c.Age}, frecuency: {c.Frequency}")
);
await psql.Disconnect();

*/

var efNativeContext = new NativeContext(cnxString);

var query = from customer in efNativeContext.Customers
            orderby customer.Firstname
            select new { customer.Id, customer.Firstname, customer.Surnames, customer.Age };


query.ToList().ForEach(x =>
  Console.WriteLine($"Id: {x.Id}, firstname: {x.Firstname}, surnames: {x.Surnames}, age: {x.Age}")
);

//efNativeContext.Customers.ToList().ForEach(x =>
//  Console.WriteLine($"Id: {x.Id}, firstname: {x.Firstname}, surnames: {x.Surnames}, age: {x.Age}")
//);