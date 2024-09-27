using BLL_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVA_APP.Catalogos.Cliente
{
    public partial class CompraCliente : System.Web.UI.Page
    {
         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RecargarGV();
                }
                catch (Exception ex)
                {

                    throw;
                }
            }
        }
        public void RecargarGV() 
        {
            CompraClientesGV.DataSource = CompraCliente_BLL.GetListCliente();
            CompraClientesGV.DataBind();
        }

        protected void btnAgregarVenta_Click(object sender, EventArgs e)
        {
            Response.Redirect("EditarPaciente.aspx");
        }
    }
}