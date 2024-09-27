using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace DTO_TVA
{
    public class CompraCliente_dto
    {
        private string _clave;
        private string _nombre;
        private string _mail;
        private DateTime _fecha;
        private decimal _total;

        public string NOMBRE { get => _nombre; set => _nombre = value; }
        public string CLAVE { get => _clave; set => _clave = value; }
        public string MAIL { get => _mail; set => _mail = value; }
        public DateTime FECHA { get => _fecha; set => _fecha = value; }
        public decimal TOTAL { get => _total; set => _total = value; }

        public CompraCliente_dto(DataRow dr)
        {
            CLAVE = dr["CLAVE"].ToString();
            NOMBRE = dr["NOMBRE"].ToString();
            MAIL = dr["MAIL"].ToString();
            FECHA = DateTime.Parse(dr["FECHA"].ToString());
            TOTAL = decimal.Parse(dr["TOTAL"].ToString());
        }
    }
}
