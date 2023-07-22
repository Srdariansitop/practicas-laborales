using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoogleEngineDarian
{
    class ValidateSearch
    {
        public static string Validate(string keyword)
        {
            bool active = true;
            while (active)
            {
                Console.WriteLine("INTRODUZCA LA PALABRA: ");
                keyword = Console.ReadLine();

                if (keyword.Length > 2) active = false;
                else
                {
                    Console.WriteLine(">>ERROR: La busqueda debe tener mas de 2 caracteres");
                    keyword = "";
                }
            }
            return keyword;
        }
    }
}
