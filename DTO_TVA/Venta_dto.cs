using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TVA
{
    public class Venta_dto
    {

        private int _id_venta;
        private DateTime _fecha;
        private int _id_cliente;
        private string _estatus;

        public int VENTA_ID { get => _id_venta; set => _id_venta = value; }
        public DateTime FECHA { get => _fecha; set => _fecha = value; }
        public int CLIENTE_ID { get => _id_cliente; set => _id_cliente = value; }
        public string ESTATUS { get => _estatus; set => _estatus = value; }

        public Venta_dto()
        {
            VENTA_ID = 0;
            FECHA = DateTime.Parse( string.Empty);
            CLIENTE_ID = 0;
            ESTATUS = string.Empty;
        }

        public Venta_dto(DataRow dr)
        {
            VENTA_ID = int.Parse(dr["VENTA_ID"].ToString());
            FECHA = DateTime.Parse( dr["FECHA"].ToString());
            CLIENTE_ID = int.Parse(dr["CLIENTE_ID"].ToString());
            ESTATUS = dr["ESTATUS"].ToString();
        }
    }
}
