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

        public  static String Ejer2(List<Heroe>heroes)
        {
            var hombres = heroes.Count(x => x.Gender == "Male");
            var mujeres = heroes.Count(x => x.Gender == "Female");
            String frase = "heroes con genero masculino " + hombres + " y heroes con genero femenino " + mujeres;
            return frase;
        }
        public static void Ejer3(List<Heroe> heroes)
        {
            var nombre = heroes.Where(y => y.Level > 7);
            int x = 0;
            foreach(var a in nombre)
            {
                do
                {
                    Console.WriteLine(a.Name);
                    x += 1;
                } while (x <= 10);
            }

        }
        public static void Ejer4(List<Heroe>heroes)
        {
            var clases = heroes.OrderBy(x => x.HeroeClass);
            foreach(var dato in clases)
            {
                Console.WriteLine("clase de heroe: " + dato.HeroeClass + " nombre del heroe: " + dato.Name);
            }
        }
        public static void Ejer5(List<Heroe> heroes)
        {
            var nombre = heroes.Where(x => x.Hp > 50);
            foreach(var a in nombre)
            {
                int contador = 0;
                if (contador <= 10)
                {
                    Console.WriteLine("nombre: " + a.Name);
                }
            }
        }

        public static void Ejer6(List<Heroe> heroes)
        {
            var nombre = heroes.Where(x => x.Hp > 50 & x.Gender == "Female");
            foreach(var a in nombre)
            {
                int contador = 0;
                if( contador <= 10)
                    {
                    Console.WriteLine("nombre: " + a.Name);
                    contador += 1;
                }
            }
        }
        public static void Ejer7(List<Heroe> heroes)
        {
            var heroe = heroes.Where(x => x.Description == "");
            foreach(var a in heroe)
            {
                Console.WriteLine("nombre: " + a.Name);
            }
        }
        public static void Ejer8(List<Heroe> heroes)
        {
            var per = heroes.Where(x => x.Gender=="Male"& x.Hp > 100 & x.Level == 10);
            foreach(var a in per)
            {
                Console.WriteLine("nombre: " + a.Name + " genero: " + a.Gender + " nivel de vida: " + a.Hp + " el nivel es: " + a.Level);
            }

        }
        public static void Ejer9(List<Heroe> heroes)
        {
            var heroe = heroes.OrderBy(x => x.Name);
            foreach(var a in heroe)
            {
                Console.WriteLine("nombre " + a.Name);
            }
        }

        public static void Ejer10(List<Heroe> heroes)
        {
            var heroe = heroes.OrderByDescending(x => x.Name);
            foreach (var a in heroe)
            {
                Console.WriteLine("nombre " + a.Name);
            }
        }
        public static void Ejer11(List<Heroe> heroes)
        {
            var guerreros = heroes.Where(a => a.HeroeClass == "Warrior");
            int suma = 0;
            foreach(var en in guerreros)
            {
                suma = suma + en.Hp;
            }
            Console.WriteLine("la suma de las vidas de los guerreros es " + suma);
        }
        public static void Ejer12(List<Heroe> heroes)
        {
            var bardos = heroes.Where(a => a.HeroeClass == "Bard" & a.Level > 3);
            int sumaMana = 0;
            foreach(var a in bardos)
            {
                sumaMana = sumaMana + a.Mp;
            }
            Console.WriteLine("La suma de las mana de los bardos es " + sumaMana);
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
