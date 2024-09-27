using DAL_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TVA
{
    public  class Venta_BLL
    {
        public static void AgregarVenta(DateTime fecha, int cliente_id, string estatus)
        {
            try
            {
                Venta_DAL.AgregarVenta(fecha, cliente_id, estatus);
            }
            catch (Exception e)
            {

                throw;
            }
        }

        public static void AgregarDetalleVenta(int id_producto, int cantidad, decimal descuento, decimal total)
        {
            try
            {
                DetalleVenta_DAL.AgregarDetalleVenta(id_producto, cantidad, descuento, total);
            }
            catch (Exception e)
            {

                throw;
            }
        }
    }
}
