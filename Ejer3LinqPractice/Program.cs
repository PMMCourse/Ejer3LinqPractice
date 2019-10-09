using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            //Carga el modelo de datos de Json que se ha facilitado en el proyecto y retornalo para su posterior consumo en el resto de apartados.
            string heroesJson = File.ReadAllText("Heroes.json");
            List<Heroes> listaHeroes = JsonConvert.DeserializeObject<List<Heroes>>(heroesJson);

        }
        //Atributos de la Clase Heroes
        public class Heroes
        {
            public string Name { get; set; }
            public int Hp { get; set; }
            public int Mp { get; set; }
            public string Class { get; set; }
            public int Level { get; set; }
            public string Gender { get; set; }
            public string Description { get; set; }
        }

        //METODOS:
        //Obten la cantidad de heroes de sexo masculino y femenino. Mostrando por pantalla el número existente.
        public static void Ejer2(List<Heroes> heroes)
        {
            var contMale = heroes.Count(p => p.Gender == "Male");
            var contFem = heroes.Count(p => p.Gender == "Female");

            Console.WriteLine($"Sexo Masculino: " + contMale + "\nSexo Femenino: " + contFem);
        }

        //Obten los diez primeros personajes con un nivel superior a 7.
        public static void Ejer3(List<Heroes> heroes)
        {
            var pers = heroes.Where(p => p.Level > 7).Take(10);
            Console.WriteLine(pers);
        }

        //Agrupa los diferentes personajes por su clase.
        public static void Ejer4(List<Heroes> heroes)
        {
            var dictionary = heroes.GroupBy(p => p.Class);
            Console.WriteLine(dictionary);
        }

        //Obtén UNICAMENTE el nombre de los diez primeros personajes con más 50 puntos de vida.
        public static void Ejer5(List<Heroes> heroes)
        {
            var nome = heroes.Select(p => p.Hp > 50);
            foreach (var nombre in heroes.Where(p => p.Hp > 50).Take(10))
            {
                Console.WriteLine($"Nombre : " + nombre.Name);
            }
        }

        //Obtén UNICAMENTE el nombre de los diez primeros personajes femeninos con más 50 puntos de vida.
        public static void Ejer6(List<Heroes> heroes)
        {
            foreach (var nombre in heroes.Where(p => p.Hp > 50 && p.Gender == "Female").Take(10))
            {
                Console.WriteLine($"Nombre : " + nombre.Name);
            }
        }

        //Obtén UNICAMENTE el nombre de los diez primeros personajes femeninos con más 50 puntos de vida.
        public static void Ejer7(List<Heroes> heroes)
        {
            var desc = heroes.Where(p => p.Description == "");
            Console.WriteLine($"Nombre : " + desc.Name);
        }

        //Obten el primero personaje masculino, con más 100 puntos de vida y nivel 10.
        public static void Ejer8(List<Heroes> heroes)
        {
            foreach (var nombre in heroes.Where(p => p.Hp > 100 && p.Level == 10 && p.Gender == "Male").Take(1))
            {
                Console.WriteLine($"Nombre : " + nombre.Name);
            }
        }

        //Ordena los personajes por su nombre de la A a la Z
        public static void Ejer9(List<Heroes> heroes)
        {
            var nombres = heroes.OrderBy(p => p.Name);
        }

        //Ordena los personajes por su nombre de la Z a la A
        public static void Ejer10(List<Heroes> heroes)
        {
            var nombres = heroes.OrderByDescending(p => p.Name);
        }

        //Muestra por pantalla la vida total de todos los geurreros
        public static void Ejer11(List<Heroes> heroes)
        {
            var total = heroes.Sum(p => p.Hp);
        }

        //Muestra por pantalla el mana total de todos los Bardos de un nivel mayor a 3.
        public static void Ejer12(List<Heroes> heroes)
        {
            var total = heroes.Where(p.Class == "Bardo" && p.Level > 3).Sum(p => p.Mp);
            Console.WriteLine(total);
        }

        //No los se hacer
        public static void Ejer13(List<Heroes> heroes)
        {

        }

        public static void Ejer14(List<Heroes> heroes)
        {

        }

        public static void Ejer15(List<Heroes> heroes)
        {

        }

    }
}
