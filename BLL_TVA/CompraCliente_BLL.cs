using DAL_TVA;
using DTO_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL_TVA
{
    public class CompraCliente_BLL
    {
        public static List<CompraCliente_dto> GetListCliente()
        {
            List<CompraCliente_dto> lista_pacientes = new List<CompraCliente_dto>();
            lista_pacientes = CompraCliente_DAL.GetListCompraCliente();
            return lista_pacientes;
        }

    }
}
