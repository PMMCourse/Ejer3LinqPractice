using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice {
    class Program {

        static void Main(string[] args) {
            List<Heroe> lista = JsonConvert.DeserializeObject<List<Heroe>>(File.ReadAllText("Heroes.json"));
            Ejer13(lista);
            Console.ReadKey();
        }

        public static void Ejer2(List<Heroe> lista) {
            int cantidadHeroesFemeninos, cantidadHeroesMasculinos;
            cantidadHeroesFemeninos = lista.Count(heroe => heroe.Gender == "Female");
            cantidadHeroesMasculinos = lista.Count(heroe => heroe.Gender == "Male");
            Console.WriteLine("Hay " + cantidadHeroesFemeninos + " heroes femeninos.");
            Console.WriteLine("Hay " + cantidadHeroesMasculinos + " heroes masculinos.");
        }

        public static void Ejer3(List<Heroe> lista) {
            var ejer3 = lista.Where(heroe => heroe.Level > 7).Take(10);
            foreach (var item in ejer3) {
                Console.WriteLine(item.Name + " " + item.Level);
            }
        }

        //No consigo escribir el resultado.
        public static void Ejer4(List<Heroe> lista) {
            var ejer4 = lista.GroupBy(x => x.HeroeClass);
            foreach (var item in ejer4) {
                Console.WriteLine();
            }
        }

        public static void Ejer5(List<Heroe> lista) {
            var ejer5 = lista.Where(heroe => heroe.Hp > 50).Take(10);
            foreach (var item in ejer5) {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ejer6(List<Heroe> lista) {
            var ejer6 = lista.Where(heroe => heroe.Hp > 50 && heroe.Gender.Equals("Female")).Take(10);
            foreach (var item in ejer6) {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ejer7(List<Heroe> lista) {
            var ejer7 = lista.Where(heroe => heroe.Description == null);
            foreach (var item in ejer7) {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ejer8(List<Heroe> lista) {
            //var ejer8 = lista.Where(heroe => heroe.Gender == "Male" && heroe.Level == 10 && heroe.Hp > 100).Take(1);
            var ejer8 = lista.Find(heroe => heroe.Hp >= 100 && heroe.Level == 10 && heroe.Gender == "Male");
            if (ejer8 != null) {
                Console.WriteLine(ejer8.Name);
            } else {
                Console.WriteLine("No se encontraron resultados");
            }
        }

        public static void Ejer9(List<Heroe> lista) {
            var ejer9 = lista.OrderBy(heroe => heroe.Name);
            foreach (var item in ejer9) {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ejer10(List<Heroe> lista) {
            var ejer10 = lista.OrderByDescending(heroe => heroe.Name);
            foreach (var item in ejer10) {
                Console.WriteLine(item.Name);
            }
        }

        public static void Ejer11(List<Heroe> lista) {
            var ejer11 = lista.Where(heroe => heroe.HeroeClass == "Warrior");
            foreach (var item in ejer11) {
                Console.WriteLine(item.Name + " " + item.Hp);
            }
        }

        public static void Ejer12(List<Heroe> lista) {
            var ejer12 = lista.Where(heroe => heroe.HeroeClass == "Bard" && heroe.Level > 3);
            int total = 0;
            foreach (var item in ejer12) {
                total = total + item.Mp;
            }
            Console.WriteLine(total);
        }

        public static void Ejer13(List<Heroe> lista) {
            var ejer13 = lista;
            int contador = 0;
            foreach (var item in ejer13) {
                if (contador % 10 != 0 || contador == 0) {
                    Console.WriteLine(item.Name);
                } else {
                    Console.ReadKey();
                    Console.WriteLine(item.Name);
                }
                contador = contador + 1;
            }
        }
    }
}
