using BLL_TVA;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace TVA_APP.Catalogos.Cliente
{
    public partial class Cliente : System.Web.UI.Page
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
            ClientesGV.DataSource = Cliente_BLL.GetListCliente();
            ClientesGV.DataBind();
        }

        protected void ClientesGV_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "Select")
            {
                int index = int.Parse(e.CommandArgument.ToString());
                string grid_id = ClientesGV.DataKeys[index].Values["CLIENTE_ID"].ToString();
                Response.Redirect("~/Catalogos/Producto/Producto.aspx?Id=" + grid_id);
            }
        }
    }
}