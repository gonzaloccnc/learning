using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreD
{
  internal readonly record struct CustomerDTO(string Fullname, int Age, CustomerFrequency Frequency)
  {
  }

  internal enum CustomerFrequency
  {
    None = 1,
    SPORADIC = 2,
    USUAL = 3
  }
}
