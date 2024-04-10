using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POO
{
    internal class Person
    {
        public string Name { get; set; }
        public short Age { get; set; }
        public DateOnly Birthday {  get; set; }
        public string Surname { get; set; }

        public Person(string name, short age, DateOnly birthday, string surname)
        {
            Name = name;
            Age = age;
            Birthday = birthday;
            Surname = surname;
        }

        public override string ToString()
        {
            return $"name: {Name}, age: {Age}, birthday: {Birthday}, surname: {Surname}";
        }
    }
}
