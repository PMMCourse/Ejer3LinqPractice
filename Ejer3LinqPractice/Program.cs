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
            //Abrimos el archivo JSON:
            string aj = File.ReadAllText("Heroes.json");

            //Agregamos el archivo JSON a una Lista para utilizar LINQ:
            List<Heroe> listaH = JsonConvert.DeserializeObject<List<Heroe>>(aj);

            Ejer4(listaH);

            Console.ReadKey();

        }

        //Ejercicio 2: Cantidad total de heroes Masculinos y Femeninos:
        public static string Ejer2(List<Heroe> h)
        {
            int f = h.Count(total => total.Gender == "Female");
            int m = h.Count(total => total.Gender == "Male");

            return $"Femenino: {f} y Masculino: {m}";
        }

        //Ejercicio 3: Diez primeros personajes con nivel mayor que 7:
        public static void Ejer3(List<Heroe> h)
        {
            var nombres = h.Where(nivel => nivel.Level > 7);
            List<Heroe> lista = nombres.ToList();

            for ( int i=0; i<=10; i++)
            {
                Console.WriteLine(lista[i].Name);
            }
        }

        //Ejercicio 4: Agrupar personajes por clase:
        //PD: Intente hacerlo con GroupBy pero era un codigo mas largo para el mismo resultado.
        public static void Ejer4(List<Heroe> h)
        {
            var clases = h.OrderBy(clase => clase.Class);

            foreach(var x in clases)
            {
                Console.WriteLine($"Nombre de Heroe: {x.Name} Clase: {x.Class}");
            }

        }
    }
}
