using DTO_TVA;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    public class Cliente_DAL
    {
        public static List<Cliente_dto> GetListCliente()
        {
            List<Cliente_dto> lista = new List<Cliente_dto>();
            try
            {
                DataSet ds;
                ds = MetodoDatos.ExecuteDataSet("pa_obtener_clientes");
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    lista.Add(new Cliente_dto(dr));
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
