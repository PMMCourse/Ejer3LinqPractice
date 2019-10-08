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

            /*Console.WriteLine(Ejer2(heroes));
            Ejer3(heroes);
            Ejer4(heroes);
            Ejer5(heroes);
            Ejer6(heroes);
            Ejer7(heroes);
            Ejer8(heroes);
            Ejer9(heroes);
            Ejer10(heroes);
            Ejer11(heroes);*/
            Ejer12(heroes);
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
                    Console.WriteLine("Nombre: " + a.Name + " Hp: " + a.Hp + " MP: " + a.Mp + " Clase: " + a.Class + " Nivel: " + a.Level + " Género: " + a.Gender + " Descripcion: " + a.Description);
                    contador++;
                }
            }
        }

        public static void Ejer4(List<Heroe> heroes)
        {
            var ej4 = heroes.OrderBy(x => x.Class);
            foreach (var a in ej4)
            {
                Console.WriteLine("Nombre: " + a.Name + " Hp: " + a.Hp + " MP: " + a.Mp + " Clase: " + a.Class + " Nivel: " + a.Level + " Género: " + a.Gender + " Descripcion: " + a.Description);
            }
        }

        public static void Ejer5(List<Heroe> heroes)
        {
            var ej5 = heroes.Where(x => x.Hp > 50);
            Console.WriteLine("Los 10 primeros heroes con vida superior a 50 son:");
            int contador = 0;
            foreach (var a in ej5)
            {
                if (contador <= 10)
                {
                    Console.WriteLine("Nombre: " + a.Name);
                    contador++;
                }
            }
        }

        public static void Ejer6(List<Heroe> heroes)
        {
            var ej6 = heroes.Where(x => x.Hp > 50 & x.Gender=="Female");
            int contador=0;
            foreach (var a in ej6)
            {
                if (contador <= 10)
                {
                    Console.WriteLine("Nombre: " + a.Name);
                    contador++;
                }
            }
        }

        public static void Ejer7(List<Heroe> heroes)
        {
            var ej7 = heroes.Where(x => x.Description==null);
            foreach (var a in ej7)
            {
                    Console.WriteLine("Nombre: " + a.Name+" Hp: "+a.Hp+" MP: "+a.Mp+" Clase: "+a.Class+" Nivel: "+a.Level+" Género: "+a.Gender+" Descripcion: "+a.Description);
            }
        }

        public static void Ejer8(List<Heroe> heroes)
        {
            var ej8 = heroes.Where(x => x.Gender=="Male" & x.Hp > 100 & x.Level > 10);
            foreach (var a in ej8)
            {
                Console.WriteLine("Nombre: " + a.Name + " Hp: " + a.Hp + " MP: " + a.Mp + " Clase: " + a.Class + " Nivel: " + a.Level + " Género: " + a.Gender + " Descripcion: " + a.Description);
            }
        }

        public static void Ejer9(List<Heroe> heroes)
        {
            var ej9 = heroes.OrderBy(x => x.Name);
            foreach (var a in ej9)
            {
                Console.WriteLine("Nombre: " + a.Name + " Hp: " + a.Hp + " MP: " + a.Mp + " Clase: " + a.Class + " Nivel: " + a.Level + " Género: " + a.Gender + " Descripcion: " + a.Description);
            }
        }

        public static void Ejer10(List<Heroe> heroes)
        {
            var ej10 = heroes.OrderByDescending(x => x.Name);
            foreach (var a in ej10)
            {
                Console.WriteLine("Nombre: " + a.Name + " Hp: " + a.Hp + " MP: " + a.Mp + " Clase: " + a.Class + " Nivel: " + a.Level + " Género: " + a.Gender + " Descripcion: " + a.Description);
            }
        }

        public static void Ejer11(List<Heroe> heroes)
        {
            var ej11 = heroes.Where(x => x.Class=="Warrior");
            int vida=0;
            foreach (var a in ej11)
            {
                vida = vida + a.Hp;
            }
            Console.WriteLine("La vida total de todos los guerreros es: "+vida);
        }

        public static void Ejer12(List<Heroe> heroes)
        {
            var ej12 = heroes.Where(x => x.Class == "Bard" & x.Level>3);
            int mana = 0;
            foreach (var a in ej12)
            {
                mana = mana + a.Mp;
            }
            Console.WriteLine("La mana total de todos los bardos de nivel mayor a 3 es: " + mana);
        }
    }
}
