using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreD.Context
{
  public class NativeContext(string cnxString) : DbContext
  {
    private readonly string _cnxString = cnxString;
    public virtual DbSet<CustomerEntity> Customers { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder builder) =>
      builder.UseNpgsql(_cnxString);
  }
}
