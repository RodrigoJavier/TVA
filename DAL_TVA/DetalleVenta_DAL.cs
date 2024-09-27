using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL_TVA
{
    public class DetalleVenta_DAL
    {
        public static void AgregarDetalleVenta(int id_producto, int cantidad, decimal descuento, decimal total)
        {
            try
            {
                int filas_afectadas;

                filas_afectadas = MetodoDatos.ExecuteNonQuery("pa_insertar_detalle_venta",
                    "@PRODUCTO_ID", id_producto,
                    "@CANTIDAD", cantidad,
                    "@DESCUENTO", descuento,
                    "@TOTAL", total);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
