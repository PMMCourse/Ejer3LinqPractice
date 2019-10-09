using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ejer3LinqPractice
{
  public static class MetodosExtension
    {
        public static String devuelveNombre(this Heroe heroess)
        {
            return "El nombre del heroe es: " + heroess.Name; 
        }
    }
}
