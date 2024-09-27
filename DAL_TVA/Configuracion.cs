using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    internal class Configuracion
    {
        static string cadena_con = @"Data source = MAESTRO-EBOOK11\SQLEXPRESS; Initial Catalog = TVA_Tienda; Integrated Security = True";
        public static string cadena_con_
        {
            get { return cadena_con; }
        }
    }
}
