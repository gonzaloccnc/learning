using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Pig: Animal
    {
        public Pig() { }

        public override string MakeSound()
        {
            return "wee weee!";
        }
    }
}
