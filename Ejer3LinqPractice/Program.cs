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
            
        }

        
        static void Ejer1()
        {
            string heroesJson = File.ReadAllText("Heroes.json");
            List<Heroe> listaHeroe = JsonConvert.DeserializeObject<List<Heroe>>(heroesJson);
        }

        static void Ejer2(List<Heroe> listaHeroe) 
        {
            var cantMasc = listaHeroe.Count(x => x.Gender == "Male");
            var cantFem = listaHeroe.Count(x => x.Gender == "Female");
            Console.WriteLine($"Masculino: {cantMasc} " + $"\nFemenino: {cantFem}");
        }

        static void Ejer3(List<Heroe> listaHeroe)
        {
            var personNivel7 = listaHeroe.Where(x => x.Level > 7)
                                         .Take(10);

            foreach (var item in personNivel7)
            {
                Console.WriteLine(item.Name);
            }
        }
        

        static void Ejer4(List<Heroe> listaHeroe)
        {
            var lista = listaHeroe.GroupBy (x => x.HeroeClass);
            
            foreach(var i in lista)
            {
                Console.WriteLine(i.Key);
                foreach (var j in i)
	            {
                    Console.WriteLine(j.Name);
	            }
            }
        }

        static void Ejer5(List<Heroe> listaHeroe)
        {   
            foreach(var i in listaHeroe.Where (p => p.Hp > 50).Take(10))
            {
                Console.WriteLine(i.Name);
            }
        }

        /*Me da error al pasar por parámetro la lista, así que te lo comento y vemos el error el próximo día
        public static void Ejer5y6(string genero)
        {   
            var nombre = listaHeroe.Where(x => x.Hp > 50 && x.Gender == genero);
           
            foreach(var i in nombre)
            {
                Console.WriteLine(i.Name);
            }
        }

        static void Ejer5()
        {   
            Ejer5y6("Female");
        }

        static void Ejer6()
        {   
            Ejer5y6("Male");
        }
        */

        static void Ejer7(List<Heroe> listaHeroe)
        {
            var descVacia = listaHeroe.Where(x => x.Description == null);

            foreach (var item in descVacia)
            {
                Console.WriteLine(item.Name);
            }
        }


        /*Sé que en la clase usaste algo del first pero me da error en el foreach y no sé como arreglarlo te lo dejo abajo de otra forma
        static void Ejer8(List<Heroe> listaHeroe)
        {
            var primerMasc = listaHeroe.FirstOrDefault(x => x.Hp > 100 && x.Level==10);

            foreach (var item in primerMasc)
            {
                Console.WriteLine(item.Name);
            }
        }
        */
        static void Ejer8(List<Heroe> listaHeroe)
        {
            var primerMasc = listaHeroe.Where(x => x.Hp > 100 && x.Level == 10)
                                       .Take(1);

                Console.WriteLine($"El primer masculino con vida +100 y nivel 10 es: {primerMasc}");
           
        }

        static void Ejer9(List<Heroe> listaHeroe)
        {
            var ordenAZ = listaHeroe.OrderBy(x => x.Name);

            foreach (var item in ordenAZ)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Ejer10(List<Heroe> listaHeroe)
        {
            var ordenZA = listaHeroe.OrderByDescending(x => x.Name);

            foreach (var item in ordenZA)
            {
                Console.WriteLine(item.Name);
            }
        }

        static void Ejer11(List<Heroe> listaHeroe)
        {
            var hpTotal = listaHeroe.Where(x => x.HeroeClass == "Warrior")
                                    .Sum(x => x.Hp);

            Console.WriteLine($"La vida total de los guerreros es: {hpTotal}");
        }

        static void Ejer12(List<Heroe> listaHeroe)
        {
            var mpTotal = listaHeroe.Where(x => x.HeroeClass == "Bard")
                                    .Sum(x => x.Mp);

            Console.WriteLine($"El maná total de los bardos es: {mpTotal}");
        }


        //Estos 3 son copiadisimos de la pizarra
        static void Ejer13(List<Heroe> listaHeroe)
        {
            for (int i = 0; i < listaHeroe.Count; i += 10)
            {
                var lista = listaHeroe.Skip(0 + i).Take(10);
                foreach (var x in lista)
                {
                    Console.WriteLine(x.Name);
                }
                Console.ReadKey();

            }
        }

        static void Ejer14(List<Heroe> listaHeroe)
        {
            var guerreroPo = listaHeroe.Where(p => p.HeroeClass == "Warrior" && p.Level > 10)
                                                    .Select(y => new gerreroPotente { Hp = y.Hp });
        }


        static void ejer14_2<THeroClass>(String clase, List<Heroe> listaHeroe) where THeroClass : Heroe, new()
        {
            var guerreroPO = listaHeroe.Where(x => x.HeroeClass == clase)
                                       .Select(y => new THeroClass { /*Meter atributos aqui*/});

        }
        
        static void ejer15<T>(this IEnumerable<T> collection, Action<T> doAction)
        {
            foreach (var item in collection)
            {
                doAction.Invoke(item);
            }
        }
    }
}





