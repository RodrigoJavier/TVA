using DTO_TVA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    public class CompraCliente_DAL
    {
        public static List<CompraCliente_dto> GetListCompraCliente()
        {
            List<CompraCliente_dto> lista = new List<CompraCliente_dto>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("ObtenerDetalleVentasPorCliente");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new CompraCliente_dto(dr));
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
