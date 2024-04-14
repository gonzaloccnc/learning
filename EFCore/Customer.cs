using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreD
{
  internal readonly record struct Customer(string Firstname, string Surnames, int Age, int Frequency)
  {
  }
}
