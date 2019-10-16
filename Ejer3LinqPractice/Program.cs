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
        static List<Heroe> listaHeroe = new List<Heroe>();
        static void Main(string[] args)
        {



        }

        static List<Heroe> Ejer1()
        {
            using (StreamReader lector = new StreamReader("Heroes.json"))
            {
                string json = lector.ReadToEnd();
                List<Heroe> resultado = JsonConvert.DeserializeObject<List<Heroe>>(json);
                return resultado;
            }
        }

        static void Ejer2()
        {
            var masculino = listaHeroe.Count(x => x.Gender.Equals("Male"));
            var femenino = listaHeroe.Count(x => x.Gender.Equals("Female"));

            if (masculino != null || femenino != null)
            {
                Console.WriteLine($"M: {masculino}");
                Console.WriteLine($"F: {femenino}");
            }
        }
        static void Ejer3() => 
        listaHeroe
                .Where(x => x.Level>7)
                .Take(10)
                .ForEach(x => Console.WriteLine(x.Name))
            
        
        static void Ejer4()
        {
            var lista = listaHeroe.GroupBy(x => x.HeroeClass);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
                {
                    Console.WriteLine(j.Name);
                }
            }
        }

        static void Ejer5()
        {
            Ejer6And7("Male");  
        }

        static void Ejer6()
        {
            Ejer6And7("Female");
        }
        static void Ejer6And7(string genero)
        {
            var nombre = listaHeroe.Where(P => P.Hp > 50 && P.Gender == genero);
            foreach(var x in nombre)
            {
                Console.WriteLine(x.Name);
            }
        }
        static void Ejer7()
        {
            var nombre = listaHeroe.Where(P => String.IsNullOrWhiteSpace(P.Description));
            foreach(var x in nombre)
            {
                Console.WriteLine(x.Name);
            }
        }

        static void Ejer8()
        {
            var primerPersonajeMasculinonv10 = listaHeroe.FirstOrDefault(p => p.Gender == "Male" && p.Level == 10 && p.Hp > 100);
            Console.WriteLine(primerPersonajeMasculinonv10.Name);
        }

        static void Ejer9()
        {
            var caustic = listaHeroe.OrderBy(p => p.Name);
            foreach (var x in caustic)
            {
                Console.WriteLine(x.Name);
            }
        }

        static void Ejer10() =>
            listaHeroe.OrderByDescending(p => p.Name)
            .ForEach(x => Console.WriteLine(x.Name));

        static void Ejer11() =>
            Console.WriteLine(
                listaHeroe
                .Where(x => x.HeroeClass == "Warrior")
                .Sum(x => x.Hp));

        static void Ejer12() =>
            listaHeroe
                .Where(x => x.HeroeClass == "Bard" && 
                       x.Level > 3)
                .Sum(x => x.Mp);

        static void Ejer13()
        {
            for(int i = 0; i<listaHeroe.Count; i += 10)
            {
                var lista = listaHeroe.Skip(0 + i).Take(10).Select(y => y.Name);
                foreach(var x in lista)
                {
                    Console.WriteLine(x);
                }
                Console.ReadKey();
                
            }
        }
        static void ejer14()
        {
            ejer14_2<guerreroPotente>("Warrior");
        }
        static List<THeroClass> ejer14_2<THeroClass>(string clase) 
            where THeroClass:Heroe, new()
        {
            return listaHeroe.Where(x => x.HeroeClass == clase)
                .Select(y => new THeroClass { }).ToList();
        }

        
       
    }
    public class guerreroPotente : Heroe
    {

    }

    public static class ExtensionMethods
    {
        public static void ForEach<T>(
            this IEnumerable<T> collection, 
            Action<T> doAction)
        {
            foreach(var item in collection)
            {
                doAction.Invoke(item);
            }
        }
    }

}
