using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    public class Venta_DAL
    {
        public static void AgregarVenta(DateTime fecha, int cliente_id, string estatus)
        {
            try
            {
                int filas_afectadas;

                filas_afectadas = MetodoDatos.ExecuteNonQuery("pa_insertar_venta",
                    "@FECHA", fecha,
                    "@CLIENTE_ID", cliente_id,
                    "@ESTATUS", estatus);
            }
            catch (Exception e)
            {

                throw;
            }
        }

    }
}
