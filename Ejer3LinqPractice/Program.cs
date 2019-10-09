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
            string heroesJson = File.ReadAllText("Heroes.json");
            List<Heroe> heroes = JsonConvert.DeserializeObject<List<Heroe>>(heroesJson);
        }

        
          public static void Ejer2(List<Heroe> heroes)
        {
             var femenino_num=heroes.Count(x => x.Gender == "Female");
            var masculino_num=heroes.Count(x => x.Gender == "Male");
            

            Console.WriteLine($"Sexo Masculino: " + masculino_num + "\nSexo Femenino: " + femenino_num);
        }

        
        public static void Ejer3(List<Heroe> heroes)
        {
            var personajes = heroes.Where(p => p.Level > 7).Take(10);
            Console.WriteLine(personajes);
        }

        
        public static void Ejer4(List<Heroe> heroes)
        {
            var grupo = heroes.GroupBy(clase => clase.Class);

            foreach(var heroe_C in grupo)
            {
                Console.WriteLine(string.Format("Clase: {0}", heroe_C.Key));

                foreach(var heroe_N in heroe_C)
                {
                    Console.WriteLine($"Nombre: {heroe_N.Name}");
                }
            }
        }

        public static void Ejer5(List<Heroe> heroes)
        {
            var nombres_heroes = heroes.Where(hp => hp.Hp > 50).ToList();

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(nombres_heroes[i].Name);
            }
        }

        
        public static void Ejer6(List<Heroe> heroes)
        {
             var nombres_heroinas = heroes.Where(x => x.Gender == "Female" && x.Hp > 50).ToList();

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(nombres_heroinas[i].Name);
            }
        }

        
        public static void Ejer7(List<Heroe> heroes)
        {
            var desc = heroes.Where(p => p.Description == null);
            Console.WriteLine($"Nombre : " + desc.Name);
        }

        
        public static void Ejer8(List<Heroe> heroes)
        {
            foreach (var nombre_primero in heroes.Where(primero => primero.Hp > 100 && primero.Level == 10 && primero.Gender == "Male").Take(1))
            {
                Console.WriteLine($"Nombre : " + nombre.Name);
            }
        }

       
        public static void Ejer9(List<Heroe> heroes)
        {
             var orden_A_Z = h.OrderBy(x => x.Name);

            foreach (var x in orden)
            {
                Console.WriteLine($"Nombre del Heroe: {x.Name}");
            }
        }

        
        public static void Ejer10(List<Heroe> heroes)
        {
             var orden_Z_A = h.OrderByDescending(x => x.Name);

            foreach (var x in orden)
            {
                Console.WriteLine($"Nombre del Heroe: {x.Name}");
            }
        }

        
        public static void Ejer11(List<Heroe> heroes)
        {
             var hpTotal = heroes.Where(x => x.Class == "Warrior").Sum(y => y.Hp);

            Console.WriteLine($"Hp total: {hpTotal}");
        }

        
        public static void Ejer12(List<Heroe> heroes)
        {
            var mana_total = heroes.Where(p.Class == "Bardo" && p.Level > 3).Sum(p => p.Mp);
            Console.WriteLine(mana_total);
        }

    }
}
