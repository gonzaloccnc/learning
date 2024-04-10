using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Dog: Animal
    {
        public Dog() { }

        public override string MakeSound()
        {
            return "wow wow!";
        }
    }
}
