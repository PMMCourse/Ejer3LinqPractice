using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            string desr = File.ReadAllText("Heroes.json");
            List<Heroe> listaHeroes = JsonConvert.DeserializeObject<List<Heroe>>(desr);
        }

        public static void Ejercicio2(List<Heroe> listaHeroes)
        {
            var cMale = listaHeroes.Count(x => x.Gender == "Male");
            var cFemale = listaHeroes.Count(x => x.Gender == "Female");

            Console.WriteLine($"Masculinos: {cMale} Femeninos: {cFemale}");
        }

        public static void Ejercicio3(List<Heroe>listaHeroes)
        {
            var primeros = listaHeroes.Where(x => x.Level > 7).Take(10);

            Console.WriteLine(primeros);
        }

        public static void Ejercicio4(List<Heroe>listaHeroes)
        {
            var agrupar = listaHeroes.GroupBy(x => x.HeroeClass);
            Console.WriteLine(agrupar);
        }

        public static void Ejercicio5(List<Heroe>listaHeroes)
        {
            var obtNombre = listaHeroes.Select(x => x.Hp > 50);

            foreach(var name in listaHeroes)
            {
                listaHeroes.Where (x => x.Hp > 50).Take(10);
                Console.WriteLine(name.Name);
            }
        }

        public static void Ejercicio6(List<Heroe>listaHeroes)
        {
            var obNombre = listaHeroes.Where(x => x.Hp > 50 && x.Gender == "Female").Take(10);

            foreach (var a in listaHeroes)
            {
                Console.WriteLine(a.Name);
            }
        }
        public static void Ejercicio7(List<Heroe> listaHeroes)
        {
            var pers = listaHeroes.Where(x => string.IsNullOrEmpty(x.Description.ToString()));

            foreach (var a in listaHeroes)
            {
                Console.WriteLine(a.Name);
            }
        }

        public static void Ejercicio8(List<Heroe>listaHeroes)
        {
            var list = listaHeroes.FindAll(x => x.Hp > 100 && x.Level == 10);

            Console.WriteLine(list);
        }
        public static void Ejercicio10(List<Heroe>listaHeroes)            
        {
            var person = listaHeroes.OrderBy(x => x.Name);
        }

        public static void Ejercicio11(List<Heroe>listaHeroes)
            
        {
            var tGuerreros = listaHeroes.Where(x => x.HeroeClass == "Warrior").Sum(a => a.Hp);

            Console.WriteLine(tGuerreros);
        }
        public static void Ejercicio12(List<Heroe> listaHeroes)
        {
            var totalB = listaHeroes.Where(x => x.HeroeClass == "Bard").Sum(a => a.Mp);

            Console.WriteLine(totalB);
        }
   
    }
}

