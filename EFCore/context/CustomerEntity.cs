using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreD.Context
{

  [Table("customers")]
  public class CustomerEntity
  {
    [Column("id")]
    public long Id { get; set; }

    [Column("firstname")]
    public string Firstname { get; set; } = null!;

    [Column("surnames")]
    public string Surnames { get; set; } = null!;

    [Column("age")]
    public int Age { get; set; }

    [Column("frequency")]
    public int Frequency { get; set; }
  }
}
