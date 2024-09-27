using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TVA
{
    public class Cliente_dto
    {
        private int _id_cliente;
        private string _nombre;
        private string _clave;
        private string _mail;
        private string _estatus;

        public int CLIENTE_ID { get => _id_cliente; set => _id_cliente = value; }
        public string NOMBRE { get => _nombre; set => _nombre = value; }
        public string CLAVE { get => _clave; set => _clave = value; }
        public string MAIL { get => _mail; set => _mail = value; }
        public string ESTATUS { get => _estatus; set => _estatus = value; }

        public Cliente_dto()
        {
            CLIENTE_ID = 0;
            NOMBRE = string.Empty;
            CLAVE = string.Empty;
            MAIL = string.Empty;
            ESTATUS = string.Empty;
        }

        public Cliente_dto(DataRow dr)
        {
            CLIENTE_ID = int.Parse(dr["CLIENTE_ID"].ToString());
            NOMBRE = dr["NOMBRE"].ToString();
            CLAVE = dr["CLAVE"].ToString();
            MAIL = dr["MAIL"].ToString();
            ESTATUS = dr["ESTATUS"].ToString();
        }
    }
}
