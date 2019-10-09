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

            Ejer13(listaH);

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
            var nombres = h.Where(nivel => nivel.Level > 7).ToList();

            for ( int i=0; i<=10; i++)
            {
                Console.WriteLine(nombres[i].Name);
            }
        }

        //Ejercicio 4: Agrupar personajes por clase:
        public static void Ejer4(List<Heroe> h)
        {
            var grupo = h.GroupBy(clase => clase.Class);

            foreach(var x in grupo)
            {
                Console.WriteLine(string.Format("Clase: {0}", x.Key));

                foreach(var y in x)
                {
                    Console.WriteLine($"Nombre: {y.Name}");
                }
            }
        }

        //Ejercicio 5: 10 primero nombres de personajes con mas de 50 HP.
        public static void Ejer5(List<Heroe> h)
        {
            var nombres = h.Where(hp => hp.Hp > 50).ToList();

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(nombres[i].Name);
            }
        }

        //Ejercicio 6: 10 primeros nombres de personajes femeninos con mas de 50 HP.
        public static void Ejer6(List<Heroe> h)
        {
            var nombres = h.Where(x => x.Gender == "Female" && x.Hp > 50).ToList();

            for (int i = 0; i <= 10; i++)
            {
                Console.WriteLine(nombres[i].Name);
            }
        }

        //Ejercicio 7: Personajes con descripcion vacia:
        public static void Ejer7(List<Heroe> h)
        {
            var nombres = h.Where(x => x.Description == null).ToList();

            for (int i = 0; i < nombres.Count; i++)
            {
                Console.WriteLine(nombres[i].Name);
            }
        }

        //Ejercicio 8: Primer Heroe masculino, mas de 100 de HP y nivel 10.
        public static void Ejer8(List<Heroe> h)
        {
            var nombre = h.FirstOrDefault(x => x.Gender == "Male" && x.Hp > 100 && x.Level == 10);
            string resul = (nombre != null) ? nombre.Name : "No existen heroes";
            Console.WriteLine(resul);

        }

        //Ejercico 9: Ordenar de la A a la Z.
        public static void Ejer9(List<Heroe> h)
        {
            var orden = h.OrderBy(x => x.Name);

            foreach (var x in orden)
            {
                Console.WriteLine($"Nombre de Heroe: {x.Name}");
            }
        }

        //Ejercicio 10: Ordenar de la Z a la A.
        public static void Ejer10(List<Heroe> h)
        {
            var orden = h.OrderByDescending(x => x.Name);

            foreach (var x in orden)
            {
                Console.WriteLine($"Nombre de Heroe: {x.Name}");
            }
        }

        //Ejercicio 11: Sumar HP de todos los Guerreros.
        public static void Ejer11(List<Heroe> h)
        {
            var hpTotal = h.Where(x => x.Class == "Warrior").Sum(y => y.Hp);

            Console.WriteLine($"Hp total: {hpTotal}");
        }

        //Ejercio 12: Sumar MP de todos los bardos.
        public static void Ejer12(List<Heroe> h)
        {
            var mpTotal = h.Where(x => x.Class == "Bard" && x.Level > 3).Sum(y => y.Mp);

            Console.WriteLine($"Mp total: {mpTotal}");
        }

        //Ejercicio 13: Mostrar 10 Personajes cada vez que se pulse una tecla.
        public static void Ejer13(List<Heroe> h)
        {
            int pocision = 0;
            var lista = h.Take(10);

            try
            {
                do
                {
                    foreach (var x in lista)
                    {
                        Console.WriteLine(x.Name);
                    }

                    Console.ReadLine();

                    pocision += 10;

                    lista = h.Skip(pocision).Take(10);

                } while (lista != lista.Last());

            }
            catch (InvalidOperationException)
            {
                Console.WriteLine("No hay mas heroes para mostrar");
            }
                     
        }

        }
    }

