using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice
{
    public class Heroe
    {
        public string Name { get; set; }

        public int Hp { get; set; }

        public int Mp { get; set; }

        //En el JSON tienes el atributo como "Class" y aqui estaba como "HeroeClass". Lo cambio para poder acceder.
        public string Class { get; set; }

        public int Level { get; set; }

        public string Gender { get; set; }

        public string Description { get; set; }
    }
}
