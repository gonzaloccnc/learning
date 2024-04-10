using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Employee(string enterprice, float salary, string name, short age, DateOnly birthday, string surname) : Person(name, age, birthday, surname)
    {
        public string Enterprice { get; set; } = enterprice;
        public float Salary { get; set; } = salary;

        public override string ToString()
        {
            return $"{base.ToString()}, enterprice: {Enterprice}, salary: ${Salary}";
        }
    }
}
