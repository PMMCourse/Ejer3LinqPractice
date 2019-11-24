using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Ejer3LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            String baseDatos = File.ReadAllText("Heroes.json");
            List<Heroe> heroes = JsonConvert.DeserializeObject<List<Heroe>>(baseDatos);
            Ejer2(heroes);
            Ejer3(heroes);
            Ejer4(heroes);
            Ejer5(heroes);
            Ejer6(heroes);
            Ejer7(heroes);
            Ejer8(heroes);
            Ejer9(heroes);
            Ejer10(heroes);
            Ejer11(heroes);
            Ejer12(heroes);
            Ejer13(heroes);
            Ejer14(heroes);
            Extension.Ejer15(heroes, 19, "paco");
        }

        public  static void Ejer2(List<Heroe>heroes)
        {
            var hombres = heroes.Count(x => x.Gender == "Male");
            var mujeres = heroes.Count(x => x.Gender == "Female");
            Console.WriteLine("heroes con genero masculino " + hombres + " y heroes con genero femenino " + mujeres);
        }
        public static void Ejer3(List<Heroe> heroes)
        {
            var nombre = heroes.Where(y => y.Level > 7).Take(10);
           Console.WriteLine(nombre);
             
            }

        
        public static void Ejer4(List<Heroe>heroes)
        {
     
        var grupos = heroes.GroupBy(x => x.HeroeClass);
        Console.WriteLine(grupos); 
        }
        public static void Ejer5(List<Heroe> heroes)
        {
            var nombre = heroes.Where(x => x.Hp > 50);
            foreach (var a in nombre)
            {
                heroes.Where(x => x.Hp > 50).Take(10);
                Console.WriteLine("nombre: " + a.Name);
            } 
            
        }

        public static void Ejer6(List<Heroe> heroes)
        {
            var nombre = heroes.Where(x => x.Hp > 50 & x.Gender == "Female").Take(10);
            foreach(var a in nombre)
            {               
              Console.WriteLine("nombre: " + a.Name);                   
            }
        }
        public static void Ejer7(List<Heroe> heroes)
        {
            var heroe = heroes.Where(x =>String.IsNullOrEmpty(x.Description));
            foreach(var a in heroe)
            {
                Console.WriteLine("nombre: " + a.Name);
            }
        }
        public static void Ejer8(List<Heroe> heroes)
        {
            var per = heroes.FindAll(x => x.Gender=="Male"& x.Hp > 100 & x.Level == 10);
            
                Console.WriteLine(per);
           

        }
        public static void Ejer9(List<Heroe> heroes)
        {
            var heroe = heroes.OrderBy(x => x.Name);
           
        }

        public static void Ejer10(List<Heroe> heroes)
        {
            var heroe = heroes.OrderByDescending(x => x.Name);
           
        }
        public static void Ejer11(List<Heroe> heroes)
        {
            var guerreros = heroes.Where(a => a.HeroeClass == "Warrior").Sum(a => a.Hp);
          
           
            Console.WriteLine("la suma de las vidas de los guerreros es " + guerreros);
        }
        public static void Ejer12(List<Heroe> heroes)
        {
            var bardos = heroes.Where(a => a.HeroeClass == "Bard" & a.Level > 3).Sum(a=>a.Mp);
            
            Console.WriteLine("La suma de las mana de los bardos es " + bardos);
        }
        public static void Ejer13(List<Heroe> heroes)
        {
           for(int num =0; num < heroes.Count; num += 10)
            {
                var grupo = heroes.Skip(0 + 1).Take(10);
                foreach(var nombre in grupo)
                {
                    Console.WriteLine(nombre.Name);
                }
                Console.ReadKey();

            }

        }
        public static void Ejer14(List<Heroe> heroes)
        {
           
        }
      
    }
    public static class Extension
    {
        public static void Ejer15(List<Heroe>heroes,int nivel,String nombre)
        {
            var busqueda = heroes.Where(per=>per.Level==nivel & per.HeroeClass==nombre);
            foreach(var a in busqueda)
            {
                Console.WriteLine("nombre: " + a.Name + " con el nivel :" + a.Level+" y que pertence a la clase "+a.HeroeClass);
            }

        }
    }

}
