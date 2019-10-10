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
        static List<Heroe> listaHeroe = new List<Heroe>();

        static List<Heroe> Ejer1()
        {
            using (StreamReader r = new StreamReader("Heroes.json"))
            {
                string json = r.ReadToEnd();
                listaHeroe = JsonConvert.DeserializeObject<List<Heroe>>(json);
                return listaHeroe;
            }
        }

        static void Ejer2()
        {
            var sexoM = listaHeroe.Count(x => x.Gender.Equals("Male"));
            var sexoF = listaHeroe.Count(x => x.Gender.Equals("Female"));


            if (sexoM != null || sexoF != null)
            {
                Console.WriteLine("Cantidad de Heroes Masculino: " + sexoM);
                Console.WriteLine("Cantidad de Heroes Masculino: " + sexoF);
            }
            else
            {
                Console.WriteLine("Error, no se ha encontrado ningun elemento que cumpla con esa condicion!");
            }
        }

        static void Ejer3()
        {
            var diezPjNvlSiete = listaHeroe.Take(10).Where(x => x.Level > 7);

            foreach (var item in diezPjNvlSiete)
	        {
                Console.WriteLine(item.ToString());
	        }
        }

        static void Ejer4()
        {
            var agruparPorClase = listaHeroe.GroupBy(x => x.Class);

            foreach (var item in agruparPorClase)
	        {
                Console.WriteLine(item);
	        }
        }

        static void Ejer5()
        {
            var diezPrimerosHp50 = listaHeroe.Take(10).Where(x => x.Hp > 50);

            foreach (var item in diezPrimerosHp50)
	        {
                Console.WriteLine(item);
	        }
        }

        static void Ejer6()
        {
            var diezPrimerosFemeninoHp50 = listaHeroe.Take(10).Where(x => x.Hp > 50 && x.Gender.Equals("Female"));

            foreach (var item in diezPrimerosFemeninoHp50)
	        {
                Console.WriteLine(item);
	        }
        }     
        
        static void Ejer7()
        {
            var personajesDescripcionVacia = listaHeroe.Where(x => String.IsNullOrEmpty(x.Description));

            foreach (var item in personajesDescripcionVacia)
	        {
                Console.WriteLine(item);
	        }
        }
        
        static void Ejer8()
        {
            var primerPersonajeMasculinoHp100Nvl10 = listaHeroe.Find(x => x.Hp > 100 && x.Level == 10);
            
            Console.WriteLine(primerPersonajeMasculinoHp100Nvl10);
        }

        static void Ejer9()
        {
            var ordenarDesdeAZ = listaHeroe.OrderBy(x => x.Name);

            foreach (var item in ordenarDesdeAZ)
	        {
                Console.WriteLine(item);
	        }
        }

        static void Ejer10()
        {
            var ordenarDesdeZA = listaHeroe.OrderByDescending(x => x.Name);

            foreach (var item in ordenarDesdeZA)
	        {
                Console.WriteLine(item);
	        }
        }

        static void Ejer11() 
        {
            var hpTotalPersonajes = listaHeroe.Where(x => x.Class == "Warrior").Sum(y => y.Hp);

            Console.WriteLine(hpTotalPersonajes);
        }

        static void Ejer12()
        {
            var manaTotalBardosNvl3 = listaHeroe.Where(x => x.Class == "Bard" && x.Level > 3).Sum(y => y.Mp);

            Console.WriteLine(manaTotalBardosNvl3);
        }

        static void Ejer13()
        {
            var mostrarPrimeros10PersonajesConTecla = listaHeroe.Take(10);

            foreach (var item in mostrarPrimeros10PersonajesConTecla)
	        {
                Console.WriteLine(item);
	        }
            Console.ReadKey();
        }

        static void Ejer14()
        {
            var warrior = listaHeroe.Where(x => x.Class == "Warrior").Select(y => new List<Guerrero>());
            var mage = listaHeroe.Where(x => x.Class == "Mage").Select(y => new List<Mago>());
            var cleric = listaHeroe.Where(x => x.Class == "Cleric").Select(y => new List<Clerigo>());
            var explorer = listaHeroe.Where(x => x.Class == "Explorer").Select(y => new List<Explorador>());
            var bard = listaHeroe.Where(x => x.Class == "Bard").Select(y => new List<Bardo>());
            var barbarian = listaHeroe.Where(x => x.Class == "Barbarian").Select(y => new List<Barbaro>());
        }

        public class Guerrero : Heroe {}
        public class Mago : Heroe {}
        public class Clerigo : Heroe {}
        public class Explorador : Heroe {}
        public class Bardo : Heroe {}
        public class Barbaro : Heroe {}

        static void Ejer15(int level)
        {
            var miMetodo = listaHeroe.Where(x => x.Level == level);

            foreach (var item in miMetodo)
	        {
                Console.WriteLine(item);
	        }
        }

        static void Main(string[] args)
        {
            Ejer1();

            Console.WriteLine("***** Obten la cantidad de heroes de sexo masculino y femenino. Mostrando por pantalla el número existente *****");
            Ejer2();
            Console.WriteLine("***** FIN Obten la cantidad de heroes de sexo masculino y femenino. Mostrando por pantalla el número existente *****");
            Console.WriteLine("");

            Console.WriteLine("***** Obten los diez primeros personajes con un nivel superior a 7 *****");
            Ejer3();
            Console.WriteLine("***** FIN Obten los diez primeros personajes con un nivel superior a 7 *****");
            Console.WriteLine("");

            Console.WriteLine("***** Agrupa los diferentes personajes por su clase *****");
            Ejer4();
            Console.WriteLine("***** FIN Agrupa los diferentes personajes por su clase *****");
            Console.WriteLine("");

            Console.WriteLine("***** Obtén UNICAMENTE el nombre de los diez primeros personajes con más 50 puntos de vida *****");
            Ejer5();
            Console.WriteLine("***** FIN Obtén UNICAMENTE el nombre de los diez primeros personajes con más 50 puntos de vida *****");
            Console.WriteLine("");

            Console.WriteLine("****** Obtén UNICAMENTE el nombre de los diez primeros personajes femeninos con más 50 puntos de vida *****");
            Ejer6();
            Console.WriteLine("****** FIN Obtén UNICAMENTE el nombre de los diez primeros personajes femeninos con más 50 puntos de vida *****");
            Console.WriteLine("");

            Console.WriteLine("****** Recupera todos los personajes que su descripcion se encuentre vacia *****");
            Ejer7();
            Console.WriteLine("****** FIN Recupera todos los personajes que su descripcion se encuentre vacia *****");
            Console.WriteLine("");

            Console.WriteLine("****** Obten el primero personaje masculino, con más 100 puntos de vida y nivel 10 *****");
            Ejer8();
            Console.WriteLine("****** FIN Obten el primero personaje masculino, con más 100 puntos de vida y nivel 10 *****");
            Console.WriteLine("");

            Console.WriteLine("****** Ordena los personajes por su nombre de la A a la Z *****");
            Ejer9();
            Console.WriteLine("****** FIN Ordena los personajes por su nombre de la A a la Z *****");
            Console.WriteLine("");

            Console.WriteLine("****** Ordena los personajes por su nombre de la Z a la A *****");
            Ejer10();
            Console.WriteLine("****** FIN Ordena los personajes por su nombre de la Z a la A *****");
            Console.WriteLine("");

            Console.WriteLine("****** Muestra por pantalla la vida total de todos los geurreros *****");
            Ejer11();
            Console.WriteLine("****** FIN Muestra por pantalla la vida total de todos los geurreros *****");
            Console.WriteLine("");

            Console.WriteLine("****** Muestra por pantalla el mana total de todos los Bardos de un nivel mayor a 3 *****");
            Ejer12();
            Console.WriteLine("****** FIN Muestra por pantalla el mana total de todos los Bardos de un nivel mayor a 3 *****");
            Console.WriteLine("");

            Console.WriteLine("****** Muestra los 10 primeros personajes y que cada vez que se pulse una tecla, se muestren los diez siguientes. Hasta que no haya personajes *****");
            Ejer13();
            Console.WriteLine("****** FIN Muestra los 10 primeros personajes y que cada vez que se pulse una tecla, se muestren los diez siguientes. Hasta que no haya personajes *****");
            Console.WriteLine("");

            Console.WriteLine("****** Crea diferentes clases de los tipos de heroe. (Guerrero, Mago, Clerigo, Explorador, Bardo y Barbaro) Transforma la lista original en seis listas con las nuevas clases y que estás mantengan todos los valores del original *****");
            Ejer14();
            Console.WriteLine("****** FIN Crea diferentes clases de los tipos de heroe. (Guerrero, Mago, Clerigo, Explorador, Bardo y Barbaro) Transforma la lista original en seis listas con las nuevas clases y que estás mantengan todos los valores del original *****");
            Console.WriteLine("");

            Console.WriteLine("****** Crea tu propio metodo de extensión, el cual puedas ejecutar cualquier acción que necesites y recorra una colección. Cuando lo tengas, usalo para mostrar nombre y nivel de todos los personajes *****");
            Ejer15(1); // Te muestra todos los personajes con ese nivel
            Console.WriteLine("****** FIN Crea tu propio metodo de extensión, el cual puedas ejecutar cualquier acción que necesites y recorra una colección. Cuando lo tengas, usalo para mostrar nombre y nivel de todos los personajes *****");
            Console.WriteLine("");

            Console.ReadKey();
        }
    }
}
