using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Poleev_linq
{
    internal class Person
    {
        public string Firstname { get; set; }
        public string Secondname { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public int Weight { get; set; }
        public Person(string firstname, string secondName, string surname, int age, int weight)
        {
            Firstname = firstname;
            Secondname = secondName;
            Surname = surname;
            Age = age;
            Weight = weight;
        }
        public override string ToString()
        {
            return $"{Firstname} {Secondname} {Surname} {Age} {Weight}";
        }
    }
}
