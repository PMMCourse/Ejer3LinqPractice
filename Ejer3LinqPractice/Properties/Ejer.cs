using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Class1
{
	public Class1()
	{
        static void Main(string[] args)
        {
            String archivo = File.ReadAllText("Heroes.json");
            List<Heroe> heroes = JsonConvert.DeserializeObject<List<Heroe>>(archivo);
        }
    }
}
