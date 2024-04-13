using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Linqd
{
  record City(long Population);
  record Country(string Name, List<City> Cities, long Area, long Population)
  {
  }

  record Product(string Name, string Category);
}
