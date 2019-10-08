using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
namespace Ejer3LinqPractice
{
    class Program
    {
        static void Main(string[] args)
        {
            String archivo = File.ReadAllText("Heroes.json");
            List<Heroe> heroes = JsonConvert.DeserializeObject<List<Heroe>>(archivo);

            Ejer13(heroes);
            heroes.Ejer15(5, "Bard");

            Console.ReadKey();
        }
        public static void Ejer2(List<Heroe> heroes)
        { 
            int male = heroes.Count(x => x.Gender == "Male");
            int female = heroes.Count(x => x.Gender == "Female");
            Console.WriteLine("Male: " + male + " Female: " + female);
        }
        public static void Ejer3(List<Heroe> heroes)
        {
            var lista = heroes.Where(x => x.Level > 7).Take(10);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name +"-"+i.Hp+"-"+i.Mp+"-"+i.Class+"-"+ i.Level + "-" + i.Gender + "-" +i.Description);
            }
        }
        public static void Ejer4(List<Heroe> heroes)
        {
            var lista = heroes.OrderBy(x => x.Class);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name + "-" + i.Hp + "-" + i.Mp + "-" + i.Class);
            }
        }
        public static void Ejer5(List<Heroe> heroes)
        {
            var lista = heroes.Where(x => x.Hp > 50).Take(10);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer6(List<Heroe> heroes)
        {
            var lista = heroes.Where(x => x.Hp > 50 && x.Gender == "Female").Take(10);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer7(List<Heroe> heroes)
        {
            var lista = heroes.Where(x => x.Description == null);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer8(List<Heroe> heroes)//no hay ningun heroe con mas de 100 puntos de vida
        {
            var lista = heroes.Where(x => x.Hp >100  && x.Gender == "Male" && x.Level == 10).Take(1);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer9(List<Heroe> heroes)
        {
            var lista = heroes.OrderBy(x => x.Name);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer10(List<Heroe> heroes)
        {
            var lista = heroes.OrderByDescending(x => x.Name);
            foreach (var i in lista)
            {
                Console.WriteLine(i.Name);
            }
        }
        public static void Ejer11(List<Heroe> heroes)
        {
            var sum = heroes.Where(x => x.Class == "Warrior").Sum(y => y.Hp);

            Console.WriteLine("el HP total de los guerreros es: "+sum);
            
        }
        public static void Ejer12(List<Heroe> heroes)
        {
            var bardo = heroes.Where(x => x.Class == "Bard" && x.Level > 3).Sum(y => y.Mp);
            
                Console.WriteLine("El mana total de los bardos es: "+bardo);
        }
        public static void Ejer13(List<Heroe> heroes)
        {

            for(int i = 0; i < heroes.Count; i+=10) { 

                var lista = heroes.Skip(0 + i).Take(10);

                foreach (var x in lista)
                {
                    Console.WriteLine(x.Name);
                }
                Console.ReadKey();
                Console.WriteLine();       
            }
            /*
            int cont = 0;
            foreach (var i in heroes)
            {
                if(cont < 10)
                {
                    Console.WriteLine(i.Name);
                    cont++;
                }
                if(cont == 10)
                {
                    Console.WriteLine();
                    Console.ReadKey();
                    cont = 0;
                }
            }
            */
        }
        public static void Ejer14(List<Heroe> heroes)//no se si es lo que quieres
        {
           var guerrero_poderoso = heroes.Where(x => x.Class == "Warrior" && x.Level > 5).Select(y => new Guerrero_ASC() {Hp = y.Hp});
           var mago_poderoso = heroes.Where(x => x.Class == "Mage" && x.Level > 5).Select(y => new Mago_ASC() { Mp = y.Mp });
           var clerigo_poderoso = heroes.Where(x => x.Class == "Cleric" && x.Level > 5).Select(y => new Clerigo_ASC() {Hp = y.Hp, Mp = y.Mp });
           var explorador_poderoso = heroes.Where(x => x.Class == "Explorer" && x.Level > 5).Select(y => new Explorador_ASC() { Hp = y.Hp});
           var bardo_poderoso = heroes.Where(x => x.Class == "Bard" && x.Level > 5).Select(y => new Bardo_ASC() { Mp = y.Mp});
           var barbaro_poderoso = heroes.Where(x => x.Class == "Barbarian" && x.Level > 5).Select(y => new Barbaro_ASC() {Hp = y.Hp });

        }
    }
    public static class Extension
    {
        public static void Ejer15(this List<Heroe> heroes,int lvl, string nombre)
        {
            var buscar = heroes.Where(x => x.Level == lvl && x.Class == nombre).Take(50);
            foreach (var i in buscar)
            {
                Console.WriteLine("Nombre: "+i.Name+ ", Nivel: "+i.Level+ " Clase: "+i.Class);
            }
        }           
    }
    public class Guerrero_ASC : Heroe
    {
    }
    public class Mago_ASC : Heroe
    {
    }
    public class Clerigo_ASC : Heroe
    {
    }
    public class Explorador_ASC : Heroe
    {
    }
    public class Bardo_ASC : Heroe
    {
    }
    public class Barbaro_ASC : Heroe
    {
    }
}
