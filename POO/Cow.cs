using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Cow: IAnimal
    {
        public Cow() { }

        public string MakeSound()
        {
            return "muuuuuuuuuuuu!";
        }
    }
}
