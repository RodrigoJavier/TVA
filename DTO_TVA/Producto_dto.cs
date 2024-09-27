using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TVA
{
    public class Producto_dto
    {
        private int _id_producto;
        private string _descripcion;
        private decimal _costo_unitario;
        private string _estatus;

        public int PRODUCTO_ID { get => _id_producto; set => _id_producto = value; }
        public string DESCRIPCION { get => _descripcion; set => _descripcion = value; }
        public decimal COSTO_UNITARIO { get => _costo_unitario; set => _costo_unitario = value; }
        public string ESTATUS { get => _estatus; set => _estatus = value; }

        public Producto_dto()
        {
            PRODUCTO_ID = 0;
            DESCRIPCION = string.Empty;
            COSTO_UNITARIO = 0;
            ESTATUS = string.Empty;
        }

        public Producto_dto(DataRow dr)
        {
            PRODUCTO_ID = int.Parse(dr["PRODUCTO_ID"].ToString());
            DESCRIPCION = dr["DESCRIPCION"].ToString();
            COSTO_UNITARIO = decimal.Parse(dr["COSTO_UNITARIO"].ToString());
            ESTATUS = dr["ESTATUS"].ToString();
        }
    }
}
