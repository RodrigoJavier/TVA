using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO_TVA;
using DAL_TVA;

namespace BLL_TVA
{
    public class Cliente_BLL
    {
        public static List<Cliente_dto> GetListCliente()
        {
            List<Cliente_dto> lista_pacientes = new List<Cliente_dto>();
            lista_pacientes = Cliente_DAL.GetListCliente();
            return lista_pacientes;
        }

    }
}
