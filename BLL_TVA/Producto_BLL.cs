using DAL_TVA;
using DTO_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TVA
{
    public class Producto_BLL
    {
        public static List<Producto_dto> GetListProducto()
        {
            List<Producto_dto> lista_producto = new List<Producto_dto>();
            lista_producto = Producto_DAL.GetListProducto();
            return lista_producto;
        }
    }
}
