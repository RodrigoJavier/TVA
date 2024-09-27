using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TVA
{
    public class DetalleVenta_dto
    {
        private int _id_venta;
        private int _id_producto;
        private int _cantidad;
        private decimal _descuento;
        private decimal _total;

        public int VENTA_ID { get => _id_venta; set => _id_venta = value; }
        public int PRODUCTO_ID { get => _id_producto; set => _id_producto = value; }
        public int CANTIDAD { get => _cantidad; set => _cantidad = value; }
        public decimal DESCUENTO { get => _descuento; set => _descuento = value; }
        public decimal TOTAL { get => _total; set => _total = value; }
    }
}
