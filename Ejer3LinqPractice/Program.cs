using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using Newtonsoft.Json;
using System.Windows.Forms;
namespace Ejer3LinqPractice
{
    class Program
    {
static void Main(string[] args) {

        String ruta = Path.GetFullPath("Heroes.json");//Obtengo de la ruta relativa la absoluta
        StreamReader jsonStream = File.OpenText(ruta);
        var json = jsonStream.ReadToEnd();
            //lo decodifico del formato JSON y lo guardo en una lista de heroes
         List <Heroe> heroes = JsonConvert.DeserializeObject<List<Heroe>>(json);

            //los metodos que no compilan es practicamente siempre por el mismo error y por ello estan comentado enteros (busque el código del error y aún asi ando perdido con ese error).
            //**********
            //**CS1061**
            //**********

            void Ejer2(){//el único que compila
                var h = heroes.Count(x => x.Gender == "Male");//si el genero es masculino lo cuenta
                var m = heroes.Count(x => x.Gender == "Female");//si el genero es masculino lo cuenta
                MessageBox.Show("Nº hombres: "+h.ToString()+ " Nº mujeres: " + m.ToString(), "Resultado de filtrado");
                Console.Read();
            }

           // Ejer2();
           
            void Ejer3(){
                //en la lita filtrada guardo los heroes de nivel mayor a 7 agrupados y solo los 10 primeros
               var listaFiltrada = heroes.GroupBy(x => x.Level > 7).Take(10);
                foreach (var j in listaFiltrada)
                {
                   // Console.WriteLine(j.Level);
                }
                Console.Read();
            }
            // Ejer3();

            
            void Ejer4() {
                 var agrupados = heroes.GroupBy(x => x.Class);
                foreach (var li in agrupados)
                {
                   // Console.WriteLine("Agrupados por clase " + li.Name+" "+li.Class);
                }
                Console.Read();
            };
             //Ejer4();
             
            void Ejer5()
            {
                var listafiltrada = heroes.GroupBy(x => x.Hp>50).Take(10);
                foreach (var li in listafiltrada)
                {
                 //   Console.WriteLine(li.Name);
                }
                Console.Read();
            }
            //Ejer5();

            void Ejer6()
            {
                /* var listaNueva = heroes.GroupBy(x => x.Hp > 50).GroupBy(y => y.Gender == "Female");

                 foreach(var v in listaNueva)
                 {
                        Console.WriteLine(v.Name);
                 }
                 */
                Console.Read();
            }
            //Ejer6();

            void Ejer7()
            {
                var listaNuev = heroes.Where(x => x.Description.Equals(String.Empty));

                foreach (var i in listaNuev)
                {
                    Console.WriteLine(i.Name.ToString());
                }
                Console.Read();

            }
            //Ejer7();

            void Ejer8()
            {
                var listaNue = heroes.Where(x => x.Gender=="Male");
                var listanu = listaNue.Where(x => x.Hp>100);
                var listan = listanu.Where(x => x.Level == 10);
                foreach (var i in listan)
                {
                    Console.WriteLine(i.Name+" "+i.Level+" "+i.Hp);
                }
                Console.Read();
            }
            //Ejer8();

            void Ejer9()//A a la Z
            {
                var listaNue = heroes.OrderBy(x=> x.Name);
                foreach (var i in listaNue)
                {
                    Console.WriteLine(i.Name);
                }
                Console.Read();
            }
            //Ejer9();

            void Ejer10()//Z a la A
            {
                var listaNue = heroes.OrderByDescending(x => x.Name);
                foreach (var i in listaNue)
                {
                    Console.WriteLine(i.Name);
                }
                Console.Read();
            }
            //Ejer10();

            void Ejer11()
            {
                var lista = heroes.Where(x => x.Class=="Warrior").Sum(x => x.Hp);
                Console.WriteLine("Eje11 resultado: "+lista);
                Console.Read();
            }
            //Ejer11();

            void Ejer12()
            {
                var lista = heroes.Where(x => x.Class == "Bard").Where(x => x.Level>3).Sum(x => x.Mp);
                Console.WriteLine("Eje12 resultado: " + lista);
                Console.Read();

            }
            //Ejer12();

            void Ejer13()
            {
               //no me sale
            }
            //Ejer13();

            void Ejer14()
            {
                List<Guerrero> listGuerreros = (List<Guerrero>) (Object) heroes.GroupBy(x => x.Class=="Warrior");
                List<Mago> listMago = (List<Mago>) (Object)heroes.GroupBy(x => x.Class == "Mage");
                List<Clerigo> listClerigo = (List<Clerigo>) (Object) heroes.GroupBy(x => x.Class == "Cleric");
                List<Explorador> listExplorador = (List<Explorador>) (Object) heroes.GroupBy(x => x.Class == "Explorer");
                List<Bardo> listBardo = (List<Bardo>) (Object) heroes.GroupBy(x => x.Class == "Bard");
                List<Barbaro> listBarbaro = (List<Barbaro>) (Object) heroes.GroupBy(x => x.Class == "Barbarian");
            }

            void Ejer15()
            {
                foreach (var i in heroes)
                {
                    i.devuelveNombre();//metodo de extension propio creado en la clase metodos de extensión
                }
            }
            //Ejer15();
        }
    }//fin main
}
