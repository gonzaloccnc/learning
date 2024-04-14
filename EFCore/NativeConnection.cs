using Npgsql;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreD
{
  internal class NativeConnection(string connectionString)
  {
    private readonly NpgsqlConnection _connection = new(connectionString);

    public async Task Connect()
    {
      await _connection.OpenAsync();
    }

    public async Task Disconnect()
    {
      await _connection.CloseAsync();
    }

    public async Task<int> InsertCustomer(Customer customer)
    {
      var cmd = _connection.CreateCommand();
      cmd.CommandText = "INSERT INTO customers (firstname, surnames, age, frequency) VALUES(@p1, @p2, @p3, @p4);";
      cmd.Parameters.AddWithValue("p1", customer.Firstname);
      cmd.Parameters.AddWithValue("p2", customer.Surnames);
      cmd.Parameters.AddWithValue("p3", customer.Age);
      cmd.Parameters.AddWithValue("p4", customer.Frequency);
      var rows = await cmd.ExecuteNonQueryAsync();
      return rows;
    }

    public async Task<List<CustomerDTO>> ReadCustomers()
    {
      List<CustomerDTO> customers = [];
      var cmd = _connection.CreateCommand();
      cmd.CommandText = "SELECT CONCAT(firstname, ', ', surnames), age, frequency FROM customers;";

      var reader = await cmd.ExecuteReaderAsync();
      while (await reader.ReadAsync())
      {
        customers.Add(new()
        {
          Fullname = reader.GetString(0),
          Age = reader.GetInt16(1),
          Frequency = reader.GetInt16(2) switch
          {
            1 => CustomerFrequency.None,
            2 => CustomerFrequency.SPORADIC,
            3 => CustomerFrequency.USUAL,
            _ => throw new Exception("unsoported frecuency"),
          }
        });
      }

      return customers;
    }
  }
}
