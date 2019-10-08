using System;
using System.IO;
using System.Collections.Generic;
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
            String archivo = File.ReadAllText("Heroes.json");
            List<Heroe> heroes= JsonConvert.DeserializeObject<List<Heroe>>(archivo);


            /* foreach (var a in heroes)
             {
                 Console.WriteLine(a.Name);
             }*/
            Console.WriteLine(Ejer2(heroes));
            Ejer3(heroes);
            Console.ReadKey();
        }
        public static String Ejer2(List<Heroe> heroes) {
            
            var femenino=heroes.Count(x => x.Gender == "Female");
            var masculino=heroes.Count(x => x.Gender == "Male");
            String cadena = "Heroes masculinos:" + masculino+" Heroes femeninos:"+femenino;
            return cadena;
        }

        public static void Ejer3(List<Heroe> heroes)
        {
            var ej3 = heroes.Where(x => x.Level >7);
            Console.WriteLine("Los 10 primeros heroes con nivel superior a 7 son:");
            int contador = 0;
            foreach (var a in ej3)
            {
                if (contador<=10) {
                    Console.WriteLine("Nombre: " + a.Name);
                    contador++;
                }
            }
        }
    }
}
