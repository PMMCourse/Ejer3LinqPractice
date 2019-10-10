using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice
{
    public class Heroe
    {
        public override string ToString()
        {
            return "Name: " + this.Name + "\nHp: " + this.Hp + "\nMp: " + this.Mp + "\nHeroeClass: " + this.Class + "\nLevel:" + this.Level + "\nGender:" + this.Gender + "\nDescription: " + this.Description + "\n";
        }
        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }

        public string Class { get; set; }

        public int Level { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }
    }
}
