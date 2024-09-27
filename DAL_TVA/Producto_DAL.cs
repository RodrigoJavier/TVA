using DTO_TVA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    public class Producto_DAL
    {
        public static List<Producto_dto> GetListProducto()
        {
            List<Producto_dto> lista = new List<Producto_dto>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("pa_obtener_productos_activos");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new Producto_dto(dr));
                }
                return lista;
            }
            catch (Exception e)
            {
                throw;
            }
        }
    }
}
